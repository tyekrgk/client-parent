using System;
using System.Drawing;
using System.Windows.Forms;
namespace ToolStripRender
{
	internal class LayoutUtils
	{
		public static Rectangle DeflateRect(Rectangle rect, Padding padding)
		{
			rect.X += padding.Left;
			rect.Y += padding.Top;
			rect.Width -= padding.Horizontal;
			rect.Height -= padding.Vertical;
			return rect;
		}
		public static Rectangle RTLTranslate(Rectangle bounds, Rectangle withinBounds)
		{
			bounds.X = withinBounds.Width - bounds.Right;
			return bounds;
		}
		public static bool IsEmptyRect(Rectangle rect)
		{
			return rect.Width <= 0 || rect.Height <= 0;
		}
	}
}
