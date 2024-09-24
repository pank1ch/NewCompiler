using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using System.Reflection;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics;
using System.Net.NetworkInformation;

namespace NewCompiler
{

    
    internal class AppService
    {
        


        private OpenFileDialog openFileDialog;
        public SaveFileDialog saveFileDialog;
        private string currentFilePath;

        private AppForm appForm;
        
        private MenuStrip appMenu;

        private Panel appPanel;
        private DataGridView appTable;
        private RichTextBox userInputBox;
        
        private Label linesLabel;

        private Button languageButton;

        
        private bool isSaved = true;

        private bool isHighlighting = false;


        private Lexer lexer;
        private Parser parser;
        private TranslationManager translationManager;

        public AppService(AppForm appForm, MenuStrip appMenu, DataGridView appTable , Panel appPanel, RichTextBox userInputBox, Label linesLabel, Button languageButton)
        {
            this.appForm = appForm;
            this.appMenu = appMenu;
            this.appTable = appTable;
            this.appPanel = appPanel;
            this.userInputBox = userInputBox;
            
            this.linesLabel = linesLabel;
            this.languageButton = languageButton;

            translationManager = new TranslationManager(appMenu, appTable, languageButton);
            lexer = new Lexer();
            parser = new Parser(translationManager);
        }


        public void OnTextSubmenuClick(string subMenuName)
        {
            string fileName = translationManager.GetCurrentTranslateFile(subMenuName);
            DocumentOpen(fileName);
        }

        public void CallHelp(string elementName)
        {
            string fileName = translationManager.GetCurrentTranslateFile(elementName);
            DocumentOpen(fileName);
        }

