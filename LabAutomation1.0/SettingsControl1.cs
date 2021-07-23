using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
namespace LabAutomation1._0
{
    public partial class SettingsControl1 : UserControl
    {
        OleDbConnection con = new OleDbConnection();
        public SettingsControl1()
        {
            con.ConnectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + Application.StartupPath + "\\DBLab.accdb";

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Dead Event
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //Dead Event
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            //Dead Event
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            //Dead Event
        }

        private void txtDisplay_TextChanged(object sender, EventArgs e)
        {
            //Dead Event
        }
        void load()
        {
            con.Open();
            String qry = "select max(rcdId+1) from loginData";
            OleDbCommand cmd = new OleDbCommand(qry, con);
            object ob = cmd.ExecuteScalar();
            txtUserId.Text = ob.ToString();
            con.Close();
        }
        string a;
        void testLoadId()
        {
            con.Open();
            String qry = "Select max(testId+1) from testDetail";
            using (OleDbCommand cmd = new OleDbCommand(qry, con))
            {
                object ob = cmd.ExecuteScalar();
                a = ob.ToString();
                txtTestId.Text = ob.ToString();
            }
            con.Close();
        }
        private void SettingsControl1_Load(object sender, EventArgs e)
        {
           
            load();
            testLoadId();

        }
        void saveData()
        {
            String qry = "insert into loginData(userName,userPass)values(@Name,@PassWord)";
            OleDbCommand cmd = new OleDbCommand(qry, con);
            cmd.Parameters.AddWithValue("@Name", txtUserName.Text);
            cmd.Parameters.AddWithValue("@PassWord", txtPassWord.Text);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Saved Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            load();
            clear();
        }
        void clear()
        {
            txtUserName.Clear();
            txtPassWord.Clear();
        }
        void update()
        {
            String qrt = "update loginData set userName='"+txtUserName.Text+ "',userPass='"+txtPassWord.Text+"' ";
            using (OleDbCommand cmd = new OleDbCommand(qrt, con))
            {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Updated Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        private void btnUserSave_Click(object sender, EventArgs e)
        {
            saveData();
        }

        private void btnUserShow_Click(object sender, EventArgs e)
        {
            bunifuCustomDataGrid1.Show();
            con.Open();
            String qry = "select userName,userPass from loginData";
            OleDbDataAdapter sda = new OleDbDataAdapter(qry, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            bunifuCustomDataGrid1.DataSource = dt;
            con.Close();
        }
        
        void cleartest()
        {
            txtTestName.Clear();
            textBox1.Clear();
            txtRange.Clear();
            txtUnit.Clear();
            txtTestId.Clear();
            cmbCategory.Text = "";
            cmbSubCategory.Text = "";
        }
        void testSave()
        {
            String qry = "INSERT INTO testDetail(testName,normalRange,testUnit,testCategory,testSubCategory)VALUES(@Name,@Range,@Unit,@Category,@Sub)";
            using(OleDbCommand cmd=new OleDbCommand(qry, con))
            {
                cmd.Parameters.AddWithValue("@Name", txtTestName.Text);
                cmd.Parameters.AddWithValue("@Range", txtRange.Text);
                cmd.Parameters.AddWithValue("@Unit", txtUnit.Text);
                cmd.Parameters.AddWithValue("@Category", cmbCategory.Text);
                cmd.Parameters.AddWithValue("@Sub", cmbSubCategory.Text);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
              
                MessageBox.Show("Saved SuccessFully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cleartest();
                testLoadId();
                txtTestName.Focus();
            }
        }
        void updateData()
        {
            try
            {
                String qry = "update testDetail set testName=@Name,normalRange=@Range,testUnit=@Unit,testCategory=@Category,testSubCategory=@Sub where testId=" + int.Parse(txtTestId.Text);
                using(OleDbCommand cmd=new OleDbCommand(qry, con))
                {
                    cmd.Parameters.AddWithValue("@Name", txtTestName.Text);
                    cmd.Parameters.AddWithValue("@Range", txtRange.Text);
                    cmd.Parameters.AddWithValue("@Unit", txtUnit.Text);
                    cmd.Parameters.AddWithValue("@Category", cmbCategory.Text);
                    cmd.Parameters.AddWithValue("@Sub", cmbSubCategory.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Updated Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cleartest();
                    testLoadId();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnTestSave_Click(object sender, EventArgs e)
        {
            if (btnTestSave.Text == "Save")
            {
                testSave();
            }
            else
            {
                updateData();
            }
        }
        private void btnTestShow_Click(object sender, EventArgs e)
        {
            bunifuCustomDataGrid2.Show();
            con.Open();
            String qry = "select testName as TestName,normalRange as Range,testUnit as Unit,testCategory as Category  from testDetail";
            using(OleDbDataAdapter sda=new OleDbDataAdapter(qry, con))
            {
                DataTable dt = new DataTable();
                sda.Fill(dt);
                bunifuCustomDataGrid2.DataSource = dt;
            }
            con.Close();
        }
        private void SettingsControl1_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void panel3_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //Dead Event
        }
        private void bunifuCustomDataGrid1_KeyDown(object sender, KeyEventArgs e)
        {
            //Dead Event
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            //Dead Event
        }
        private void btnTestDelete_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Do you Want to Delete?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {

                    String qry = "delete * from testDetail where testId=" + int.Parse(txtTestId.Text);
                    using (OleDbCommand cmd = new OleDbCommand(qry, con))
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Deleted Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        con.Close();
                        cleartest();
                        testLoadId();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                cleartest();
            }
       }
       private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            if (txtTestId.Text != a)
            {
                btnTestSave.Text = "Save";
            }
            else
            {
                btnTestSave.Text = "Update";
            }
            if (textBox1.Text == string.Empty)
            {
                cleartest();
                txtTestId.Clear();
                testLoadId();
            }
            try
            {
                con.Open();
                String qry = "select * from testDetail where testName='"+ textBox1.Text+ "'";
                using(OleDbCommand cmd=new OleDbCommand(qry, con))
                {
                    OleDbDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        txtTestId.Text = dr["testId"].ToString();
                        txtTestName.Text = dr["testName"].ToString();
                        txtRange.Text = dr["normalRange"].ToString();
                        txtUnit.Text = dr["testUnit"].ToString();
                        cmbCategory.Text = dr["testCategory"].ToString();
                        cmbSubCategory.Text = dr["testSubCategory"].ToString();
                        
                    }
                    dr.Close();
                }
                con.Close();
             // dr.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            bunifuCustomDataGrid1.Hide();
            bunifuCustomDataGrid2.Hide();
        }
    }
}
