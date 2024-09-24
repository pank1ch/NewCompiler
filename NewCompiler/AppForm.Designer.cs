namespace NewCompiler
{
    partial class AppForm
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
            this.userInputBox = new System.Windows.Forms.RichTextBox();
            this.linesLabel = new System.Windows.Forms.Label();
            this.AppPanel = new System.Windows.Forms.Panel();
            this.userOutputBox = new System.Windows.Forms.RichTextBox();
            this.appMenu = new System.Windows.Forms.MenuStrip();
            this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.createFileSubmenu = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileSubmenu = new System.Windows.Forms.ToolStripMenuItem();
            this.saveSubmenu = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsSubmenu = new System.Windows.Forms.ToolStripMenuItem();
            this.exitSubmenu = new System.Windows.Forms.ToolStripMenuItem();
            this.editMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelSubmenu = new System.Windows.Forms.ToolStripMenuItem();
            this.repeatSubmenu = new System.Windows.Forms.ToolStripMenuItem();
            this.cutSubmenu = new System.Windows.Forms.ToolStripMenuItem();
            this.copySubmenu = new System.Windows.Forms.ToolStripMenuItem();
            this.insertSubmenu = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteSubmenu = new System.Windows.Forms.ToolStripMenuItem();
            this.selectAllSubmenu = new System.Windows.Forms.ToolStripMenuItem();
            this.textMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.taskSubmenu = new System.Windows.Forms.ToolStripMenuItem();
            this.grammarSubmenu = new System.Windows.Forms.ToolStripMenuItem();
            this.grammarСlassificationSubmenu = new System.Windows.Forms.ToolStripMenuItem();
            this.analysisMethodSubmenu = new System.Windows.Forms.ToolStripMenuItem();
            this.diagnosticSubmenu = new System.Windows.Forms.ToolStripMenuItem();
            this.testExampleSubmenu = new System.Windows.Forms.ToolStripMenuItem();
            this.literatureSubmenu = new System.Windows.Forms.ToolStripMenuItem();
            this.startMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.callHelpSubmenu = new System.Windows.Forms.ToolStripMenuItem();
            this.programInfoSubmenu = new System.Windows.Forms.ToolStripMenuItem();
            this.appStatusMenu = new System.Windows.Forms.StatusStrip();
            this.capsStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.languageStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.AppTable = new System.Windows.Forms.DataGridView();
            this.messageColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.positionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lineColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.languageButton = new System.Windows.Forms.Button();
            this.informationButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.insertTextButton = new System.Windows.Forms.Button();
            this.cutTextButton = new System.Windows.Forms.Button();
            this.copyTextButton = new System.Windows.Forms.Button();
            this.returnChangesButton = new System.Windows.Forms.Button();
            this.cancelChangesButton = new System.Windows.Forms.Button();
            this.saveFileButton = new System.Windows.Forms.Button();
            this.openFileButton = new System.Windows.Forms.Button();
            this.createFileButton = new System.Windows.Forms.Button();
            this.AppPanel.SuspendLayout();
            this.appMenu.SuspendLayout();
            this.appStatusMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AppTable)).BeginInit();
            this.SuspendLayout();
            // 
            // userInputBox
            // 
            this.userInputBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.userInputBox.Location = new System.Drawing.Point(22, 15);
            this.userInputBox.Name = "userInputBox";
            this.userInputBox.Size = new System.Drawing.Size(781, 240);
            this.userInputBox.TabIndex = 16;
            this.userInputBox.Text = "";
            // 
            // linesLabel
            // 
            this.linesLabel.AutoSize = true;
            this.linesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.linesLabel.Location = new System.Drawing.Point(3, 19);
            this.linesLabel.Name = "linesLabel";
            this.linesLabel.Size = new System.Drawing.Size(14, 16);
            this.linesLabel.TabIndex = 18;
            this.linesLabel.Text = "1";
            // 
            // AppPanel
            // 
            this.AppPanel.AutoScroll = true;
            this.AppPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AppPanel.Controls.Add(this.userInputBox);
            this.AppPanel.Controls.Add(this.linesLabel);
            this.AppPanel.Location = new System.Drawing.Point(12, 94);
            this.AppPanel.Name = "AppPanel";
            this.AppPanel.Size = new System.Drawing.Size(825, 296);
            this.AppPanel.TabIndex = 20;
            // 
            // userOutputBox
            // 
            this.userOutputBox.Location = new System.Drawing.Point(674, 746);
            this.userOutputBox.Name = "userOutputBox";
            this.userOutputBox.ReadOnly = true;
            this.userOutputBox.Size = new System.Drawing.Size(142, 11);
            this.userOutputBox.TabIndex = 21;
            this.userOutputBox.Text = "";
            this.userOutputBox.Visible = false;
            // 
            // appMenu
            // 
            this.appMenu.BackColor = System.Drawing.SystemColors.Window;
            this.appMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu,
            this.editMenu,
            this.textMenu,
            this.startMenu,
            this.helpMenu});
            this.appMenu.Location = new System.Drawing.Point(0, 0);
            this.appMenu.Name = "appMenu";
            this.appMenu.Size = new System.Drawing.Size(849, 24);
            this.appMenu.TabIndex = 23;
            this.appMenu.Text = "menuStrip1";
            // 
            // fileMenu
            // 
            this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createFileSubmenu,
            this.openFileSubmenu,
            this.saveSubmenu,
            this.saveAsSubmenu,
            this.exitSubmenu});
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Size = new System.Drawing.Size(48, 20);
            this.fileMenu.Text = "Файл";
            // 
            // createFileSubmenu
            // 
            this.createFileSubmenu.Name = "createFileSubmenu";
            this.createFileSubmenu.Size = new System.Drawing.Size(154, 22);
            this.createFileSubmenu.Text = "Создать";
            // 
            // openFileSubmenu
            // 
            this.openFileSubmenu.Name = "openFileSubmenu";
            this.openFileSubmenu.Size = new System.Drawing.Size(154, 22);
            this.openFileSubmenu.Text = "Открыть";
            // 
            // saveSubmenu
            // 
            this.saveSubmenu.Name = "saveSubmenu";
            this.saveSubmenu.Size = new System.Drawing.Size(154, 22);
            this.saveSubmenu.Text = "Сохранить";
            // 
            // saveAsSubmenu
            // 
            this.saveAsSubmenu.Name = "saveAsSubmenu";
            this.saveAsSubmenu.Size = new System.Drawing.Size(154, 22);
            this.saveAsSubmenu.Text = "Сохранить как";
            // 
            // exitSubmenu
            // 
            this.exitSubmenu.Name = "exitSubmenu";
            this.exitSubmenu.Size = new System.Drawing.Size(154, 22);
            this.exitSubmenu.Text = "Выход";
            // 
            // editMenu
            // 
            this.editMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cancelSubmenu,
            this.repeatSubmenu,
            this.cutSubmenu,
            this.copySubmenu,
            this.insertSubmenu,
            this.deleteSubmenu,
            this.selectAllSubmenu});
            this.editMenu.Name = "editMenu";
            this.editMenu.Size = new System.Drawing.Size(59, 20);
            this.editMenu.Text = "Правка";
            // 
            // cancelSubmenu
            // 
            this.cancelSubmenu.Name = "cancelSubmenu";
            this.cancelSubmenu.Size = new System.Drawing.Size(148, 22);
            this.cancelSubmenu.Text = "Отменить";
            // 
            // repeatSubmenu
            // 
            this.repeatSubmenu.Name = "repeatSubmenu";
            this.repeatSubmenu.Size = new System.Drawing.Size(148, 22);
            this.repeatSubmenu.Text = "Повторить";
            // 
            // cutSubmenu
            // 
            this.cutSubmenu.Name = "cutSubmenu";
            this.cutSubmenu.Size = new System.Drawing.Size(148, 22);
            this.cutSubmenu.Text = "Вырезать";
            // 
            // copySubmenu
            // 
            this.copySubmenu.Name = "copySubmenu";
            this.copySubmenu.Size = new System.Drawing.Size(148, 22);
            this.copySubmenu.Text = "Копировать";
            // 
            // insertSubmenu
            // 
            this.insertSubmenu.Name = "insertSubmenu";
            this.insertSubmenu.Size = new System.Drawing.Size(148, 22);
            this.insertSubmenu.Text = "Вставить";
            // 
            // deleteSubmenu
            // 
            this.deleteSubmenu.Name = "deleteSubmenu";
            this.deleteSubmenu.Size = new System.Drawing.Size(148, 22);
            this.deleteSubmenu.Text = "Удалить";
            // 
            // selectAllSubmenu
            // 
            this.selectAllSubmenu.Name = "selectAllSubmenu";
            this.selectAllSubmenu.Size = new System.Drawing.Size(148, 22);
            this.selectAllSubmenu.Text = "Выделить все";
            // 
            // textMenu
            // 
            this.textMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.taskSubmenu,
            this.grammarSubmenu,
            this.grammarСlassificationSubmenu,
            this.analysisMethodSubmenu,
            this.diagnosticSubmenu,
            this.testExampleSubmenu,
            this.literatureSubmenu});
            this.textMenu.Name = "textMenu";
            this.textMenu.Size = new System.Drawing.Size(48, 20);
            this.textMenu.Text = "Текст";
            // 
            // taskSubmenu
            // 
            this.taskSubmenu.Name = "taskSubmenu";
            this.taskSubmenu.Size = new System.Drawing.Size(288, 22);
            this.taskSubmenu.Text = "Постановка задачи";
            // 
            // grammarSubmenu
            // 
            this.grammarSubmenu.Name = "grammarSubmenu";
            this.grammarSubmenu.Size = new System.Drawing.Size(288, 22);
            this.grammarSubmenu.Text = "Грамматика";
            // 
            // grammarСlassificationSubmenu
            // 
            this.grammarСlassificationSubmenu.Name = "grammarСlassificationSubmenu";
            this.grammarСlassificationSubmenu.Size = new System.Drawing.Size(288, 22);
            this.grammarСlassificationSubmenu.Text = "Классификация грамматики";
            // 
            // analysisMethodSubmenu
            // 
            this.analysisMethodSubmenu.Name = "analysisMethodSubmenu";
            this.analysisMethodSubmenu.Size = new System.Drawing.Size(288, 22);
            this.analysisMethodSubmenu.Text = "Метод анализа";
            // 
            // diagnosticSubmenu
            // 
            this.diagnosticSubmenu.Name = "diagnosticSubmenu";
            this.diagnosticSubmenu.Size = new System.Drawing.Size(288, 22);
            this.diagnosticSubmenu.Text = "Диагностика и нейтрализация ошибок";
            // 
            // testExampleSubmenu
            // 
            this.testExampleSubmenu.Name = "testExampleSubmenu";
            this.testExampleSubmenu.Size = new System.Drawing.Size(288, 22);
            this.testExampleSubmenu.Text = "Тестовый пример";
            // 
            // literatureSubmenu
            // 
            this.literatureSubmenu.Name = "literatureSubmenu";
            this.literatureSubmenu.Size = new System.Drawing.Size(288, 22);
            this.literatureSubmenu.Text = "Список литературы";
            // 
            // startMenu
            // 
            this.startMenu.Name = "startMenu";
            this.startMenu.Size = new System.Drawing.Size(46, 20);
            this.startMenu.Text = "Пуск";
            // 
            // helpMenu
            // 
            this.helpMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.callHelpSubmenu,
            this.programInfoSubmenu});
            this.helpMenu.Name = "helpMenu";
            this.helpMenu.Size = new System.Drawing.Size(65, 20);
            this.helpMenu.Text = "Справка";
            // 
            // callHelpSubmenu
            // 
            this.callHelpSubmenu.Name = "callHelpSubmenu";
            this.callHelpSubmenu.Size = new System.Drawing.Size(156, 22);
            this.callHelpSubmenu.Text = "Вызов справки";
            // 
            // programInfoSubmenu
            // 
            this.programInfoSubmenu.Name = "programInfoSubmenu";
            this.programInfoSubmenu.Size = new System.Drawing.Size(156, 22);
            this.programInfoSubmenu.Text = "О программе";
            // 
            // appStatusMenu
            // 
            this.appStatusMenu.BackColor = System.Drawing.SystemColors.Window;
            this.appStatusMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.capsStatusLabel,
            this.languageStatusLabel});
            this.appStatusMenu.Location = new System.Drawing.Point(0, 747);
            this.appStatusMenu.Name = "appStatusMenu";
            this.appStatusMenu.Size = new System.Drawing.Size(849, 22);
            this.appStatusMenu.TabIndex = 25;
            this.appStatusMenu.Text = "statusStrip2";
            // 
            // capsStatusLabel
            // 
            this.capsStatusLabel.Name = "capsStatusLabel";
            this.capsStatusLabel.Size = new System.Drawing.Size(118, 17);
            this.capsStatusLabel.Text = "toolStripStatusLabel1";
            // 
            // languageStatusLabel
            // 
            this.languageStatusLabel.Name = "languageStatusLabel";
            this.languageStatusLabel.Size = new System.Drawing.Size(118, 17);
            this.languageStatusLabel.Text = "toolStripStatusLabel1";
            // 
            // AppTable
            // 
            this.AppTable.AllowUserToAddRows = false;
            this.AppTable.AllowUserToDeleteRows = false;
            this.AppTable.AllowUserToResizeColumns = false;
            this.AppTable.AllowUserToResizeRows = false;
            this.AppTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AppTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.messageColumn,
            this.positionColumn,
            this.lineColumn});
            this.AppTable.Location = new System.Drawing.Point(12, 418);
            this.AppTable.Name = "AppTable";
            this.AppTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.AppTable.Size = new System.Drawing.Size(825, 190);
            this.AppTable.TabIndex = 26;
            // 
            // messageColumn
            // 
            this.messageColumn.HeaderText = "Описание";
            this.messageColumn.Name = "messageColumn";
            this.messageColumn.ReadOnly = true;
            this.messageColumn.Width = 400;
            // 
            // positionColumn
            // 
            this.positionColumn.HeaderText = "Позиция";
            this.positionColumn.Name = "positionColumn";
            this.positionColumn.ReadOnly = true;
            this.positionColumn.Width = 190;
            // 
            // lineColumn
            // 
            this.lineColumn.HeaderText = "строка";
            this.lineColumn.Name = "lineColumn";
            this.lineColumn.ReadOnly = true;
            this.lineColumn.Width = 190;
            // 
            // languageButton
            // 
            this.languageButton.BackColor = System.Drawing.SystemColors.HighlightText;
            this.languageButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.languageButton.Image = global::NewCompiler.Properties.Resources.ruFlag;
            this.languageButton.Location = new System.Drawing.Point(630, 38);
            this.languageButton.Name = "languageButton";
            this.languageButton.Size = new System.Drawing.Size(71, 50);
            this.languageButton.TabIndex = 15;
            this.languageButton.UseVisualStyleBackColor = false;
            // 
            // informationButton
            // 
            this.informationButton.BackColor = System.Drawing.SystemColors.HighlightText;
            this.informationButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.informationButton.Image = global::NewCompiler.Properties.Resources.info;
            this.informationButton.Location = new System.Drawing.Point(574, 38);
            this.informationButton.Name = "informationButton";
            this.informationButton.Size = new System.Drawing.Size(50, 50);
            this.informationButton.TabIndex = 14;
            this.informationButton.UseVisualStyleBackColor = false;
            this.informationButton.Click += new System.EventHandler(this.informationButton_Click);
            // 
            // startButton
            // 
            this.startButton.BackColor = System.Drawing.SystemColors.HighlightText;
            this.startButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.startButton.Image = global::NewCompiler.Properties.Resources.play;
            this.startButton.Location = new System.Drawing.Point(518, 38);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(50, 50);
            this.startButton.TabIndex = 13;
            this.startButton.UseVisualStyleBackColor = false;
            // 
            // insertTextButton
            // 
            this.insertTextButton.BackColor = System.Drawing.SystemColors.HighlightText;
            this.insertTextButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.insertTextButton.Image = global::NewCompiler.Properties.Resources.insertText;
            this.insertTextButton.Location = new System.Drawing.Point(462, 38);
            this.insertTextButton.Name = "insertTextButton";
            this.insertTextButton.Size = new System.Drawing.Size(50, 50);
            this.insertTextButton.TabIndex = 12;
            this.insertTextButton.UseVisualStyleBackColor = false;
            // 
            // cutTextButton
            // 
            this.cutTextButton.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cutTextButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cutTextButton.Image = global::NewCompiler.Properties.Resources.cutText;
            this.cutTextButton.Location = new System.Drawing.Point(406, 38);
            this.cutTextButton.Name = "cutTextButton";
            this.cutTextButton.Size = new System.Drawing.Size(50, 50);
            this.cutTextButton.TabIndex = 11;
            this.cutTextButton.UseVisualStyleBackColor = false;
            // 
            // copyTextButton
            // 
            this.copyTextButton.BackColor = System.Drawing.SystemColors.HighlightText;
            this.copyTextButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.copyTextButton.Image = global::NewCompiler.Properties.Resources.copyFile;
            this.copyTextButton.Location = new System.Drawing.Point(350, 38);
            this.copyTextButton.Name = "copyTextButton";
            this.copyTextButton.Size = new System.Drawing.Size(50, 50);
            this.copyTextButton.TabIndex = 10;
            this.copyTextButton.UseVisualStyleBackColor = false;
            // 
            // returnChangesButton
            // 
            this.returnChangesButton.BackColor = System.Drawing.SystemColors.HighlightText;
            this.returnChangesButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.returnChangesButton.Image = global::NewCompiler.Properties.Resources.forward;
            this.returnChangesButton.Location = new System.Drawing.Point(294, 38);
            this.returnChangesButton.Name = "returnChangesButton";
            this.returnChangesButton.Size = new System.Drawing.Size(50, 50);
            this.returnChangesButton.TabIndex = 9;
            this.returnChangesButton.UseVisualStyleBackColor = false;
            // 
            // cancelChangesButton
            // 
            this.cancelChangesButton.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cancelChangesButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cancelChangesButton.Image = global::NewCompiler.Properties.Resources.backward;
            this.cancelChangesButton.Location = new System.Drawing.Point(238, 38);
            this.cancelChangesButton.Name = "cancelChangesButton";
            this.cancelChangesButton.Size = new System.Drawing.Size(50, 50);
            this.cancelChangesButton.TabIndex = 8;
            this.cancelChangesButton.UseVisualStyleBackColor = false;
            // 
            // saveFileButton
            // 
            this.saveFileButton.BackColor = System.Drawing.SystemColors.HighlightText;
            this.saveFileButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.saveFileButton.Image = global::NewCompiler.Properties.Resources.saveFile;
            this.saveFileButton.Location = new System.Drawing.Point(124, 38);
            this.saveFileButton.Name = "saveFileButton";
            this.saveFileButton.Size = new System.Drawing.Size(50, 50);
            this.saveFileButton.TabIndex = 7;
            this.saveFileButton.UseVisualStyleBackColor = false;
            // 
            // openFileButton
            // 
            this.openFileButton.BackColor = System.Drawing.SystemColors.HighlightText;
            this.openFileButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.openFileButton.Image = global::NewCompiler.Properties.Resources.openFile;
            this.openFileButton.Location = new System.Drawing.Point(68, 38);
            this.openFileButton.Name = "openFileButton";
            this.openFileButton.Size = new System.Drawing.Size(50, 50);
            this.openFileButton.TabIndex = 6;
            this.openFileButton.UseVisualStyleBackColor = false;
            // 
            // createFileButton
            // 
            this.createFileButton.BackColor = System.Drawing.SystemColors.HighlightText;
            this.createFileButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.createFileButton.Image = global::NewCompiler.Properties.Resources.createFile;
            this.createFileButton.Location = new System.Drawing.Point(12, 38);
            this.createFileButton.Name = "createFileButton";
            this.createFileButton.Size = new System.Drawing.Size(50, 50);
            this.createFileButton.TabIndex = 5;
            this.createFileButton.UseVisualStyleBackColor = false;
            // 
            // AppForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(849, 769);
            this.Controls.Add(this.AppTable);
            this.Controls.Add(this.appStatusMenu);
            this.Controls.Add(this.userOutputBox);
            this.Controls.Add(this.AppPanel);
            this.Controls.Add(this.languageButton);
            this.Controls.Add(this.informationButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.insertTextButton);
            this.Controls.Add(this.cutTextButton);
            this.Controls.Add(this.copyTextButton);
            this.Controls.Add(this.returnChangesButton);
            this.Controls.Add(this.cancelChangesButton);
            this.Controls.Add(this.saveFileButton);
            this.Controls.Add(this.openFileButton);
            this.Controls.Add(this.createFileButton);
            this.Controls.Add(this.appMenu);
            this.MainMenuStrip = this.appMenu;
            this.MinimumSize = new System.Drawing.Size(726, 630);
            this.Name = "AppForm";
            this.Text = "AppForm";
            this.Load += new System.EventHandler(this.AppForm_Load);
            this.AppPanel.ResumeLayout(false);
            this.AppPanel.PerformLayout();
            this.appMenu.ResumeLayout(false);
            this.appMenu.PerformLayout();
            this.appStatusMenu.ResumeLayout(false);
            this.appStatusMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AppTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button createFileButton;
        private System.Windows.Forms.Button openFileButton;
        private System.Windows.Forms.Button saveFileButton;
        private System.Windows.Forms.Button cancelChangesButton;
        private System.Windows.Forms.Button returnChangesButton;
        private System.Windows.Forms.Button copyTextButton;
        private System.Windows.Forms.Button cutTextButton;
        private System.Windows.Forms.Button insertTextButton;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button informationButton;
        private System.Windows.Forms.Button languageButton;
        private System.Windows.Forms.RichTextBox userInputBox;
        private System.Windows.Forms.Label linesLabel;
        
        
        private System.Windows.Forms.Panel AppPanel;
        private System.Windows.Forms.RichTextBox userOutputBox;
        private System.Windows.Forms.MenuStrip appMenu;
        private System.Windows.Forms.ToolStripMenuItem fileMenu;
        private System.Windows.Forms.ToolStripMenuItem createFileSubmenu;
        private System.Windows.Forms.ToolStripMenuItem openFileSubmenu;
        private System.Windows.Forms.ToolStripMenuItem saveSubmenu;
        private System.Windows.Forms.ToolStripMenuItem saveAsSubmenu;
        private System.Windows.Forms.ToolStripMenuItem exitSubmenu;
        private System.Windows.Forms.ToolStripMenuItem editMenu;
        private System.Windows.Forms.ToolStripMenuItem cancelSubmenu;
        private System.Windows.Forms.ToolStripMenuItem repeatSubmenu;
        private System.Windows.Forms.ToolStripMenuItem cutSubmenu;
        private System.Windows.Forms.ToolStripMenuItem copySubmenu;
        private System.Windows.Forms.ToolStripMenuItem insertSubmenu;
        private System.Windows.Forms.ToolStripMenuItem deleteSubmenu;
        private System.Windows.Forms.ToolStripMenuItem selectAllSubmenu;
        private System.Windows.Forms.ToolStripMenuItem startMenu;
        private System.Windows.Forms.ToolStripMenuItem helpMenu;
        private System.Windows.Forms.ToolStripMenuItem callHelpSubmenu;
        private System.Windows.Forms.ToolStripMenuItem programInfoSubmenu;
        private System.Windows.Forms.StatusStrip appStatusMenu;
        private System.Windows.Forms.ToolStripStatusLabel capsStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel languageStatusLabel;
        private System.Windows.Forms.DataGridView AppTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn messageColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn positionColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lineColumn;
        private System.Windows.Forms.ToolStripMenuItem textMenu;
        private System.Windows.Forms.ToolStripMenuItem taskSubmenu;
        private System.Windows.Forms.ToolStripMenuItem grammarSubmenu;
        private System.Windows.Forms.ToolStripMenuItem grammarСlassificationSubmenu;
        private System.Windows.Forms.ToolStripMenuItem analysisMethodSubmenu;
        private System.Windows.Forms.ToolStripMenuItem diagnosticSubmenu;
        private System.Windows.Forms.ToolStripMenuItem testExampleSubmenu;
        private System.Windows.Forms.ToolStripMenuItem literatureSubmenu;
    }
}