using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompiler2
{
    class functionSymbol_Table
    {
        public List<functionSymbol> SymbolList;

        public functionSymbol_Table()
        {
            SymbolList = new List<functionSymbol>();
        }

        public void addSymbol(functionSymbol s)
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
 
        public bool searchSymbolbyName3(string name)
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
        public functionSymbol getSymbolByName(string name)
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
