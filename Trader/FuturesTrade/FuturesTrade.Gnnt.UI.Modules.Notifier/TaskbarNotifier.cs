using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
namespace FuturesTrade.Gnnt.UI.Modules.Notifier
{
	public class TaskbarNotifier : Form
	{
		public enum TaskbarStates
		{
			hidden,
			appearing,
			visible,
			disappearing
		}
		protected Bitmap BackgroundBitmap;
		protected Bitmap CloseBitmap;
		protected Point CloseBitmapLocation;
		protected Size CloseBitmapSize;
		protected Rectangle RealTitleRectangle;
		protected Rectangle RealContentRectangle;
		protected Rectangle WorkAreaRectangle;
		protected Timer timer = new Timer();
		protected TaskbarNotifier.TaskbarStates taskbarState;
		protected string titleText;
		protected string contentText;
		protected Color normalTitleColor = Color.FromArgb(255, 0, 0);
		protected Color hoverTitleColor = Color.FromArgb(255, 0, 0);
		protected Color normalContentColor = Color.FromArgb(0, 0, 0);
		protected Color hoverContentColor = Color.FromArgb(0, 0, 102);
		protected Font normalTitleFont = new Font("Arial", 12f, FontStyle.Regular, GraphicsUnit.Pixel);
		protected Font hoverTitleFont = new Font("Arial", 12f, FontStyle.Bold, GraphicsUnit.Pixel);
		protected Font normalContentFont = new Font("Arial", 11f, FontStyle.Regular, GraphicsUnit.Pixel);
		protected Font hoverContentFont = new Font("Arial", 11f, FontStyle.Regular, GraphicsUnit.Pixel);
		protected int nShowEvents;
		protected int nHideEvents;
		protected int nVisibleEvents;
		protected int nIncrementShow;
		protected int nIncrementHide;
		protected bool bIsMouseOverPopup;
		protected bool bIsMouseOverClose;
		protected bool bIsMouseOverContent;
		protected bool bIsMouseOverTitle;
		protected bool bIsMouseDown;
		public Rectangle TitleRectangle;
		public Rectangle ContentRectangle;
		public bool TitleClickable;
		public bool ContentClickable = true;
		public bool CloseClickable = true;
		public bool EnableSelectionRectangle = true;
		public bool AutoHide = true;
		public event EventHandler CloseClick;
		public event EventHandler TitleClick;
		public event EventHandler ContentClick;
		public TaskbarNotifier.TaskbarStates TaskbarState
		{
			get
			{
				return this.taskbarState;
			}
		}
		public string TitleText
		{
			get
			{
				return this.titleText;
			}
			set
			{
				this.titleText = value;
				this.Refresh();
			}
		}
		public string ContentText
		{
			get
			{
				return this.contentText;
			}
			set
			{
				this.contentText = value;
				this.Refresh();
			}
		}
		public Color NormalTitleColor
		{
			get
			{
				return this.normalTitleColor;
			}
			set
			{
				this.normalTitleColor = value;
				this.Refresh();
			}
		}
		public Color HoverTitleColor
		{
			get
			{
				return this.hoverTitleColor;
			}
			set
			{
				this.hoverTitleColor = value;
				this.Refresh();
			}
		}
		public Color NormalContentColor
		{
			get
			{
				return this.normalContentColor;
			}
			set
			{
				this.normalContentColor = value;
				this.Refresh();
			}
		}
		public Color HoverContentColor
		{
			get
			{
				return this.hoverContentColor;
			}
			set
			{
				this.hoverContentColor = value;
				this.Refresh();
			}
		}
		public Font NormalTitleFont
		{
			get
			{
				return this.normalTitleFont;
			}
			set
			{
				this.normalTitleFont = value;
				this.Refresh();
			}
		}
		public Font HoverTitleFont
		{
			get
			{
				return this.hoverTitleFont;
			}
			set
			{
				this.hoverTitleFont = value;
				this.Refresh();
			}
		}
		public Font NormalContentFont
		{
			get
			{
				return this.normalContentFont;
			}
			set
			{
				this.normalContentFont = value;
				this.Refresh();
			}
		}
		public Font HoverContentFont
		{
			get
			{
				return this.hoverContentFont;
			}
			set
			{
				this.hoverContentFont = value;
				this.Refresh();
			}
		}
		public TaskbarNotifier()
		{
			base.WindowState = FormWindowState.Minimized;
			base.Show();
			base.Hide();
			base.WindowState = FormWindowState.Normal;
			base.ShowInTaskbar = false;
			base.TopMost = true;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.ControlBox = false;
			this.timer.Enabled = true;
			this.timer.Tick += new EventHandler(this.OnTimer);
		}
		public void Show(string strTitle, string strContent, int nTimeToShow, int nTimeToStay, int nTimeToHide)
		{
			this.WorkAreaRectangle = Screen.GetWorkingArea(this.WorkAreaRectangle);
			this.titleText = strTitle;
			this.contentText = strContent;
			this.nVisibleEvents = nTimeToStay;
			this.CalculateMouseRectangles();
			if (nTimeToShow > 10)
			{
				int num = Math.Min(nTimeToShow / 10, this.BackgroundBitmap.Height);
				this.nShowEvents = nTimeToShow / num;
				this.nIncrementShow = this.BackgroundBitmap.Height / num;
			}
			else
			{
				this.nShowEvents = 10;
				this.nIncrementShow = this.BackgroundBitmap.Height;
			}
			if (nTimeToHide > 10)
			{
				int num = Math.Min(nTimeToHide / 10, this.BackgroundBitmap.Height);
				this.nHideEvents = nTimeToHide / num;
				this.nIncrementHide = this.BackgroundBitmap.Height / num;
			}
			else
			{
				this.nHideEvents = 10;
				this.nIncrementHide = this.BackgroundBitmap.Height;
			}
			switch (this.taskbarState)
			{
			case TaskbarNotifier.TaskbarStates.hidden:
				this.taskbarState = TaskbarNotifier.TaskbarStates.appearing;
				base.SetBounds(this.WorkAreaRectangle.Left + 17, this.WorkAreaRectangle.Bottom - 1, this.BackgroundBitmap.Width, 0);
				this.timer.Interval = this.nShowEvents;
				this.timer.Start();
				base.Show();
				return;
			case TaskbarNotifier.TaskbarStates.appearing:
				this.Refresh();
				return;
			case TaskbarNotifier.TaskbarStates.visible:
				this.timer.Stop();
				this.timer.Interval = this.nVisibleEvents;
				this.timer.Start();
				this.Refresh();
				return;
			case TaskbarNotifier.TaskbarStates.disappearing:
				this.timer.Stop();
				this.taskbarState = TaskbarNotifier.TaskbarStates.visible;
				base.SetBounds(this.WorkAreaRectangle.Left + 17, this.WorkAreaRectangle.Bottom - this.BackgroundBitmap.Height - 1, this.BackgroundBitmap.Width, this.BackgroundBitmap.Height);
				this.timer.Interval = this.nVisibleEvents;
				this.timer.Start();
				this.Refresh();
				return;
			default:
				return;
			}
		}
		public new void Hide()
		{
			if (this.taskbarState != TaskbarNotifier.TaskbarStates.hidden)
			{
				this.timer.Stop();
				this.taskbarState = TaskbarNotifier.TaskbarStates.hidden;
				base.Hide();
			}
		}
		public void SetBackgroundBitmap(string strFilename, Color transparencyColor)
		{
			this.BackgroundBitmap = new Bitmap(strFilename);
			base.Width = this.BackgroundBitmap.Width;
			base.Height = this.BackgroundBitmap.Height;
			base.Region = this.BitmapToRegion(this.BackgroundBitmap, transparencyColor);
		}
		public void SetBackgroundBitmap(Image image, Color transparencyColor)
		{
			this.BackgroundBitmap = new Bitmap(image);
			base.Width = this.BackgroundBitmap.Width;
			base.Height = this.BackgroundBitmap.Height;
			base.Region = this.BitmapToRegion(this.BackgroundBitmap, transparencyColor);
		}
		public void SetCloseBitmap(string strFilename, Color transparencyColor, Point position)
		{
			this.CloseBitmap = new Bitmap(strFilename);
			this.CloseBitmap.MakeTransparent(transparencyColor);
			this.CloseBitmapSize = new Size(this.CloseBitmap.Width / 3, this.CloseBitmap.Height);
			this.CloseBitmapLocation = position;
		}
		public void SetCloseBitmap(Image image, Color transparencyColor, Point position)
		{
			this.CloseBitmap = new Bitmap(image);
			this.CloseBitmap.MakeTransparent(transparencyColor);
			this.CloseBitmapSize = new Size(this.CloseBitmap.Width / 3, this.CloseBitmap.Height);
			this.CloseBitmapLocation = position;
		}
		protected void DrawCloseButton(Graphics grfx)
		{
			if (this.CloseBitmap != null)
			{
				Rectangle destRect = new Rectangle(this.CloseBitmapLocation, this.CloseBitmapSize);
				Rectangle srcRect;
				if (this.bIsMouseOverClose)
				{
					if (this.bIsMouseDown)
					{
						srcRect = new Rectangle(new Point(this.CloseBitmapSize.Width * 2, 0), this.CloseBitmapSize);
					}
					else
					{
						srcRect = new Rectangle(new Point(this.CloseBitmapSize.Width, 0), this.CloseBitmapSize);
					}
				}
				else
				{
					srcRect = new Rectangle(new Point(0, 0), this.CloseBitmapSize);
				}
				grfx.DrawImage(this.CloseBitmap, destRect, srcRect, GraphicsUnit.Pixel);
			}
		}
		protected void DrawText(Graphics grfx)
		{
			if (this.titleText != null && this.titleText.Length != 0)
			{
				StringFormat stringFormat = new StringFormat();
				stringFormat.Alignment = StringAlignment.Near;
				stringFormat.LineAlignment = StringAlignment.Center;
				stringFormat.FormatFlags = StringFormatFlags.NoWrap;
				if (this.bIsMouseOverTitle)
				{
					grfx.DrawString(this.titleText, this.hoverTitleFont, new SolidBrush(this.hoverTitleColor), this.TitleRectangle, stringFormat);
				}
				else
				{
					grfx.DrawString(this.titleText, this.normalTitleFont, new SolidBrush(this.normalTitleColor), this.TitleRectangle, stringFormat);
				}
			}
			if (this.contentText != null && this.contentText.Length != 0)
			{
				StringFormat stringFormat2 = new StringFormat();
				stringFormat2.Alignment = StringAlignment.Center;
				stringFormat2.LineAlignment = StringAlignment.Center;
				stringFormat2.FormatFlags = StringFormatFlags.MeasureTrailingSpaces;
				if (this.bIsMouseOverContent)
				{
					grfx.DrawString(this.contentText, this.hoverContentFont, new SolidBrush(this.hoverContentColor), this.ContentRectangle, stringFormat2);
					if (this.EnableSelectionRectangle)
					{
						ControlPaint.DrawBorder3D(grfx, this.RealContentRectangle, Border3DStyle.Etched, Border3DSide.Left | Border3DSide.Top | Border3DSide.Right | Border3DSide.Bottom);
						return;
					}
				}
				else
				{
					grfx.DrawString(this.contentText, this.normalContentFont, new SolidBrush(this.normalContentColor), this.ContentRectangle, stringFormat2);
				}
			}
		}
		protected void CalculateMouseRectangles()
		{
			Graphics graphics = base.CreateGraphics();
			StringFormat stringFormat = new StringFormat();
			stringFormat.Alignment = StringAlignment.Center;
			stringFormat.LineAlignment = StringAlignment.Center;
			stringFormat.FormatFlags = StringFormatFlags.MeasureTrailingSpaces;
			SizeF sizeF = graphics.MeasureString(this.titleText, this.hoverTitleFont, this.TitleRectangle.Width, stringFormat);
			SizeF sizeF2 = graphics.MeasureString(this.contentText, this.hoverContentFont, this.ContentRectangle.Width, stringFormat);
			graphics.Dispose();
			this.RealTitleRectangle = new Rectangle(this.TitleRectangle.Left, this.TitleRectangle.Top, (int)sizeF.Width, (int)sizeF.Height);
			this.RealTitleRectangle.Inflate(0, 2);
			this.RealContentRectangle = new Rectangle((this.ContentRectangle.Width - (int)sizeF2.Width) / 2 + this.ContentRectangle.Left, (this.ContentRectangle.Height - (int)sizeF2.Height) / 2 + this.ContentRectangle.Top, (int)sizeF2.Width, (int)sizeF2.Height);
			this.RealContentRectangle.Inflate(0, 2);
		}
		protected Region BitmapToRegion(Bitmap bitmap, Color transparencyColor)
		{
			if (bitmap == null)
			{
				throw new ArgumentNullException("Bitmap", "Bitmap cannot be null!");
			}
			int height = bitmap.Height;
			int width = bitmap.Width;
			GraphicsPath graphicsPath = new GraphicsPath();
			for (int i = 0; i < height; i++)
			{
				for (int j = 0; j < width; j++)
				{
					if (!(bitmap.GetPixel(j, i) == transparencyColor))
					{
						int num = j;
						while (j < width && bitmap.GetPixel(j, i) != transparencyColor)
						{
							j++;
						}
						graphicsPath.AddRectangle(new Rectangle(num, i, j - num, 1));
					}
				}
			}
			Region result = new Region(graphicsPath);
			graphicsPath.Dispose();
			return result;
		}
		protected void OnTimer(object obj, EventArgs ea)
		{
			switch (this.taskbarState)
			{
			case TaskbarNotifier.TaskbarStates.appearing:
				base.FormBorderStyle = FormBorderStyle.None;
				if (base.Height < this.BackgroundBitmap.Height)
				{
					base.SetBounds(base.Left, base.Top - this.nIncrementShow, base.Width, base.Height + this.nIncrementShow);
					return;
				}
				this.timer.Stop();
				base.Height = this.BackgroundBitmap.Height;
				this.timer.Interval = this.nVisibleEvents;
				this.taskbarState = TaskbarNotifier.TaskbarStates.visible;
				this.timer.Start();
				return;
			case TaskbarNotifier.TaskbarStates.visible:
				this.timer.Stop();
				this.timer.Interval = this.nHideEvents;
				this.taskbarState = TaskbarNotifier.TaskbarStates.disappearing;
				if (this.AutoHide)
				{
					this.timer.Start();
					return;
				}
				break;
			case TaskbarNotifier.TaskbarStates.disappearing:
				if (base.Top < this.WorkAreaRectangle.Bottom)
				{
					base.SetBounds(base.Left, base.Top + this.nIncrementHide, base.Width, base.Height - this.nIncrementHide);
					return;
				}
				this.Hide();
				break;
			default:
				return;
			}
		}
		protected override void OnMouseEnter(EventArgs ea)
		{
			base.OnMouseEnter(ea);
			this.bIsMouseOverPopup = true;
			this.Refresh();
		}
		protected override void OnMouseLeave(EventArgs ea)
		{
			base.OnMouseLeave(ea);
			this.bIsMouseOverPopup = false;
			this.bIsMouseOverClose = false;
			this.bIsMouseOverTitle = false;
			this.bIsMouseOverContent = false;
			this.Refresh();
		}
		protected override void OnMouseMove(MouseEventArgs mea)
		{
			base.OnMouseMove(mea);
			bool flag = false;
			if (mea.X > this.CloseBitmapLocation.X && mea.X < this.CloseBitmapLocation.X + this.CloseBitmapSize.Width && mea.Y > this.CloseBitmapLocation.Y && mea.Y < this.CloseBitmapLocation.Y + this.CloseBitmapSize.Height && this.CloseClickable)
			{
				if (!this.bIsMouseOverClose)
				{
					this.bIsMouseOverClose = true;
					this.bIsMouseOverTitle = false;
					this.bIsMouseOverContent = false;
					this.Cursor = Cursors.Hand;
					flag = true;
				}
			}
			else
			{
				if (this.RealContentRectangle.Contains(new Point(mea.X, mea.Y)) && this.ContentClickable)
				{
					if (!this.bIsMouseOverContent)
					{
						this.bIsMouseOverClose = false;
						this.bIsMouseOverTitle = false;
						this.bIsMouseOverContent = true;
						this.Cursor = Cursors.Hand;
						flag = true;
					}
				}
				else
				{
					if (this.RealTitleRectangle.Contains(new Point(mea.X, mea.Y)) && this.TitleClickable)
					{
						if (!this.bIsMouseOverTitle)
						{
							this.bIsMouseOverClose = false;
							this.bIsMouseOverTitle = true;
							this.bIsMouseOverContent = false;
							this.Cursor = Cursors.Hand;
							flag = true;
						}
					}
					else
					{
						if (this.bIsMouseOverClose || this.bIsMouseOverTitle || this.bIsMouseOverContent)
						{
							flag = true;
						}
						this.bIsMouseOverClose = false;
						this.bIsMouseOverTitle = false;
						this.bIsMouseOverContent = false;
						this.Cursor = Cursors.Default;
					}
				}
			}
			if (flag)
			{
				this.Refresh();
			}
		}
		protected override void OnMouseDown(MouseEventArgs mea)
		{
			base.OnMouseDown(mea);
			this.bIsMouseDown = true;
			if (this.bIsMouseOverClose)
			{
				this.Refresh();
			}
		}
		protected override void OnMouseUp(MouseEventArgs mea)
		{
			base.OnMouseDown(mea);
			this.bIsMouseDown = false;
			if (this.bIsMouseOverClose)
			{
				this.timer.Interval = this.nHideEvents;
				this.taskbarState = TaskbarNotifier.TaskbarStates.disappearing;
				this.timer.Start();
				if (this.CloseClick != null)
				{
					this.CloseClick(this, new EventArgs());
					return;
				}
			}
			else
			{
				if (this.bIsMouseOverTitle)
				{
					if (this.TitleClick != null)
					{
						this.TitleClick(this, new EventArgs());
						return;
					}
				}
				else
				{
					if (this.bIsMouseOverContent)
					{
						if (!this.AutoHide)
						{
							this.timer.Interval = this.nHideEvents;
							this.taskbarState = TaskbarNotifier.TaskbarStates.disappearing;
							this.timer.Start();
						}
						if (this.ContentClick != null)
						{
							this.ContentClick(this, new EventArgs());
						}
					}
				}
			}
		}
		protected override void OnPaintBackground(PaintEventArgs pea)
		{
			Graphics graphics = pea.Graphics;
			graphics.PageUnit = GraphicsUnit.Pixel;
			Bitmap image = new Bitmap(this.BackgroundBitmap.Width, this.BackgroundBitmap.Height);
			Graphics graphics2 = Graphics.FromImage(image);
			if (this.BackgroundBitmap != null)
			{
				graphics2.DrawImage(this.BackgroundBitmap, 0, 0, this.BackgroundBitmap.Width, this.BackgroundBitmap.Height);
			}
			this.DrawCloseButton(graphics2);
			this.DrawText(graphics2);
			graphics.DrawImage(image, 0, 0);
		}
		private void InitializeComponent()
		{
			base.SuspendLayout();
			base.ClientSize = new Size(292, 272);
			base.Name = "TaskbarNotifier";
			base.TopMost = true;
			base.ResumeLayout(false);
		}
	}
}
