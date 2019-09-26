using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R3St0ckDesktop
{
   public class MCM
    {
        public int LocationID { get; set; }
        public int TransactionID { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Report_Type { get; set; }
        public int Department_ID { get; set; }
        public String Department_Name { get; set; }
        public Double Discount_Amount { get; set; }
        public int Discount_Count { get; set; }
        public Double Promotion_Amount { get; set; }
        public int Promotion_Count { get; set; }
        public Double Refund_Amount { get; set; }
        public int Refund_Count { get; set; }
        public int Sales_Quantity { get; set; }
        public Double Sales_Amount { get; set; }
        public int Transaction_Count { get; set; }
        public Double Unscanned_Sales { get; set; }
        public int Unscanned_Sales_Count { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
