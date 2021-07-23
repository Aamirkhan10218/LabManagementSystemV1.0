using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using LabAutomation1._0.Reports;

namespace LabAutomation1._0.ReportsContainers
{
    public partial class AllTestContainer : Form
    {
        OleDbConnection con = new OleDbConnection();
        String FromD="", ToD="";
        public AllTestContainer(String FromD,String ToD)
        {
            con.ConnectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + Application.StartupPath + "\\DBLab.accdb";

            this.FromD = FromD;
            this.ToD = ToD;
            InitializeComponent();
        }
        private void loadData()
        {
            try
            {
                con.Open();
                String qry = "select * from BloodRecord  where testDate between '" + FromD+ "' and '"+ToD+"' ";
                OleDbDataAdapter sda = new OleDbDataAdapter(qry, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                AllReports ar = new AllReports();
                ar.SetDataSource(dt);
                AllReportViewer.ReportSource = ar;
                ar.SetParameterValue("FromDate", FromD);
                ar.SetParameterValue("ToDate", ToD);
                con.Close();
            }catch(Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AllTestContainer_Load(object sender, EventArgs e)
        {
          loadData();
          // MessageBox.Show(FromD, ToD);
        }
    }
}
