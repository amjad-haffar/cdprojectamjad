using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompiler2
{
    class ErrorList
    {
        public List<Error> errors;
        public ErrorList()
        {
            this.errors= new List<Error>();
            this.errors.Add(new Error(-1, "compiled"));
        }
        public void adderror(Error e){
            this.errors.Add(e);
        }
        public void printList()
        {
            for (int i = 0; i < errors.Count(); i++)
            {
                if (errors.Count()==1 )
                {
                    Console.WriteLine(errors[i].Message);
                    
                }
                if(i!=0)
                {
                    Console.WriteLine("error (" + i + ") at line " + errors[i].lineNumber + " :" + errors[i].Message);
                }
            }
        }
    }
}
