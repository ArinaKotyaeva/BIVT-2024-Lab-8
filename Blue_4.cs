using System;

namespace Lab_8
{
    public class Blue_4 : Blue
    {
        private int _output;
        public int Output => _output;

        public Blue_4(string input) : base(input)
        {
            _output = 0;
        }

        public override void Review()
        {
            if (string.IsNullOrEmpty(Input)) return;

            int currentNumber = 0;
            bool inNumber = false;

            for (int i = 0; i < Input.Length; i++)
            {
                char simvol = Input[i];

                if (simvol >= '0' && simvol <= '9')
                {
                    currentNumber = currentNumber * 10 + (simvol - '0');
                    inNumber = true;
                }
                else
                {
                    if (inNumber)
                    {
                        _output += currentNumber;
                        currentNumber = 0;
                        inNumber = false;
                    }
                }
            }

            if (inNumber)
            {
                _output += currentNumber;
            }
        }

        public override string ToString()
        {
            return _output.ToString();
        }
    }
}