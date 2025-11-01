using System.Drawing;
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable StructCanBeMadeReadOnly
// ReSharper disable UnusedMember.Global
// ReSharper disable ConvertToAutoPropertyWhenPossible
// ReSharper disable CommentTypo
#pragma warning disable IDE0290

namespace Hi3Helper.Win32.Native.Structs
{
    /// <summary>The RECT structure defines a rectangle by the coordinates of its upper-left and lower-right corners.</summary>
    /// <remarks>The RECT structure is identical to the <a href="https://docs.microsoft.com/windows/desktop/api/windef/ns-windef-rectl">RECTL</a> structure.</remarks>
    public struct Rect
    {
        /// <summary>Specifies the <i>x</i>-coordinate of the upper-left corner of the rectangle.</summary>
        private readonly int _left;

        /// <summary>Specifies the <i>y</i>-coordinate of the upper-left corner of the rectangle.</summary>
        private readonly int _top;

        /// <summary>Specifies the <i>x</i>-coordinate of the lower-right corner of the rectangle.</summary>
        private readonly int _right;

        /// <summary>Specifies the <i>y</i>-coordinate of the lower-right corner of the rectangle.</summary>
        private readonly int _bottom;

        public Rect(Rectangle value) : this(value.Left, value.Top, value.Right, value.Bottom)
        {
        }

        // ReSharper disable once UnusedMember.Global
        public Rect(Point location, Size size) : this(location.X, location.Y, unchecked(location.X + size.Width), unchecked(location.Y + size.Height))
        {
        }

        // ReSharper disable once ConvertToPrimaryConstructor
        public Rect(int left, int top, int right, int bottom)

        {
            _left = left;
            _top = top;
            _right = right;
            _bottom = bottom;
        }


        // ReSharper disable once IdentifierTypo
        // ReSharper disable once InconsistentNaming
        public static Rect FromXYWH(int x, int y, int width, int height) =>
            new Rect(x, y, unchecked(x + width), unchecked(y + height));

        public readonly int Width => unchecked(_right - _left);

        public readonly int Height => unchecked(_bottom - _top);

        public readonly bool IsEmpty => _left == 0 && _top == 0 && _right == 0 && _bottom == 0;

        public readonly int X => _left;

        public readonly int Y => _top;

        public readonly Size Size => new Size(Width, Height);

        public static implicit operator Rectangle(Rect value) =>
            new Rectangle(value._left, value._top, value.Width, value.Height);

        public static implicit operator RectangleF(Rect value) =>
            new RectangleF(value._left, value._top, value.Width, value.Height);

        public static implicit operator Rect(Rectangle value) => new Rect(value);
    }
}
