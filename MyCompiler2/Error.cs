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
        public String code;
        public String Message;
        public Error()
        {
            this.lineNumber = -1;
            this.code = "";
            this.Message = "";
        }
        public Error(int l, String m,String c)
        {
            this.lineNumber = l;
            this.Message = m;
            this.code = c;
        }
    }
}
