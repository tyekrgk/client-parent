using System;
using System.Drawing;
namespace Gnnt.MEBS.HQModel
{
	public class RHColor
	{
		public const int COLORSTYLE_CLASSICAL = 0;
		public const int COLORSTYLE_MODERN = 1;
		public const int COLORSTYLE_ELEGANCE = 2;
		public const int COLORSTYLE_SOFTNESS = 3;
		public const int COLORSTYLE_DIGNITY = 4;
		public const int COLORSTYLE_TRADITION = 5;
		public Color clBackGround;
		public Color clPriceChange;
		public Color clIncrease;
		public Color clDecrease;
		public Color clEqual;
		public Color clGrid;
		public Color clMinLine;
		public Color clCursor;
		public Color clProductName;
		public Color clVolume;
		public Color clReserve;
		public Color clNumber;
		public Color clHighlight;
		public Color clItem;
		public Color clMultiQuote_TitleBack;
		public Color clKLineUp;
		public Color clKLineDown;
		public Color clKLineEqual;
		public Color clPolyLine;
		public Color clUSALine;
		public Color[] clIndicator = new Color[6];
		public RHColor(int iStyle)
		{
			switch (iStyle)
			{
			case 1:
				this.clBackGround = Color.FromArgb(255, 255, 255);
				this.clIncrease = Color.FromArgb(240, 0, 0);
				this.clDecrease = Color.FromArgb(0, 128, 0);
				this.clEqual = Color.FromArgb(68, 68, 68);
				this.clGrid = Color.FromArgb(160, 160, 160);
				this.clMinLine = Color.FromArgb(0, 0, 160);
				this.clCursor = Color.FromArgb(255, 128, 0);
				this.clHighlight = Color.FromArgb(112, 219, 255);
				this.clItem = Color.FromArgb(0, 0, 128);
				this.clMultiQuote_TitleBack = Color.FromArgb(192, 192, 192);
				this.clProductName = Color.FromArgb(0, 0, 128);
				this.clVolume = Color.FromArgb(0, 0, 192);
				this.clReserve = Color.FromArgb(64, 128, 128);
				this.clNumber = Color.FromArgb(0, 0, 128);
				this.clKLineUp = Color.FromArgb(255, 0, 0);
				this.clKLineDown = Color.FromArgb(0, 128, 0);
				this.clKLineEqual = Color.FromArgb(128, 128, 128);
				this.clPolyLine = Color.FromArgb(0, 255, 255);
				this.clUSALine = Color.FromArgb(0, 255, 255);
				this.clIndicator[0] = Color.FromArgb(0, 0, 64);
				this.clIndicator[1] = Color.FromArgb(255, 0, 128);
				this.clIndicator[2] = Color.FromArgb(255, 128, 0);
				this.clIndicator[3] = Color.FromArgb(128, 0, 0);
				this.clIndicator[4] = Color.FromArgb(255, 0, 255);
				this.clIndicator[5] = Color.FromArgb(128, 128, 16);
				this.clPriceChange = this.clHighlight;
				return;
			case 2:
				this.clBackGround = Color.FromArgb(0, 0, 128);
				this.clIncrease = Color.FromArgb(255, 0, 0);
				this.clDecrease = Color.FromArgb(0, 255, 255);
				this.clEqual = Color.FromArgb(255, 255, 255);
				this.clGrid = Color.FromArgb(128, 128, 128);
				this.clMinLine = Color.FromArgb(255, 255, 255);
				this.clCursor = Color.FromArgb(192, 192, 192);
				this.clHighlight = Color.FromArgb(255, 255, 128);
				this.clItem = Color.FromArgb(255, 255, 255);
				this.clMultiQuote_TitleBack = Color.FromArgb(0, 0, 176);
				this.clProductName = Color.FromArgb(255, 255, 0);
				this.clVolume = Color.FromArgb(224, 224, 0);
				this.clReserve = Color.FromArgb(64, 128, 128);
				this.clNumber = Color.FromArgb(192, 192, 192);
				this.clKLineUp = Color.FromArgb(255, 0, 0);
				this.clKLineDown = Color.FromArgb(128, 255, 255);
				this.clKLineEqual = Color.FromArgb(255, 255, 255);
				this.clPolyLine = Color.FromArgb(0, 255, 255);
				this.clUSALine = Color.FromArgb(0, 255, 255);
				this.clIndicator[0] = Color.FromArgb(255, 255, 0);
				this.clIndicator[1] = Color.FromArgb(255, 255, 255);
				this.clIndicator[2] = Color.FromArgb(0, 0, 255);
				this.clIndicator[3] = Color.FromArgb(255, 128, 64);
				this.clIndicator[4] = Color.FromArgb(255, 0, 255);
				this.clIndicator[5] = Color.FromArgb(128, 128, 16);
				this.clPriceChange = this.clHighlight;
				return;
			case 3:
				this.clBackGround = Color.FromArgb(248, 248, 240);
				this.clIncrease = Color.FromArgb(255, 0, 0);
				this.clDecrease = Color.FromArgb(0, 160, 0);
				this.clEqual = Color.FromArgb(0, 0, 0);
				this.clGrid = Color.FromArgb(192, 192, 192);
				this.clMinLine = Color.FromArgb(0, 0, 0);
				this.clCursor = Color.FromArgb(64, 64, 64);
				this.clItem = Color.FromArgb(0, 0, 0);
				this.clMultiQuote_TitleBack = Color.FromArgb(232, 232, 224);
				this.clProductName = Color.FromArgb(0, 0, 255);
				this.clHighlight = Color.FromArgb(112, 219, 255);
				this.clReserve = Color.FromArgb(64, 128, 128);
				this.clVolume = Color.FromArgb(96, 96, 0);
				this.clNumber = Color.FromArgb(64, 64, 64);
				this.clKLineUp = Color.FromArgb(255, 0, 0);
				this.clKLineDown = Color.FromArgb(0, 0, 255);
				this.clKLineEqual = Color.FromArgb(128, 128, 128);
				this.clPolyLine = Color.FromArgb(0, 255, 255);
				this.clUSALine = Color.FromArgb(0, 255, 255);
				this.clIndicator[0] = Color.FromArgb(64, 64, 64);
				this.clIndicator[1] = Color.FromArgb(192, 0, 64);
				this.clIndicator[2] = Color.FromArgb(32, 128, 32);
				this.clIndicator[3] = Color.FromArgb(128, 0, 0);
				this.clIndicator[4] = Color.FromArgb(255, 0, 255);
				this.clIndicator[5] = Color.FromArgb(128, 128, 16);
				this.clPriceChange = this.clHighlight;
				return;
			case 4:
				this.clBackGround = Color.FromArgb(245, 252, 253);
				this.clIncrease = Color.FromArgb(255, 128, 128);
				this.clDecrease = Color.FromArgb(0, 255, 0);
				this.clEqual = Color.FromArgb(160, 160, 160);
				this.clGrid = Color.FromArgb(128, 128, 128);
				this.clMinLine = Color.FromArgb(160, 160, 160);
				this.clCursor = Color.FromArgb(32, 32, 32);
				this.clHighlight = Color.FromArgb(128, 128, 255);
				this.clItem = Color.FromArgb(0, 0, 255);
				this.clMultiQuote_TitleBack = Color.FromArgb(160, 240, 160);
				this.clProductName = Color.FromArgb(64, 64, 255);
				this.clVolume = Color.FromArgb(128, 128, 0);
				this.clReserve = Color.FromArgb(64, 128, 128);
				this.clNumber = Color.FromArgb(32, 32, 32);
				this.clKLineUp = Color.FromArgb(255, 0, 0);
				this.clKLineDown = Color.FromArgb(0, 255, 0);
				this.clKLineEqual = Color.FromArgb(64, 64, 64);
				this.clPolyLine = Color.FromArgb(0, 255, 255);
				this.clUSALine = Color.FromArgb(0, 255, 255);
				this.clIndicator[0] = Color.FromArgb(160, 160, 0);
				this.clIndicator[1] = Color.FromArgb(175, 175, 175);
				this.clIndicator[2] = Color.FromArgb(0, 0, 255);
				this.clIndicator[3] = Color.FromArgb(255, 128, 64);
				this.clIndicator[4] = Color.FromArgb(255, 0, 255);
				this.clIndicator[5] = Color.FromArgb(128, 128, 16);
				this.clPriceChange = this.clHighlight;
				return;
			case 5:
				this.clBackGround = Color.FromArgb(10, 10, 10);
				this.clIncrease = Color.FromArgb(255, 60, 60);
				this.clDecrease = Color.FromArgb(0, 230, 0);
				this.clEqual = Color.FromArgb(255, 255, 255);
				this.clGrid = Color.FromArgb(192, 0, 0);
				this.clMinLine = Color.FromArgb(255, 255, 255);
				this.clCursor = Color.FromArgb(192, 192, 192);
				this.clItem = Color.FromArgb(0, 255, 255);
				this.clMultiQuote_TitleBack = Color.FromArgb(128, 128, 128);
				this.clProductName = Color.FromArgb(230, 230, 230);
				this.clHighlight = Color.FromArgb(23, 38, 62);
				this.clVolume = Color.FromArgb(200, 200, 0);
				this.clReserve = Color.FromArgb(0, 255, 255);
				this.clNumber = Color.FromArgb(230, 230, 230);
				this.clKLineUp = Color.FromArgb(255, 0, 0);
				this.clKLineDown = Color.FromArgb(0, 255, 255);
				this.clKLineEqual = Color.FromArgb(255, 255, 255);
				this.clPolyLine = Color.FromArgb(0, 255, 255);
				this.clUSALine = Color.FromArgb(0, 255, 255);
				this.clIndicator[0] = Color.FromArgb(255, 255, 255);
				this.clIndicator[1] = Color.FromArgb(255, 255, 0);
				this.clIndicator[2] = Color.FromArgb(255, 0, 255);
				this.clIndicator[3] = Color.FromArgb(0, 255, 0);
				this.clIndicator[4] = Color.FromArgb(255, 128, 0);
				this.clIndicator[5] = Color.FromArgb(128, 128, 16);
				this.clPriceChange = Color.FromArgb(0, 0, 255);
				return;
			}
			this.clBackGround = Color.FromArgb(0, 0, 0);
			this.clIncrease = Color.FromArgb(255, 96, 96);
			this.clDecrease = Color.FromArgb(0, 255, 96);
			this.clEqual = Color.FromArgb(255, 255, 255);
			this.clGrid = Color.FromArgb(160, 0, 0);
			this.clMinLine = Color.FromArgb(255, 255, 255);
			this.clCursor = Color.FromArgb(192, 192, 192);
			this.clItem = Color.FromArgb(255, 255, 255);
			this.clMultiQuote_TitleBack = Color.FromArgb(40, 40, 40);
			this.clProductName = Color.FromArgb(255, 255, 64);
			this.clHighlight = Color.FromArgb(40, 49, 98);
			this.clVolume = Color.FromArgb(255, 255, 64);
			this.clReserve = Color.FromArgb(0, 255, 0);
			this.clNumber = Color.FromArgb(192, 192, 192);
			this.clKLineUp = Color.FromArgb(255, 96, 96);
			this.clKLineDown = Color.FromArgb(0, 255, 255);
			this.clKLineEqual = Color.FromArgb(255, 255, 255);
			this.clPolyLine = Color.FromArgb(0, 255, 255);
			this.clUSALine = Color.FromArgb(0, 255, 255);
			this.clIndicator[0] = Color.FromArgb(255, 255, 255);
			this.clIndicator[1] = Color.FromArgb(255, 255, 0);
			this.clIndicator[2] = Color.FromArgb(255, 0, 255);
			this.clIndicator[3] = Color.FromArgb(0, 255, 0);
			this.clIndicator[4] = Color.FromArgb(255, 128, 0);
			this.clIndicator[5] = Color.FromArgb(128, 128, 16);
			this.clPriceChange = this.clHighlight;
		}
	}
}