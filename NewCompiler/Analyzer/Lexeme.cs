using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewCompiler
{
    internal class Lexeme
    {
        private string value;
        private int index;
        public Lexeme(string value, int index) {

            this.value = value;
            this.index = index;
            
        }

        public string Value {
            get
            {
               return value;
            }        
        }

        public int Index
        {
            get
            {
                return index;
            }       
        }
    }
}
