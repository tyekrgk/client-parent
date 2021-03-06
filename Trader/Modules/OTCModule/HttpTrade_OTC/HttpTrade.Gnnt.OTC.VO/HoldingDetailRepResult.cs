using System;
using ToolsLibrary.util;
namespace HttpTrade.Gnnt.OTC.VO
{
	public class HoldingDetailRepResult
	{
		private string RETCODE;
		private string MESSAGE;
		private string TTLREC;
		public long RetCode
		{
			get
			{
				return Tools.StrToLong(this.RETCODE);
			}
		}
		public string RetMessage
		{
			get
			{
				return this.MESSAGE;
			}
		}
		public int TotalRecord
		{
			get
			{
				return Tools.StrToInt(this.TTLREC);
			}
		}
	}
}
