using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Authentication.ExtendedProtection;
using System.Text;
using System.Threading.Tasks;

namespace NewCompiler
{

    public enum ParserResultStatus
    {
        EmptyString,
        IsDuplicate,
        
        NoConst,
        NoIdent,
        NoColon,
        NoType,
        NoEquals,
        NoNumber,
        NumberError,
        NoSemicolon,

        InvalidSymbol,      
        Success,
    }
    internal class Parser
    {
        private TranslationManager translationManager;

        private ParserResultStatus parserResultStatus = ParserResultStatus.Success;
      
        public enum State
        {
            Start,    
            ExpectIdent,
            ExpectColon,
            ExpectType,
            ExpectEquals,
            ExpectNumber,
            ExpectSemicolon,
            Error,
            Accept

        }
        public Parser(TranslationManager translationManager)
        {
            this.translationManager = translationManager;
        }


        public List<ResultItem> ValidateTokens(List<Token> tokens)
        {              
            List<ResultItem> resultList = new List<ResultItem>();

            ResultItem resultItem;    
            string resultMessage;

            bool NoGlobalSemiColon = false;
            int emptySemiColonIndex = -1;
       
            if (tokens.Count == 0)
            {
                parserResultStatus = ParserResultStatus.EmptyString;
                resultMessage = GetResultMessage(parserResultStatus);

                resultItem = new ResultItem(resultMessage, 0);
                resultList.Add(resultItem);
                return resultList;
            }

            State currentState = State.Start;

            for (int i = 0; i < tokens.Count; i++)
            {
                Token token = tokens[i];
                switch (currentState)
                {
                    case State.Start:

                        if (WhiteSpaceNewLineCheck(token)) continue;
                        
                        if (token.Type == TokenType.TOKEN_CONST)
                        {

                            if (NoGlobalSemiColon)
                            {
                                parserResultStatus = ParserResultStatus.NoSemicolon;
                                resultMessage = GetResultMessage(parserResultStatus);
                                resultItem = new ResultItem(resultMessage, emptySemiColonIndex + 1);
                                resultList.Add(resultItem);
                                NoGlobalSemiColon = false;
                            }

                            int tokenIndex = i;
                            int neighborIndex = i;
                            bool noIdent = true, noColon = true, noSemiColon = true;
                                                   
                            Token neighborToken;

                            for (int j = i + 1; j < tokens.Count && neighborIndex <= tokenIndex + 6; j++)
                            {
                                neighborToken = tokens[j];

                                if (WhiteSpaceNewLineCheck(neighborToken)) continue;

                                neighborIndex++;
                                if (neighborToken.Type == TokenType.TOKEN_ERROR)
                                {
                                    parserResultStatus = ParserResultStatus.InvalidSymbol;
                                    resultMessage = GetResultMessage(parserResultStatus, neighborToken.Value);                                    
                                    AddUniqueError(resultList, resultMessage, neighborToken.StartPosition);                                                                                                   
                                    continue;
                                }
                               
                                if (neighborToken.Type == TokenType.TOKEN_SEMICOLON) noSemiColon = false;

                                if (neighborIndex == tokenIndex + 1 && neighborToken.Type == TokenType.TOKEN_IDENT)
                                {
                                    noIdent = false;
                                    noColon = false;
                                }

                                if (neighborIndex == tokenIndex + 1 && neighborToken.Type == TokenType.TOKEN_COLON) noColon = false;

                            }

                            if (noIdent)
                            {
                                parserResultStatus = ParserResultStatus.NoIdent;
                                resultMessage = GetResultMessage(parserResultStatus);
                                resultItem = new ResultItem(resultMessage, token.EndPosition + 1);
                                resultList.Add(resultItem);                               
                            }

                            if (noColon)
                            {
                                parserResultStatus = ParserResultStatus.NoColon;
                                resultMessage = GetResultMessage(parserResultStatus);
                                resultItem = new ResultItem(resultMessage, token.EndPosition + 1);
                                resultList.Add(resultItem);
                            }

                            if (noSemiColon)
                            {
                                if (!NoGlobalSemiColon) NoGlobalSemiColon = true;
                                emptySemiColonIndex = token.EndPosition;
                            }
                          
                            currentState = State.ExpectIdent;
                        }
                        else
                        {
                            i--;
                            currentState = ChangeState(token);
                        }
                        break;



                    case State.ExpectIdent:

                        if (WhiteSpaceNewLineCheck(token)) continue;
                        
                        if (token.Type == TokenType.TOKEN_IDENT)
                        {
                            int tokenIndex = i;
                            int neighborIndex = i;
                            Token neighborToken;
                            bool noConst = true, noColon = true, noSemiColon = true;
                            
                            for (int j = i + 1; j < tokens.Count && neighborIndex <= tokenIndex + 5; j++)
                            {
                                neighborToken = tokens[j];

                                if (WhiteSpaceNewLineCheck(neighborToken)) continue;

                                neighborIndex++;

                                if (neighborToken.Type == TokenType.TOKEN_ERROR)
                                {
                                    parserResultStatus = ParserResultStatus.InvalidSymbol;
                                    resultMessage = GetResultMessage(parserResultStatus, neighborToken.Value);
                                    AddUniqueError(resultList, resultMessage, neighborToken.StartPosition);
                                    continue;
                                }                              

                                if (neighborToken.Type == TokenType.TOKEN_SEMICOLON) noSemiColon = false;

                                if (neighborIndex == tokenIndex + 1 && neighborToken.Type == TokenType.TOKEN_COLON) noColon = false;                               
                            }

                            neighborIndex = i;

                            for (int j = i - 1; j >= 0; j--)
                            {
                                neighborToken = tokens[j];

                                if (WhiteSpaceNewLineCheck(neighborToken)) continue;
                                
                                neighborIndex--;

                                if (neighborIndex + 1 == tokenIndex && neighborToken.Type == TokenType.TOKEN_CONST)
                                {
                                    noConst = false;
                                    break;
                                }                               
                            }

                            if (noConst)
                            {
                                parserResultStatus = ParserResultStatus.NoConst;
                                resultMessage = GetResultMessage(parserResultStatus);
                                resultItem = new ResultItem(resultMessage, token.StartPosition);
                                resultList.Add(resultItem);
                            }

                            if (noColon)
                            {
                                parserResultStatus = ParserResultStatus.NoColon;
                                resultMessage = GetResultMessage(parserResultStatus);
                                resultItem = new ResultItem(resultMessage, token.EndPosition + 1);
                                resultList.Add(resultItem);
                            }

                            if (noSemiColon)
                            {
                                if (!NoGlobalSemiColon) NoGlobalSemiColon = true;
                                emptySemiColonIndex = token.EndPosition;
                            }

                            currentState = State.ExpectColon;
                        }
                        else
                        {
                            i--;
                            currentState = ChangeState(token);
                        }
                        break;


                    case State.ExpectColon:

                        if (WhiteSpaceNewLineCheck(token)) continue;
                        
                        if (token.Type == TokenType.TOKEN_COLON)
                        {
                            int tokenIndex = i;
                            int neighborIndex = i;
                            Token neighborToken;

                            bool noIdent = true, noType = true, noSemiColon = true;
                            
                            for (int j = i + 1; j < tokens.Count && neighborIndex <= tokenIndex + 4; j++)
                            {
                                neighborToken = tokens[j];

                                if (WhiteSpaceNewLineCheck(neighborToken)) continue;

                                neighborIndex++;

                                if (neighborToken.Type == TokenType.TOKEN_ERROR)
                                {
                                    parserResultStatus = ParserResultStatus.InvalidSymbol;
                                    resultMessage = GetResultMessage(parserResultStatus, neighborToken.Value);
                                    AddUniqueError(resultList, resultMessage, neighborToken.StartPosition);
                                    continue;
                                }

                                if (neighborToken.Type == TokenType.TOKEN_SEMICOLON) noSemiColon = false;

                                if (neighborIndex == tokenIndex + 1 && neighborToken.Type == TokenType.TOKEN_INTEGER) noType = false;
                              
                            }

                            neighborIndex = i;

                            for (int j = i - 1; j >= 0; j--)
                            {
                                neighborToken = tokens[j];

                                if (WhiteSpaceNewLineCheck(neighborToken)) continue;
                                
                                neighborIndex--;

                                if (neighborIndex + 1 == tokenIndex && neighborToken.Type == TokenType.TOKEN_IDENT) 
                                {                                   
                                    noIdent = false;                       
                                    break;
                                }

                                if (neighborIndex + 1 == tokenIndex && neighborToken.Type == TokenType.TOKEN_CONST)
                                {
                                    noIdent = false;
                                    break;
                                }
                            }

                            if (noIdent)
                            {
                                parserResultStatus = ParserResultStatus.NoIdent;
                                resultMessage = GetResultMessage(parserResultStatus);
                                resultItem = new ResultItem(resultMessage, token.StartPosition);
                                resultList.Add(resultItem);
                            }

                            if (noType)
                            {
                                parserResultStatus = ParserResultStatus.NoType;
                                resultMessage = GetResultMessage(parserResultStatus);
                                resultItem = new ResultItem(resultMessage, token.EndPosition + 1);
                                resultList.Add(resultItem);
                            }

                            if (noSemiColon)
                            {
                                if (!NoGlobalSemiColon) NoGlobalSemiColon = true;                               
                                emptySemiColonIndex = token.EndPosition;
                            }

                            currentState = State.ExpectType;
                        }
                        else
                        {
                            i--;
                            currentState = ChangeState(token);
                        }
                        break;



                    case State.ExpectType:

                        if (WhiteSpaceNewLineCheck(token)) continue;
                        
                        if (token.Type == TokenType.TOKEN_INTEGER)
                        {
                            int tokenIndex = i;
                            int neighborIndex = i;
                            Token neighborToken;

                            bool noColon = true, noEquals = true, noSemiColon = true;
                            
                            for (int j = i + 1; j < tokens.Count && neighborIndex <= tokenIndex + 3; j++)
                            {
                                neighborToken = tokens[j];

                                if (WhiteSpaceNewLineCheck(neighborToken)) continue;

                                neighborIndex++;

                                if (neighborToken.Type == TokenType.TOKEN_ERROR)
                                {
                                    parserResultStatus = ParserResultStatus.InvalidSymbol;
                                    resultMessage = GetResultMessage(parserResultStatus, neighborToken.Value);
                                    AddUniqueError(resultList, resultMessage, neighborToken.StartPosition);
                                    continue;
                                }
                                
                                if (neighborToken.Type == TokenType.TOKEN_SEMICOLON) noSemiColon = false;
                                
                                if (tokenIndex + 1 == neighborIndex && neighborToken.Type == TokenType.TOKEN_EQUALS) noEquals = false;
                                
                                //if (tokenIndex + 1 == neighborIndex && neighborToken.Type == TokenType.TOKEN_NUMBER) noEquals = false;                                
                            }

                            neighborIndex = i;

                            for (int j = i - 1; j >= 0; j--)
                            {
                                neighborToken = tokens[j];

                                if (WhiteSpaceNewLineCheck(neighborToken)) continue;
                                
                                neighborIndex--;

                                if (neighborIndex + 1 == tokenIndex && neighborToken.Type == TokenType.TOKEN_COLON)
                                {                         
                                    noColon = false;                                   
                                    break;
                                }

                                if (neighborIndex + 1 == tokenIndex && neighborToken.Type == TokenType.TOKEN_IDENT)
                                {
                                    noColon = false;
                                    break;
                                }
                                if (neighborIndex + 1 == tokenIndex && neighborToken.Type == TokenType.TOKEN_CONST)
                                {
                                    noColon = false;
                                    break;
                                }
                            }

                            if (noColon)
                            {
                                parserResultStatus = ParserResultStatus.NoColon;
                                resultMessage = GetResultMessage(parserResultStatus);
                                resultItem = new ResultItem(resultMessage, token.StartPosition);
                                resultList.Add(resultItem);
                            }

                            if (noEquals)
                            {
                                parserResultStatus = ParserResultStatus.NoEquals;
                                resultMessage = GetResultMessage(parserResultStatus);
                                resultItem = new ResultItem(resultMessage, token.EndPosition + 1);
                                resultList.Add(resultItem);
                            }

                            if (noSemiColon)
                            {
                                if (!NoGlobalSemiColon) NoGlobalSemiColon = true;                              
                                emptySemiColonIndex = token.EndPosition;
                            }

                            currentState = State.ExpectEquals;

                        }
                        else
                        {
                            i--;
                            currentState = ChangeState(token);
                        }
                        break;



                    case State.ExpectEquals:

                        if (WhiteSpaceNewLineCheck(token)) continue;
                        
                        if (token.Type == TokenType.TOKEN_EQUALS)
                        {
                            int tokenIndex = i;
                            int neighborIndex = i;
                            Token neighborToken;

                            bool noType = true, noNumber = true, noSemiColon = true;

                            bool isInvalidTerm = false;
                            int invalidTermIndex = -1;
                                                    
                            for (int j = i + 1; j < tokens.Count && neighborIndex <= tokenIndex + 2; j++)
                            {
                                neighborToken = tokens[j];

                                if (WhiteSpaceNewLineCheck(neighborToken)) continue;

                                neighborIndex++;

                                if (neighborToken.Type == TokenType.TOKEN_ERROR)
                                {
                                    parserResultStatus = ParserResultStatus.InvalidSymbol;
                                    resultMessage = GetResultMessage(parserResultStatus, neighborToken.Value);
                                    AddUniqueError(resultList, resultMessage, neighborToken.StartPosition);
                                    continue;
                                }

                                if (neighborToken.Type == TokenType.TOKEN_SEMICOLON) { 
                                    noSemiColon = false;                                   
                                }
                                
                                if (tokenIndex + 1 == neighborIndex)
                                {
                                    if (neighborToken.Type == TokenType.TOKEN_NUMBER) noNumber = false;

                                    else if (neighborToken.Type != TokenType.TOKEN_SEMICOLON)
                                    {
                                        parserResultStatus = ParserResultStatus.NumberError;
                                        resultMessage = GetResultMessage(parserResultStatus, neighborToken.Value);
                                        resultItem = new ResultItem(resultMessage, neighborToken.StartPosition);
                                        resultList.Add(resultItem);
                                        noNumber = false;

                                        isInvalidTerm = true;
                                        invalidTermIndex = j;
                                        break;                                       
                                    }                                                                                                  
                                }
                            }

                            

                            neighborIndex = i;

                            for (int j = i - 1; j >= 0; j--)
                            {
                                neighborToken = tokens[j];

                                if (WhiteSpaceNewLineCheck(neighborToken)) continue;
                                
                                neighborIndex--;

                                if (neighborIndex + 1 == tokenIndex && neighborToken.Type == TokenType.TOKEN_INTEGER)
                                {                                 
                                    noType = false;
                                    break;
                                }

                                if (neighborIndex + 1 == tokenIndex && neighborToken.Type == TokenType.TOKEN_COLON)
                                {
                                    noType = false;
                                    break;
                                }
                            }

                            if (noType)
                            {
                                parserResultStatus = ParserResultStatus.NoType;
                                resultMessage = GetResultMessage(parserResultStatus);
                                resultItem = new ResultItem(resultMessage, token.StartPosition);
                                resultList.Add(resultItem);
                            }

                            if (noNumber)
                            {
                                parserResultStatus = ParserResultStatus.NoNumber;
                                resultMessage = GetResultMessage(parserResultStatus);
                                resultItem = new ResultItem(resultMessage, token.EndPosition + 1);
                                resultList.Add(resultItem);
                            }
                           
                            if (isInvalidTerm)
                            {
                                bool isFound = false;
                                for (int k = invalidTermIndex + 1; k < tokens.Count; k++)
                                {
                                    neighborToken = tokens[k];

                                    if (neighborToken.Type != TokenType.TOKEN_SEMICOLON)
                                    {
                                        continue;
                                    }
                                    else
                                    {
                                        isFound = true;
                                        i = k - 1;
                                        currentState = State.ExpectSemicolon;
                                        break;
                                    }

                                }
                                if (!isFound)
                                {
                                    for (int t = tokens.Count -1;  t > 0; t--)
                                    {
                                        if (WhiteSpaceNewLineCheck(tokens[t])) continue;
                                        emptySemiColonIndex = tokens[t].EndPosition;
                                        break;
                                    }
                                    i = tokens.Count - 1;
                                }
                            }
                            
                            else
                            {
                                if (noSemiColon)
                                {
                                    if (!NoGlobalSemiColon) NoGlobalSemiColon = true;
                                    emptySemiColonIndex = token.EndPosition;
                                }

                                currentState = State.ExpectNumber;
                            }                                                    
                        }
                        else
                        {
                            i--;
                            currentState = ChangeState(token);
                        }
                        break;


                    case State.ExpectNumber:

                        if (WhiteSpaceNewLineCheck(token)) continue;
                        
                        if (token.Type == TokenType.TOKEN_NUMBER)
                        {
                            int tokenIndex = i;
                            int neighborIndex = i;
                            Token neighborToken;

                            bool noEquals = true, noSemiColon = true;
                            
                            for (int j = i + 1; j < tokens.Count && neighborIndex <= tokenIndex + 1; j++)
                            {
                                neighborToken = tokens[j];

                                if (WhiteSpaceNewLineCheck(neighborToken)) continue;

                                neighborIndex++;

                                if (neighborToken.Type == TokenType.TOKEN_ERROR)
                                {
                                    parserResultStatus = ParserResultStatus.InvalidSymbol;
                                    resultMessage = GetResultMessage(parserResultStatus, neighborToken.Value);
                                    AddUniqueError(resultList, resultMessage, neighborToken.StartPosition);
                                    continue;
                                }
                               
                                if (neighborToken.Type == TokenType.TOKEN_SEMICOLON) noSemiColon = false;                               
                            }

                            neighborIndex = i;

                            for (int j = i - 1; j >= 0; j--)
                            {
                                neighborToken = tokens[j];

                                if (WhiteSpaceNewLineCheck(neighborToken)) continue;
                                
                                neighborIndex--;

                                if (neighborIndex + 1 == tokenIndex && neighborToken.Type == TokenType.TOKEN_EQUALS)
                                {                                
                                    noEquals = false;
                                    break;
                                }

                                if (neighborIndex + 1 == tokenIndex && neighborToken.Type == TokenType.TOKEN_INTEGER)
                                {
                                    noEquals = false;
                                    break;
                                }
                            }

                            if (noEquals)
                            {
                                parserResultStatus = ParserResultStatus.NoEquals;
                                resultMessage = GetResultMessage(parserResultStatus);
                                resultItem = new ResultItem(resultMessage, token.StartPosition);
                                resultList.Add(resultItem);
                            }

                            if (noSemiColon)
                            {
                                if (!NoGlobalSemiColon) NoGlobalSemiColon = true;
                                emptySemiColonIndex = token.EndPosition;
                            }
                            currentState = State.ExpectSemicolon;
                        }
                        else
                        {
                            i--;
                            currentState = ChangeState(token);
                        }
                        break;


                    case State.ExpectSemicolon:

                        if (WhiteSpaceNewLineCheck(token)) continue;
                        
                        if (token.Type == TokenType.TOKEN_SEMICOLON)
                        {
                            NoGlobalSemiColon = false;

                            if (i + 1 == tokens.Count)
                            {
                                currentState = State.Accept;
                            }
                            else
                            {
                                Token neighborToken;
                                bool isEnd = true;
                                int positionToJump = -1;
                                for (int j = i + 1; j < tokens.Count; j++)
                                {
                                    neighborToken = tokens[j];
                                    if (WhiteSpaceNewLineCheck(neighborToken)) continue;

                                    if (neighborToken.Type == TokenType.TOKEN_SEMICOLON) continue;
                                    else
                                    {
                                        positionToJump = j;
                                        isEnd = false;
                                        break;
                                    }                                   
                                }

                                if (!isEnd)
                                {
                                    i = positionToJump - 1;
                                    currentState = State.Start;
                                }
                                else
                                {
                                    currentState = State.Accept;
                                }
                               
                            }
                        }
                        else
                        {
                            i--;
                            currentState = ChangeState(token);
                        }
                        break;


                    case State.Accept:                        
                        break;

                    case State.Error:

                        parserResultStatus = ParserResultStatus.InvalidSymbol;
                        resultMessage = GetResultMessage(parserResultStatus, token.Value);
                        AddUniqueError(resultList, resultMessage, token.StartPosition);

                        bool isTextEnd = true;
                        for (int j = i + 1; j < tokens.Count; j++)
                        {
                            Token neighborToken = tokens[j];
                             
                            if (WhiteSpaceNewLineCheck(neighborToken))
                            {
                                continue;
                            }
                            else
                            {
                                isTextEnd = false;
                                i = j - 1;
                                currentState = ChangeState(neighborToken);
                                break;
                            }
                            
                        } 
                        
                        if (isTextEnd)
                        {
                            i = tokens.Count - 1;
                        }
                        break;
                }
            }

            DuplicatesIDCheck(resultList, tokens);


            if (NoGlobalSemiColon)
            {
                parserResultStatus = ParserResultStatus.NoSemicolon;
                resultMessage = GetResultMessage(parserResultStatus);

                resultItem = new ResultItem(resultMessage, emptySemiColonIndex + 1);
                resultList.Add(resultItem);
            }

            if (resultList.Count == 0)
            {
                parserResultStatus = ParserResultStatus.Success;
                resultMessage = GetResultMessage(parserResultStatus);

                resultItem = new ResultItem(resultMessage, -1);
                resultList.Add(resultItem);
            }

            return resultList;
        }

