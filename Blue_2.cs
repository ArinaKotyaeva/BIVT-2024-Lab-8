using System;
using System.Text;

namespace Lab_8
{
    public class Blue_2 : Blue
    {
        private string _delet;
        private string _output;
        public string Output => _output;

        public Blue_2(string input, string delet) : base(input)
        {
            _delet = delet;
            _output = null;
        }

        public override void Review()
        {
            if (Input == null || _delet == null || _delet.Length == 0)
            {
                _output = string.Empty;
                return;
            }

            string[] words = SplitIntoWords(Input);
            var result = new StringBuilder();
            bool firstWord = true;

            foreach (string word in words)
            {
                if (!ContainsSequence(word, _delet))
                {
                    if (!firstWord)
                    {
                        result.Append(" ");
                    }
                    result.Append(word);
                    firstWord = false;
                }
            }

            _output = result.ToString();
        }

        private bool ContainsSequence(string word, string sequence)
        {
            for (int i = 0; i <= word.Length - sequence.Length; i++)
            {
                bool match = true;
                for (int j = 0; j < sequence.Length; j++)
                {
                    if (char.ToLower(word[i + j]) != char.ToLower(sequence[j]))
                    {
                        match = false;
                        break;
                    }
                }
                if (match)
                {
                    return true;
                }
            }
            return false;
        }

        private string[] SplitIntoWords(string input)
        {
            var words = new System.Collections.Generic.List<string>();
            int start = 0;
            bool inWord = false;

            for (int i = 0; i < input.Length; i++)
            {
                if (!char.IsWhiteSpace(input[i]))
                {
                    if (!inWord)
                    {
                        start = i;
                        inWord = true;
                    }
                }
                else if (inWord)
                {
                    words.Add(input.Substring(start, i - start));
                    inWord = false;
                }
            }

            if (inWord)
            {
                words.Add(input.Substring(start));
            }

            return words.ToArray();
        }

        public override string ToString()
        {
            return _output ?? string.Empty;
        }
    }
}
