namespace LabAutomation1._0
{
    partial class PictureSlides
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.SlidePictureBox = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.SlidePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // SlidePictureBox
            // 
            this.SlidePictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SlidePictureBox.Location = new System.Drawing.Point(0, 0);
            this.SlidePictureBox.Name = "SlidePictureBox";
            this.SlidePictureBox.Size = new System.Drawing.Size(723, 424);
            this.SlidePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.SlidePictureBox.TabIndex = 0;
            this.SlidePictureBox.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // PictureSlides
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.SlidePictureBox);
            this.Name = "PictureSlides";
            this.Size = new System.Drawing.Size(723, 424);
            ((System.ComponentModel.ISupportInitialize)(this.SlidePictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox SlidePictureBox;
        private System.Windows.Forms.Timer timer1;
    }
}
