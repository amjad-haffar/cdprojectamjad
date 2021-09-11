using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompiler2
{
    class Error
    {
        public int lineNumber;
        public String Message;
        public Error()
        {
            this.lineNumber = -1;
            this.Message = "";
        }
        public Error(int l, String m)
        {
            this.lineNumber = l;
            this.Message = m;
        }
    }
}
