using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompiler2
{
    public class Lexical
    {
        public TokenList TL;
        string input;
        List<string> keywordLanList;
        List<string> dataTypeLanList;
        int currentLine;

        public Lexical(string txt)
        {
            currentLine = 1;
            input = txt;
            TL = new TokenList();
            keywordLanList = new List<string>();
            dataTypeLanList = new List<string>();

            keywordLanList.Add("cin");
            keywordLanList.Add("cout");
            keywordLanList.Add("if");
            keywordLanList.Add("while");
            keywordLanList.Add("switch");
            keywordLanList.Add("for");
            keywordLanList.Add("else");
            keywordLanList.Add("return");
            keywordLanList.Add("endl");
            keywordLanList.Add("class");
            keywordLanList.Add("main");


            dataTypeLanList.Add("int");
            dataTypeLanList.Add("double");
            dataTypeLanList.Add("bool");
            dataTypeLanList.Add("float");
            dataTypeLanList.Add("String");
            dataTypeLanList.Add("char");
        }

        public void genTokens()
        {

            int index = 0;
            
            while(index<input.Length)
            {
                char ch = input[index];
                
                string tmp = "";
                
                if (ch == '#')
                {
                    while (true)
                    {
                        tmp = tmp + ch;
                        index++;
                        ch = input[index];
                        if (input[index + 1] == '\n')
                        {
                            break;
                        }
                    }

                    Token tok = new Token(Language.Comment, tmp, currentLine);
                    TL.addToken(tok);

                }
                //else if ((ch >= 'a' && ch <= 'z') || (ch >= 'A' && ch <= 'Z'))
                //{
                //    while ((ch >= 'a' && ch <= 'z') || (ch >= 'A' && ch <= 'Z'))
                //    {
                //        tmp = tmp + ch;
                //        if ((index + 1) == input.Length)
                //        {
                //            index++;
                //            break;
                //        }
                //        index++;
                //        ch = input[index];
                //    }

                //    if (keywordLanList.Contains(tmp))
                //    {
                //        Token tok = new Token(Language.Keyword, tmp, currentLine);
                //        TL.addToken(tok);
                //    }
                //    else if (dataTypeLanList.Contains(tmp))
                //    {
                //        Token tok = new Token(Language.DataType, tmp, currentLine);
                //        TL.addToken(tok);
                //    }

                //    else
                //    {

                //        Token tok = new Token(Language.Identifer, tmp, currentLine);
                //        TL.addToken(tok);
                //    }


                //}

                
                //else if (ch >= '0' && ch <= '9')
                    
                //{
                //    bool sss = false;
                //    while (ch >= '0' && ch <= '9')
                //    {
                //        tmp = tmp + ch;
                //        index++;
                //        ch = input[index];
                //    }
                //    if (ch == '.')
                //    {
                //        tmp = tmp + ch;
                //        index++;
                //        ch = input[index];

                //        while ((ch >= '0' && ch <= '9' )|| ch=='.')
                //        {
                //            tmp = tmp + ch;
                //            index++;
                //            ch = input[index];
                //            if (ch == '.')
                //            {
                //                sss = true;
                //            }
                //        }

                //        if (sss)
                //        {
                //            Token tok = new Token(Language.Error, tmp, currentLine);
                //            TL.addToken(tok);
                //        }
                //        else
                //        {
                //            Token tok = new Token(Language.DoubleNumber, tmp, currentLine);
                //            TL.addToken(tok);
                //        }
                //    }
                //    else
                //    {
                //        Token tok = new Token(Language.IntNumber, tmp, currentLine);
                //        TL.addToken(tok);
                //    }


                //}
                else if ((ch >= 'a' && ch <= 'z') || (ch >= 'A' && ch <= 'Z') || (ch >= '0' && ch <= '9'))
                {
                    bool sss = false;
                    while ((ch >= 'a' && ch <= 'z') || (ch >= 'A' && ch <= 'Z') || (ch >= '0' && ch <= '9'))
                    {
                        tmp = tmp + ch;
                       
                        if ((index + 1) == input.Length)
                        {
                            index++;
                            break;
                        }
                        index++;
                        ch = input[index];
                    }
                  
                        if (tmp == "false")
                        {
                            Token tok = new Token(Language.falseBoolean, tmp, currentLine);
                            TL.addToken(tok);
                           
                        }
                    else if (tmp == "true")
                    {
                        Token tok = new Token(Language.trueBoolean, tmp, currentLine);
                        TL.addToken(tok);
                        
                    }




                    else
                    if (tmp.All(char.IsDigit))
                    {
                        if (ch == '.')
                        {
                            tmp = tmp + ch;
                            index++;
                            ch = input[index];

                            while ((ch >= '0' && ch <= '9') || ch == '.')
                            {
                                tmp = tmp + ch;
                                index++;
                                ch = input[index];
                                if (ch == '.')
                                {
                                    sss = true;
                                }
                            }

                            if (sss)
                            {
                                Token tok = new Token(Language.Error, tmp, currentLine);
                                TL.addToken(tok);
                            }
                            else
                            {
                                Token tok = new Token(Language.DoubleNumber, tmp, currentLine);
                                TL.addToken(tok);
                            }
                        }
                        else if (tmp.All(char.IsDigit))//ch!='.' && (ch >= '0' && ch <= '9')
                        {


                            Token tok = new Token(Language.IntNumber, tmp, currentLine);
                            TL.addToken(tok);
                            

                        }
                    }
                    else if (keywordLanList.Contains(tmp))
                    {
                        Token tok = new Token(Language.Keyword, tmp, currentLine);
                        TL.addToken(tok);
                    }
                    else if (dataTypeLanList.Contains(tmp))
                    {
                        Token tok = new Token(Language.DataType, tmp, currentLine);
                        TL.addToken(tok);
                    }
                    else
                    {
                        char rr = tmp.ToCharArray()[0];//(rr >= '0' && rr <= '9')
                        if (rr >= '0' && rr <= '9')
                        {

                            Token tok = new Token(Language.Error, tmp, currentLine);
                            TL.addToken(tok);
                        }
                        else
                        {
                            Token tok = new Token(Language.Identifer, tmp, currentLine);
                            TL.addToken(tok);
                        }

                    }
                }
               
                else if (ch == '\'')
                {
                    tmp = tmp + ch;
                    index++;
                    ch = input[index];
                    while ((ch >= 'a' && ch <= 'z') || (ch >= 'A' && ch <= 'Z') || (ch >= '0' && ch <= '9')||ch==' '|| ch == ';' || ch == ',' || ch == '=' || ch == '.' || ch == '(' || ch == ')' || ch == '{' || ch == '}' || ch == '<' || ch == '>' || ch == '+' || ch == '*' || ch == '/' || ch == '-' || ch == '&' || ch == '|' || ch == '[' || ch == ']'||ch== ':')
                    {
                        tmp = tmp + ch;
                        index++;
                        ch = input[index];
                        while ((ch >= 'a' && ch <= 'z') || (ch >= 'A' && ch <= 'Z') || (ch >= '0' && ch <= '9')|| ch == ' '|| ch == ';' || ch == ',' || ch == '=' || ch == '.' || ch == '(' || ch == ')' || ch == '{' || ch == '}' || ch == '<' || ch == '>' || ch == '+' || ch == '*' || ch == '/' || ch == '-' || ch == '&' || ch == '|' || ch == '[' || ch == ']'||ch== ':')
                        {

                            tmp = tmp + ch;
                            index++;
                            ch = input[index];
                            if (ch == '\'')
                            {
                                tmp = tmp + ch;
                                index++;
                                ch = input[index];
                                Token tmpToken = new Token(Language.String, tmp, currentLine);
                                TL.addToken(tmpToken);
                                break;
                            }

                        }
                         if (ch == '\'')
                        {
                            tmp = tmp + ch;
                            index++;
                            ch = input[index];
                            Token tmpToken = new Token(Language.Char, tmp, currentLine);
                            TL.addToken(tmpToken);
                            break;
                        }break;
                    }
                }
               

                else if (ch == ';' || ch == ',' || ch == '=' || ch == '.' || ch == '(' || ch == ')' || ch == '{' || ch == '}' || ch == '<' || ch == '>' || ch == '+' || ch == '*' || ch == '/' || ch == '-'||ch=='&'||ch=='|'|| ch == '['|| ch == ']')

                {
                    if (ch == '<')
                    {
                        
                        tmp = tmp + ch;
                        index++;
                        ch = input[index];
                        if (input[index] == '<')
                        {
                            tmp = "<<";
                            Token tmpToken = new Token(Language.SpecialChar, tmp, currentLine);
                            TL.addToken(tmpToken);
                            index++;
                        }else if(input[index] == '=')
                        {
                            tmp = "<=";
                            Token tmpToken = new Token(Language.SpecialChar, tmp, currentLine);
                            TL.addToken(tmpToken);
                            index++;
                        }
                       
                        else
                        {
                            Token tmpToken = new Token(Language.SpecialChar, tmp, currentLine);
                            TL.addToken(tmpToken);
                        }
                    }
                    else if(ch == '>')
                    {
                        tmp = tmp + ch;
                        index++;
                        ch = input[index];
                        if (input[index] == '=')
                        {
                            tmp = ">=";
                            Token tmpToken = new Token(Language.SpecialChar, tmp, currentLine);
                            TL.addToken(tmpToken);
                            index++;
                        }
                        else
                        {
                            Token tmpToken = new Token(Language.SpecialChar, tmp, currentLine);
                            TL.addToken(tmpToken);
                        }
                    }else
                    if (ch == '&')
                    {
                        tmp = tmp + ch;
                        index++;
                        ch = input[index];
                        if (input[index] == '&')
                        {
                            tmp = "&&";
                            Token tmpToken = new Token(Language.SpecialChar, tmp, currentLine);
                            TL.addToken(tmpToken);
                            index++;
                        }

                        else
                        {
                            Token tmpToken = new Token(Language.SpecialChar, tmp, currentLine);
                            TL.addToken(tmpToken);
                        }
                    }
                    else
                    {

                        Token tok = new Token(Language.SpecialChar, ch + "", currentLine);
                        TL.addToken(tok);
                        Console.WriteLine(ch);
                        index++;
                    }
                }
            
                else if (ch == '\n')
                {
                    currentLine++;
                    index++;
                }
                else
                {
                    index++;
                }
            
            }

        }

        public void printTokens()
        {
            TL.print();
        }
    }
}
