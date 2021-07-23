using LabAutomation1._0.Reports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabAutomation1._0.ReportsContainers
{
    public partial class Tom : Form
    {
        public Tom()
        {
            InitializeComponent();
        }

        private void Tom_Load(object sender, EventArgs e)
        {
            TestAll ta = new TestAll();
            crystalReportViewer1.ReportSource = ta;
         crystalReportViewer1.Refresh();

        }

        private void Tom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
