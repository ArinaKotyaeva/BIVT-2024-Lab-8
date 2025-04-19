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
            if (Input == null || _delet == null)
            {
                _output = string.Empty;
                return;
            }

            string[] words = SplitIntoWords(Input);
            var result = new StringBuilder();
            bool firstWord = true;

            for (int i = 0; i < words.Length; i++)
            {
                string word = words[i];
                bool containsSequence = false;

                for (int j = 0; j <= word.Length - _delet.Length; j++)
                {
                    bool match = true;
                    for (int k = 0; k < _delet.Length; k++)
                    {
                        if (char.ToLower(word[j + k]) != char.ToLower(_delet[k]))
                        {
                            match = false;
                            break;
                        }
                    }
                    containsSequence = match ? true : containsSequence;
                }

                if (!containsSequence)
                {
                    result.Append(firstWord ? word : " " + word);
                    firstWord = false;
                }
                else
                {
                    string punctuation = GetPunctuation(word);
                    if (punctuation.Length > 0)
                    {
                        result.Append(firstWord ? punctuation : " " + punctuation);
                        firstWord = false;
                    }
                }
            }

            _output = result.ToString();
        }

        private string[] SplitIntoWords(string input)
        {
            var words = new System.Collections.Generic.List<string>();
            int start = 0;
            bool inWord = false;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] != ' ')
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

        private string GetPunctuation(string word)
        {
            var punctuation = new StringBuilder();
            for (int i = 0; i < word.Length; i++)
            {
                if (i == 0 || i == word.Length - 2 || i == word.Length - 1)
                {
                    if (IsPunctuation(word[i]))
                    {
                        punctuation.Append(word[i]);
                    }
                }
            }
            return punctuation.ToString();
        }

        private bool IsPunctuation(char c)
        {
            char[] punctuations = { '.', ',', ';', ':', '!', '?', '"', '(', ')', '[', ']', '{', '}', '/', '–' };
            for (int i = 0; i < punctuations.Length; i++)
            {
                if (c == punctuations[i])
                {
                    return true;
                }
            }
            return false;
        }

        public override string ToString()
        {
            return _output == null || _output.Length == 0 ? string.Empty : _output;
        }
    }
}