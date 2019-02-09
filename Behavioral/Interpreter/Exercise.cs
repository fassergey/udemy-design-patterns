using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Interpreter
{
    public class ExpressionProcessor
    {
        private enum Sign
        {
            Number, Plus, Minus, Variable
        }

        private class Token
        {
            public Sign SignType { get; set; }
            public string Text { get; set; }

            public Token(Sign signType, string text)
            {
                SignType = signType;
                Text = text ?? throw new ArgumentNullException(nameof(text));
            }

            public override string ToString()
            {
                return $"`{Text}`";
            }
        }
        
        public Dictionary<char, int> Variables = new Dictionary<char, int>();

        public int Calculate(string expression)
        {
            if (!Validate(expression)) return 0;

            var validExpression = SubstituteVariablesWithNumbers(expression);

            var tokens = Lexer(validExpression);
            var parsed = Parse(tokens);

            return parsed.Value;
        }

        private bool Validate(string expression)
        {
            if (string.IsNullOrEmpty(expression)) return false;

            var regex = new Regex("^[0-9a-zA-Z+-]+$");
            if (!regex.IsMatch(expression))
                return false;

            var regex1 = new Regex("[a-z, A-Z]{2,}");
            if (regex1.IsMatch(expression))
                return false;

            var regex2 = new Regex("[a-z, A-Z]");
            var vars = regex2.Matches(expression);
            foreach (var v in vars)
            {
                if (!Variables.Any(x => string.Equals(x.Key.ToString(), v.ToString())))
                    return false;
            }

            return true;
        }

        private string SubstituteVariablesWithNumbers(string expression)
        {
            var result = new StringBuilder(expression.Trim('+'));

            foreach (var variable in Variables.Keys)
            {
                result = result.Replace(variable.ToString(), Variables[variable].ToString());
            }

            return result.ToString();
        }

        private List<Token> Lexer(string expression)
        {
            var result = new List<Token>();

            for (int i = 0; i < expression.Length; i++)
            {
                switch (expression[i])
                {
                    case '+':
                        result.Add(new Token(Sign.Plus, "+"));
                        break;
                    case '-':
                        result.Add(new Token(Sign.Minus, "-"));
                        break;
                    default:
                        var sb = new StringBuilder();
                        sb.Append(expression[i]);
                        for (int j = i + 1; j < expression.Length; j++)
                        {
                            if (char.IsDigit(expression[j]))
                            {
                                sb.Append(expression[j]);
                                ++i;
                            }
                            else
                            {
                                break;
                            }
                        }
                        result.Add(new Token(Sign.Number, sb.ToString()));
                        break;
                }
            }

            return result;
        }


        interface IElement
        {
            int Value { get; }
        }

        class Number : IElement
        {
            public Number(int value)
            {
                Value = value;
            }

            public int Value { get; }
        }

        class BinaryOperation : IElement
        {
            public int Value
            {
                get
                {
                    switch (OperationType)
                    {
                        case Type.Add:
                            return Left.Value + Right.Value;
                        case Type.Sub:
                            return Left.Value - Right.Value;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
            }

            public enum Type
            {
                Add, Sub
            }

            public Type OperationType { get; set; }
            public IElement Left, Right;
        }

        private IElement Parse(IReadOnlyList<Token> tokens)
        {
            var result = new BinaryOperation();
            
            if (tokens.Count == 1)
                return new Number(int.Parse(tokens[0].Text));

            result.Left = new Number(int.Parse(tokens[0].Text));
            result.OperationType = (tokens[1].SignType == Sign.Plus) ?
                                    BinaryOperation.Type.Add :
                                    BinaryOperation.Type.Sub;
            result.Right = new Number(int.Parse(tokens[2].Text));

            var newTokens = new List<Token>();
            newTokens.Add(new Token(Sign.Number, result.Value.ToString()));
            newTokens.AddRange(tokens.Skip(3));

            return Parse(newTokens);
        }
    }
}
