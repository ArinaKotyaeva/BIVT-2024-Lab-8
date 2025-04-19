using System;
using System.Text;

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

            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length == 0) continue;

                char firstChar = GetFirstLetter(words[i]);
                if (firstChar == '\0') continue;

                totalWords++;
                if (letterCounts.ContainsKey(firstChar))
                    letterCounts[firstChar]++;
                else
                    letterCounts[firstChar] = 1;
            }

            _output = new (char, double)[letterCounts.Count];
            int index = 0;
            foreach (var pair in letterCounts)
            {
                double percent = totalWords > 0 ? Math.Round(pair.Value * 100.0 / totalWords, 4) : 0;
                _output[index++] = (pair.Key, percent);
            }
        }

        private string[] GetFilteredWords(string text)
        {
            var result = new System.Collections.Generic.List<string>();
            bool inWord = false;
            int start = 0;

            for (int i = 0; i < text.Length; i++)
            {
                char c = text[i];
                bool isLetter = (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z') ||
                                c == 'ё' || c == 'Ё' || c == '\'' || c == '-';

                if (!inWord && isLetter)
                {
                    start = i;
                    inWord = true;
                }
                else if (inWord && !isLetter)
                {
                    string word = text.Substring(start, i - start).ToLower();
                    if (word.Length > 0 && char.IsLetter(word[0]))
                        result.Add(word);
                    inWord = false;
                }
            }

            if (inWord)
            {
                string word = text.Substring(start).ToLower();
                if (word.Length > 0 && char.IsLetter(word[0]))
                    result.Add(word);
            }

            return result.ToArray();
        }

        private char GetFirstLetter(string word)
        {
            for (int i = 0; i < word.Length; i++)
            {
                char c = word[i];
                if (char.IsLetter(c))
                    return c;
            }
            return '\0';
        }

        private (char, double)[] GetSortedOutput()
        {
            var sorted = new (char, double)[_output.Length];
            Array.Copy(_output, sorted, _output.Length);

            for (int i = 0; i < sorted.Length - 1; i++)
            {
                for (int j = 0; j < sorted.Length - i - 1; j++)
                {
                    bool swap = sorted[j].Item2 < sorted[j + 1].Item2 ? true :
                              (sorted[j].Item2 == sorted[j + 1].Item2 &&
                               sorted[j].Item1 > sorted[j + 1].Item1);

                    if (swap)
                    {
                        var temp = sorted[j];
                        sorted[j] = sorted[j + 1];
                        sorted[j + 1] = temp;
                    }
                }
            }

            return sorted;
        }

        public override string ToString()
        {
            if (_output == null || _output.Length == 0)
                return null;

            var result = new StringBuilder();
            var output = Output;

            for (int i = 0; i < output.Length; i++)
            {
                result.Append(output[i].Item1);
                result.Append(" - ");
                result.Append(output[i].Item2.ToString("F4"));
                result.Append(i < output.Length - 1 ? Environment.NewLine : "");
            }

            return result.ToString();
        }
    }
}