using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompiler2
{
    class FunctionParamterSymbol_Table
    {
        public List<functionParamterSymbol> SymbolList;

        public FunctionParamterSymbol_Table()
        {
            SymbolList = new List<functionParamterSymbol>();
        }

        public void addSymbol(functionParamterSymbol s)
        {
            SymbolList.Add(s);
        }

 

        public bool searchSymbolByName(string name)
        {
            for (int i = 0; i < SymbolList.Count; i++)
            {
                if (SymbolList[i].name == name)
                {
                    return true;
                }
            }
            return false;
        }
        public bool searchSymbolbyName2(string name)
        {
            for (int i = SymbolList.Count - 1; i >= 0; i--)
            {
                if (SymbolList[i].name == name )
                {
                    return true;
                }
            }
            return false;
        }
        public bool searchSymbolbyCountparamter2(int count)
        {
            for (int i = SymbolList.Count - 1; i >= 0; i--)
            {
                if (SymbolList[i].parameterCount == count)
                {
                    return true;
                }
            }
            return false;
        }
        public int searchSymbolbyCountparamter3()
        {

            return SymbolList.Count;
           
           
        }
        public bool searchSymbolbyNamefunction2(string name)
        {
            for (int i = SymbolList.Count - 1; i >= 0; i--)
            {
                if (SymbolList[i].functionname == name)
                {
                    return true;
                }
            }
            return false;
        }

        public functionParamterSymbol getSymbolByName(string name)
        {
            for (int i = SymbolList.Count - 1; i >= 0; i--)
            {
                if (SymbolList[i].name == name)
                {
                    return SymbolList[i];
                }
            }
            return null;
        }

        public void print()
        {
            for (int i = 0; i < SymbolList.Count; i++)
            {
                SymbolList[i].print();
            }
        }
    
}
}
