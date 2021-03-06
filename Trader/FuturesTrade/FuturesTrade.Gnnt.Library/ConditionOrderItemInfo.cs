using System;
using System.Collections;
namespace FuturesTrade.Gnnt.Library
{
	public class ConditionOrderItemInfo
	{
		public string m_strItems;
		public Hashtable m_htItemInfo;
		public ConditionOrderItemInfo()
		{
			this.initAllItem();
		}
		private void initAllItem()
		{
			this.m_strItems = "SelectAll;OrderNo;CommodityID;OrderState;B_S;O_L;Price;Qty;ConditionCommodityID;CoditionType;ConditionSign;ConditionPrice;PrepareTime;MatureTime;OrderTime;TransactionsCode;";
			this.m_htItemInfo = new Hashtable();
			this.m_htItemInfo.Add("SelectAll", new ColItemInfo(Global.M_ResourceManager.GetString("TradeStr_SelectFlag"), 6, "", 0));
			this.m_htItemInfo.Add("OrderNo", new ColItemInfo(Global.M_ResourceManager.GetString("TradeStr_ConditionOrderNo"), 10, "", 0));
			this.m_htItemInfo.Add("CommodityID", new ColItemInfo(Global.M_ResourceManager.GetString("TradeStr_CommodityID"), 10, "", 0));
			this.m_htItemInfo.Add("OrderState", new ColItemInfo(Global.M_ResourceManager.GetString("TradeStr_OrderState"), 10, "", 0));
			this.m_htItemInfo.Add("B_S", new ColItemInfo(Global.M_ResourceManager.GetString("TradeStr_B_S"), 8, "", 0));
			this.m_htItemInfo.Add("O_L", new ColItemInfo(Global.M_ResourceManager.GetString("TradeStr_O_L"), 10, "", 0));
			this.m_htItemInfo.Add("Price", new ColItemInfo(Global.M_ResourceManager.GetString("TradeStr_Price"), 10, Global.formatMoney, 0));
			this.m_htItemInfo.Add("Qty", new ColItemInfo(Global.M_ResourceManager.GetString("TradeStr_Qty"), 10, "", 0));
			this.m_htItemInfo.Add("ConditionCommodityID", new ColItemInfo(Global.M_ResourceManager.GetString("TradeStr_ConditionCommodityID"), 12, "", 0));
			this.m_htItemInfo.Add("CoditionType", new ColItemInfo(Global.M_ResourceManager.GetString("TradeStr_ConditionType"), 8, "", 0));
			this.m_htItemInfo.Add("ConditionSign", new ColItemInfo(Global.M_ResourceManager.GetString("TradeStr_ConditionSign"), 10, "", 0));
			this.m_htItemInfo.Add("ConditionPrice", new ColItemInfo(Global.M_ResourceManager.GetString("TradeStr_ConditionPrice"), 10, Global.formatMoney, 0));
			this.m_htItemInfo.Add("PrepareTime", new ColItemInfo(Global.M_ResourceManager.GetString("TradeStr_PrepareTime"), 12, "", 0));
			this.m_htItemInfo.Add("MatureTime", new ColItemInfo(Global.M_ResourceManager.GetString("TradeStr_MatureTime"), 12, "", 0));
			this.m_htItemInfo.Add("OrderTime", new ColItemInfo(Global.M_ResourceManager.GetString("TradeStr_OrderTime"), 12, "", 0));
			this.m_htItemInfo.Add("TransactionsCode", new ColItemInfo(Global.M_ResourceManager.GetString("TradeStr_TransactionsCode"), 10, "", 0));
			string text = (string)Global.HTConfig["ConditionOrderItemName"];
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
			string text2 = (string)Global.HTConfig["ConditionOrderItems"];
			if (text2.Length > 0)
			{
				this.m_strItems = text2;
			}
		}
	}
}
