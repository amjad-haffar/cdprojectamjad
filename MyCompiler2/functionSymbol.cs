using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompiler2
{
    public class functionSymbol
    {
        public string name;
    
        
        //string value;

        public functionSymbol()
        {
         
            name = "";

           
        }
       
        
        public functionSymbol(string n)
        {
            name = n;
         
          

        }

        public void print()
        {
            Console.WriteLine("Name = " + name  );
        }

    }
}