        private void DuplicatesIDCheck(List<ResultItem> resultList, List<Token> tokens)
        {      
            string resultMessage = string.Empty;
            ResultItem resultItem;

            Token uniqueIdentifier = null;
            for (int j = 0; j < tokens.Count; j++)
            {
                Token currentToken = tokens[j];

                if (uniqueIdentifier != null)
                {
                    if (uniqueIdentifier.Value == currentToken.Value)
                    {
                        parserResultStatus = ParserResultStatus.IsDuplicate;
                        resultMessage = GetResultMessage(parserResultStatus, uniqueIdentifier.Value);
                        resultItem = new ResultItem(resultMessage, currentToken.StartPosition);
                        resultList.Add(resultItem);
                    }
                }

                if (currentToken.Type == TokenType.TOKEN_IDENT)
                {
                    uniqueIdentifier = currentToken;
                }
            }
        }
        
        private void AddUniqueError(List<ResultItem> resultList, string message, int position)
        {
            if (!resultList.Any(error => error.Message == message && error.Position == position))
            {
                resultList.Add(new ResultItem(message, position));
            }
        }    
        private bool WhiteSpaceNewLineCheck(Token currentToken)
        {
            if (currentToken.Type == TokenType.TOKEN_WHITESPACE || currentToken.Type == TokenType.TOKEN_NEWLINE)
            {
                return true;
            }
            return false;
        }

        private State ChangeState(Token currentToken)
        {
            TokenType type = currentToken.Type;

            switch (type)
            {
                case TokenType.TOKEN_CONST:
                    return State.Start;
                
                case TokenType.TOKEN_IDENT:
                    return State.ExpectIdent;

                case TokenType.TOKEN_COLON:
                    return State.ExpectColon;

                case TokenType.TOKEN_INTEGER:
                    return State.ExpectType;
                               
                case TokenType.TOKEN_EQUALS:
                    return State.ExpectEquals;

                
                case TokenType.TOKEN_NUMBER:
                    return State.ExpectNumber;
                
                case TokenType.TOKEN_SEMICOLON:
                    return State.ExpectSemicolon;

                case TokenType.TOKEN_ERROR:
                    return State.Error;
                  
            }
            return State.Accept;
        }

        private string GetResultMessage(ParserResultStatus stateMessage, string tokenValue = "")
        {
            string message = translationManager.GetParserResultTranslate(stateMessage, tokenValue);
            return message;
        }
        
    }
}
