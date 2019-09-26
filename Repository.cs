using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;
using System.Xml.Linq;
namespace R3St0ckDesktop
{
    public partial class Repository : Form
    {
        Utility ul = new Utility();
        public Repository()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtFilePath.Text == "")
            {
                MessageBox.Show("Please Select File");
            }
            else
            {
                StringBuilder str = new StringBuilder();
                if (txtFilePath.Text.Contains("FGM"))
                {
                    FGM fgm = new FGM();
                    foreach (XElement level0Element in XElement.Load(txtFilePath.Text).Elements("TransmissionHeader"))
                    {
                        //DgwRssFeedsLinks.Rows.Add(level0Element.Element("StoreLocationID").Value);
                        fgm.LocationID = Convert.ToInt32(level0Element.Element("StoreLocationID").Value);
                    }
                    foreach (XElement level0Element in XElement.Load(txtFilePath.Text).Elements("FuelGradeMovement"))
                    {

                        foreach (XElement level1Element in level0Element.Elements("MovementHeader"))
                        {
                            fgm.TransactionID = Convert.ToInt32(level1Element.Element("ReportSequenceNumber").Value);
                            fgm.PrimaryReportPeriod = Convert.ToInt32(level1Element.Element("PrimaryReportPeriod").Value);
                            fgm.CreateDate = Convert.ToDateTime(level1Element.Element("BusinessDate").Value);
                            fgm.BeginDate = Convert.ToDateTime(level1Element.Element("BeginDate").Value + " " + level1Element.Element("BeginTime").Value);
                            fgm.EndDate = Convert.ToDateTime(level1Element.Element("EndDate").Value + " " + level1Element.Element("EndTime").Value);
                        }
                        foreach (XElement level2Element in level0Element.Elements("FGMDetail"))
                        {
                            fgm.FuelGradeID = Convert.ToInt32(level2Element.Element("FuelGradeID").Value);

                            foreach (XElement level3Element in level2Element.Elements("FGMPositionSummary"))
                            {

                                foreach (XElement level4Element in level3Element.Elements("FGMSalesTotals"))
                                {
                                    fgm.FuelGradeSalesVolume = Convert.ToDouble(level4Element.Element("FuelGradeSalesVolume").Value);
                                    fgm.FuelGradeSalesAmount = Convert.ToDouble(level4Element.Element("FuelGradeSalesAmount").Value);
                                }
                            }
                            string s = "insert into FGM values(" + fgm.LocationID + "," + fgm.TransactionID + ",'" + fgm.BeginDate +
                                 "','" + fgm.EndDate + "'," + fgm.PrimaryReportPeriod + "," + fgm.FuelGradeID + ",0," + fgm.FuelGradeSalesVolume +
                                 "," + fgm.FuelGradeSalesAmount + ",'" + fgm.CreateDate.ToString() + "','" + DateTime.Now.ToString() + "'," + 0 + ")";

                            str.Append(s);
                            ul.InsertUpdate(s);
                        }

                    }
                }
                if (txtFilePath.Text.Contains("MCM"))
                {
                    MCM mcm = new MCM();
                    foreach (XElement level0Element in XElement.Load(txtFilePath.Text).Elements("TransmissionHeader"))
                    {
                        //DgwRssFeedsLinks.Rows.Add(level0Element.Element("StoreLocationID").Value);
                        mcm.LocationID = Convert.ToInt32(level0Element.Element("StoreLocationID").Value);
                    }
                    foreach (XElement level0Element in XElement.Load(txtFilePath.Text).Elements("MerchandiseCodeMovement"))
                    {

                        foreach (XElement level1Element in level0Element.Elements("MovementHeader"))
                        {
                            mcm.TransactionID = Convert.ToInt32(level1Element.Element("ReportSequenceNumber").Value);
                            mcm.Report_Type = Convert.ToInt32(level1Element.Element("PrimaryReportPeriod").Value);
                            mcm.CreateDate = Convert.ToDateTime(level1Element.Element("BusinessDate").Value);
                            mcm.BeginDate = Convert.ToDateTime(level1Element.Element("BeginDate").Value + " " + level1Element.Element("BeginTime").Value);
                            mcm.EndDate = Convert.ToDateTime(level1Element.Element("EndDate").Value + " " + level1Element.Element("EndTime").Value);
                        }
                        foreach (XElement level2Element in level0Element.Elements("MCMDetail"))
                        {
                            mcm.Department_ID = Convert.ToInt32(level2Element.Element("MerchandiseCode").Value);
                            mcm.Department_Name = (level2Element.Element("MerchandiseCodeDescription").Value);
                            foreach (XElement level3Element in level2Element.Elements("FGMPositionSummary"))
                            {

                                foreach (XElement level4Element in level3Element.Elements("MCMSalesTotals"))
                                {
                                    mcm.Transaction_Count = Convert.ToInt32(level4Element.Element("TransactionCount").Value);
                                    mcm.Discount_Amount = Convert.ToDouble(level4Element.Element("DiscountAmount").Value);
                                    mcm.Discount_Count = Convert.ToInt32(level4Element.Element("DiscountCount").Value);
                                    mcm.Promotion_Amount = Convert.ToDouble(level4Element.Element("PromotionAmount").Value);
                                    mcm.Promotion_Count = Convert.ToInt32(level4Element.Element("PromotionCount").Value);
                                    mcm.Refund_Amount = Convert.ToDouble(level4Element.Element("RefundAmount").Value);
                                    mcm.Refund_Count = Convert.ToInt32(level4Element.Element("RefundCount").Value);
                                    mcm.Sales_Amount = Convert.ToDouble(level4Element.Element("SalesAmount").Value);
                                    mcm.Sales_Quantity = Convert.ToInt32(level4Element.Element("SalesQuantity").Value);
                                    mcm.Unscanned_Sales = Convert.ToDouble(level4Element.Element("OpenDepartmentSalesAmount").Value);
                                    mcm.Unscanned_Sales_Count = Convert.ToInt32(level4Element.Element("OpenDepartmentTransactionCount").Value);

                                }
                            }
                            string s = "insert into MCM values(" + mcm.LocationID + "," + mcm.TransactionID + ",'" + mcm.BeginDate +
                                 "','" + mcm.EndDate + "'," + mcm.Report_Type + "," + mcm.Department_ID + "," + mcm.Department_Name +
                                 "," + mcm.Discount_Amount + "," + mcm.Discount_Count + "," + mcm.Promotion_Amount + "," + mcm.Promotion_Count + "," + mcm.Refund_Amount +
                                 "," + mcm.Refund_Count + "," + mcm.Sales_Quantity + "," + mcm.Sales_Amount + "," + mcm.Transaction_Count + "," + mcm.Unscanned_Sales +
                                    "," + mcm.Unscanned_Sales_Count + ",'" + mcm.CreateDate.ToString() + "','" + DateTime.Now.ToString("yyyy/mm/dd") + "'," + 0 + ")";

                            str.Append(s);

                        }

                    }


                }

                if (txtFilePath.Text.Contains("ISM"))
                {
                    ISM ism = new ISM();
                    foreach (XElement level0Element in XElement.Load(txtFilePath.Text).Elements("TransmissionHeader"))
                    {
                        //DgwRssFeedsLinks.Rows.Add(level0Element.Element("StoreLocationID").Value);
                        ism.LocationID = Convert.ToInt32(level0Element.Element("StoreLocationID").Value);
                    }
                    foreach (XElement level0Element in XElement.Load(txtFilePath.Text).Elements("ItemSalesMovement"))
                    {

                        foreach (XElement level1Element in level0Element.Elements("MovementHeader"))
                        {
                            ism.Processing_Log_ID = Convert.ToInt32(level1Element.Element("ReportSequenceNumber").Value);
                            ism.Report_Type = Convert.ToInt32(level1Element.Element("PrimaryReportPeriod").Value);
                            ism.CreateDate = Convert.ToDateTime(level1Element.Element("BusinessDate").Value);
                            ism.BeginDate = Convert.ToDateTime(level1Element.Element("BeginDate").Value + " " + level1Element.Element("BeginTime").Value);
                            ism.EndDate = Convert.ToDateTime(level1Element.Element("EndDate").Value + " " + level1Element.Element("EndTime").Value);
                        }
                        foreach (XElement level2Element in level0Element.Elements("ISMDetail"))
                        {
                            foreach (XElement level31Element in level2Element.Elements("ItemCode"))
                            {
                                ism.UPC_Code = (level31Element.Element("POSCode").Value);
                                ism.Modifier = Convert.ToInt32(level31Element.Element("POSCodeModifier").Value);
                            }
                               
                            ism.Department_Number = Convert.ToInt32(level2Element.Element("MerchandiseCode").Value);
                            ism.Description = (level2Element.Element("Description").Value);
                            ism.Selling_Unit = Convert.ToInt32(level2Element.Element("SellingUnits").Value);
                            foreach (XElement level3Element in level2Element.Elements("ISMSellPriceSummary"))
                            {
                                ism.Total_Price = Convert.ToDouble(level3Element.Element("ActualSalesPrice").Value);
                                foreach (XElement level4Element in level3Element.Elements("ISMSalesTotals"))
                                {
                                    ism.Reason_Code = Convert.ToInt32(level4Element.Element("TransactionCount").Value);
                                    ism.Discount_Amount = Convert.ToDouble(level4Element.Element("DiscountAmount").Value);
                                    ism.Discount_Count = Convert.ToInt32(level4Element.Element("DiscountCount").Value);
                                    ism.Promotion_Amount = Convert.ToDouble(level4Element.Element("PromotionAmount").Value);
                                    ism.Promotion_Count = Convert.ToInt32(level4Element.Element("PromotionCount").Value);
                                    ism.Refund_Amount = Convert.ToDouble(level4Element.Element("RefundAmount").Value);
                                    ism.Refund_Count = Convert.ToInt32(level4Element.Element("RefundCount").Value);
                                    ism.Unit_Price = Convert.ToDouble(level4Element.Element("SalesAmount").Value);
                                    ism.Unit_Sold = Convert.ToInt32(level4Element.Element("SalesQuantity").Value);
                                  
                                }
                            }
                            string s = "insert into Location_Product_Sale values(" + ism.LocationID + "," + ism.Processing_Log_ID + ",'" + ism.BeginDate +
                                 "','" + ism.EndDate +  "'," + ism.Department_Number + ",'" + ism.UPC_Code + "'," + ism.Modifier + ",'" + ism.Description + "'," + ism.Selling_Unit +
                                 "," + ism.Unit_Price + "," + ism.Unit_Sold + "," + ism.Total_Price + "," + ism.Reason_Code + 
                                 "," + ism.Discount_Amount + "," + ism.Discount_Count + "," + ism.Promotion_Amount + "," + ism.Promotion_Count + "," + ism.Refund_Amount +
                                 "," + ism.Refund_Count + ",'" + ism.CreateDate.ToString() + "','" + DateTime.Now.ToString("yyyy/mm/dd") + "'," + 0 + ")";

                            str.Append(s);

                        }

                    }


                }
            }
              }

        private void txtFilePath_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtFilePath_Click(object sender, EventArgs e)
        {
             OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "Browse Text Files",

                CheckFileExists = true,
                CheckPathExists = true,
                DefaultExt = "xml",
                Filter = "xml files (*.xml)|*.xml",
                FilterIndex = 2,
                RestoreDirectory = true,
                ReadOnlyChecked = true,
                ShowReadOnly = true
            };
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtFilePath.Text = openFileDialog1.FileName;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DgwRssFeedsLinks.Columns.Add(new DataGridViewLinkColumn());
            DgwRssFeedsLinks.Columns.Add(new DataGridViewTextBoxColumn());
            this.DgwRssFeedsLinks.Columns[1].Visible = false;
            DataGridViewLinkColumn links = new DataGridViewLinkColumn();
            links.UseColumnTextForLinkValue = true;
            links.ActiveLinkColor = Color.White;
            links.LinkBehavior = LinkBehavior.SystemDefault;
            links.LinkColor = Color.Blue;
            links.TrackVisitedState = true;
            links.VisitedLinkColor = Color.YellowGreen;
        }
    }
}
