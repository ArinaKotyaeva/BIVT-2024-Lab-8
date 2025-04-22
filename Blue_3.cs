using System;
using System.Text;
using System.Linq;

namespace Lab_8
{
    public class Blue_3 : Blue
    {
        private (char, double)[] _output;
        public (char, double)[] Output
        {
            get
            {
                if (_output == null) return null;

                (char, double)[] copy = new (char, double)[_output.Length];
                Array.Copy(_output, copy, _output.Length);
                return copy;
            }
        };

        public Blue_3(string input) : base(input)
        {
            _output = null;
        }

        public override void Review()
        {
            if (string.IsNullOrWhiteSpace(Input))
            {
                _output = null;
                return;
            }

            char[] signs = { ' ', '.', '!', '?', ',', ':', '\"', ';', '–', '(', ')', '[', ']', '{', '}', '/' };
            string words = Input.Split(signs, StringSplitOptions.RemoveEmptyEntries); ;
            int count_l = new int[char.MaxValue];
            int count_w = 0;

            foreach (string word in words)
            {
                if (word.Length == 0) continue;

                char first = char.ToLower(word[0]);
                if (char.IsLetter(first))
                {
                    count_l[first]++;
                    count_w++;
                }

            }
            int uni = 0;
            for (int i = 0; i < count_l.Length; i++)
            {
                if (count_l[i] > 0) uni++;
            }

            _output = new (char, double)[uni];
            int ind = 0;

            for (int i = 0; i < count_l.Length; i++)
            {
                if (count_l[i] > 0)
                {
                    double res = Math.Round(count_l[i] * 100.0 / count_w, 4);
                    _output[ind++] = ((char)i, res);
                }
            }

            Array.Sort(_output, (x, y) =>
            {
                int cmp = y.Item2.CompareTo(x.Item2);
                return cmp != 0 ? cmp : x.Item1.CompareTo(y.Item1);
            });
        }

        public override string ToString()
        {
            string result = "";
            for (int i = 0; i < _output.Length; i++)
            {
                result += $"{_output[i].letter} - {_output[i].percent:f4}";
                if (i != _output.Length - 1) result += "\n";
            }
            return result;
        }
    }
}
