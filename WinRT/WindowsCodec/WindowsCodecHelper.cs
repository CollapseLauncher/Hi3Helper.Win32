using Hi3Helper.Win32.ManagedTools;
using Hi3Helper.Win32.Native.Enums;
using Hi3Helper.Win32.Native.Enums.D3D;
using Hi3Helper.Win32.Native.Enums.MediaFoundation;
using Hi3Helper.Win32.Native.Enums.WIC;
using Hi3Helper.Win32.Native.Interfaces.DXGI;
using Hi3Helper.Win32.Native.Interfaces.MediaFoundation;
using Hi3Helper.Win32.Native.Interfaces.WIC;
using Hi3Helper.Win32.Native.LibraryImport;
using Hi3Helper.Win32.Native.Structs;
using Hi3Helper.Win32.Native.Structs.MediaFoundation;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo

namespace Hi3Helper.Win32.WinRT.WindowsCodec;

/// <summary>
/// Windows codec helper class to check for supported codecs using native Media Foundation and WIC
/// </summary>
public static class WindowsCodecHelper
{
    private const uint GENERIC_READ       = 0x80000000u;
    private const uint MF_E_NO_MORE_TYPES = 0xC00D36B9u;
    private const uint E_NOTIMPL          = 0x80004001u;
    private const uint MF_VERSION         = 0x00020070u;
    private const uint MFSTARTUP_LITE     = 0x00000001u;

    private const uint MF_SOURCE_READER_FIRST_VIDEO_STREAM = 0xFFFFFFFC;
    private const uint MF_SOURCE_READER_FIRST_AUDIO_STREAM = 0xFFFFFFFD;

    // https://github.com/jishi/Jishi.StreamToSonos/tree/master/NAudio/MediaFoundation
    // -- MediaType
    private static readonly Guid MFMediaType_Video = new("73646976-0000-0010-8000-00aa00389b71");
    private static readonly Guid MFMediaType_Audio = new("73647561-0000-0010-8000-00aa00389b71");
    private static readonly Guid MF_MT_MAJOR_TYPE  = new("48eba18e-f8c9-4687-bf11-0a74c9f96a8f");
    private static readonly Guid MF_MT_SUBTYPE     = new("f7e34c9a-42e8-4714-b74b-cb29d72c35e5");

    // -- Factory Class ID
    private static readonly Guid CLSID_MFReadWriteClassFactory = new("48e2ed0f-98c2-4a37-bed5-166312ddd83f");
    private static readonly Guid CLSID_MFSourceReader          = new("1777133C-0881-411B-A577-AD545F0714C4");
    // https://github.com/dahall/Vanara/blob/1db7a8a251c7e45235f6e5bf2605b37db3642751/PInvoke/Direct2D/WindowsCodecs.Enums.cs#L1613
    private static readonly Guid CLSID_WICImagingFactory       = new("cacaf262-9370-4615-a13b-9f5539da4c0a");

    private static readonly Guid MFT_CATEGORY_VIDEO_DECODER = new("D6C02D4B-6833-45B4-971A-05A4B04BAB91");
    private static readonly Guid MFT_CATEGORY_AUDIO_DECODER = new("9ea73fb4-ef7a-4559-8d5d-719d8f0426c7");

    private static readonly Guid MF_TRANSFORM_ASYNC_UNLOCK   = new("e5666d6b-3422-4eb6-a421-da7db1f8e207");
    private static readonly Guid MFT_FRIENDLY_NAME_Attribute = new("314ffbae-5b41-4c95-9c19-4e7d586face3");
    private static readonly Guid MF_SA_D3D11_AWARE           = new("206b4fc8-fcf9-4c51-afe3-9764369e33a0");

    private static readonly HashSet<Guid> SupportedVideoCodec = [];
    private static readonly HashSet<Guid> SupportedAudioCodec = [];

