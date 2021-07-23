namespace LabAutomation1._0.ReportsContainers
{
    partial class AllTestContainer
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
            this.AllReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // AllReportViewer
            // 
            this.AllReportViewer.ActiveViewIndex = -1;
            this.AllReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AllReportViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.AllReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AllReportViewer.Location = new System.Drawing.Point(0, 0);
            this.AllReportViewer.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.AllReportViewer.Name = "AllReportViewer";
            this.AllReportViewer.ShowCloseButton = false;
            this.AllReportViewer.ShowCopyButton = false;
            this.AllReportViewer.ShowGotoPageButton = false;
            this.AllReportViewer.ShowGroupTreeButton = false;
            this.AllReportViewer.ShowLogo = false;
            this.AllReportViewer.ShowParameterPanelButton = false;
            this.AllReportViewer.ShowRefreshButton = false;
            this.AllReportViewer.ShowTextSearchButton = false;
            this.AllReportViewer.Size = new System.Drawing.Size(664, 430);
            this.AllReportViewer.TabIndex = 1;
            this.AllReportViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // AllTestContainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 430);
            this.Controls.Add(this.AllReportViewer);
            this.Name = "AllTestContainer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reort Viewer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.AllTestContainer_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer AllReportViewer;
    }
}