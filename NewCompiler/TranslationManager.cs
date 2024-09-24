using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;

namespace NewCompiler
{
    public class TranslationManager
    {
        private readonly Dictionary<string, string> RussianMenuDictionary = new Dictionary<string, string>
        {
            { "fileMenu", "Файл" },
            { "createFileSubmenu", "Создать" },
            { "openFileSubmenu", "Открыть" },
            { "saveSubmenu", "Сохранить" },
            { "saveAsSubmenu", "Сохранить как" },
            { "exitSubmenu", "Выход" },

            { "editMenu", "Правка" },
            { "cancelSubmenu", "Отменить" },
            { "repeatSubmenu", "Повторить" },
            { "cutSubmenu", "Вырезать" },
            { "copySubmenu", "Копировать" },
            { "insertSubmenu", "Вставить" },
            { "deleteSubmenu", "Удалить" },
            { "selectAllSubmenu", "Выделить все" },

            {"textMenu", "Текст" },
            {"taskSubmenu", "Постановка задачи" },
            {"grammarSubmenu", "Грамматика" },
            {"grammarСlassificationSubmenu", "Классификация грамматики" },
            {"analysisMethodSubmenu", "Метод анализа" },
            {"diagnosticSubmenu", "Диагностика и нейтрализация ошибок" },
            {"testExampleSubmenu", "Тестовый пример" },
            {"literatureSubmenu", "Список литературы" },


            { "startMenu", "Пуск" },

            { "helpMenu", "Справка" },
            { "callHelpSubmenu", "Вызов справки" },
            { "programInfoSubmenu", "О программе" },

        };
        private readonly Dictionary<string, string> EnglishMenuDictionary = new Dictionary<string, string>
        {
            { "fileMenu", "File" },
            { "createFileSubmenu", "Create" },
            { "openFileSubmenu", "Open" },
            { "saveSubmenu", "Save" },
            { "saveAsSubmenu", "Save as" },
            { "exitSubmenu", "Exit" },

            { "editMenu", "Edit" },
            { "cancelSubmenu", "Cancel" },
            { "repeatSubmenu", "Repeat" },
            { "cutSubmenu", "Cut" },
            { "copySubmenu", "Copy" },
            { "insertSubmenu", "Insert" },
            { "deleteSubmenu", "Delete" },
            { "selectAllSubmenu", "Select all" },

            {"textMenu", "Text" },
            {"taskSubmenu", "Problem definition" },
            {"grammarSubmenu", "Grammar" },
            {"grammarСlassificationSubmenu", "Grammar classification" },
            {"analysisMethodSubmenu", "Method of analysis" },
            {"diagnosticSubmenu", "Diagnosis and neutralization of errors" },
            {"testExampleSubmenu", "Test example" },
            {"literatureSubmenu", "List of literature" },


            { "startMenu", "Start" },

            { "helpMenu", "Help" },
            { "callHelpSubmenu", "Call help" },
            { "programInfoSubmenu", "Program info" },

        };

        private MenuStrip appMenu;
        private DataGridView appTable;
        private Button languageButton;

        private string currentLanguage = "ru";

        private string ENGLISH_LANGUAGE = "us";
        private string RUSSIAN_LANGUAGE = "ru";
        public TranslationManager(MenuStrip appMenu, DataGridView appTable ,Button languageButton)
        {
            this.appMenu = appMenu;
            this.appTable = appTable;
            this.languageButton = languageButton;
                
        }

        public TranslationManager()
        {
            
        }


        public string GetCurrentTranslateFile(string key)
        {
            if (currentLanguage == ENGLISH_LANGUAGE)
            {
                switch (key)
                {
                    case "informationButton":
                        return "documentationEN.html";

                    case "callHelpSubmenu":
                        return "documentationEN.html";

                    case "taskSubmenu":
                        return "TaskEN.html";

                    case "grammarSubmenu":
                        return "GrammarEN.html";

                    case "grammarСlassificationSubmenu":
                        return "GrammarСlassificationEN.html";

                    case "analysisMethodSubmenu":
                        return "AnalysisMethodEN.html";

                    case "diagnosticSubmenu":
                        return "DiagnosticEN.html";

                    case "testExampleSubmenu":
                        return "TestExampleEN.html";

                    case "literatureSubmenu":
                        return "LiteratureEN.html";
                }
                
            }
            if (currentLanguage == RUSSIAN_LANGUAGE)
            {
                switch (key)
                {
                    case "informationButton":
                        return "documentationRU.html";

                    case "callHelpSubmenu":
                        return "documentationRU.html";

                    case "taskSubmenu":
                        return "TaskRU.html";

                    case "grammarSubmenu":
                        return "GrammarRU.html";

                    case "grammarСlassificationSubmenu":
                        return "GrammarClassificationRU.html";

                    case "analysisMethodSubmenu":
                        return "AnalysisMethodRU.html";

                    case "diagnosticSubmenu":
                        return "DiagnosticRU.html";

                    case "testExampleSubmenu":
                        return "TestExampleRU.html";

                    case "literatureSubmenu":
                        return "LiteratureRU.html";
                }
            }
            return string.Empty;
        }

