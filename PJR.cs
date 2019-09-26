using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R3St0ckDesktop
{
   public class PJR
    {
       
        public int LocationID { get; set; }
        public int Transaction_ID { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Register_ID { get; set; }
        public int Cashier_ID { get; set; }
        public int Department_ID { get; set; }
        public string UPC_Code { get; set; }
        public int Fuel_Line { get; set; }
        public int Fuel_Grade_ID { get; set; }
        public string Transaction_Type { get; set; }
        public string Transaction_Status { get; set; }
        public string Fuel_Description { get; set; }
        public Double Actual_Sale_Price { get; set; }
        public Double Sale_Qty { get; set; }
        public Double Sale_Amount { get; set; }
        public String Transaction_Entry_Method { get; set; }
        public int Modifier { get; set; }
        public string Description { get; set; }
        public int Selling_Unit { get; set; }
        public Double Unit_Price { get; set; }
        public int Unit_Sold { get; set; }
        public Double Total_Price { get; set; }
        public Double Discount_Amount { get; set; }
        public int Discount_Count { get; set; }
        public Double Promotion_Amount { get; set; }
        public int Promotion_Count { get; set; }
        public Double Refund_Amount { get; set; }
        public int Refund_Count { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
