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
    public partial class UrineTestControl3 : UserControl
    {
        OleDbConnection con = new OleDbConnection();
        public UrineTestControl3()
        {

            InitializeComponent();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
                 //  AllTestContainer atc = new AllTestContainer(txtFromDate.Text,txtToDate.Text);
    AllTestContainer atc = new AllTestContainer(fromDate.Text,toDate.Text);

            atc.Show();
        }

        private void UrineTestControl3_Load(object sender, EventArgs e)
        {
            toDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            fromDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void bunifuTileButton1_Click(object sender, EventArgs e)
        {
            Tom t = new Tom();
            t.Show();

        }
    }
}