        public void SetLanguage()
        {
            if (currentLanguage == RUSSIAN_LANGUAGE)
            {
                currentLanguage = ENGLISH_LANGUAGE;
                TranslateMenu(EnglishMenuDictionary);
                TranslateTable();
                ChangeLanguageFlag();
                


            }
            else
            {
                currentLanguage = RUSSIAN_LANGUAGE;
                TranslateMenu(RussianMenuDictionary);
                TranslateTable();
                ChangeLanguageFlag();
                
            }
        }

        private void TranslateMenu(Dictionary<string, string> currentDictionary)
        {
            foreach (ToolStripMenuItem menuItem in this.appMenu.Items)
            {
                menuItem.Text = currentDictionary[menuItem.Name];

                foreach (ToolStripMenuItem subItem in menuItem.DropDownItems)
                {
                    if (subItem is ToolStripMenuItem subMenuItem)
                    {
                        subMenuItem.Text = currentDictionary[subMenuItem.Name];
                    }
                }
            }


        }

        private void TranslateTable()
        {
            foreach (DataGridViewColumn column in appTable.Columns)
            {
                column.HeaderText = GetColumnTranslate(column.Name);
            }
            appTable.Rows.Clear();
        }

        
        private string GetColumnTranslate(string key)
        {
            if (currentLanguage == ENGLISH_LANGUAGE)
            {
                switch (key)
                {
                    case "messageColumn":
                        return "Description";
                    case "positionColumn":
                        return "Position";
                    case "lineColumn":
                        return "Line";
                }
            }
            else if (currentLanguage == RUSSIAN_LANGUAGE)
            {
                switch (key)
                {
                    case "messageColumn":
                        return "Описание";
                    case "positionColumn":
                        return "Позиция";
                    case "lineColumn":
                        return "Строка";
                }
            }
            return string.Empty;
        }

        public string GetMessageBoxTranslate(string key)
        {
            if (currentLanguage == ENGLISH_LANGUAGE)
            {
                switch (key)
                {
                    case "SaveChangesQuestion":
                        return "Save changes to the current file?";
                    case "SaveTitle":
                        return "Save";
                    
                }
            }
            else if (currentLanguage == RUSSIAN_LANGUAGE)
            {
                switch (key)
                {
                    case "SaveChangesQuestion":
                        return "Сохранить изменения в текущем файле?";
                    case "SaveTitle":
                        return "Сохранение";
                    
                }
            }
            return string.Empty;
        }


        public string GetCapsLockTranslate(string key)
        {
            if (currentLanguage == ENGLISH_LANGUAGE)
            {
                switch (key)
                {
                    case "capsOn":
                        return "CapsLock key: on";
                    case "capsOff":
                        return "CapsLock key: off";

                }
            }
            else if (currentLanguage == RUSSIAN_LANGUAGE)
            {
                switch (key)
                {
                    case "capsOn":
                        return "Клавиша CapsLock: нажата";
                    case "capsOff":
                        return "Клавиша CapsLock: не нажата";

                }
            }
            return string.Empty;
        }


        public string GetInputLanguageTranslate()
        {
            string currentTranslate;
            if (currentLanguage == ENGLISH_LANGUAGE)
            {
                currentTranslate = "Current Layout: " + InputLanguage.CurrentInputLanguage.Culture.EnglishName;
                return currentTranslate;


            }
            currentTranslate = "Текущая раскладка: " + InputLanguage.CurrentInputLanguage.LayoutName;
            return currentTranslate;
        }

        private void ChangeLanguageFlag()
        {
            if (currentLanguage == ENGLISH_LANGUAGE)
            {
                languageButton.Image = Properties.Resources.usa_flag;
            }
            else
            {
                languageButton.Image = Properties.Resources.ruFlag;
            }
        }

