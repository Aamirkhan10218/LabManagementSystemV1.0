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
namespace LabAutomation1._0.ReportsContainers
{
    public partial class ReportContainerForm : Form
    {
        OleDbConnection con = new OleDbConnection();
        String  id;
        public ReportContainerForm(String id)
        {
            con.ConnectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + Application.StartupPath + "\\DBLab.accdb";

            this.id = id;
           
            InitializeComponent();
        }
       
        void loadReportData()
        {
            try
            {
                con.Open();
                String qry = "select * from bloodTestRecord where recID=" + int.Parse(id);
                OleDbDataAdapter sda = new OleDbDataAdapter(qry, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                Reports.BloodTestReport btr = new Reports.BloodTestReport();
                btr.SetDataSource(dt);
                BloodTestViewer.ReportSource = btr;
                btr.SetParameterValue("Name", name);
                btr.SetParameterValue("Gender", gender);
                btr.SetParameterValue("PatientId", id);
                btr.SetParameterValue("ReportDate", date);
                btr.SetParameterValue("Age", age);
                con.Close();
             
            }
            catch(Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }
        String name = "";
        String date = "";
        String age = "";
        String gender = "";
    
        void getPateintRecord()
        {
            try
            {
                con.Open();
                String qry = "select * from BloodRecord where ID="+int.Parse(id);
                OleDbCommand cmd = new OleDbCommand(qry, con);
                OleDbDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    name = dr["PatientName"].ToString();
                    date = dr["testDate"].ToString();
                    gender = dr["PatientGender"].ToString();
                    age = dr["Ageggg"].ToString();
                }
                dr.Close();
                con.Close();
            }catch(Exception ex)
            {
                MessageBox.Show(""+ex);
            }
        }
        private void ReportContainerForm_Load(object sender, EventArgs e)
        {


              getPateintRecord();
            loadReportData();
        }

        private void ReportContainerForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
