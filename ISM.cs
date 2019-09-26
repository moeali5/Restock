using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R3St0ckDesktop
{
   public class ISM
    {
        public string UPC_Code { get; set; }
        public int LocationID { get; set; }
        public int Processing_Log_ID { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Report_Type { get; set; }
        public int Department_Number { get; set; }
        public int Modifier { get; set; }
        public String Description { get; set; }
        public int Selling_Unit { get; set; }
        public Double Unit_Price { get; set; }
        public int Unit_Sold { get; set; }
        public Double Total_Price { get; set; }
        public int Reason_Code { get; set; }
        public Double Discount_Amount { get; set; }
        public int Discount_Count { get; set; }
        public Double Promotion_Amount { get; set; }
        public int Promotion_Count { get; set; }
        public Double Refund_Amount { get; set; }
        public int Refund_Count { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
