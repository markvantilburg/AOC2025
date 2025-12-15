public class p4b
{
    public void Main()
    {
        //string[] inputs = File.ReadAllLines("4a-example.txt");
        string[] inputs = File.ReadAllLines("4a.txt");

        long countReachable = 0;

        for (int j = 0; j < inputs.Length; j++)
        {
            for (int i = 0; i < inputs[j].Length; i++)
            {
                // nothing to check if it's not a stack of paper
                if (inputs[j].ToCharArray()[i].Equals('.')) continue;

                if (inputs[j][i].ToString().Equals("@"))
                {
                    if (CheckSurroundingValues(j, i, inputs))
                    {
                        char[] line = inputs[j].ToCharArray();
                        line[i] = '.';
                        inputs[j] = new String(line);
                        countReachable++;

                        // restart when one is removed
                        j = 0;
                        i = 0;
                    }
                }
            }
        }

        Console.WriteLine("countReachable= " + countReachable);
    }

    private bool CheckSurroundingValues(int lineNumber, int cellToCheck, string[] inputs)
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
