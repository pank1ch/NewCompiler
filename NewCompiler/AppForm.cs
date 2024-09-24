using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection.Emit;
using System.Reflection;
using static System.Net.Mime.MediaTypeNames;

namespace NewCompiler
{

    public partial class AppForm : Form
    {
        private AppService appService;
        
        public AppForm()
        {
            InitializeComponent();
            this.KeyPreview = true;
        
            appService = new AppService(
                this, 
                this.appMenu,
                this.AppTable,
                this.AppPanel,
                this.userInputBox,                 
                this.linesLabel, 
                this.languageButton
            );

            this.Text = appService.AssemblyTitle;

            appService.AppResize();
            appService.CapsLockCheck(capsStatusLabel);
            appService.InputLanguageCheck(languageStatusLabel);

                
            this.Resize += (sender, evt) => appService.AppResize();
                    
            this.InputLanguageChanged += (sender, evt) => appService.InputLanguageCheck(languageStatusLabel);
            
            this.KeyDown += (sender, evt) => {

                appService.CapsLockCheck(capsStatusLabel);

                if (evt.Control && evt.KeyCode == Keys.Z)
                {
                    appService.UndoChanges();
                }

                if (evt.Control && evt.KeyCode == Keys.Y)
                {
                    
                    appService.RedoChanges();
                }

            };
                     
            userInputBox.TextChanged += (sender, evt) => appService.OnUserInput();

            SetAppMenu();
            SetAppButtons();
            SetTableSettings();

            AppTable.CellClick += appService.OnRowSelect;


            this.FormClosing += appService.OnAppClose;

            this.userInputBox.MouseWheel += (sender, evt) =>
            {
                if (Control.ModifierKeys == Keys.Control) ((HandledMouseEventArgs)evt).Handled = true;             
            };
           
        }

        private void SetTableSettings()
        {
            this.AppTable.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            this.AppTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            this.AppTable.Columns[0].FillWeight = 60; 
            this.AppTable.Columns[1].FillWeight = 20; 
            this.AppTable.Columns[2].FillWeight = 20;
        }

        private void SetAppMenu()
        {
            appMenu.MouseEnter += (sender, e) =>
            {
                Cursor = Cursors.Hand;
            };

            appMenu.MouseLeave += (sender, e) =>
            {
                Cursor = Cursors.Default;
            };

            //----------------------------------------- files ----------------------------------------------//
            this.createFileSubmenu.Click += (sender, evt) => appService.CreateFile();
            this.openFileSubmenu.Click += (sender, evt) => appService.OpenFile();
            this.saveSubmenu.Click += (sender, evt) => appService.SaveFileChanges();
            this.saveAsSubmenu.Click += (sender, evt) => appService.SaveAsFile();
            this.exitSubmenu.Click += (sender, evt) => appService.CloseApplication();
            

            //---------------------------------------- edit ------------------------------------------------//

            this.cancelSubmenu.Click += (sender, evt) => appService.UndoChanges();
            this.repeatSubmenu.Click += (sender, evt) => appService.RedoChanges();
            this.cutSubmenu.Click += (sender, evt) => appService.RemoveSelectedText();
            this.copySubmenu.Click += (sender, evt) => appService.CopySelectedText();
            this.insertSubmenu.Click += (sender, evt) => appService.InsertCopyText();
            this.deleteSubmenu.Click += (sender, evt) => appService.DeleteSelectedText();
            this.selectAllSubmenu.Click += (sender, evt) => appService.SelectAll();

            //--------------------------------------text ----------------------------------------------------//

            this.taskSubmenu.Click += (sender, evt) => appService.OnTextSubmenuClick(this.taskSubmenu.Name);
            this.grammarSubmenu.Click += (sender, evt) => appService.OnTextSubmenuClick(this.grammarSubmenu.Name);
            this.grammarСlassificationSubmenu.Click += (sender, evt) => appService.OnTextSubmenuClick(this.grammarСlassificationSubmenu.Name);
            this.analysisMethodSubmenu.Click += (sender, evt) => appService.OnTextSubmenuClick(this.analysisMethodSubmenu.Name);
            this.diagnosticSubmenu.Click += (sender, evt) => appService.OnTextSubmenuClick(this.diagnosticSubmenu.Name);
            this.testExampleSubmenu.Click += (sender, evt) => appService.OnTextSubmenuClick(this.testExampleSubmenu.Name);
            this.literatureSubmenu.Click += (sender, evt) => appService.OnTextSubmenuClick(this.literatureSubmenu.Name);

            // ---------------------------------------- start ------------------------------------------------//
            this.startMenu.Click += (sender, evt) => appService.ParseUserInput();

            // ---------------------------------------- Help ------------------------------------------------//
            this.callHelpSubmenu.Click += (sender, evt) => appService.CallHelp(this.callHelpSubmenu.Name);
            this.programInfoSubmenu.Click += (sender, evt) => appService.CallProgramInfo();
        }


        private void SetAppButtons()
        {
            this.openFileButton.Click += (sender, evt) => appService.OpenFile();
            
            this.createFileButton.Click += (sender, evt) => appService.CreateFile();
            this.saveFileButton.Click += (sender, evt) => appService.SaveFileChanges();

            this.cancelChangesButton.Click += (sender, evt) => appService.UndoChanges();
            this.returnChangesButton.Click += (sender, evt) => appService.RedoChanges();

            this.copyTextButton.Click += (sender, evt) => appService.CopySelectedText();
            this.cutTextButton.Click += (sender, evt) => appService.RemoveSelectedText();
            this.insertTextButton.Click += (sender, evt) => appService.InsertCopyText();


            this.startButton.Click += (sender, evt) => appService.ParseUserInput();

            this.informationButton.Click += (sender, evt) => appService.CallHelp(this.informationButton.Name);

            this.languageButton.Click += (sender, evt) => {

                appService.TranslateApplication();
                appService.CapsLockCheck(capsStatusLabel);
                appService.InputLanguageCheck(languageStatusLabel);

            };
        }

        private void informationButton_Click(object sender, EventArgs e)
        {
           
        }

        private void AppForm_Load(object sender, EventArgs e)
        {

        }
    }
}




