using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompiler2
{
    class Program
    {
        /*
        ر
       */
      
        static void Main(string[] args)
        {
            Parser pars = new Parser(@"class amjad {
String dd(int y,int o,int h,int j){}
int main(){
int v;
int h;
int k;
int j;
dd(v,h,k);
}");

        }
    }
}
