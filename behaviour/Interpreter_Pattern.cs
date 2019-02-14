using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace behaviour
{

    public static class ChineseEnglishDict
    {
        private static Dictionary<string, string> _dictory = new Dictionary<string, string>();

        static ChineseEnglishDict()
        {
            _dictory.Add("this", "这");
            _dictory.Add("is", "是");
            _dictory.Add("an", "一个");
            _dictory.Add("apple", "苹果");
        }

        public static string GetEnglish(string value)
        {
            return _dictory[value];
        }
    }

    //用来解释文字
    public interface IExpression
    {
        void Interpret(StringBuilder sb);
    }


    public class WordExpression : IExpression
    {
        private string _value;

        public WordExpression(string value)
        {
            _value = value;
        }

        public void Interpret(StringBuilder sb)
        {
            sb.Append(ChineseEnglishDict.GetEnglish(_value.ToLower()));
        }
    }

    public class SymbolExpression : IExpression
    {
        private string _value;

        public SymbolExpression(string value)
        {
            _value = value;
        }

        public void Interpret(StringBuilder sb)
        {
            switch (_value)
            {
                case ".":
                    sb.Append("。");
                    break;
            }
        }
    }

    public static class Translator
    {
        public static string Translate(string sentense)
        {
            StringBuilder sb = new StringBuilder();
            List<IExpression> expressions = new List<IExpression>();
            string[] elements = sentense.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string element in elements)
            {
                string[] words = element.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string word in words)
                {
                    expressions.Add(new WordExpression(word));
                }
                expressions.Add(new SymbolExpression("."));
            }
            foreach (IExpression expression in expressions)
            {
                expression.Interpret(sb);
            }
            return sb.ToString();
        }
    }



}
