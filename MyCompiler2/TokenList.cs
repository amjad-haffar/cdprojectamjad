using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompiler2
{
    public class TokenList
    {
        public List<Token> tokens;

        public TokenList()
        {
            tokens = new List<Token>();
        }

        public void addToken(Token tok)
        {
            tokens.Add(tok);
        }

        public void print()
        {
            for(int i=0;i<tokens.Count;i++)
            {
                tokens[i].print();
            }
        }
    }
}
