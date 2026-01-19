using Hi3Helper.Win32.ManagedTools;
using Hi3Helper.Win32.Native.Enums;
using Hi3Helper.Win32.Native.Enums.WIC;
using Hi3Helper.Win32.Native.Interfaces.MediaFoundation;
using Hi3Helper.Win32.Native.Interfaces.WIC;
using Hi3Helper.Win32.Native.LibraryImport;
using Hi3Helper.Win32.Native.Structs;
using Hi3Helper.Win32.Native.Structs.MediaFoundation;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml.Linq;

namespace Hi3Helper.Win32.WinRT.WindowsCodec;

public static class WindowsCodecHelper
{
    private const uint GENERIC_READ   = 0x80000000u;
    private const uint MF_VERSION     = 0x00020070u;
    private const uint MFSTARTUP_LITE = 0x00000001u;

    private const uint MF_SOURCE_READER_FIRST_VIDEO_STREAM = 0xFFFFFFFC;
    private const uint MFT_ENUM_FLAG_SORTANDFILTER         = 0x00000040;

    // https://github.com/jishi/Jishi.StreamToSonos/tree/master/NAudio/MediaFoundation
    // -- MediaType
    private static readonly Guid MFMediaType_Video = new("73646976-0000-0010-8000-00aa00389b71");
    private static readonly Guid MFMediaType_Audio = new("73647561-0000-0010-8000-00aa00389b71");
    private static readonly Guid MF_MT_MAJOR_TYPE  = new("48eba18e-f8c9-4687-bf11-0a74c9f96a8f");
    private static readonly Guid MF_MT_SUBTYPE     = new("f7e34c9a-42e8-4714-b74b-cb29d72c35e5");

    // -- Factory Class ID
    private static readonly Guid CLSID_MFReadWriteClassFactory = new("48e2ed0f-98c2-4a37-bed5-166312ddd83f");
    private static readonly Guid CLSID_MFSourceReader          = new("1777133C-0881-411B-A577-AD545F0714C4");

    private static readonly Guid MF_DEVSOURCE_ATTRIBUTE_SOURCE_TYPE             = new("C6E13360-30AC-11D0-A18C-00A0C9118956");
    private static readonly Guid MF_DEVSOURCE_ATTRIBUTE_SOURCE_TYPE_VIDCAP_GUID = new("8AC3587A-4AE7-42D8-99E0-0A6013EEF90F");
    private static readonly Guid MF_READWRITE_DISABLE_CONVERTERS                = new("98D5B065-1374-4847-8D92-5F1A4D5B3B99");
    private static readonly Guid MFT_CATEGORY_VIDEO_DECODER                     = new("D6C02D4B-6833-45B4-971A-05A4B04BAB91");
    private static readonly Guid MFT_CATEGORY_AUDIO_DECODER                     = new("9ea73fb4-ef7a-4559-8d5d-719d8f0426c7");

    private static readonly HashSet<Guid> SupportedVideoCodec = [];
    private static readonly HashSet<Guid> SupportedAudioCodec = [];

    static WindowsCodecHelper()
    {
        GetCodecTypeToHashSet(SupportedVideoCodec, in MFT_CATEGORY_VIDEO_DECODER, in MFMediaType_Video);
        GetCodecTypeToHashSet(SupportedAudioCodec, in MFT_CATEGORY_AUDIO_DECODER, in MFMediaType_Audio);
    }

