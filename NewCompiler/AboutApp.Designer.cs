namespace NewCompiler
{
    partial class AboutApp
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
            this.mainTitleLabel = new System.Windows.Forms.Label();
            this.copyrightLabel = new System.Windows.Forms.Label();
            this.locationLabel = new System.Windows.Forms.Label();
            this.developersArea = new System.Windows.Forms.GroupBox();
            this.developerInfo = new System.Windows.Forms.Label();
            this.developerTitle = new System.Windows.Forms.Label();
            this.linkLabel = new System.Windows.Forms.LinkLabel();
            this.versionLabel = new System.Windows.Forms.Label();
            this.currentVersion = new System.Windows.Forms.Label();
            this.componentsArea = new System.Windows.Forms.GroupBox();
            this.componentsTable = new System.Windows.Forms.DataGridView();
            this.nameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.versionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.closeButton = new System.Windows.Forms.Button();
            this.developersArea.SuspendLayout();
            this.componentsArea.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.componentsTable)).BeginInit();
            this.SuspendLayout();
            // 
            // mainTitleLabel
            // 
            this.mainTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mainTitleLabel.Location = new System.Drawing.Point(12, 23);
            this.mainTitleLabel.Name = "mainTitleLabel";
            this.mainTitleLabel.Size = new System.Drawing.Size(262, 40);
            this.mainTitleLabel.TabIndex = 1;
            this.mainTitleLabel.Text = "Объявление целочисленной константы с инициализацией на Pascal";
            // 
            // copyrightLabel
            // 
            this.copyrightLabel.AutoSize = true;
            this.copyrightLabel.Location = new System.Drawing.Point(12, 85);
            this.copyrightLabel.Name = "copyrightLabel";
            this.copyrightLabel.Size = new System.Drawing.Size(157, 13);
            this.copyrightLabel.TabIndex = 2;
            this.copyrightLabel.Text = "Copyright (c) 2024 Kirilenko Kirill";
            // 
            // locationLabel
            // 
            this.locationLabel.AutoSize = true;
            this.locationLabel.Location = new System.Drawing.Point(12, 105);
            this.locationLabel.Name = "locationLabel";
            this.locationLabel.Size = new System.Drawing.Size(120, 13);
            this.locationLabel.TabIndex = 3;
            this.locationLabel.Text = "Россия, НГТУ, АВТФ ";
            // 
            // developersArea
            // 
            this.developersArea.Controls.Add(this.developerInfo);
            this.developersArea.Controls.Add(this.developerTitle);
            this.developersArea.Location = new System.Drawing.Point(294, 23);
            this.developersArea.Name = "developersArea";
            this.developersArea.Size = new System.Drawing.Size(181, 100);
            this.developersArea.TabIndex = 4;
            this.developersArea.TabStop = false;
            this.developersArea.Text = "Разработчики";
            // 
            // developerInfo
            // 
            this.developerInfo.Location = new System.Drawing.Point(17, 33);
            this.developerInfo.Name = "developerInfo";
            this.developerInfo.Size = new System.Drawing.Size(162, 24);
            this.developerInfo.TabIndex = 6;
            this.developerInfo.Text = "Кириленко Кирилл Андреевич";
            // 
            // developerTitle
            // 
            this.developerTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.developerTitle.Location = new System.Drawing.Point(12, 17);
            this.developerTitle.Name = "developerTitle";
            this.developerTitle.Size = new System.Drawing.Size(167, 23);
            this.developerTitle.TabIndex = 5;
            this.developerTitle.Text = "Ведущий разработчик:";
            // 
            // linkLabel
            // 
            this.linkLabel.AutoSize = true;
            this.linkLabel.Location = new System.Drawing.Point(12, 132);
            this.linkLabel.Name = "linkLabel";
            this.linkLabel.Size = new System.Drawing.Size(38, 13);
            this.linkLabel.TabIndex = 5;
            this.linkLabel.TabStop = true;
            this.linkLabel.Text = "Github";
            // 
            // versionLabel
            // 
            this.versionLabel.AutoSize = true;
            this.versionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.versionLabel.Location = new System.Drawing.Point(12, 56);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(50, 13);
            this.versionLabel.TabIndex = 6;
            this.versionLabel.Text = "Версия";
            // 
            // currentVersion
            // 
            this.currentVersion.AutoSize = true;
            this.currentVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.currentVersion.ForeColor = System.Drawing.Color.ForestGreen;
            this.currentVersion.Location = new System.Drawing.Point(68, 56);
            this.currentVersion.Name = "currentVersion";
            this.currentVersion.Size = new System.Drawing.Size(36, 13);
            this.currentVersion.TabIndex = 7;
            this.currentVersion.Text = "1.0.0";
            // 
            // componentsArea
            // 
            this.componentsArea.Controls.Add(this.componentsTable);
            this.componentsArea.Location = new System.Drawing.Point(12, 154);
            this.componentsArea.Name = "componentsArea";
            this.componentsArea.Size = new System.Drawing.Size(463, 102);
            this.componentsArea.TabIndex = 8;
            this.componentsArea.TabStop = false;
            this.componentsArea.Text = "Компоненты";
            // 
            // componentsTable
            // 
            this.componentsTable.AllowUserToAddRows = false;
            this.componentsTable.AllowUserToDeleteRows = false;
            this.componentsTable.AllowUserToResizeRows = false;
            this.componentsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.componentsTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameColumn,
            this.versionColumn,
            this.dateColumn});
            this.componentsTable.Location = new System.Drawing.Point(-40, 14);
            this.componentsTable.Name = "componentsTable";
            this.componentsTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.componentsTable.Size = new System.Drawing.Size(501, 101);
            this.componentsTable.TabIndex = 0;
            // 
            // nameColumn
            // 
            this.nameColumn.HeaderText = "Имя";
            this.nameColumn.Name = "nameColumn";
            this.nameColumn.Width = 150;
            // 
            // versionColumn
            // 
            this.versionColumn.HeaderText = "Версия";
            this.versionColumn.Name = "versionColumn";
            this.versionColumn.Width = 150;
            // 
            // dateColumn
            // 
            this.dateColumn.HeaderText = "Дата";
            this.dateColumn.Name = "dateColumn";
            this.dateColumn.Width = 158;
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(181, 277);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(112, 23);
            this.closeButton.TabIndex = 9;
            this.closeButton.Text = "OK";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // AboutApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 309);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.componentsArea);
            this.Controls.Add(this.currentVersion);
            this.Controls.Add(this.versionLabel);
            this.Controls.Add(this.linkLabel);
            this.Controls.Add(this.developersArea);
            this.Controls.Add(this.locationLabel);
            this.Controls.Add(this.copyrightLabel);
            this.Controls.Add(this.mainTitleLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutApp";
            this.Text = "О программе";
            this.Load += new System.EventHandler(this.AboutApp_Load);
            this.developersArea.ResumeLayout(false);
            this.componentsArea.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.componentsTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label mainTitleLabel;
        private System.Windows.Forms.Label copyrightLabel;
        private System.Windows.Forms.Label locationLabel;
        private System.Windows.Forms.GroupBox developersArea;
        private System.Windows.Forms.Label developerInfo;
        private System.Windows.Forms.Label developerTitle;
        private System.Windows.Forms.LinkLabel linkLabel;
        private System.Windows.Forms.Label versionLabel;
        private System.Windows.Forms.Label currentVersion;
        private System.Windows.Forms.GroupBox componentsArea;
        private System.Windows.Forms.DataGridView componentsTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn versionColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateColumn;
        private System.Windows.Forms.Button closeButton;
    }
}