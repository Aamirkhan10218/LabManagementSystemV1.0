using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabAutomation1._0
{
    public partial class PictureSlides : UserControl
    {
        public PictureSlides()
        {
            InitializeComponent();
        }
        private int picNumber = 1;
        private void SlidePics()
        {
            if (picNumber==10)
            {
                picNumber = 1;
            }
            SlidePictureBox.ImageLocation = String.Format(@"Grafics\{0}.jpg", picNumber);
            picNumber++;

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            SlidePics();
        }
    }
}