    private static void GetCodecTypeToHashSet(HashSet<Guid> hashSet,
                                              in Guid       categoryGuid,
                                              in Guid       mediaTypeGuid)
    {
        Unsafe.SkipInit(out IMFActivate[] mftActivates);

        try
        {
            HResult hr =
                PInvoke.MFTEnumEx(in categoryGuid,
                                  MFT_ENUM_FLAG_SORTANDFILTER,
                                  in Unsafe.NullRef<MFT_REGISTER_TYPE_INFO>(),
                                  in Unsafe.NullRef<MFT_REGISTER_TYPE_INFO>(),
                                  out mftActivates,
                                  out _);
            if (!hr)
            {
                return;
            }

            Guid iidImfTransform = typeof(IMFTransform).GUID;
            foreach (IMFActivate activate in mftActivates)
            {
                hr = activate.ActivateObject(iidImfTransform, out nint mftPpv);
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

                    for (uint i = 0; ; i++)
                    {
                        hr = transform.GetInputAvailableType(0, i, out IMFMediaType? ppType);
                        if (!hr || ppType == null)
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
                                hashSet.Add(subType);
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
                    if (transform != null) ComMarshal<IMFTransform>.TryReleaseComObject(transform, out _);
                    if (mftPpv != nint.Zero) Marshal.Release(mftPpv);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[StaticCtor::WindowsCodecHelper] {ex}");
        }
        finally
        {
            if (mftActivates != null!)
            {
                foreach (IMFActivate activate in mftActivates)
                {
                    ComMarshal<IMFActivate>.TryReleaseComObject(activate, out _);
                }
            }
        }
    }


    public static bool IsFileSupported(string filePath)
    {
        if (IsFileSupportedImage(filePath))
            return true;

        if (IsFileSupportedVideo(filePath))
            return true;

        return false;
    }

    private static bool IsFileSupportedImage(string filePath)
    {
        Guid factoryGuid = new("CACAF262-9370-4615-A13B-9F5539DA4C0A");
        if (!ComMarshal<IWICImagingFactory>.TryCreateComObject(in factoryGuid,
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
            decoder?.GetContainerFormat(out guidContainerFormat);
            return guidContainerFormat != Guid.Empty;
        }
        finally
        {
            ComMarshal<IWICBitmapDecoder>.TryReleaseComObject(decoder, out _);
            ComMarshal<IWICImagingFactory>.TryReleaseComObject(factory, out _);
        }
    }

    public static bool IsFileSupportedVideo(string   filePath,
                                            out bool canPlayVideo,
                                            out bool canPlayAudio,
                                            out Guid audioCodecGuid,
                                            out Guid videoCodecGuid)
    {
        Unsafe.SkipInit(out canPlayVideo);
        Unsafe.SkipInit(out canPlayAudio);
        Unsafe.SkipInit(out audioCodecGuid);
        Unsafe.SkipInit(out videoCodecGuid);

        try
        {
            PInvoke.MFStartup(MF_VERSION, MFSTARTUP_LITE);
            if (!ComMarshal<IMFReadWriteClassFactory>
                   .TryCreateComObject(in CLSID_MFReadWriteClassFactory,
                                       CLSCTX.CLSCTX_INPROC_SERVER,
                                       out IMFReadWriteClassFactory? factory,
                                       out _))
            {
                return false;
            }

            nint[]  ppMfAttributes = new nint[1];
            HResult hr             = PInvoke.MFCreateAttributes(ppMfAttributes, ppMfAttributes.Length);
            if (!hr ||
                !ComMarshal<IMFAttributes>.TryCreateComObjectFromReference(ppMfAttributes[0],
                                                                           out IMFAttributes? attribute,
                                                                           out _))
            {
                return false;
            }

            return false;
        }
        finally
        {
            PInvoke.MFShutdown();
        }
    }

    private static bool IsFileSupportedVideo(string filePath)
    {
        Unsafe.SkipInit(out IMFSourceReader? reader);
        Unsafe.SkipInit(out IMFAttributes? attribute);
        try
        {
            PInvoke.MFStartup(MF_VERSION, MFSTARTUP_LITE);

            Guid factoryGuid = new("48e2ed0f-98c2-4a37-bed5-166312ddd83f");
            if (!ComMarshal<IMFReadWriteClassFactory>
                   .TryCreateComObject(in factoryGuid,
                                       CLSCTX.CLSCTX_INPROC_SERVER,
                                       out IMFReadWriteClassFactory? factory,
                                       out _))
            {
                return false;
            }

            Guid readerFactoryGuid = new("1777133C-0881-411B-A577-AD545F0714C4");
            Guid readerIidGuid     = typeof(IMFSourceReader).GUID;

            nint[]  ppMfAttributes = new nint[1];
            HResult hr             = PInvoke.MFCreateAttributes(ppMfAttributes, ppMfAttributes.Length);
            if (!hr)
            {
                return false;
            }

            if (!ComMarshal<IMFAttributes>.TryCreateComObjectFromReference(ppMfAttributes[0], out attribute, out _))
            {
                return false;
            }
            // attribute.SetGUID(in MF_DEVSOURCE_ATTRIBUTE_SOURCE_TYPE, in MF_DEVSOURCE_ATTRIBUTE_SOURCE_TYPE_VIDCAP_GUID);
            attribute.SetUINT32(in MF_READWRITE_DISABLE_CONVERTERS, 1);

            Uri fileUri = new(filePath);
            hr  = factory.CreateInstanceFromURL(in readerFactoryGuid, fileUri.ToString(), null, in readerIidGuid, out nint ppvReader);
            if (!hr || ppvReader == nint.Zero)
            {
                return false;
            }

            if (!ComMarshal<IMFSourceReader>.TryCreateComObjectFromReference(ppvReader, out reader, out _))
            {
                return false;
            }

            hr = reader.SetStreamSelection(MF_SOURCE_READER_FIRST_VIDEO_STREAM, true);
            if (!hr)
            {
                return false;
            }

            hr = reader.ReadSample(MF_SOURCE_READER_FIRST_VIDEO_STREAM, 0, out _, out _, out _, out nint ppSample);
            if (ppSample != nint.Zero) Marshal.Release(ppSample);

            return hr;
        }
        finally
        {
            if (reader != null) ComMarshal<IMFSourceReader>.TryReleaseComObject(reader, out _);
            PInvoke.MFShutdown();
        }
    }
}
