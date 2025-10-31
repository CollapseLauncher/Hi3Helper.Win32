using System.Drawing;

namespace Hi3Helper.Win32.Native.Structs.DXGI
{
 /// <summary>Describes information about present that helps the operating system optimize presentation.</summary>
 /// <remarks>
 /// <para>This structure is used by the <a href="https://docs.microsoft.com/windows/desktop/api/dxgi1_2/nf-dxgi1_2-idxgiswapchain1-present1">Present1</a> method. The scroll rectangle and the list of dirty rectangles could overlap.  In this situation, the dirty rectangles take priority. Applications can then have pieces of dynamic content on top of a scrolled area. For example, an application could scroll a page and play video at the same time. The following diagram and coordinates illustrate this example. </para>
 /// <para>This doc was truncated.</para>
 /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi1_2/ns-dxgi1_2-dxgi_present_parameters#">Read more on learn.microsoft.com</see>.</para>
 /// </remarks>
public struct DXGI_PRESENT_PARAMETERS
 {
  /// <summary>The number of updated rectangles that you update in the back buffer for the presented frame. The operating system uses this information to optimize presentation. You can set this member to 0 to indicate that you update the whole frame.</summary>
  public uint DirtyRectsCount;

  /// <summary>A list of updated rectangles that you update in the back buffer for the presented frame. An application must update every single pixel in each rectangle that it reports to the runtime; the application cannot assume that the pixels are saved from the previous frame. For more information about updating dirty rectangles, see Remarks. You can set this member to <b>NULL</b> if <b>DirtyRectsCount</b> is 0. An application must not update any pixel outside of the dirty rectangles.</summary>
  public unsafe Rect* pDirtyRects;

  /// <summary>
  /// <para>A pointer to the scrolled rectangle. The scrolled rectangle is the rectangle of the previous frame from which the runtime bit-block transfers (bitblts) content. The runtime also uses the scrolled rectangle to optimize presentation in terminal server and indirect display scenarios. The scrolled rectangle also describes the destination rectangle, that is, the region on the current frame that is filled with scrolled content. You can set this member to <b>NULL</b> to indicate that no content is scrolled from the previous frame.</para>
  /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgi1_2/ns-dxgi1_2-dxgi_present_parameters#members">Read more on learn.microsoft.com</see>.</para>
  /// </summary>
  public unsafe Rect* pScrollRect;

  /// <summary>A pointer to the offset of the scrolled area that goes from the source rectangle (of previous frame) to the destination rectangle (of current frame). You can set this member to <b>NULL</b> to indicate no offset.</summary>
  public unsafe Point* pScrollOffset;
 }
}