    // HACK: Add the codec manually due to VP90 FourCC isn't registered, even the extension does exist.
    private static readonly Guid   MEDIASUBTYPE_VP80         = new("30385056-0000-0010-8000-00AA00389B71");
    private static readonly Guid   MEDIASUBTYPE_VP90         = new("30395056-0000-0010-8000-00AA00389B71");
    private const           string VP9TransformExtensionName = "VP9VideoExtensionDecoder";

    // HACK: Make sure to initialize HW-decoder early to make sure the HW transforms are detected.
    public static ReadOnlySpan<D3D_FEATURE_LEVEL> FeatureLevels => [
        D3D_FEATURE_LEVEL.D3D_FEATURE_LEVEL_11_1,
        D3D_FEATURE_LEVEL.D3D_FEATURE_LEVEL_11_0,
        D3D_FEATURE_LEVEL.D3D_FEATURE_LEVEL_10_1,
        D3D_FEATURE_LEVEL.D3D_FEATURE_LEVEL_10_0,
        D3D_FEATURE_LEVEL.D3D_FEATURE_LEVEL_9_3,
        D3D_FEATURE_LEVEL.D3D_FEATURE_LEVEL_9_2,
        D3D_FEATURE_LEVEL.D3D_FEATURE_LEVEL_9_1
    ];

    private const  int                   D3D11_SDK_VERSION                   = 7;
    private static nint                  ppD3D11deviceShared                 = nint.Zero;
    private static nint                  ppD3D11DeviceImmediateContextShared = nint.Zero;
    private static IMFDXGIDeviceManager? deviceManagerShared;
    private static nint                  deviceManagerSharedPpv = nint.Zero;

