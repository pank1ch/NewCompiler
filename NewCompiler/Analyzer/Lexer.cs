using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewCompiler
{
    internal class Lexer
    {      
        public Lexer() { }

        private HashSet<char> errorSymbols = new HashSet<char>
        {
            '@', '#', '$', '%', '^', '&', '*', '(', ')', '{', '}', '[', ']', '|', '\\', '/', '<', '>', ',', '.', '?', '!', '~'
        };

        private HashSet<char> functionalSymbols = new HashSet<char>
        {
            ' ', '\n', ':', ';', '='
        };

        public List<Token> InputAnalyze(string userInput)
        {        
            List<Lexeme> lexemsList = GetInputLexems(userInput);

            List<Token> tokens = new List<Token>();

            foreach (Lexeme lexeme in lexemsList) {

                Token newToken = AnalyzeToken(lexeme.Value, lexeme.Index);
                tokens.Add(newToken);
            }

            return tokens;
        }
        
        private Token AnalyzeToken(string word, int index)
        {
            Token newToken = null;
            bool isNumber = false;     
            bool isError = false;
            switch (word)
            {
                case "const":          
                    newToken = new Token(TokenType.TOKEN_CONST, "ключевое слово", word);
                    newToken.StartPosition = (index - word.Length + 1);
                    newToken.EndPosition = index;
                    return newToken;

                case "integer":
                    newToken = new Token(TokenType.TOKEN_INTEGER, "тип данных", word);
                    newToken.StartPosition = (index - word.Length + 1);
                    newToken.EndPosition = index;
                    return newToken;

                case " ":
                    newToken = new Token(TokenType.TOKEN_WHITESPACE, "разделитель", word);
                    newToken.StartPosition = index;
                    newToken.EndPosition = index;
                    return newToken;

                case "\n":
                    newToken = new Token(TokenType.TOKEN_NEWLINE, "новая строка", "\\n");
                    newToken.StartPosition = index;
                    newToken.EndPosition = index;
                    return newToken;
                case ":":
                    newToken = new Token(TokenType.TOKEN_COLON, "разделитель типа", word);
                    newToken.StartPosition = index;  
                    newToken.EndPosition = index;
                    return newToken;

                case "=":
                    newToken = new Token(TokenType.TOKEN_EQUALS, "оператор присваивания", word);
                    newToken.StartPosition = index;
                    newToken.EndPosition = index;
                    return newToken;
                     
                case "-":
                    newToken = new Token(TokenType.TOKEN_MINUS, "знак", word);
                    newToken.StartPosition = index;
                    newToken.EndPosition = index;
                    return newToken;

                case ";":
                    newToken = new Token(TokenType.TOKEN_SEMICOLON, "конец оператора", word);
                    newToken.StartPosition = index;
                    newToken.EndPosition = index;
                    return newToken;

                default:

                 
                    break;

            }
            isNumber = int.TryParse(word, out _);

            if (isNumber)
            {
                newToken = new Token(TokenType.TOKEN_NUMBER, "число", word);
                newToken.StartPosition = (index - word.Length + 1);
                newToken.EndPosition = index;
                return newToken;
            }
      
            if (word.Length == 1)
            {
                char currentChar = word[0];
                isError = errorSymbols.Contains(currentChar);
                
                if (isError)
                {
                    newToken = new Token(TokenType.TOKEN_ERROR, "Недопустимый символ", word);
                    newToken.StartPosition = index;
                    newToken.EndPosition = index;
                    return newToken;
                }
            }

            newToken = new Token(TokenType.TOKEN_IDENT, "идентификатор", word);
            newToken.StartPosition = (index - word.Length + 1);
            newToken.EndPosition = index;
            return newToken;


       

        }

        public List<Lexeme> GetInputLexems(string currentText)
        {
            List<Lexeme> inputLexems = new List<Lexeme>();

            Lexeme currentLexeme;
            string currentWord = string.Empty;
         
            for (int i = 0; i < currentText.Length; i++)
            {
                char currentChar = currentText[i];
                int currentIndex = i;

                if (char.IsDigit(currentChar) == false && int.TryParse(currentWord, out _) == true)
                {
                    if (errorSymbols.Contains(currentChar)  || functionalSymbols.Contains(currentChar))
                    {
                        currentLexeme = new Lexeme(currentWord, currentIndex - 1);
                        inputLexems.Add(currentLexeme);
                        currentWord = "";
                        currentLexeme = null;

                    }
                    

                    
                }


                if (errorSymbols.Contains(currentChar))
                {

                    if (currentWord.Length > 0)
                    {
                        currentLexeme = new Lexeme(currentWord, currentIndex - 1);
                        inputLexems.Add(currentLexeme);
                        currentWord = "";
                        currentLexeme = null;
                    }
                    currentLexeme = new Lexeme(currentChar.ToString(), currentIndex);
                    inputLexems.Add(currentLexeme);
                    continue;
                }


                if (currentChar == '=')
                {
                    if (currentWord.Length > 0)
                    {
                        currentLexeme = new Lexeme(currentWord, currentIndex - 1);
                        inputLexems.Add(currentLexeme);
                        currentWord = "";
                        currentLexeme = null;
                    }
                    currentLexeme = new Lexeme(currentChar.ToString(), currentIndex);
                    inputLexems.Add(currentLexeme);
                    continue;

                }


                if (currentChar == ':')
                {
                    if (currentWord.Length > 0)
                    {
                        currentLexeme = new Lexeme(currentWord, currentIndex - 1);
                        inputLexems.Add(currentLexeme);
                        currentWord = "";
                        currentLexeme = null;
            
                    }
                    currentLexeme = new Lexeme(currentChar.ToString(), currentIndex);
                    inputLexems.Add(currentLexeme);
                    continue;
                    
                }

                if (currentChar == ';')
                {
                    if (currentWord.Length > 0)
                    {
                        currentLexeme = new Lexeme(currentWord, currentIndex - 1);
                        inputLexems.Add(currentLexeme);
                        currentWord = "";
                        currentLexeme = null;
                    }
                    currentLexeme = new Lexeme(currentChar.ToString(), currentIndex);
                    inputLexems.Add(currentLexeme);
                    continue;

                }

                if (currentChar == '\n')
                {
                    if (currentWord.Length > 0)
                    {
                        currentLexeme = new Lexeme(currentWord, currentIndex - 1);
                        inputLexems.Add(currentLexeme);
                        currentWord = "";
                        currentLexeme = null;
                    }
                    currentLexeme = new Lexeme(currentChar.ToString(), currentIndex);
                    inputLexems.Add(currentLexeme);
                    
                    continue;

                }

                if (i > 0)
                {
           
                    if (currentChar == ' ' && currentText[i - 1] != ' ')
                    {

                        if (currentWord.Length > 0) {
                            currentLexeme = new Lexeme(currentWord, currentIndex - 1);
                            inputLexems.Add(currentLexeme);
                            currentWord = "";
                            currentLexeme = null;

                        }

                        
                    }
                    
                }
                
                if (currentChar == ' ')
                {
                    currentLexeme = new Lexeme(currentChar.ToString(), currentIndex);
                    inputLexems.Add(currentLexeme);
                    continue;

                }

                if (currentIndex + 1 == currentText.Length)
                {
                    if (currentWord.Length > 0)
                    {
                        currentWord += currentChar;
                        currentLexeme = new Lexeme(currentWord, currentIndex);
                        inputLexems.Add(currentLexeme);
                        currentWord = "";
                        currentLexeme = null;
                        break;
                    }
                    else
                    {
                        currentLexeme = new Lexeme(currentChar.ToString(), currentIndex);
                        inputLexems.Add(currentLexeme);
                        currentLexeme = null;
                        break;

                    }
                }


                else
                {
                    currentWord += currentChar;
                }            
                             
            }

            return inputLexems;

        }
    }
}
