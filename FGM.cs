using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R3St0ckDesktop
{
  public  class FGM
    {
       
        public int LocationID { get;set; }
        public int TransactionID { get;set; }
        public DateTime BeginDate { get;set; }
        public DateTime EndDate { get;set; }
        public int PrimaryReportPeriod { get; set; }
        public int FuelGradeID { get; set; }
        public Double FuelGradeSalesVolume { get; set; }
        public Double FuelGradeSalesAmount { get; set; }
        public DateTime CreateDate { get; set; }


    }
}
