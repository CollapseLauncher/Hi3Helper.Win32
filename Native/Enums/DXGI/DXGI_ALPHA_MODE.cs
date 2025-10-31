using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hi3Helper.Win32.Native.Enums.DXGI
{
 /// <summary>Identifies the alpha value, transparency behavior, of a surface.</summary>
 /// <remarks>For more information about alpha mode, see <a href="https://docs.microsoft.com/windows/desktop/api/dcommon/ne-dcommon-d2d1_alpha_mode">D2D1_ALPHA_MODE</a>.</remarks>
 public enum DXGI_ALPHA_MODE
 {
  /// <summary>Indicates that the transparency behavior is not specified.</summary>
  DXGI_ALPHA_MODE_UNSPECIFIED = 0,
  /// <summary>Indicates that the transparency behavior is premultiplied. Each color is first scaled by the alpha value. The alpha value itself is the same in both straight and premultiplied alpha. Typically, no color channel value is greater than the alpha channel value. If a color channel value in a premultiplied format is greater than the alpha channel, the standard source-over blending math results in an additive blend.</summary>
  DXGI_ALPHA_MODE_PREMULTIPLIED = 1,
  /// <summary>Indicates that the transparency behavior is not premultiplied. The alpha channel indicates the transparency of the color.</summary>
  DXGI_ALPHA_MODE_STRAIGHT = 2,
  /// <summary>Indicates to ignore the transparency behavior.</summary>
  DXGI_ALPHA_MODE_IGNORE = 3,
 }
}
