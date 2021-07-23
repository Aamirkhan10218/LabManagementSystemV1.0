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
using LabAutomation1._0.ReportsContainers;

namespace LabAutomation1._0
{
    public partial class BloodTestControl2 : UserControl
    {
        OleDbDataAdapter sda;
        DataSet ds;
        OleDbCommandBuilder cmb;
        OleDbConnection con = new OleDbConnection();
        public BloodTestControl2()
        {
            con.ConnectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + Application.StartupPath + "\\DBLab.accdb";
            InitializeComponent();
        }
        DataTable dt = new DataTable();
        private void BloodTestControl2_Load(object sender, EventArgs e)
        {
            this.Refresh();
            txtGender.Focus();
            rptIdLoad();
            txtYear.Text = DateTime.Now.ToString("yyyy");
            txtDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            alltestLaod();
           
        }
        private void alltestLaod()
        {
            try
            {
                con.Open();
                String qry = "select * from testDetail";// where testCategory='Blood Test'";
                 sda = new OleDbDataAdapter(qry, con);

                sda.Fill(dt);

                bunifuCustomDataGrid2.DataSource = dt;
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
       String a;
        void rptIdLoad()
        {
            try
            {
                con.Open();
                String qry = "select max(ID+1) from BloodRecord";
                OleDbCommand cmd = new OleDbCommand(qry, con);
                object ob = cmd.ExecuteScalar();
                a = ob.ToString();
                txRptId.Text = ob.ToString();
                con.Close();
            }
           catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void saveReportData()
        {
            String qry = "INSERT INTO BloodRecord(RegNo,testDate,PatientGender,PatientName,Ageggg)VALUES(@Reg,@Date,@Gender,@Name,@Father)";
            OleDbCommand cmd = new OleDbCommand(qry, con);
            cmd.Parameters.AddWithValue("@Reg", txtYear.Text);
            cmd.Parameters.AddWithValue("@Date", txtDate.Text);
            cmd.Parameters.AddWithValue("@Gender", txtGender.Text);
            cmd.Parameters.AddWithValue("@Name", txtPatientName.Text);
            cmd.Parameters.AddWithValue("@Father", txtFather.Text);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            
        }
           private void bunifuCustomDataGrid2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtTestName.Text = bunifuCustomDataGrid2.CurrentRow.Cells["testName"].Value.ToString();
                txtRange.Text = bunifuCustomDataGrid2.CurrentRow.Cells["normalRange"].Value.ToString();
                txtCategory.Text = bunifuCustomDataGrid2.CurrentRow.Cells["testSubCategory"].Value.ToString();
                txtUnit.Text = bunifuCustomDataGrid2.CurrentRow.Cells["testUnit"].Value.ToString();
                txtCategory1.Text = bunifuCustomDataGrid2.CurrentRow.Cells["testCategory"].Value.ToString();
                txtId.Text = bunifuCustomDataGrid2.CurrentRow.Cells["testId"].Value.ToString();
                txtValue.Focus();
                bunifuCustomDataGrid2.Hide();
          
            }
        }
        

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
               
                txtId.Focus();

                bunifuCustomDataGrid2.Show();

            }
        }

