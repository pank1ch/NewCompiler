using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewCompiler
{
    internal class ResultItem
    {
        private string message;
        private int position;
       
        public string Message
        {
            get { return message; }         
        }
        public int Position
        {
            get { return position; }
        }

        public ResultItem(string message, int position)
        {
            this.message = message;
            this.position = position; 
            
        }
    }
}



