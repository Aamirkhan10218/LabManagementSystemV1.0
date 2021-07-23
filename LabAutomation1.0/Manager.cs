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
using System.IO;

namespace LabAutomation1._0
{
    public partial class Manager : Form
    {
        OleDbConnection con = new OleDbConnection();
        public Manager()
        {
            con.ConnectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + Application.StartupPath + "\\DBLab.accdb";

            InitializeComponent();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
          
            try
            {
                con.Open();
                String qry = "insert into Requirements(re)values('" + bunifuMaterialTextbox1.Text + "')";
                OleDbCommand cmd = new OleDbCommand(qry, con);
                cmd.ExecuteNonQuery();
                label4.Hide();
                bunifuCircleProgressbar1.Show();
                timer1.Start();
                label3.Show();
                label2.Show();
                
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        String createdFoler = DateTime.Now.ToString("dd-MM-yyyy");
           String Directory = @"D:\BackUp(Lab Automation1.0)";
        String Source = @"C:\Program Files (x86)\IDL Soft\Lab Automation1.0\DBLab.accdb";

       String fileName = "DBLab.accdb";
        void creatFolder()
        {
            bool exist = System.IO.Directory.Exists(Directory + "\\" + createdFoler);
            if (!exist)
            {
                System.IO.Directory.CreateDirectory(Directory + "\\" + createdFoler);
                FileCopy();
                if (MessageBox.Show(this, "BackUp Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    Application.Exit();

                }

            }
            else
            {
                FileDelete();
                FileCopy();
                if (MessageBox.Show(this, "BackUp Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    Application.Exit();
                }


            }
        }

            void FileCopy()
               {
                String Destination = @"D:\BackUp(Lab Automation1.0)\" + createdFoler+ "/" + fileName;
                File.Copy(Source, Destination);
            }
        void FileDelete()
        {
            String Destination = @"D:\BackUp(Lab Automation1.0)\" + createdFoler + "/" + fileName;

            File.Delete(Destination);
        }
        private void Manager_Load(object sender, EventArgs e)
        {
            bunifuMaterialTextbox1.Text = DateTime.Now.ToString("dd/MM/yyyy-hh:mm");
            bunifuCircleProgressbar1.Hide();
           
            label1.Hide();
            label2.Hide();
            label3.Hide();
            bunifuCircleProgressbar1.Value = 0;
        }
        
              private void timer1_Tick_1(object sender, EventArgs e)
        {
            try
            {
                bunifuCircleProgressbar1.Value+= 5;

                if (bunifuCircleProgressbar1.Value >= 100)
                {
                    timer1.Stop();
                    creatFolder();
                    label2.Hide();
                    label3.Hide();

                }
            }
            catch (Exception)
            {
                return;
            }
        }
    }
}