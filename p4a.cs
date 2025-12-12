using System;

public class p4a
{
    //public string[] inputs = File.ReadAllLines("4a-example.txt");
    public string[] inputs = File.ReadAllLines("4a.txt");

    public void Main()
    {
        long countReachable = 0;

        for (int j = 0; j < inputs.Length; j++)
        {
            for (int i = 0; i < inputs[j].Length; i++)
            {
                // nothing to check if it's not a stack of paper
                if (inputs[j][i].ToString().Equals(".")) continue;

                if (inputs[j][i].ToString().Equals("@"))
                {
                    if (CheckSurroundingValues(j, i))
                    {
                        countReachable++;
                    }
                }
            }
        }

        Console.WriteLine("countReachable= " + countReachable);
    }

    private bool CheckSurroundingValues(int lineNumber, int cellToCheck)
    {
        int rolls = 0;

        // previous line
        if (lineNumber > 0)
        {
            if (cellToCheck > 0)
            {
                if (inputs[lineNumber - 1][cellToCheck - 1].ToString().Equals("@")) rolls++;
            }

            if (inputs[lineNumber - 1][cellToCheck].ToString().Equals("@")) rolls++;

            if (cellToCheck < inputs[lineNumber - 1].Length - 1)
            {
                if (inputs[lineNumber - 1][cellToCheck + 1].ToString().Equals("@")) rolls++;
            }
        }

        // current line, skip self
        if (cellToCheck > 0)
        {
            if (inputs[lineNumber][cellToCheck - 1].ToString().Equals("@")) rolls++;
        }

        if (cellToCheck < inputs[lineNumber].Length - 1)
        {
            if (inputs[lineNumber][cellToCheck + 1].ToString().Equals("@")) rolls++;
        }

        // next line
        if (lineNumber < inputs.Length - 1)
        {
            if (cellToCheck > 0)
            {
                if (inputs[lineNumber + 1][cellToCheck - 1].ToString().Equals("@")) rolls++;
            }

            if (inputs[lineNumber + 1][cellToCheck].ToString().Equals("@")) rolls++;

            if (cellToCheck < inputs[lineNumber].Length - 1)
            {
                if (inputs[lineNumber + 1][cellToCheck + 1].ToString().Equals("@")) rolls++;
            }
        }

        return rolls < 4;
    }
}