        private void DocumentOpen(string fileName)
        {
            string folderPath = Path.Combine(System.Windows.Forms.Application.StartupPath, "HTMLFiles");
   
            string filePath = Path.Combine(folderPath, fileName);
       
            Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true });
        }
        
        public void ParseUserInput()
        {
            string text = userInputBox.Text;
            List<Token> userTokens = lexer.InputAnalyze(text);

            List <ResultItem> resultList = parser.ValidateTokens(userTokens);

            this.appTable.Rows.Clear();

            foreach (var resultItem in resultList)
            {
                string[] newRow = new string[3];

                newRow[0] = resultItem.Message;

                if (resultItem.Position == -1)
                {
                    this.appTable.Rows.Add(newRow);
                    continue;
                }
           
                newRow[1] = resultItem.Position.ToString();

                int lineNumber = userInputBox.GetLineFromCharIndex(resultItem.Position) + 1;
                newRow[2] = lineNumber.ToString();

                this.appTable.Rows.Add(newRow);

            }
            this.appTable.ClearSelection();           
        }


        public void OnRowSelect(object sender, DataGridViewCellEventArgs evt)
        {
            if (evt.RowIndex >= 0)
            {              
                DataGridViewRow selectedRow = appTable.Rows[evt.RowIndex];
                
                int positionIndex = Convert.ToInt32(selectedRow.Cells[1].Value);

                userInputBox.SelectionStart = positionIndex;
                userInputBox.Focus();
            }
        }
        public string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }


        public void AppResize()
        {
            appPanel.Width = this.appForm.ClientSize.Width - appPanel.Left * 2;
            userInputBox.Width = appPanel.Width - userInputBox.Left * 2;

            if (appPanel.Width - userInputBox.Width < 20)
            {
                userInputBox.Width = userInputBox.Width - 30;
            }           
        }


        public void OnUserInput()
        {
            isSaved = false;
          
            if (!isHighlighting)
            {
                SyntaxHighlighting();
            }

            ResizeUserInput();
            UpdateLineNumbers();     
        }

        private void ResizeUserInput()
        {
            this.userInputBox.SuspendLayout();

            this.userInputBox.Height = Math.Max(this.userInputBox.PreferredSize.Height, 240);

            this.userInputBox.ResumeLayout();
        }

        private void UpdateLineNumbers()
        {
            int lineCount = this.userInputBox.Lines.Length;

            if (lineCount <= 0)
            {
                this.linesLabel.Text = "1";
                return;
            }

            this.linesLabel.Text = "";

            for (int i = 0; i < lineCount; i++)
            {
                this.linesLabel.Text += (i + 1) + Environment.NewLine;
            }
        }

        public void OpenFile()
        {
            this.openFileDialog = new OpenFileDialog();

            this.openFileDialog.Title = "Выберите файл";
            this.openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt";
            this.openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            if (this.openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.currentFilePath = this.openFileDialog.FileName;

               
                
                string[] fileText = File.ReadAllLines(currentFilePath);

                this.userInputBox.Clear();

                foreach (string textLine in fileText) {

                    this.userInputBox.AppendText(textLine + "\n");
                }
                SyntaxHighlighting();
                ResetUndoHistory();
                isSaved = true;
                
                
            }

        }

        public void CreateFile()
        {
            this.saveFileDialog = new SaveFileDialog();

            this.saveFileDialog.Title = "Создать";

            this.saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt";

            this.saveFileDialog.FileName = "NewScript.txt";

            this.saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            if (this.saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog.FileName, this.userInputBox.Text);

                this.currentFilePath = this.saveFileDialog.FileName;
                this.isSaved = true;
            }
        }


        public void SaveFileChanges()
        {
            if (string.IsNullOrEmpty(this.currentFilePath))
            {
                SaveAsFile();
            }
            else
            {
                File.WriteAllText(this.currentFilePath, this.userInputBox.Text);
                this.isSaved = true;
            }
        }


        public void SaveAsFile()
        {
            this.saveFileDialog = new SaveFileDialog();

            this.saveFileDialog.Title = "Сохранить как";

            this.saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt";

            this.saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments);

            if (this.saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.currentFilePath = this.saveFileDialog.FileName;

                File.WriteAllText(this.currentFilePath, this.userInputBox.Text);
                this.isSaved = true;
            }


        }

        public void CloseApplication()
        {
            this.appForm.Close();
        }

        public void OnAppClose(object sender, FormClosingEventArgs evt)
        {         
            string messageDescription = translationManager.GetMessageBoxTranslate("SaveChangesQuestion");
            string messageTitle = translationManager.GetMessageBoxTranslate("SaveTitle");
           
            if (!isSaved)
            {
                var result = MessageBox.Show(
                  messageDescription,
                  messageTitle,
                  MessageBoxButtons.YesNoCancel,
                  MessageBoxIcon.Question
                );


                if (result == DialogResult.Yes)
                {
                    SaveFileChanges();

                }

                if (result == DialogResult.Cancel)
                {
                    evt.Cancel = true;
                }

            }
        }
          
        public void UndoChanges()
        {
            isHighlighting = true;
            if (userInputBox.CanUndo)
            {
                if (userInputBox.UndoActionName == "Нет данных")
                {
                    while (userInputBox.UndoActionName == "Нет данных")
                    {
                        userInputBox.Undo();
                    }
                }             
                
                userInputBox.Undo();
                
            }
            isHighlighting = false;                        
        }

        public void RedoChanges()
        {
            isHighlighting = true;
            if (this.userInputBox.CanRedo) {

                userInputBox.Redo();

                if (userInputBox.RedoActionName == "Нет данных")
                {
                    while (userInputBox.RedoActionName == "Нет данных")
                    {
                        userInputBox.Redo();
                    }

                }
            }
            isHighlighting = false;                  
        }

        private void ResetUndoHistory()
        {
            string currentText = this.userInputBox.Text;
            this.userInputBox.Text = string.Empty;
            this.userInputBox.Text = currentText;
            this.userInputBox.SelectionStart = 0;
            this.userInputBox.ClearUndo();            
        }


        public void CopySelectedText()
        {
            if (string.IsNullOrEmpty(this.userInputBox.SelectedText)) return;
             
            Clipboard.SetText(this.userInputBox.SelectedText);
            this.userInputBox.Focus();
        }

        public void RemoveSelectedText()
        {
            if (string.IsNullOrEmpty(this.userInputBox.SelectedText)) return;
            
            Clipboard.SetText(this.userInputBox.SelectedText);
            this.userInputBox.SelectedText = string.Empty;
            this.userInputBox.Focus();
        }

        public void DeleteSelectedText()
        {
            if (string.IsNullOrEmpty(this.userInputBox.SelectedText)) return;
            this.userInputBox.SelectedText = string.Empty;
            this.userInputBox.Focus();
        }

        public void InsertCopyText()
        {
            if (Clipboard.ContainsText())
            {
                string clipboardText = Clipboard.GetText();

                int insertPosition = this.userInputBox.SelectionStart;

                this.userInputBox.Text = this.userInputBox.Text.Insert(insertPosition, clipboardText);

                this.userInputBox.SelectionStart = insertPosition + clipboardText.Length;

                this.userInputBox.Focus();
            }
        }


        public void SelectAll()
        {
            this.userInputBox.SelectAll();
        }




        private List<string> GetInputNumbers()
        {
            string inputText = this.userInputBox.Text;
            string currentNumber= "";

            List <string> numbers = new List<string>();

            for (int i = 0; i < inputText.Length; i++)
            {
                int currentIndex = i;
                char currentChar = inputText[i];

                if (Char.IsDigit(currentChar))
                {
                    currentNumber += currentChar;
                }

                if (!Char.IsDigit(currentChar) && currentNumber.Length > 0)
                {
                    numbers.Add(currentNumber);
                    currentNumber = string.Empty;
                }

                if (currentIndex + 1 == inputText.Length)
                {
                    if (currentNumber.Length > 0)
                    {
                        numbers.Add(currentNumber);
                        currentNumber = string.Empty;
                    }
                }
            }

            

            return numbers;
        }

        private void RemoveInvalidHighlighting()
        {
            string[] words = userInputBox.Text.Split(new char[] { ' ', '\n', '\r', '\t', '.', ',', '!', '?', ';' }, StringSplitOptions.RemoveEmptyEntries);

            int startIndex = 0;

            foreach (string word in words)
            {
                int wordIndex = userInputBox.Text.IndexOf(word, startIndex);

                if (wordIndex != -1 && (!IsKeyword(word) || !IsNumber(word)))
                {                  
                    userInputBox.SelectionStart = wordIndex;
                    userInputBox.SelectionLength = word.Length;
                    userInputBox.SelectionColor = Color.Black;
                }
                startIndex = wordIndex + word.Length;
            }          
        }

        private bool IsKeyword(string word)
        {
            return word == "integer" || word == "const"; 
        }

        private bool IsNumber(string word)
        {
            return int.TryParse(word, out _);
        }

        private void SyntaxHighlighting()
        {
            isHighlighting = true;

            int originalIndex = userInputBox.SelectionStart;
            int originalLength = userInputBox.SelectionLength;
            Color originalColor = Color.Black;

            List<string> numbersList = GetInputNumbers();
            string[] keyWords = { "const", "integer" };


            RemoveInvalidHighlighting();
            
            userInputBox.SuspendLayout();
            
            foreach (string keyWord in keyWords)
            {
                HighlightWord(keyWord);
            }

            foreach (var number in numbersList)
            {
                HighlightWord(number);
            }
           
            userInputBox.SelectionStart = originalIndex;
            userInputBox.SelectionLength = originalLength;
            userInputBox.SelectionColor = originalColor;
        
            userInputBox.ResumeLayout();

            isHighlighting = false;           
        }
       
        private void HighlightWord(string word)
        {          
            Color highlightColor = Color.Black;
            
            if (int.TryParse(word, out _)) highlightColor = Color.Green;
            
            if (word == "integer" || word == "const") highlightColor = Color.Blue;
            
            int startIndex = 0;
            while (startIndex < userInputBox.TextLength)
            {
                int wordStartIndex = userInputBox.Find(word, startIndex, RichTextBoxFinds.None);
                if (wordStartIndex != -1)
                {
                    bool isWordIndependent = true;

                    if (wordStartIndex > 0)
                    {
                        char charBefore = this.userInputBox.Text[wordStartIndex - 1];
                        
                        if (Char.IsLetterOrDigit(charBefore) || charBefore == '_')
                        {
                            isWordIndependent = false;
                        }
                    }

                    if (wordStartIndex + word.Length < this.userInputBox.TextLength)
                    {
                        char charAfter = this.userInputBox.Text[wordStartIndex + word.Length];
                        if (Char.IsLetterOrDigit(charAfter) || charAfter == '_')
                        {
                            isWordIndependent = false;
                        }
                    }

                    if (isWordIndependent)
                    {
                        userInputBox.SelectionStart = wordStartIndex;
                        userInputBox.SelectionLength = word.Length;
                        
                        // Проверяем, совпадает ли текущий цвет с желаемым
                        if (userInputBox.SelectionColor != highlightColor)
                        {                            
                            userInputBox.SelectionColor = highlightColor;
                        }
                    }                    
                }
                else
                {
                    break;
                }
                startIndex = wordStartIndex + word.Length;
            }
        }


        public void TranslateApplication()
        {
            translationManager.SetLanguage();            
        }
     
        public void CapsLockCheck(ToolStripStatusLabel capsStatusLabel)
        {
            string capsStatusKey = string.Empty;
            if (Control.IsKeyLocked(Keys.CapsLock))
            {
                capsStatusKey = "capsOn";
                capsStatusLabel.Text = translationManager.GetCapsLockTranslate(capsStatusKey);
            }
            else
            {
                capsStatusKey = "capsOff";
                capsStatusLabel.Text = translationManager.GetCapsLockTranslate(capsStatusKey);
            }
        }

        public void InputLanguageCheck(ToolStripStatusLabel languageStatusLabel)
        {          
            languageStatusLabel.Text = translationManager.GetInputLanguageTranslate();
        }

        public void CallProgramInfo()
        {
            AboutApp aboutForm = new AboutApp(translationManager);
            aboutForm.ShowDialog();
        }
       
    }
}
