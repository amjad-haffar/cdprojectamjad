using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompiler2
{
    public class SymbolTable
    {
        public List<Symbol> SymbolList;

        public SymbolTable()
        {
            SymbolList = new List<Symbol>();
        }

        public void addSymbol(Symbol s)
        {
            SymbolList.Add(s);
        }

        public void deleteSymbolsByScope(int scope)
        {
            for (int i = 0; i < SymbolList.Count; i++)
            {
                if (SymbolList[i].scope == scope)
                {
                    SymbolList.RemoveAt(i);


                }
            }

        }

        public bool searchSymbolByName(string name )
        {
            for (int i = 0; i < SymbolList.Count; i++)
            {
                if (SymbolList[i].name == name )
                {
                    return true;
                }
            }
            return false;
        }
        public bool searchSymbolbyName2(string name, int scope)
        {
            for (int i = SymbolList.Count - 1; i >= 0; i--)
            {
                if (SymbolList[i].name == name && SymbolList[i].scope > scope)
                {
                    return true;
                }
            }
            return false;
        }
        public bool searchSymbolbyName3(string name, int scope)
        {
            for (int i = SymbolList.Count - 1; i >= 0; i--)
            {
                if (SymbolList[i].name == name && SymbolList[i].scope == scope)
                {
                    return true;
                }
            }
            return false;
        }
        public Symbol getSymbolByName(string name)
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
