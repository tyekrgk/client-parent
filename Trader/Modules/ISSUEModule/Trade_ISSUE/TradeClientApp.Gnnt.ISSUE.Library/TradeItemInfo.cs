using System;
using System.Collections;
namespace TradeClientApp.Gnnt.ISSUE.Library
{
	public class TradeItemInfo
	{
		public string m_strItems;
		public Hashtable m_htItemInfo;
		public TradeItemInfo()
		{
			this.initAllItem();
		}
		private void initAllItem()
		{
			this.m_strItems = "TradeNo;Time;TransactionsCode;CommodityID;B_S;O_L;Price;Qty;Liqpl;LPrice;Comm;";
			this.m_htItemInfo = new Hashtable();
			this.m_htItemInfo.Add("TradeNo", new ColItemInfo(Global.M_ResourceManager.GetString("TradeStr_TradeNo"), 11, "", 0));
			this.m_htItemInfo.Add("Time", new ColItemInfo(Global.M_ResourceManager.GetString("TradeStr_Time"), 8, "Time", 0));
			this.m_htItemInfo.Add("TransactionsCode", new ColItemInfo(Global.M_ResourceManager.GetString("TradeStr_TransactionsCode"), 9, "", 0));
			this.m_htItemInfo.Add("CommodityID", new ColItemInfo(Global.M_ResourceManager.GetString("TradeStr_CommodityID"), 8, "", 0));
			this.m_htItemInfo.Add("CommodityName", new ColItemInfo(Global.M_ResourceManager.GetString("TradeStr_CommodityName"), 8, "", 0));
			this.m_htItemInfo.Add("B_S", new ColItemInfo(Global.M_ResourceManager.GetString("TradeStr_B_S"), 6, "", 0));
			this.m_htItemInfo.Add("O_L", new ColItemInfo(Global.M_ResourceManager.GetString("TradeStr_O_L"), 9, "", 0));
			this.m_htItemInfo.Add("Price", new ColItemInfo(Global.M_ResourceManager.GetString("TradeStr_Price"), 10, "", 0));
			this.m_htItemInfo.Add("Qty", new ColItemInfo(Global.M_ResourceManager.GetString("TradeStr_Qty"), 6, "", 0));
			this.m_htItemInfo.Add("Liqpl", new ColItemInfo(Global.M_ResourceManager.GetString("TradeStr_Liqpl"), 10, Global.formatMoney, 0));
			this.m_htItemInfo.Add("LPrice", new ColItemInfo(Global.M_ResourceManager.GetString("TradeStr_LPrice"), 10, "", 0));
			this.m_htItemInfo.Add("Comm", new ColItemInfo(Global.M_ResourceManager.GetString("TradeStr_Comm"), 9, Global.formatMoney, 0));
			this.m_htItemInfo.Add("Market", new ColItemInfo(Global.M_ResourceManager.GetString("TradeStr_MarKet"), 8, "", 1));
			string text = (string)Global.HTConfig["TradeItemName"];
			string[] array = text.Split(new char[]
			{
				';'
			});
			for (int i = 0; i < array.Length; i++)
			{
				string[] array2 = array[i].Split(new char[]
				{
					':'
				});
				if (array2.Length == 2 && array2[1].Length > 0)
				{
					ColItemInfo colItemInfo = (ColItemInfo)this.m_htItemInfo[array2[0]];
					if (colItemInfo != null)
					{
						colItemInfo.name = array2[1];
					}
				}
			}
			string text2 = (string)Global.HTConfig["TradeItems"];
			if (text2.Length > 0)
			{
				this.m_strItems = text2;
			}
		}
	}
}
