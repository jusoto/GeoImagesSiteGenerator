namespace GeoPhotoSiteGenerator
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.fbdImages = new System.Windows.Forms.FolderBrowserDialog();
            this.txtInputFolder = new System.Windows.Forms.TextBox();
            this.btnImageFolder = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.txtSiteUrl = new System.Windows.Forms.TextBox();
            this.txtPageFileName = new System.Windows.Forms.TextBox();
            this.txtKmlFileName = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.pgbFiles = new System.Windows.Forms.ProgressBar();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtApiKey = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtInitialCoordinates = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Site URL";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Page file name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 172);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Kml file name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 207);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Image Folder";
            // 
            // txtInputFolder
            // 
            this.txtInputFolder.Location = new System.Drawing.Point(116, 207);
            this.txtInputFolder.Name = "txtInputFolder";
            this.txtInputFolder.Size = new System.Drawing.Size(240, 20);
            this.txtInputFolder.TabIndex = 7;
            // 
            // btnImageFolder
            // 
            this.btnImageFolder.Location = new System.Drawing.Point(362, 205);
            this.btnImageFolder.Name = "btnImageFolder";
            this.btnImageFolder.Size = new System.Drawing.Size(38, 23);
            this.btnImageFolder.TabIndex = 8;
            this.btnImageFolder.Text = "...";
            this.btnImageFolder.UseVisualStyleBackColor = true;
            this.btnImageFolder.Click += new System.EventHandler(this.btnImageFolder_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(140, 258);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(141, 35);
            this.btnCreate.TabIndex = 9;
            this.btnCreate.Text = "Create Site";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // txtSiteUrl
            // 
            this.txtSiteUrl.Location = new System.Drawing.Point(116, 45);
            this.txtSiteUrl.Name = "txtSiteUrl";
            this.txtSiteUrl.Size = new System.Drawing.Size(284, 20);
            this.txtSiteUrl.TabIndex = 10;
            // 
            // txtPageFileName
            // 
            this.txtPageFileName.Location = new System.Drawing.Point(116, 136);
            this.txtPageFileName.Name = "txtPageFileName";
            this.txtPageFileName.Size = new System.Drawing.Size(165, 20);
            this.txtPageFileName.TabIndex = 11;
            // 
            // txtKmlFileName
            // 
            this.txtKmlFileName.Location = new System.Drawing.Point(116, 169);
            this.txtKmlFileName.Name = "txtKmlFileName";
            this.txtKmlFileName.Size = new System.Drawing.Size(165, 20);
            this.txtKmlFileName.TabIndex = 12;
            // 
            // pgbFiles
            // 
            this.pgbFiles.Location = new System.Drawing.Point(24, 308);
            this.pgbFiles.Name = "pgbFiles";
            this.pgbFiles.Size = new System.Drawing.Size(376, 21);
            this.pgbFiles.TabIndex = 13;
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(116, 12);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(165, 20);
            this.txtTitle.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Title";
            // 
            // txtApiKey
            // 
            this.txtApiKey.Location = new System.Drawing.Point(116, 74);
            this.txtApiKey.Name = "txtApiKey";
            this.txtApiKey.Size = new System.Drawing.Size(284, 20);
            this.txtApiKey.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Google API Key";
            // 
            // txtInitialCoordinates
            // 
            this.txtInitialCoordinates.Location = new System.Drawing.Point(116, 103);
            this.txtInitialCoordinates.Name = "txtInitialCoordinates";
            this.txtInitialCoordinates.Size = new System.Drawing.Size(165, 20);
            this.txtInitialCoordinates.TabIndex = 19;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 103);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Initial Coordinates";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 348);
            this.Controls.Add(this.txtInitialCoordinates);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtApiKey);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pgbFiles);
            this.Controls.Add(this.txtKmlFileName);
            this.Controls.Add(this.txtPageFileName);
            this.Controls.Add(this.txtSiteUrl);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.btnImageFolder);
            this.Controls.Add(this.txtInputFolder);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.FolderBrowserDialog fbdImages;
        private System.Windows.Forms.TextBox txtInputFolder;
        private System.Windows.Forms.Button btnImageFolder;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.TextBox txtSiteUrl;
        private System.Windows.Forms.TextBox txtPageFileName;
        private System.Windows.Forms.TextBox txtKmlFileName;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ProgressBar pgbFiles;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtApiKey;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtInitialCoordinates;
        private System.Windows.Forms.Label label7;
    }
}