        private void textBox10_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                 btnNew.Focus();
               
            }
        }
        void save()  
        {
            try
            {
                for (int i = 0; i < bunifuCustomDataGrid1.Rows.Count; i++)
                {

                    String qry = "insert into bloodTestRecord(testName,testRange,testUnit,TestCategory,testValue,TestSubCategory,recID)values(@Name,@Range,@Unit,@Value,@Category,@id,@subcat)";
                    OleDbCommand cmd = new OleDbCommand(qry, con);
                    cmd.Parameters.AddWithValue("@Name", bunifuCustomDataGrid1.Rows[i].Cells[0].Value.ToString());
                    cmd.Parameters.AddWithValue("@Range", bunifuCustomDataGrid1.Rows[i].Cells[1].Value.ToString());
                    cmd.Parameters.AddWithValue("@Unit", bunifuCustomDataGrid1.Rows[i].Cells[2].Value.ToString());
                    cmd.Parameters.AddWithValue("@Category", bunifuCustomDataGrid1.Rows[i].Cells[3].Value.ToString());
                    cmd.Parameters.AddWithValue("@subcat", bunifuCustomDataGrid1.Rows[i].Cells[5].Value.ToString());
                    cmd.Parameters.AddWithValue("@Value", bunifuCustomDataGrid1.Rows[i].Cells[4].Value.ToString());

                    cmd.Parameters.AddWithValue("@id", txRptId.Text);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    bunifuCustomDataGrid2.Hide();
                    if (i >= bunifuCustomDataGrid1.Rows.Count - 1)
                    {
                        bunifuCustomDataGrid1.Rows.Clear();
                        break;
                    }
                }
               MessageBox.Show("Saved Successfully","Message",MessageBoxButtons.OK,MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
     
        void clear2()
        {
            txtId.Clear();
            txtTestName.Clear();
            txtRange.Clear();
            txtUnit.Clear();
            txtValue.Clear();
            txtCategory.Clear();
            txtCategory1.Clear();
        }
        void clear()
        {
           
            txtGender.Text = "";
            txtPatientName.Clear();
            txtFather.Clear();

        }
    
        private void txtId_TextChanged(object sender, EventArgs e)
        {
            //if (txtId.Text.Length == 10)
            //{
                try
                {
                    DataView dv = dt.DefaultView;
                    dv.RowFilter = "testName like'%" + txtId.Text + "%'";
                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            //}
            
        }

        private void txtId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                
                bunifuCustomDataGrid2.Focus();
            }
        }

        private void BloodTestControl2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                bunifuCustomDataGrid2.Hide();
            }
        }
       
        void delete1()
        {
           
                try
                {
                    String qry = "delete * from BloodRecord where ID=" + txRptId.Text;
                    using (OleDbCommand cmd = new OleDbCommand(qry, con))
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                    
                        con.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            
           
        }
        void delete2()
        {
            if(MessageBox.Show("Do you really want to delete?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                try
                {
                    String qry = "delete * from bloodTestRecord where recID=" + txRptId.Text;
                    using (OleDbCommand cmd = new OleDbCommand(qry, con))
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Deleted Successfully.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        gridview3.SendToBack();
                        con.Close();
                        delete1();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Nothing Done ");
            }
           
        }
        private void txRptId_TextChanged(object sender, EventArgs e)
        {
            if (txRptId.Text == a)
            {
                btnSave.Text = "Save";
            }
            else
            {
                btnSave.Text = "Update";
            }
        }
       void showdataintGridView1()
        {
            gridview3.BringToFront();
            try
            {
                con.Open();
                String qry = "select * from bloodTestRecord where recID=" + int.Parse(txRptId.Text);
                sda = new OleDbDataAdapter(qry, con);
                 ds = new DataSet();
                    sda.Fill(ds,"Aamir");
                   gridview3.DataSource = ds.Tables[0];
          
                con.Close();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void loadName()
        {
            try
            {
                con.Open();
                String qry = "select * from BloodRecord where ID="+int.Parse(txRptId.Text);
                OleDbCommand cmd = new OleDbCommand(qry, con);
                OleDbDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    txtPatientName.Text = dr["PatientName"].ToString();
                    txtFather.Text = dr["Ageggg"].ToString();
                    txtGender.Text=dr["PatientGender"].ToString();
                    txtDate.Text = dr["testDate"].ToString();
                    txtYear.Text = dr["RegNo"].ToString();
                }
                dr.Close();
                con.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error in Loading Patient Information."+ex.Message.ToString());
            }
        }
        private void txRptId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loadName();
                showdataintGridView1();
            }
        }

       private void txtPatientName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtFather.Focus();
            }
        }

        private void txtGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtPatientName.Focus();
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            bunifuCustomDataGrid1.Rows.Add(txtTestName.Text, txtRange.Text, txtUnit.Text, txtCategory.Text,txtCategory1.Text, txtValue.Text);
            bunifuCustomDataGrid2.Show();
            txtId.Focus();
            clear2();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (btnSave.Text == "Save")
            {
                bunifuCustomDataGrid1.Rows.Add(txtTestName.Text, txtRange.Text, txtUnit.Text, txtCategory.Text, txtCategory1.Text, txtValue.Text);

                saveReportData();
                save();
                clear();
                clear2();
                rptIdLoad();
            }
            else
            {
                try
                {
                cmb = new OleDbCommandBuilder(sda);
                sda.Update(ds, "Aamir");
                MessageBox.Show("Saved Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clear();
                    gridview3.SendToBack();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            delete2();//contains the definition of delete1 methode
            clear();
        }

        private void btnPreviewReport_Click(object sender, EventArgs e)
        {
            ReportContainerForm rcf = new ReportContainerForm(txRptId.Text);
            rcf.Show();
            gridview3.Hide();
            clear();
            rptIdLoad(); 
        }

        private void gridview3_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(MessageBox.Show(this,"Do You want to delete this Test", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                int rowIndex = gridview3.CurrentCell.RowIndex;
                gridview3.Rows.RemoveAt(rowIndex);
            }
           
        }

    }

}
