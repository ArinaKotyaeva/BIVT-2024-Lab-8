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
        } 

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

            string[] words = Input.Split(' ', '.', '!', '?', ',', ':', '\"', ';', '–', '(', ')', '[', ']', '{', '}', '/');
            if (words.Length == 0) return;

            (char, double)[] count_l = new (char, double)[words.Length];
            int count_w = 0;
            int uni = 0;

            foreach (string word in words)
            {
                if (string.IsNullOrEmpty(word)) continue;

                char first = char.ToLower(word[0]);
                bool found = false;

                for (int i = 0; i < uni; i++)
                {
                    if (char.IsLetter(count_l[i].Item1))
                    {
                        if (count_l[i].Item1 == first)
                        {
                            count_l[i] = (first, count_l[i].Item2 + 1);
                            found = true;
                            count_w++;
                            break;
                        }
                    }
                }

                if (!found && char.IsLetter(first))
                {
                    count_l[uni] = (first, 1);
                    uni++;
                    count_w++;
                }
            }

            _output = new (char, double)[uni];

            for (int i = 0; i < uni; i++)
            {
                double res = Math.Round(count_l[i].Item2 * 100.0 / count_w, 4);
                _output[i] = (count_l[i].Item1, res);
            }

            Array.Sort(_output, (x, y) =>
            {
                int cmp = y.Item2.CompareTo(x.Item2);
                return cmp != 0 ? cmp : x.Item1.CompareTo(y.Item1);
            });
        }

        public override string ToString()
        {
            if (_output == null) return string.Empty;

            StringBuilder result = new StringBuilder();
            for (int i = 0; i < _output.Length; i++)
            {
                result.Append($"{_output[i].Item1} - {_output[i].Item2:f4}");
                if (i != _output.Length - 1) result.AppendLine();
            }
            return result.ToString();
        }
    }
}
