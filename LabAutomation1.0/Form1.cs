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
namespace LabAutomation1._0
{
    
    public partial class Form1 : Form
    {
        OleDbConnection con = new OleDbConnection();
       
        public Form1()
        {
            con.ConnectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + Application.StartupPath + "\\DBLab.accdb";
            InitializeComponent();
        }
        String a = "";
        void checking()
        {
            try
            {
                con.Open();
                String qry = "select re from Requirements";
                OleDbCommand cmd = new OleDbCommand(qry, con);
                OleDbDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    a = dr["re"].ToString();
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            bunifuCircleProgressbar1.Value = 0;
         checking();
        }
        String Directory = @"D:\BackUp(Lab Automation1.0)";
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                bunifuCircleProgressbar1.Value += 4;
               if (bunifuCircleProgressbar1.Value >= 100)
                {
                    timer1.Stop();
                    if (a == string.Empty)
                    {
                        bool exist = System.IO.Directory.Exists(Directory);
                        if (!exist)
                        {
                          System.IO.Directory.Exists(Directory);
                        }
                        DashBoard df = new DashBoard();
                        df.Show();
                        bunifuTransition1.HideSync(bunifuCircleProgressbar1);
                        this.Hide();
                    }
                    else
                    {

                        DashBoard df = new DashBoard();
                        df.Show();
                        bunifuTransition1.HideSync(bunifuCircleProgressbar1);
                        this.Hide();
                    }
                    
                   
                }
            }
            catch (Exception)
            {
                return;
            }
        }
    }
}
