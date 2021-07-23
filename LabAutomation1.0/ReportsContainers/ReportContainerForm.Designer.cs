namespace LabAutomation1._0.ReportsContainers
{
    partial class ReportContainerForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.BloodTestViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // BloodTestViewer
            // 
            this.BloodTestViewer.ActiveViewIndex = -1;
            this.BloodTestViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BloodTestViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.BloodTestViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BloodTestViewer.Location = new System.Drawing.Point(0, 0);
            this.BloodTestViewer.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.BloodTestViewer.Name = "BloodTestViewer";
            this.BloodTestViewer.ShowCloseButton = false;
            this.BloodTestViewer.ShowCopyButton = false;
            this.BloodTestViewer.ShowGotoPageButton = false;
            this.BloodTestViewer.ShowGroupTreeButton = false;
            this.BloodTestViewer.ShowLogo = false;
            this.BloodTestViewer.ShowParameterPanelButton = false;
            this.BloodTestViewer.ShowRefreshButton = false;
            this.BloodTestViewer.ShowTextSearchButton = false;
            this.BloodTestViewer.Size = new System.Drawing.Size(1105, 595);
            this.BloodTestViewer.TabIndex = 0;
            this.BloodTestViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // ReportContainerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1105, 595);
            this.Controls.Add(this.BloodTestViewer);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MaximizeBox = false;
            this.Name = "ReportContainerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ReportContainerForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ReportContainerForm_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer BloodTestViewer;
    }
}