namespace ImageSearchDownloader
{
    partial class Form1
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
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.folderSelectButton = new System.Windows.Forms.Button();
            this.buttonSelectSearchEngine = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxQueries = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonDownload = new System.Windows.Forms.Button();
            this.checkBoxDownloadPage = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.numericUpDownMaxResults = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxLog = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxResults)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(757, 29);
            this.panel1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.folderSelectButton);
            this.flowLayoutPanel1.Controls.Add(this.buttonSelectSearchEngine);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(757, 29);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // folderSelectButton
            // 
            this.folderSelectButton.AutoSize = true;
            this.folderSelectButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.folderSelectButton.Location = new System.Drawing.Point(3, 3);
            this.folderSelectButton.Name = "folderSelectButton";
            this.folderSelectButton.Size = new System.Drawing.Size(125, 23);
            this.folderSelectButton.TabIndex = 0;
            this.folderSelectButton.Text = "Set destination &folder...";
            this.folderSelectButton.UseVisualStyleBackColor = true;
            this.folderSelectButton.Click += new System.EventHandler(this.FolderSelectButton_Click);
            // 
            // buttonSelectSearchEngine
            // 
            this.buttonSelectSearchEngine.AutoSize = true;
            this.buttonSelectSearchEngine.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonSelectSearchEngine.Location = new System.Drawing.Point(134, 3);
            this.buttonSelectSearchEngine.Name = "buttonSelectSearchEngine";
            this.buttonSelectSearchEngine.Size = new System.Drawing.Size(112, 23);
            this.buttonSelectSearchEngine.TabIndex = 1;
            this.buttonSelectSearchEngine.Text = "Set search &engine...";
            this.buttonSelectSearchEngine.UseVisualStyleBackColor = true;
            this.buttonSelectSearchEngine.Click += new System.EventHandler(this.ButtonSelectSearchEngine_Click);
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 609);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(757, 0);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.splitContainer1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 29);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(757, 580);
            this.panel3.TabIndex = 2;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Controls.Add(this.flowLayoutPanel2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(757, 580);
            this.splitContainer1.SplitterDistance = 335;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxQueries);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(335, 496);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Queries (one per line):";
            // 
            // textBoxQueries
            // 
            this.textBoxQueries.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxQueries.Location = new System.Drawing.Point(3, 16);
            this.textBoxQueries.Multiline = true;
            this.textBoxQueries.Name = "textBoxQueries";
            this.textBoxQueries.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxQueries.Size = new System.Drawing.Size(329, 477);
            this.textBoxQueries.TabIndex = 0;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel2.Controls.Add(this.buttonClear);
            this.flowLayoutPanel2.Controls.Add(this.buttonDownload);
            this.flowLayoutPanel2.Controls.Add(this.checkBoxDownloadPage);
            this.flowLayoutPanel2.Controls.Add(this.tableLayoutPanel1);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 496);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(335, 84);
            this.flowLayoutPanel2.TabIndex = 0;
            // 
            // buttonClear
            // 
            this.buttonClear.AutoSize = true;
            this.buttonClear.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonClear.Location = new System.Drawing.Point(3, 3);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(56, 23);
            this.buttonClear.TabIndex = 0;
            this.buttonClear.Text = "&Clear list";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // buttonDownload
            // 
            this.buttonDownload.AutoSize = true;
            this.buttonDownload.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonDownload.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDownload.Location = new System.Drawing.Point(65, 3);
            this.buttonDownload.Name = "buttonDownload";
            this.buttonDownload.Size = new System.Drawing.Size(116, 23);
            this.buttonDownload.TabIndex = 1;
            this.buttonDownload.Text = "&Download images";
            this.buttonDownload.UseVisualStyleBackColor = true;
            this.buttonDownload.Click += new System.EventHandler(this.buttonDownload_Click);
            // 
            // checkBoxDownloadPage
            // 
            this.checkBoxDownloadPage.AutoSize = true;
            this.checkBoxDownloadPage.Location = new System.Drawing.Point(3, 32);
            this.checkBoxDownloadPage.Name = "checkBoxDownloadPage";
            this.checkBoxDownloadPage.Size = new System.Drawing.Size(179, 17);
            this.checkBoxDownloadPage.TabIndex = 3;
            this.checkBoxDownloadPage.Text = "also download source web page";
            this.checkBoxDownloadPage.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.numericUpDownMaxResults, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 55);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(232, 26);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // numericUpDownMaxResults
            // 
            this.numericUpDownMaxResults.AutoSize = true;
            this.numericUpDownMaxResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericUpDownMaxResults.Location = new System.Drawing.Point(119, 3);
            this.numericUpDownMaxResults.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownMaxResults.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownMaxResults.Name = "numericUpDownMaxResults";
            this.numericUpDownMaxResults.Size = new System.Drawing.Size(110, 20);
            this.numericUpDownMaxResults.TabIndex = 0;
            this.numericUpDownMaxResults.ThousandsSeparator = true;
            this.numericUpDownMaxResults.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "Max number of results";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.groupBox2);
            this.splitContainer2.Panel2Collapsed = true;
            this.splitContainer2.Size = new System.Drawing.Size(418, 580);
            this.splitContainer2.SplitterDistance = 295;
            this.splitContainer2.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBoxLog);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(418, 580);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Activity log";
            // 
            // textBoxLog
            // 
            this.textBoxLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxLog.Location = new System.Drawing.Point(3, 16);
            this.textBoxLog.Multiline = true;
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.ReadOnly = true;
            this.textBoxLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxLog.Size = new System.Drawing.Size(412, 561);
            this.textBoxLog.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(757, 609);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Image Downloader";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxResults)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button folderSelectButton;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxQueries;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonDownload;
        private System.Windows.Forms.Button buttonSelectSearchEngine;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBoxLog;
        private System.Windows.Forms.CheckBox checkBoxDownloadPage;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.NumericUpDown numericUpDownMaxResults;
        private System.Windows.Forms.Label label1;
    }
}

