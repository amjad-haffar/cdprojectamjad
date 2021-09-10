using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MyCompiler2
{
    public enum Language { DataType,Keyword,SpecialChar,Identifer,IntNumber,DoubleNumber,Error,Comment,String,trueBoolean,falseBoolean, logicalOP,Char };

    public class Token
    {
        public Language type;
        public string value;
        public int line;

        public Token()
        {
            value = "";
            line = -1;
        }

        public Token(Language type,string value,int line)
        {
            this.type = type;
            this.value = value;
            this.line = line;
        }
        public void print()
        {
            Console.Write("Type = " + type + " | ");
            Console.Write("Value = " + value + " | ");
            Console.Write("Line = " + line);

            Console.WriteLine();
        }
    }
}
