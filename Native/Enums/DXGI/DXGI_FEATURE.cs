using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hi3Helper.Win32.Native.Enums.DXGI
{
 /// <summary>Specifies a range of hardware features, to be used when checking for feature support.</summary>
 /// <remarks>This enum is used by the <a href="https://docs.microsoft.com/windows/desktop/api/dxgi1_5/nf-dxgi1_5-idxgifactory5-checkfeaturesupport">CheckFeatureSupport</a> method.</remarks>
 public enum DXGI_FEATURE
 {
  /// <summary>The display supports tearing, a requirement of variable refresh rate displays.</summary>
  DXGI_FEATURE_PRESENT_ALLOW_TEARING = 0,
 }
}
