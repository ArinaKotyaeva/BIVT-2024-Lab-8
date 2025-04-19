using System;
using System.Text;

namespace Lab_8 { 

public class Blue_1 : Blue
{
    private string[] _output;
    public string[] Output => _output;

    public Blue_1(string textInput) : base(textInput)
    {
            _output = null;
    }

    public override void Review()
    {
        if (Input == null)
        {
            _output = null;
            return;
        }

        string[] wordArray = Input.Split(' ');
        string line = "";
        string[] linesCollection = new string[0];

        foreach (string singleWord in wordArray)
        {
            int potentialLength = line.Length + singleWord.Length + (line.Length > 0 ? 1 : 0);

            if (potentialLength <= 50)
            {
                if (line.Length > 0)
                    line += " ";
                line += singleWord;
            }
            else
            {
                Array.Resize(ref linesCollection, linesCollection.Length + 1);
                linesCollection[linesCollection.Length - 1] = line;
                line = singleWord;
            }
        }

        if (line.Length > 0)
        {
            Array.Resize(ref linesCollection, linesCollection.Length + 1);
            linesCollection[linesCollection.Length - 1] = line;
        }

       _output = linesCollection;
    }

    public override string ToString()
    {
        if (_output == null) return null;

        var result = new StringBuilder();
        for (int index = 0; index < _output.Length; index++)
        {
            if (index < _output.Length - 1)
                result.AppendLine(_output[index]);
            else
                result.Append(_output[index]);
        }
        return result.ToString();
    }
}
}