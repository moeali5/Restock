using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace R3St0ckDesktop
{
   
    class Utility
    {
        String qry = "";
        static String constr = ConfigurationManager.ConnectionStrings["C7Entities"].ConnectionString.ToString();
        SqlConnection objConnection = new SqlConnection(constr);
        public String InsertUpdate(String qry)
        {
            objConnection.Open();
            SqlCommand cmd = new SqlCommand(qry, objConnection);
            cmd.ExecuteNonQuery();
            objConnection.Close();
            return "Save Successfully";
        }
    }
}
