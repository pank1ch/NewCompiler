using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewCompiler
{

    enum TokenType
    {
        TOKEN_CONST = 1,
        TOKEN_IDENT,
        TOKEN_INTEGER,
        TOKEN_WHITESPACE,
        TOKEN_NEWLINE,
        TOKEN_COLON,
        TOKEN_EQUALS,
        TOKEN_NUMBER,
        TOKEN_MINUS,
        TOKEN_SEMICOLON,
        TOKEN_ERROR,
        



    }
    internal class Token
    {
        
        private TokenType type;
        private string description;
        private string value;
   
        private int startPosition;
        private int endPosition;
        
        public Token(TokenType type, string description, string value)
        {
            this.type = type;
            this.description = description;
            this.value = value;
            
          
        }


        public string GetInfo()
        {
            return "Current Token: " + type + " - " + description + " - " + value + " - position ["+startPosition+","+endPosition+"]";
        }

        

        public int StartPosition
        {
            get
            {
                return startPosition;
            }
            set
            {
                startPosition = value;
            }
        }

        public int EndPosition
        {
            get
            {
                return endPosition;
            }
            set
            {
                endPosition = value;
            }
        }



        public TokenType Type {
            get 
            {
                return type;
            } 
               
        }

        public string Description
        {
            get
            {
                return description;
            }
            
        }

        

        public string Value
        {
            get { return value; }
            
        }

    }
}
