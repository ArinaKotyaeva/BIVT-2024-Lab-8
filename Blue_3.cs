using System;
using System.Text;
using System.Linq;

namespace Lab_8
{
    public class Blue_3 : Blue
    {
        private (char, double)[] _output;
        public (char, double)[] Output => _output;

        public Blue_3(string input) : base(input)
        {
            _output = null;
        }

        public override void Review()
        {
            if (string.IsNullOrWhiteSpace(Input))
            {
                _output = new (char, double)[0];
                return;
            }

            string[] words = GetFilteredWords(Input);
            var letterCounts = new System.Collections.Generic.Dictionary<char, int>();
            int totalWords = 0;

            foreach (string word in words)
            {
                if (word.Length == 0) continue;

                char firstChar = char.ToLower(GetFirstLetter(word));
                if (firstChar == '\0') continue;

                totalWords++;
                if (letterCounts.ContainsKey(firstChar))
                    letterCounts[firstChar]++;
                else
                    letterCounts[firstChar] = 1;
            }

            _output = letterCounts
                .Select(pair => (pair.Key, totalWords > 0 ? Math.Round(pair.Value * 100.0 / totalWords, 4) : 0))
                .OrderByDescending(x => x.Item2)
                .ThenBy(x => x.Item1)
                .ToArray();
        }

        private string[] GetFilteredWords(string text)
        {
            var result = new System.Collections.Generic.List<string>();
            var currentWord = new StringBuilder();

            foreach (char c in text)
            {
                if (char.IsLetter(c) || c == '\'' || c == '-')
                {
                    currentWord.Append(c);
                }
                else if (currentWord.Length > 0)
                {
                    result.Add(currentWord.ToString());
                    currentWord.Clear();
                }
            }

            if (currentWord.Length > 0)
            {
                result.Add(currentWord.ToString());
            }

            return result.ToArray();
        }

        private char GetFirstLetter(string word)
        {
            foreach (char c in word)
            {
                if (char.IsLetter(c))
                    return c;
            }
            return '\0';
        }

        public override string ToString()
        {
            if (_output == null || _output.Length == 0)
                return string.Empty;

            var result = new StringBuilder();
            for (int i = 0; i < _output.Length; i++)
            {
                result.Append(_output[i].Item1);
                result.Append(" - ");
                result.Append(_output[i].Item2.ToString("F4"));
                if (i < _output.Length - 1)
                    result.AppendLine();
            }

            return result.ToString();
        }
    }
}