        public string GetParserResultTranslate(ParserResultStatus stateMessage, string tokenValue = "")
        {
            if (currentLanguage == ENGLISH_LANGUAGE)
            {
                switch (stateMessage)
                {                 
                    case ParserResultStatus.EmptyString:
                        return "Found end of file but keyword 'const' expected";

                    case ParserResultStatus.IsDuplicate:
                        return $"An identifier named '{tokenValue}' already exists";

                    case ParserResultStatus.NoConst:
                        return "Keyword 'const' is required";

                    case ParserResultStatus.NoIdent:
                        return "An identifier is required";

                    case ParserResultStatus.NoColon:
                        return "A separator of the type ':' is required";

                    case ParserResultStatus.NoType:
                        return "The 'integer' data type is required";

                    case ParserResultStatus.NoEquals:
                        return "The assignment operator '=' is required";

                    case ParserResultStatus.NoNumber:
                        return "An expression is required";

                    case ParserResultStatus.NumberError:
                        return $"Invalid term '{tokenValue}' in the expression";

                    case ParserResultStatus.NoSemicolon:
                        return "The end of the instruction is required ';'";

                    case ParserResultStatus.Success:
                        return "No errors";

                    case ParserResultStatus.InvalidSymbol:
                        return $"Invalid Symbol '{tokenValue}'";


                }
            }

            if (currentLanguage == RUSSIAN_LANGUAGE)
            {
                switch (stateMessage)
                {
                    case ParserResultStatus.EmptyString:
                        return "Встречен конец файла, а ожидалось ключевое слово 'const'";

                    case ParserResultStatus.IsDuplicate:
                        return $"Идентификатор с именем '{tokenValue}' уже существует";

                    case ParserResultStatus.NoConst:
                        return "Требуется ключевое слово 'const'";

                    case ParserResultStatus.NoIdent:
                        return "Требуется идентификатор";

                    case ParserResultStatus.NoColon:
                        return "Требуется разделитель типа ':'";

                    case ParserResultStatus.NoType:
                        return "Требуется тип данных integer";

                    case ParserResultStatus.NoEquals:
                        return "Требуется оператор присваивания '='";

                    case ParserResultStatus.NoNumber:
                        return "Требуется выражение";

                    case ParserResultStatus.NumberError:
                        return $"Недопустимый термин '{tokenValue}' в выражении";

                    case ParserResultStatus.NoSemicolon:
                        return "Требуется конец инструкции ';'";

                   
                    case ParserResultStatus.Success:
                        return "Ошибок нет";

                    case ParserResultStatus.InvalidSymbol:
                        return $"Недопустимый символ '{tokenValue}'";
                }
            }

            return string.Empty;


            
        }


        public string GetAppInfoTranslate(string element) { 

            if (currentLanguage == ENGLISH_LANGUAGE)
            {
                switch (element)
                {
                    case "AboutApp":

                        return "About app";

                    case "mainTitleLabel":

                        return "Declaring an integer constant with initialization in Pascal";

                    case "versionLabel":
                        return "Version";

                    case "locationLabel":
                        return "Russia, NSTU";

                    case "componentsArea":
                        return "Components";

                    case "developersArea":
                        return "Developers";

                    case "developerTitle":
                        return "Main developer";

                    case "developerInfo":
                        return "Kirilenko K.A.";

                    case "nameColumn":
                        return "Name";

                    case "versionColumn":
                        return "Version";

                    case "dateColumn":
                        return "Date";                 
                }
            }

            if (currentLanguage == RUSSIAN_LANGUAGE)
            {
                switch (element)
                {
                    case "AboutApp":

                        return "О программе";

                    case "mainTitleLabel":

                        return "Объявление целочисленной константы с инициализацией на Pascal";

                    case "versionLabel":
                        return "Версия";

                    case "locationLabel":
                        return "Россия, НГТУ, АВТФ";

                    case "componentsArea":
                        return "Компоненты";

                    case "developersArea":
                        return "Разработчики";

                    case "developerTitle":
                        return "Ведущий разработчик";

                    case "developerInfo":
                        return "Кириленко Кирилл Андреевич";

                    case "nameColumn":
                        return "Имя";

                    case "versionColumn":
                        return "Версия";

                    case "dateColumn":
                        return "Дата";
                }
            }


            return string.Empty;
        }
    }
}
