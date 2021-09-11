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
        }
        public void adderror(Error e){
            if (e.Message != "")
            {
                this.errors.Add(e);
            }
        }
        public void printList()
        {
            for (int i = 0; i < errors.Count(); i++)
            {
                Console.WriteLine("error (" + i + ") at line " + errors[i].lineNumber + " :" + errors[i].Message);
            }
        }
    }
}
