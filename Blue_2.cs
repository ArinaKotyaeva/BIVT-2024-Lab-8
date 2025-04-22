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

            string[] words = _input.Split(' '); ;
            string result = "";
            string firstWord = "";

            foreach (string word in words)
            {
                if (string.IsNullOrWhiteSpace(item) || string.IsNullOrEmpty(item)) continue;

                if (!item.ToLower().Contains(_lastPart.ToLower()))
                {
                    result += firstWord + word;
                    firstWord = " ";
                }
                else if (item.Length > 0 && !(char.IsLetter(item[0])))
                {
                    result += " " + word[0] + word[0];
                    firstWord = " ";
                }
                if (item.ToLower().Contains(_lastPart.ToLower()) && item.Length > 0 && !(char.IsLetter(item[item.Length - 1])))
                {
                    result += word[word.Length - 1];
                    firstWord = " ";
                }
            }
            _output = result;
        }

        public override string ToString()
        {
            if (string.IsNullOrEmpty(_output))
                return string.Empty;

            return _output;
        }
    }
}
