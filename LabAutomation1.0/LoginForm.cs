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
    public partial class LoginForm : Form
    {
        OleDbConnection con = new OleDbConnection();
        public LoginForm()
        {
            con.ConnectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + Application.StartupPath + "\\DBLab.accdb";
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            txtId.Focus();
        }
        void passCheck()
        {
            try
            {
                con.Open();
                String qry = "select userName,userPass,rcdId from loginData where userName='" +txtUser.Text+ "' and userPass='" + txtPassWord.Text + "'";
                OleDbCommand cmd = new OleDbCommand(qry, con);
                OleDbDataReader dr = cmd.ExecuteReader();
                int count = 0;
                while (dr.Read())
                {
                    txtUser.Text = dr["userName"].ToString();
                    count++;
                }
                if (count == 1)
                {
                    DashBoard db = new DashBoard();
                    db.Show();
                    
                    this.Hide();
                }
                else
                {
                    MessageBox.Show(this, "Mismatch Password od Id", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPassWord.Text = "";
                    txtUser.Text = "";
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void nameLoad()
        {
            try
            {
                con.Open();
                String qry = "select userName from loginData Where rcdId="+int.Parse(txtId.Text);
                OleDbCommand cmd = new OleDbCommand(qry, con);
                OleDbDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    txtUser.Text = dr["userName"].ToString();
                }
                con.Close();
                dr.Close();
            }
            catch (Exception ex)
            {
                      MessageBox.Show(ex.Message);
            }
        }
        private void bunifuMaterialTextbox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                nameLoad();
                txtPassWord.Focus();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            passCheck();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
