using System;
using System.Collections.Generic;
namespace TradeInterface.Gnnt.DataVO
{
	public class OrderQueryPagingResponseVO : RecResponseVO
	{
		public long UpdateTime;
		public List<OrderInfo> OrderInfoList = new List<OrderInfo>();
		public OrderQueryTotalRow TotalRow = new OrderQueryTotalRow();
	}
}