    private static unsafe void GetCodecTypeToHashSet(HashSet<Guid> hashSet,
                                                     in Guid       categoryGuid,
                                                     in Guid       mediaTypeGuid)
    {
        Unsafe.SkipInit(out IMFActivate[] mftActivates);
        Unsafe.SkipInit(out nint mftActivatesPpv);

        try
        {
            const MFT_ENUM_FLAG flags = MFT_ENUM_FLAG.MFT_ENUM_FLAG_ASYNCMFT |
                                        MFT_ENUM_FLAG.MFT_ENUM_FLAG_LOCALMFT |
                                        MFT_ENUM_FLAG.MFT_ENUM_FLAG_HARDWARE |
                                        MFT_ENUM_FLAG.MFT_ENUM_FLAG_SYNCMFT |
                                        MFT_ENUM_FLAG.MFT_ENUM_FLAG_SORTANDFILTER;
            HResult hr =
                PInvoke.MFTEnum2(in categoryGuid,
                                 flags,
                                 in Unsafe.NullRef<MFT_REGISTER_TYPE_INFO>(),
                                 in Unsafe.NullRef<MFT_REGISTER_TYPE_INFO>(),
                                 null,
                                 out mftActivatesPpv,
                                 out int mftActivatesCount);
            if (!hr)
            {
                return;
            }

            Span<nint> mftActivatesPtrSpan = new((void*)mftActivatesPpv, mftActivatesCount);
            mftActivates = new IMFActivate[mftActivatesCount];
            for (int i = 0; i < mftActivatesCount; i++)
            {
                ComMarshal<IMFActivate>.TryCreateComObjectFromReference(mftActivatesPtrSpan[i],
                                                                        out mftActivates[i],
                                                                        out _);
            }

            Guid iidImfTransform = typeof(IMFTransform).GUID;
            foreach (IMFActivate activate in mftActivates)
            {
                hr = activate.ActivateObject(iidImfTransform, out nint mftPpv);
                activate.GetAllocatedString(in MFT_FRIENDLY_NAME_Attribute,
                                            out string? activateName,
                                            out _);

                Unsafe.SkipInit(out IMFTransform? transform);
                try
                {
                    if (!hr ||
                        !ComMarshal<IMFTransform>.TryCreateComObjectFromReference(mftPpv,
                                                                                  out transform,
                                                                                  out _))
                    {
                        continue;
                    }
                    // AddTransformFromHW(transform);

                    for (uint i = 0; ; i++)
                    {
                        hr = transform.GetInputAvailableType(0, i, out IMFMediaType? ppType);
                        if ((uint)hr is MF_E_NO_MORE_TYPES or E_NOTIMPL)
                        {
                            break;
                        }

                        if (ppType == null)
                        {
                            break;
                        }

                        try
                        {
                            if (!ppType.GetGUID(in MF_MT_MAJOR_TYPE, out Guid majorType) ||
                                !ppType.GetGUID(in MF_MT_SUBTYPE,    out Guid subType))
                            {
                                continue;
                            }

                            if (majorType == mediaTypeGuid)
                            {
                                hashSet.Add(subType);
                            }

                            if (activateName.Equals(VP9TransformExtensionName, StringComparison.OrdinalIgnoreCase) &&
                                subType == MEDIASUBTYPE_VP80)
                            {
                                hashSet.Add(MEDIASUBTYPE_VP90); // Add VP9 FourCC GUID to the hash set
                            }
                        }
                        finally
                        {
                            ComMarshal<IMFMediaType>.TryReleaseComObject(ppType, out _);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[StaticCtor::WindowsCodecHelper] {ex}");
                }
                finally
                {
                    ComMarshal<IMFTransform>.TryReleaseComObject(transform, out _);
                    // if (mftPpv != nint.Zero) Marshal.Release(mftPpv);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[StaticCtor::WindowsCodecHelper] {ex}");
        }
        finally
        {
            if (mftActivatesPpv != nint.Zero)
            {
                Marshal.FreeCoTaskMem(mftActivatesPpv);
            }
        }
    }

    private static void AddTransformFromHW(IMFTransform transform)
    {
        if (!transform.GetAttributes(out IMFAttributes? attributes) ||
            attributes == null)
        {
            return;
        }

        if (!attributes.GetUINT32(in MF_SA_D3D11_AWARE, out uint isd3d11Aware))
        {
            return;
        }

        if (isd3d11Aware <= 0) return;
        attributes.SetUINT32(in MF_TRANSFORM_ASYNC_UNLOCK, 1);

        if (ppD3D11deviceShared == nint.Zero || ppD3D11DeviceImmediateContextShared == nint.Zero)
        {
            const D3D_DRIVER_TYPE          DriverType          = D3D_DRIVER_TYPE.D3D_DRIVER_TYPE_HARDWARE;
            const D3D11_CREATE_DEVICE_FLAG flags               = D3D11_CREATE_DEVICE_FLAG.D3D11_CREATE_DEVICE_VIDEO_SUPPORT;
            D3D_FEATURE_LEVEL              supportedD3DFeature = default;

            PInvoke.D3D11CreateDevice(nint.Zero,
                                      DriverType,
                                      nint.Zero,
                                      flags,
                                      in MemoryMarshal.GetReference(FeatureLevels),
                                      FeatureLevels.Length,
                                      D3D11_SDK_VERSION,
                                      out ppD3D11deviceShared,
                                      ref supportedD3DFeature,
                                      out ppD3D11DeviceImmediateContextShared).ThrowOnFailure();

            if (!PInvoke.MFCreateDXGIDeviceManager(out uint resetToken,
                                                   out deviceManagerShared) ||
                deviceManagerShared == null)
            {
                return;
            }

            if (!deviceManagerShared.ResetDevice(ppD3D11deviceShared, resetToken))
            {
                return;
            }
            ComMarshal<IMFDXGIDeviceManager>.TryGetComInterfaceReference(deviceManagerShared,
                                                                         out deviceManagerSharedPpv,
                                                                         out _,
                                                                         requireQueryInterface: true);
        }

        if (deviceManagerSharedPpv != nint.Zero)
        {
            transform.ProcessMessage(MFT_MESSAGE_TYPE.MFT_MESSAGE_SET_D3D_MANAGER, deviceManagerSharedPpv);
        }
    }

    /// <summary>
    /// Determines whether the image or video file is supported natively using Media Foundation and WIC.<br/>
    /// To specifically check for image or video support, use <see cref="IsFileSupportedImage(string)"/> or <see cref="IsFileSupportedVideo(string, out bool, out bool, out Guid, out Guid)"/> instead.
    /// </summary>
    /// <param name="filePath">The URL or Local File Path of the file to check.</param>
    /// <returns><see langword="true"/> if whether the file is supported as an image or video file. Otherwise, <see langword="false"/>.</returns>
    public static bool IsFileSupported(string filePath)
    {
        if (IsFileSupportedImage(filePath))
            return true;

        return IsFileSupportedVideo(filePath,
                                    out _,
                                    out _,
                                    out _,
                                    out _);
    }

    /// <summary>
    /// Determines whether the specified file is a natively supported image format by Windows Imaging Component (WIC).
    /// </summary>
    /// <param name="filePath">The URL or Local File Path of the file to check.</param>
    /// <returns><see langword="true"/> if whether the file is supported as an image file. Otherwise, <see langword="false"/>.</returns>
    public static bool IsFileSupportedImage(string filePath)
    {
        if (!ComMarshal<IWICImagingFactory>.TryCreateComObject(in CLSID_WICImagingFactory,
                                                               CLSCTX.CLSCTX_INPROC_SERVER,
                                                               out IWICImagingFactory? factory,
                                                               out _))
        {
            return false;
        }

        Unsafe.SkipInit(out IWICBitmapDecoder? decoder);

        try
        {
            HResult hr = factory.CreateDecoderFromFilename(filePath,
                                                           nint.Zero,
                                                           GENERIC_READ,
                                                           WICDecodeOptions.WICDecodeMetadataCacheOnDemand,
                                                           out decoder);

            if (!hr || decoder == null)
            {
                return false;
            }

            Unsafe.SkipInit(out Guid guidContainerFormat);
            decoder.GetContainerFormat(out guidContainerFormat);
            return guidContainerFormat != Guid.Empty;
        }
        finally
        {
            ComMarshal<IWICBitmapDecoder>.TryReleaseComObject(decoder, out _);
            ComMarshal<IWICImagingFactory>.TryReleaseComObject(factory, out _);
        }
    }

    /// <summary>
    /// Determines whether the specified file is a natively supported video format by Media Foundation.
    /// </summary>
    /// <param name="filePath">The URL or Local File Path of the file to check.</param>
    /// <param name="canPlayVideo">Whether the video codec is supported.</param>
    /// <param name="canPlayAudio">Whether the audio codec is supported.</param>
    /// <param name="audioCodecGuid">The <see cref="Guid"/> of the audio codec.</param>
    /// <param name="videoCodecGuid">The <see cref="Guid"/> of the video codec. Some FourCC identified-based codec string can be obtained using <see cref="TryGetFourCCString"/> method.</param>
    /// <returns>
    /// <see langword="true"/> if whether the file is supported as a video file. Otherwise, <see langword="false"/>.
    /// Though, this method will always return <see langword="false"/> if the video codec is not supported.
    /// Even if this method returns <see langword="true"/>, doesn't mean that the audio codec is supported.
    /// You might need to make sure the audio support via <paramref name="canPlayAudio"/> argument.
    /// </returns>
    public static bool IsFileSupportedVideo(string   filePath,
                                            out bool canPlayVideo,
                                            out bool canPlayAudio,
                                            out Guid videoCodecGuid,
                                            out Guid audioCodecGuid)
    {
        if (SupportedAudioCodec.Count == 0)
        {
            GetCodecTypeToHashSet(SupportedAudioCodec, in MFT_CATEGORY_AUDIO_DECODER, in MFMediaType_Audio);
        }

        if (SupportedVideoCodec.Count == 0)
        {
            GetCodecTypeToHashSet(SupportedVideoCodec, in MFT_CATEGORY_VIDEO_DECODER, in MFMediaType_Video);
        }
        PInvoke.MFStartup(MF_VERSION, MFSTARTUP_LITE);

        Unsafe.SkipInit(out canPlayVideo);
        Unsafe.SkipInit(out canPlayAudio);
        Unsafe.SkipInit(out videoCodecGuid);
        Unsafe.SkipInit(out audioCodecGuid);

        Unsafe.SkipInit(out IMFReadWriteClassFactory? factory);
        Unsafe.SkipInit(out IMFSourceReader? reader);
        Unsafe.SkipInit(out IMFMediaType? videoMediaType);
        Unsafe.SkipInit(out IMFMediaType? audioMediaType);

        try
        {
            if (!ComMarshal<IMFReadWriteClassFactory>
                   .TryCreateComObject(in CLSID_MFReadWriteClassFactory,
                                       CLSCTX.CLSCTX_INPROC_SERVER,
                                       out factory,
                                       out _))
            {
                return false;
            }

            Guid readerIid = typeof(IMFSourceReader).GUID;
            HResult hr = factory.CreateInstanceFromURL(in CLSID_MFSourceReader, filePath, null, in readerIid, out nint readerPpv);

            if (!hr ||
                !ComMarshal<IMFSourceReader>.TryCreateComObjectFromReference(readerPpv, out reader, out _))
            {
                return false;
            }

            reader.GetNativeMediaType(MF_SOURCE_READER_FIRST_VIDEO_STREAM, 0, out nint videoMediaTypePpv);
            reader.GetNativeMediaType(MF_SOURCE_READER_FIRST_AUDIO_STREAM, 0, out nint audioMediaTypePpv);
            ComMarshal<IMFMediaType>.TryCreateComObjectFromReference(videoMediaTypePpv,
                                                                     out videoMediaType,
                                                                     out _);
            ComMarshal<IMFMediaType>.TryCreateComObjectFromReference(audioMediaTypePpv,
                                                                     out audioMediaType,
                                                                     out _);

            videoMediaType?.GetGUID(in MF_MT_SUBTYPE, out videoCodecGuid);
            audioMediaType?.GetGUID(in MF_MT_SUBTYPE, out audioCodecGuid);

            canPlayVideo = SupportedVideoCodec.Contains(videoCodecGuid);
            canPlayAudio = SupportedAudioCodec.Contains(audioCodecGuid);
            return canPlayVideo;
        }
        finally
        {
            ComMarshal<IMFMediaType>.TryReleaseComObject(audioMediaType, out _);
            ComMarshal<IMFMediaType>.TryReleaseComObject(videoMediaType, out _);
            ComMarshal<IMFSourceReader>.TryReleaseComObject(reader, out _);
            ComMarshal<IMFReadWriteClassFactory>.TryReleaseComObject(factory, out _);
            PInvoke.MFShutdown();
        }
    }

    /// <summary>
    /// Try to get the FourCC string from a given codec <see cref="Guid"/>.
    /// </summary>
    /// <param name="guid">The <see cref="Guid"/> of the codec.</param>
    /// <param name="codecString">FourCC string output</param>
    /// <returns>
    /// <see langword="true"/> if the FourCC string can be obtained from the <see cref="Guid"/>'s bytes. Otherwise, <see langword="false"/>.
    /// </returns>
    public static unsafe bool TryGetFourCCString(
        in                      Guid    guid,
        [NotNullWhen(true)] out string? codecString)
    {
        const int sizeOfGuid = 16;
        Unsafe.SkipInit(out codecString);

        if (Unsafe.IsNullRef(in guid))
        {
            return false;
        }

        Span<byte> guidBytes = stackalloc byte[sizeOfGuid];
        if (!guid.TryWriteBytes(guidBytes))
        {
            return false;
        }

        ReadOnlySpan<byte> fourCCSpan = guidBytes[..4]
                                       .Trim((byte)0x20)
                                       .Trim((byte)0x0); // Trim out spaces or null

        Span<char> charSpan = stackalloc char[fourCCSpan.Length];
        if (!Encoding.UTF8.TryGetChars(fourCCSpan, charSpan, out int charsWritten) ||
            !Ascii.IsValid(charSpan[..charsWritten]))
        {
            return false;
        }

        codecString = new string(charSpan[..charsWritten]);
        return true;
    }
}
