namespace aoc2025;

using System;

public class p6a
{
    public long?[] solutions;

    public void Main()
    {
        //string[] inputs = File.ReadAllLines("6a-example.txt");
        string[] inputs = File.ReadAllLines("6a.txt");

        string[] calculations = inputs[inputs.Length - 1].Split(' ', StringSplitOptions.RemoveEmptyEntries);

        int numberOfAssignments = inputs[0].Split(' ', StringSplitOptions.RemoveEmptyEntries).Length;

        solutions = new long?[numberOfAssignments];

        for (int currentAssignment = 0; currentAssignment < numberOfAssignments; currentAssignment++)
        {
            for (int i = 0; i < inputs.Length-1; i++)
            {
                var x = inputs[i].Split(' ', StringSplitOptions.RemoveEmptyEntries)[currentAssignment];
                var calcTYpe = calculations[currentAssignment];
                Calculate(x, currentAssignment, calcTYpe);
            }
        }

        long total = 0;
        foreach (long temp in solutions)
        {
            total += temp;
        }

        Console.WriteLine("total= " + total);
    }

    public void Calculate(string value, int assignmentNo, string arithmetic)
    {
        if (solutions[assignmentNo] == null)
        {
            solutions[assignmentNo] = long.Parse(value);
        }
        else
        {
            if (arithmetic == "*")
            {
                solutions[assignmentNo] *= long.Parse(value);
            }
            else if (arithmetic == "+")
            {
                solutions[assignmentNo] += long.Parse(value);
            }
        }
    }
}
