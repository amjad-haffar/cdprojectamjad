using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompiler2
{

    public class Parser
    {
        SymbolTable ST;
        functionSymbol_Table ST1;
        FunctionParamterSymbol_Table ST2;
        ErrorList EL;
        int scopeCounter;
        Lexical lex;
        int counter;
        int counter2;
        bool programStatus;
        int indexarrynumber;
        int index;

        public Parser(string input)
        {
            lex = new Lexical(input);
            programStatus = true;
            lex.genTokens();
            lex.printTokens();
            ST = new SymbolTable();
            ST1 = new functionSymbol_Table();
            ST2 = new FunctionParamterSymbol_Table();
            EL = new ErrorList();
            scopeCounter = 0;
            indexarrynumber = 1;
            counter = 1;
            counter2 = 1;
            index = 0;
            checkGrammer();
            EL.printList();
        }
        public void checkGrammer()
        {
            if (StartProgram() == true)
            {
                Console.WriteLine("True");
            }
            else
            {
                Console.WriteLine("False");
            }
        }
        public bool StartProgram()
        {
            if (lex.TL.tokens[index].value == "class")
            {
                index++;
                if (lex.TL.tokens[index].type == Language.Identifer)
                {
                    index++;
                    if (lex.TL.tokens[index].value == "{")
                    {
                        index++;
                        if (Methods())
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        //methodes
        public bool Methods()
        {
            if (MainMethod())
            {
                return true;
            }
            if (MethodList())
            {
                if (MainMethod())
                {
                    return true;
                }
            }

            return false;

        }
        public bool MethodList()
        {
            if (Method())
            {
                return true;
            }
            return false;
        }
        public bool Method()
        {
            if (lex.TL.tokens[index].type == Language.DataType)
            {
                index++;
                Token tmpIdToken = lex.TL.tokens[index];
                functionSymbol s = new functionSymbol(tmpIdToken.value);
                if (lex.TL.tokens[index].type == Language.Identifer)
                {
                    String h = lex.TL.tokens[index].value;
                    //   functionSymbol s = new functionSymbol(tmpIdToken.value, scopeCounter);
                    index++;
                    if (lex.TL.tokens[index].value == "(")
                    {
                        index++;
                        if (Params(tmpIdToken.value))
                        {
                            ST1.addSymbol(s);
                            if (lex.TL.tokens[index].value == ")")
                            {
                                index++;
                                if (lex.TL.tokens[index].value == "{")
                                {
                                    index++;
                                    if (StmtList())
                                    {
                                        if (lex.TL.tokens[index].value == "}")
                                        {
                                            index++;
                                            return true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return false;
        }
        public bool Params(String tmpIdToken)
        {
            if (Parameter(tmpIdToken))
            {
                if (PP(tmpIdToken))
                {

                   
                        if (PP(tmpIdToken))
                        {

                        if (PP(tmpIdToken))
                        {

                            return true;
                        }

                    }

                }
            }
            return false;
        }
        public bool Parameter(String tmpIdToken)
        {

            
            if (lex.TL.tokens[index].type == Language.DataType)
            {
                Token Datatype = lex.TL.tokens[index];
                index++;
                if (lex.TL.tokens[index].type == Language.Identifer)
                {

                    Console.WriteLine("function parameter count is" + counter);
                    functionParamterSymbol s1 = new functionParamterSymbol(Datatype.value, lex.TL.tokens[index].value, tmpIdToken, counter);
                    ST2.addSymbol(s1);

                    counter++;
                    index++;
                    return true;
                }
                else { return false; }
            }
            if (lex.TL.tokens[index].value == ")")
            {

            

                return true;
            }
            return false;
        }
        public bool PP(string tmpIdToken)
        {

            if (lex.TL.tokens[index].value == ",")
            {

                index++;
                if (Parameter(tmpIdToken))
                {

                    return true;
                }
                else { return false; }
            }
            if (lex.TL.tokens[index].value == ")")
            {

                return true;
            }
            return false;

        }
        public bool MainMethod()
        {
        cc:
            if (lex.TL.tokens[index].value == "int")
            {
            ff: index++;
                if (lex.TL.tokens[index].type == Language.Keyword)
                {
                dd: index++;
                    if (lex.TL.tokens[index].value == "(")
                    {
                    xx: index++;
                        if (lex.TL.tokens[index].value == ")")
                        {
                        cx: index++;
                            if (lex.TL.tokens[index].value == "{")
                            {
                                index++;
                                scopeCounter++;
                                if (StmtList())
                                {
                                    if (lex.TL.tokens[index].value == "}")
                                    {
                                        index++;
                                        ST.deleteSymbolsByScope(scopeCounter);
                                        Symbol.flag = false;
                                        scopeCounter--;
                                        return true;
                                    }
                                    else
                                    {
                                        Console.WriteLine("ERRoR forget } ");
                                        lex.TL.tokens[index].value = "}";
                                        index--;
                                        //goto cx;

                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("ERRoR forget { ");
                                lex.TL.tokens[index].value = "{";
                                index--;
                                //goto cx;
                            }
                        }
                        else
                        {
                            Console.WriteLine("ERRoR forget ) ");
                            lex.TL.tokens[index].value = ")";
                            index--;
                            //goto xx;

                        }
                    }
                    else
                    {
                        Console.WriteLine("ERRoR forget ( ");
                        lex.TL.tokens[index].value = "(";
                        index--;
                        //goto dd;
                    }
                }
                else
                {
                    //Console.WriteLine("ERRoR must be main  ");
                    lex.TL.tokens[index].value = "main";
                    index--;
                    //goto ff;
                }
            }
            else
            {

                Console.WriteLine("ERRoR must be int  ");
                lex.TL.tokens[index].value = "int";
                //goto cc;

            }
            return false;
        }
        //statments
        public bool StmtList()
        {
            if (lex.TL.tokens[index].value == "}")
            {
                return true;
            }
            if (Stmt())
            {
                if (StmtList())
                {
                    return true;
                }
            }
            return false;
        }
        public bool Stmt()
        {
            if (lex.TL.tokens[index].value == "else")
            {
                EL.adderror(new Error(lex.TL.tokens[index].line, "if statment expected", ""));
                return false;
            }
            else
            if (lex.TL.tokens[index].value == "cout")
            {
                if (OutputStmt())
                {
                    return true;
                }
            }
            else if (lex.TL.tokens[index].value == "cin")
            {
                if (InputStmt())
                {
                    return true;
                }
            }
            else if (lex.TL.tokens[index].type == Language.DataType)
            {

                if (DefinintionStmt())
                {
                    return true;
                }
                //definition
            }
            else if (lex.TL.tokens[index].type == Language.Identifer)
            {
                Token tmp = lex.TL.tokens[index];
                if (Exp(tmp.value))
                {
                    if (lex.TL.tokens[index].value == ";")
                    {
                        index++;
                        return true;
                    }
                }
                if (Callfunction())
                {
                    return true;
                }

            }

            else if (lex.TL.tokens[index].value == "for" || lex.TL.tokens[index].value == "while")
            {
                if (Exprloop())
                {
                    return true;
                }
            }
            else if (lex.TL.tokens[index].value == "if")
            {
                if (ifs())
                {
                    return true;
                }
            }
            else
            {
                EL.adderror(new Error(lex.TL.tokens[index].line, "wrong start of statment", ""));
                for (int search = index; search < lex.TL.tokens.Count; search++)
                {
                    Console.WriteLine(lex.TL.tokens[index].value);
                    if (lex.TL.tokens[search].value == ";" || lex.TL.tokens[search].value == "}")
                    {
                        index = search;
                        break;
                    }
                }
                //return false;
            }
            return false;
        }
        public bool loop2()
        {
            if (lex.TL.tokens[index].value == ";")
            {
                index++;
                return true;
            }
            else if (lex.TL.tokens[index].value == ">")
            {
                index++;
                if (lex.TL.tokens[index].value == ">")
                {
                    index++;
                    if (lex.TL.tokens[index].type == Language.Identifer)
                    {
                        index++;
                        if (loop2())
                        {
                            return true;
                        }
                    }
                }
            }
            return false;

        }
        //declare
        public bool DefinintionStmt()
        {
            Token tmpTypeToken = lex.TL.tokens[index];
            if (lex.TL.tokens[index].type == Language.DataType)
            {
                index++;
                if (Ds2(tmpTypeToken.value))
                {
                    if (loopdec(tmpTypeToken.value))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public bool loopdec(string tmptype)
        {
            if (lex.TL.tokens[index].value == ";")
            {
                index++;
                indexarrynumber = 1;
                return true;
            }
            else
                if (lex.TL.tokens[index].value == ",")
            {
                index++;
                if (Ds2(tmptype))
                {
                    if (loopdec(tmptype))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public bool Ds2(string tmptype)
        {
            Token tmpIdToken = lex.TL.tokens[index];
            if (lex.TL.tokens[index].type == Language.Identifer)
            {
                Symbol s = new Symbol(tmpIdToken.value, tmptype, scopeCounter);
                if (!ST.searchSymbolByName(tmpIdToken.value))
                {
                    index++;
                    if (lex.TL.tokens[index].value == "=")
                    {
                        index++;
                        if (SimpleExp(tmptype))
                        {
                            ST.addSymbol(s);
                            ST.print();
                            return true;
                        }
                    }
                    else if (lex.TL.tokens[index].value == "[")
                    {
                        index++;
                        if (E(tmptype))
                        {
                            return true;
                        }
                    }
                    else
                    {
                        ST.addSymbol(s);
                        ST.print();
                        return true;
                    }
                }
                else if (ST.searchSymbolbyName2(tmpIdToken.value, scopeCounter))
                {
                    if (!ST.searchSymbolbyName3(tmpIdToken.value, scopeCounter))
                    {
                        index++;
                        if (lex.TL.tokens[index].value == "=")
                        {
                            index++;
                            if (SimpleExp(tmptype))
                            {
                                ST.addSymbol(s);
                                ST.print();
                                return true;
                            }
                        }
                        else if (lex.TL.tokens[index].value == "[")
                        {
                            index++;
                            if (E(tmptype))
                            {
                                return true;
                            }
                        }
                        else
                        {
                            ST.addSymbol(s);
                            ST.print();
                            return true;
                        }

                    }
                    else if (ST.searchSymbolbyName3(tmpIdToken.value, scopeCounter))
                    {

                        Console.WriteLine("ERRor in name");
                    }

                }
                else if (ST.searchSymbolByName(tmpIdToken.value))
                {

                    Console.WriteLine("ERRor in name");
                }
            }
            return false;
        }
        public bool E(string tmptype)
        {

            if (lex.TL.tokens[index].type == Language.IntNumber)
            {
                Token tmpTypeToken = lex.TL.tokens[index];
                var indexnumber = tmpTypeToken.value;
                index++;
                if (lex.TL.tokens[index].value == "]")
                {
                    index++;
                    if (lex.TL.tokens[index].value == "=")
                    {
                        index++;
                        if (ArrayIndex(tmptype, indexnumber))
                        {
                            return true;
                        }
                    }
                    else if (lex.TL.tokens[index].value == "[")
                    {
                        index++;
                        if (E(tmptype))
                        {
                            return true;
                        }
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        //if
        public bool ifs()
        {
            if (lex.TL.tokens[index].value == "if")
            {
                index++;
                if (lex.TL.tokens[index].value == "(")
                {
                    index++;
                    Token tmpTypeToken = lex.TL.tokens[index];
                    if (Exp(tmpTypeToken.value))
                    {
                        if (lex.TL.tokens[index].value == ")")
                        {
                            index++;
                            if (lex.TL.tokens[index].value == "{")
                            {
                                index++;

                                scopeCounter++;
                                if (ifs())
                                {
                                    if (lex.TL.tokens[index].value == "}")
                                    {
                                        index++;
                                        ST.deleteSymbolsByScope(scopeCounter);
                                        Symbol.flag = false;
                                        scopeCounter--;
                                        if (lex.TL.tokens[index].value == "else")
                                        {
                                            index++;
                                            if (lex.TL.tokens[index].value == "{")
                                            {
                                                index++;

                                                scopeCounter++;
                                                if (ifs())
                                                {
                                                    if (lex.TL.tokens[index].value == "}")
                                                    {
                                                        index++;
                                                        ST.deleteSymbolsByScope(scopeCounter);
                                                        Symbol.flag = false;
                                                        scopeCounter--;
                                                        return true;
                                                    }
                                                }
                                            }
                                        }
                                        return true;
                                    }
                                }

                            }
                        }
                    }
                }
            }
            else if (StmtList())
            {
                return true;
            }
            return false;
        }
        //loops
        public bool Exprloop()
        {
            if (lex.TL.tokens[index].value == "for" || lex.TL.tokens[index].value == "while")
            {
                if (lex.TL.tokens[index].value == "for")
                {
                    index++;
                    if (lex.TL.tokens[index].value == "(")
                    {
                        index++;
                        if (DefinintionStmt())
                        {
                            Token tmpTypeToken = lex.TL.tokens[index];
                            if (Exp(tmpTypeToken.value))
                            {
                                if (lex.TL.tokens[index].value == ";")
                                {
                                    index++;
                                    Token tmpTypeToken2 = lex.TL.tokens[index];
                                    if (Exp(tmpTypeToken2.value))
                                    {
                                        if (lex.TL.tokens[index].value == ")")
                                        {
                                            index++;
                                            if (lex.TL.tokens[index].value == "{")
                                            {
                                                index++;
                                                scopeCounter++;
                                                if (StmtList())
                                                {
                                                    if (lex.TL.tokens[index].value == "}")
                                                    {
                                                        index++;
                                                        ST.deleteSymbolsByScope(scopeCounter);
                                                        Symbol.flag = false;
                                                        scopeCounter--;
                                                        return true;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else
                    if (lex.TL.tokens[index].value == "while")
                {
                    index++;
                    if (lex.TL.tokens[index].value == "(")
                    {
                        index++;
                        Token tmpTypeToken = lex.TL.tokens[index];
                        if (Exp(tmpTypeToken.value))
                        {

                            if (lex.TL.tokens[index].value == ")")
                            {
                                index++;
                                if (lex.TL.tokens[index].value == "{")
                                {
                                    index++;

                                    scopeCounter++;
                                    if (StmtList())
                                    {
                                        if (lex.TL.tokens[index].value == "}")
                                        {
                                            index++;
                                            ST.deleteSymbolsByScope(scopeCounter);
                                            Symbol.flag = false;
                                            scopeCounter--;
                                            return true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            //else if (StmtList())
            //{
            //    return true;
            //}
            return false;
        }
        //call function
        public bool Callfunction()
        {
            Token gg = lex.TL.tokens[index];
            if (ST1.searchSymbolbyName3(lex.TL.tokens[index].value))
            {
                index++;
                if (lex.TL.tokens[index].value == "(")
                {
                    index++;
                    if (CallParams(gg.value))
                    {
                        if (ST2.searchSymbolbyCountparamter3()== counter2)
                        {
                            if (lex.TL.tokens[index].value == ")")
                            {
                                index++;
                                if (lex.TL.tokens[index].value == ";")
                                {
                                    index++;
                                    return true;

                                }
                            }
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Error no function with this name");
                return false;

            }
            return false;
        }
        public bool CallParams(string name)
        {
            if (Passvalue(name))
            {
                if (PV(name))
                {
                    if (PV(name))
                    {
                        if (PV(name))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        public bool Passvalue(string name)
        {

            if (lex.TL.tokens[index].type == Language.Identifer)
            {
                if (ST2.searchSymbolbyNamefunction2(name))
                {
                    if (ST.searchSymbolByName(lex.TL.tokens[index].value))
                    {
                      
                         //  Console.WriteLine();
                            index++;
                            return true;
                        
                    }
                }

                

            }
            if (Values() != "")
            {
                return true;
            }
            return false;
        }
        public bool PV(string name)
        {
            if (lex.TL.tokens[index].value == ",")
            {

                index++;
                if (Passvalue(name))
                {
                    counter2++;
                    return true;
                }
                else { return false; }
            }
            if (lex.TL.tokens[index].value == ")")
            {
                return true;
            }
            return false;
        }
        //EXP
        public bool condition()
        {
            Token tmp = lex.TL.tokens[index];
            if (lex.TL.tokens[index].value == "(" || lex.TL.tokens[index].type == Language.Identifer || lex.TL.tokens[index].type == Language.IntNumber || lex.TL.tokens[index].type == Language.trueBoolean || lex.TL.tokens[index].type == Language.String || lex.TL.tokens[index].type == Language.Char)
            {

                if (SimpleExp(tmp.value))
                {
                    if (CompareOp())
                    {
                        if (SimpleExp(tmp.value))
                        {
                            return true;
                        }
                    }

                }
            }
            return false;

        }
        public bool Exp(String tmptype)
        {
            if (lex.TL.tokens[index].value == "(" || lex.TL.tokens[index].type == Language.Identifer || lex.TL.tokens[index].type == Language.IntNumber || lex.TL.tokens[index].type == Language.trueBoolean || lex.TL.tokens[index].type == Language.String || lex.TL.tokens[index].type == Language.Char)
            {
                if (SimpleExp(tmptype))
                {
                    if (CompareOp())
                    {
                        if (SimpleExp(tmptype))
                        {
                            return true;
                        }
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            return false;

        }
        public bool CompareOp()
        {
            if (lex.TL.tokens[index].value == ">")
            {
                index++;
                return true;
            }
            else
            if (lex.TL.tokens[index].value == "<")

            {
                index++;
                return true;
            }
            else if (lex.TL.tokens[index].value == "is")

            {
                index++;
                return true;
            }

            else if (lex.TL.tokens[index].value == "not")

            {
                index++;
                return true;
            }
            else if (lex.TL.tokens[index].value == "<=")

            {
                index++;
                return true;
            }
            else if (lex.TL.tokens[index].value == ">=")

            {
                index++;
                return true;
            }
            return false;
        }
        public bool SimpleExp(string tmptype)
        {
            if (Term(tmptype))
            {
                if (SimpleExpPrime(tmptype))
                {
                    return true;
                }
            }
            return false;
        }
        public bool SimpleExpPrime(string tmptype)
        {
            if (AddOp())
            {
                if (Term(tmptype))
                {
                    if (SimpleExpPrime(tmptype))
                    {

                        return true;
                    }

                }
            }
            else
            {
                return true;
            }
            return false;
        }
        public bool AddOp()
        {
            if (lex.TL.tokens[index].value == "+")
            {
                index++;
                return true;
            }
            else if (lex.TL.tokens[index].value == "-")
            {
                index++;
                return true;
            }
            return false;
        }
        public bool BooleanOp()
        {
            if (lex.TL.tokens[index].value == "and")
            {
                index++;
                return true;
            }
            else if (lex.TL.tokens[index].value == "or")
            {
                index++;
                return true;
            }
            return false;
        }
        public bool Term(string tmptype)
        {

            if (Factor(tmptype))
            {
                if (TermPrime(tmptype))
                {
                    return true;
                }
            }
            return false;
        }
        public bool TermPrime(string tmptype)
        {
            if (MulOp())
            {
                if (Factor(tmptype))
                {
                    if (TermPrime(tmptype))
                    {
                        return true;
                    }
                }
            }
            else
            {
                return true;
            }
            return false;
        }
        public bool MulOp()
        {
            if (lex.TL.tokens[index].value == "*")
            {
                index++;
                return true;
            }
            else if (lex.TL.tokens[index].value == "/")
            {
                index++;
                return true;
            }
            else if (lex.TL.tokens[index].value == "%")
            {
                index++;
                return true;
            }
            return false;
        }
        public bool Factor(string tmptype)
        {
            if (Factor2(tmptype))
            {
                return true;
            }
            else if (lex.TL.tokens[index].value == "-")
            {
                index++;
                if (Factor2(tmptype))
                {
                    return true;
                }
            }
            else
               if (Boolean())
            {
                return true;
            }
            return false;
        }
        public bool Boolean()
        {
            if (lex.TL.tokens[index].type == Language.trueBoolean)
            {
                index++;
                return true;
            }
            else
              if (lex.TL.tokens[index].type == Language.falseBoolean)
            {
                index++;
                return true;
            }
            return false;

        }
        public bool Factor2(string tmptype)
        {
            Token tmpIdToken = lex.TL.tokens[index];
            if (lex.TL.tokens[index].value == "(")
            {
                index++;
                if (SimpleExp(tmptype))
                {
                    if (lex.TL.tokens[index].value == ")")
                    {
                        index++;
                        return true;
                    }
                }
            }

            else
            {
                string valRes = Values();

                if (valRes != "")
                {
                    if (valRes == tmptype)
                    {
                        return true;
                    }
                    else if (ST.searchSymbolByName(tmptype))
                    {
                        Console.WriteLine("find the type");
                        return true;
                    }
                    else if (lex.TL.tokens[index - 2].value == "<<")
                    {

                        return true;

                    }
                    else
                    {
                        Console.WriteLine("Error type");
                        Console.WriteLine(tmptype);
                        return false;
                    }
                }
                else
                if (lex.TL.tokens[index].type == Language.Identifer)
                {
                    if (ST.searchSymbolByName(lex.TL.tokens[index].value))
                    {
                        index++;
                        return true;
                    }

                    else
                    {
                        Console.WriteLine("Error you must Declare " + lex.TL.tokens[index].value);
                        return false;
                    }
                }
            }

            return false;
        }
        public bool ArrayIndex(string tmptype, string indexnumber)
        {
            if (lex.TL.tokens[index].value == "{")
            {
                index++;
                if (Element(tmptype, indexnumber))
                {
                    if (lex.TL.tokens[index].value == "}")
                    {
                        index++;
                        return true;
                    }
                }

                if (lex.TL.tokens[index].value == "}")
                {
                    index++;
                    return true;
                }
            }
            return false;
        }
        public bool Element(string tmptype, string indexnumber)
        {
            if (!(indexarrynumber > Convert.ToInt32(indexnumber)))
            {
                if (ArryVal(tmptype, indexnumber))
                {

                    if (lex.TL.tokens[index].value == ",")
                    {
                        indexarrynumber++;
                        index++;
                        if (Element(tmptype, indexnumber))
                        {
                            return true;
                        }

                    }
                    return true;
                }

            }
            else
            {
                Console.WriteLine("ERRoR in index ARRy");
                return false;
            }

            return false;
        }
        public bool ArryVal(string tmptype, string indexnumber)
        {
            if (ArrayIndex(tmptype, indexnumber))
            {
                return true;
            }
            else
            {
                String val = Values();
                if (val != "")
                {
                    if (val == tmptype)
                    {
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("ERROR in type of value in index arry");
                        return false;
                    }
                }
            }
            return false;
        }
        public bool outputvalue(string tmptype)
        {

            if (lex.TL.tokens[index].value == "(" || lex.TL.tokens[index].type == Language.Identifer || lex.TL.tokens[index].type == Language.IntNumber || lex.TL.tokens[index].type == Language.trueBoolean || lex.TL.tokens[index].type == Language.falseBoolean || lex.TL.tokens[index].type == Language.String || lex.TL.tokens[index].type == Language.Char)
            {
                if (SimpleExp(tmptype))
                {


                    return true;


                }
            }
            return false;

        }
        // io
        public bool InputStmt()
        {
            if (lex.TL.tokens[index].value == "cin")
            {
                index++;
                if (lex.TL.tokens[index].value == ">")
                {
                    index++;
                    if (lex.TL.tokens[index].value == ">")
                    {
                        index++;
                        if (lex.TL.tokens[index].type == Language.Identifer)
                        {
                            index++;
                            if (loop2())
                            {
                                return true;
                            }
                        }

                    }
                }
            }
            return false;
        }
        public bool OutputStmt()
        {

            if (lex.TL.tokens[index].value == "cout")
            {
                index++;
                if (lex.TL.tokens[index].value == "<<")
                {

                    index++;
                    Token tmpTypeToken = lex.TL.tokens[index];
                    if (outputvalue(tmpTypeToken.value))
                    {
                        if (Loop())
                        {
                            return true;
                        }

                    }

                }

            }
            return false;
        }
        public bool Loop()
        {

            if (lex.TL.tokens[index].value == ";")
            {
                index++;
                return true;
            }
            else

                if (lex.TL.tokens[index].value == "<<")
            {


                index++;
                Token tmpTypeToken = lex.TL.tokens[index];
                if (outputvalue(tmpTypeToken.value))
                {
                    if (Loop())
                    {
                        return true;
                    }
                }

            }
            return false;
        }
        public String Values()
        {
            if (lex.TL.tokens[index].type == Language.IntNumber)
            {
                index++;
                return "int";
            }

            else if (lex.TL.tokens[index].type == Language.DoubleNumber)
            {
                index++;
                return "double";
            }
            else if (lex.TL.tokens[index].type == Language.falseBoolean)
            {
                index++;
                return "bool";
            }
            else if (lex.TL.tokens[index].type == Language.trueBoolean)
            {
                index++;
                return "bool";
            }
            else if (lex.TL.tokens[index].type == Language.String)
            {
                index++;
                return "String";
            }
            else if (lex.TL.tokens[index].type == Language.Char)
            {
                index++;
                return "char";
            }
            else
            {
                return "";
            }
        }
    }
}
