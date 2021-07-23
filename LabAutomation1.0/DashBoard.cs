using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabAutomation1._0
{
    public partial class DashBoard : Form
    {
        public DashBoard()
        {
            InitializeComponent();
            settingsControl11.Visible = false;
            bloodTestControl21.Visible = false;
            urineTestControl31.Visible = false;
            aboutUsControl41.Visible = false;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show(this,"Do you Want to take Backup?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                Manager m = new Manager();
                m.Show();
            }
           
            else
            {
                Application.Exit();
            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bunifuGradientPanel2.Height = btnSettings.Height;
            bunifuGradientPanel2.Top = btnSettings.Top;
            bunifuTransition2.HideSync(bloodTestControl21);
            bunifuTransition4.HideSync(aboutUsControl41);
            bunifuTransition3.HideSync(urineTestControl31);
            bunifuTransition1.ShowSync(settingsControl11);
            bunifuTransition5.HideSync(pictureSlides1);
        }

        private void btnBloodTest_Click(object sender, EventArgs e)
        {
            bunifuGradientPanel2.Height = btnBloodTest.Height;
            bunifuGradientPanel2.Top = btnBloodTest.Top;
            bunifuTransition1.HideSync(settingsControl11);
            bunifuTransition4.HideSync(aboutUsControl41);
            bunifuTransition3.HideSync(urineTestControl31);
            bunifuTransition5.HideSync(pictureSlides1);
            bunifuTransition2.ShowSync(bloodTestControl21);
        }

        private void btnUrinrTest_Click(object sender, EventArgs e)
        {
            bunifuGradientPanel2.Height = btnUrinrTest.Height;
            bunifuGradientPanel2.Top = btnUrinrTest.Top;
            bunifuTransition1.HideSync(settingsControl11);
            bunifuTransition4.HideSync(aboutUsControl41);
            bunifuTransition5.HideSync(pictureSlides1);
            bunifuTransition2.HideSync(bloodTestControl21);
            bunifuTransition3.ShowSync(urineTestControl31);
        }

        private void btnAboutUs_Click(object sender, EventArgs e)
        {
            bunifuGradientPanel2.Height = btnAboutUs.Height;
            bunifuGradientPanel2.Top = btnAboutUs.Top;
            bunifuTransition1.HideSync(settingsControl11);
            bunifuTransition2.HideSync(bloodTestControl21);
            bunifuTransition3.HideSync(urineTestControl31);
            bunifuTransition4.ShowSync(aboutUsControl41);
            bunifuTransition5.HideSync(pictureSlides1);
        }

     
        private void button1_Click_1(object sender, EventArgs e)
        {
             
            bunifuGradientPanel2.Height = btnhome.Height;
            bunifuGradientPanel2.Top = btnhome.Top;
            bunifuTransition1.HideSync(settingsControl11);
            bunifuTransition2.HideSync(bloodTestControl21);
            bunifuTransition3.HideSync(urineTestControl31);
            bunifuTransition4.HideSync(aboutUsControl41);
            bunifuTransition5.ShowSync(pictureSlides1);
        }

    }
}
