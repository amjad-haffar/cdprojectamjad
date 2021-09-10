using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompiler2
{
    public class Symbol
    {
        public string name;
        public string type;
        public int scope;
        public static bool flag = true;
        //string value;

        public Symbol()
        {
            type = "";
            name = "";

            scope = -1;
        }

        public Symbol(string n, string t, int s)
        {
            name = n;
            type = t;
            scope = s;

        }

        public void print()
        {
            Console.WriteLine("Name = " + name + " , Type = " + type + " Scope = " + scope);
        }

    }
}
