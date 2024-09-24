using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewCompiler
{
    public partial class AboutApp : Form
    {
        private TranslationManager translationManager;
        public AboutApp(TranslationManager translationManager)
        {
            
            InitializeComponent();


            this.translationManager = translationManager;
            SetFormTranslation();

            linkLabel.LinkClicked += (sender, evt) => LinkOpen();

            FillComponentsTable();
            this.componentsTable.SelectionChanged += (sender, evt) => this.componentsTable.ClearSelection();

            closeButton.Click += (sender, evt) => this.Close();


            

            

        }

        



        private void FillComponentsTable()
        {
            string[] UIRow = new string[] { "User Interface", "1.0.0", "2024" };
            this.componentsTable.Rows.Add(UIRow);

            string[] lexerRow = new string[] { "Lexer", "1.0.0", "2024" };
            this.componentsTable.Rows.Add(lexerRow);

            string[] parserRow = new string[] { "Parser", "1.0.0", "2024" };
            this.componentsTable.Rows.Add(parserRow);

            
        }




        private void LinkOpen()
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = "https://github.com/pank1ch",
                UseShellExecute = true
            });
        }


        private void SetFormTranslation() {


            

            this.Text = translationManager.GetAppInfoTranslate(this.Name);

            this.mainTitleLabel.Text = translationManager.GetAppInfoTranslate(this.mainTitleLabel.Name);
            this.versionLabel.Text = translationManager.GetAppInfoTranslate(this.versionLabel.Name);
            this.locationLabel.Text = translationManager.GetAppInfoTranslate(this.locationLabel.Name);

            this.componentsArea.Text = translationManager.GetAppInfoTranslate(this.componentsArea.Name);
            this.componentsTable.Columns[0].HeaderText = translationManager.GetAppInfoTranslate(this.componentsTable.Columns[0].Name);
            this.componentsTable.Columns[1].HeaderText = translationManager.GetAppInfoTranslate(this.componentsTable.Columns[1].Name);
            this.componentsTable.Columns[2].HeaderText = translationManager.GetAppInfoTranslate(this.componentsTable.Columns[2].Name);

            this.developersArea.Text = translationManager.GetAppInfoTranslate(this.developersArea.Name);
            this.developerTitle.Text = translationManager.GetAppInfoTranslate(this.developerTitle.Name);
            this.developerInfo.Text = translationManager.GetAppInfoTranslate(this.developerInfo.Name);

        }

        private void closeButton_Click(object sender, EventArgs e)
        {

        }

        private void AboutApp_Load(object sender, EventArgs e)
        {

        }
    }
}
