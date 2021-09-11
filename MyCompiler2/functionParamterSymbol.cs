using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompiler2
{
    public class functionParamterSymbol
    {
        public string name;
        public string type;
        public string functionname;
       public int parameterCount;
       
        //string value;

        public functionParamterSymbol()
        {
            type = "";
            name = "";
            functionname = "";
            parameterCount = 0;

        }

        public functionParamterSymbol(string n, string t,string f,int p)
        {
            name = n;
            type = t;
            functionname = f;
            parameterCount = p;
        }

        public void print()
        {
            Console.WriteLine("Name = " + name + " , Type = " + type );
        }

    }
}
