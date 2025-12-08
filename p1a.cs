using System;
using System.Collections.Generic;

class p1a
{
    static void Main()
    {
        string[] inputs = File.ReadAllLines("1.txt");


        int value = 50; // Starting value
        List<int> zeroLines = new List<int>();

        Console.WriteLine("Starting value: 50");
        Console.WriteLine("----------------------------");

        for (int i = 0; i < inputs.Length; i++)
        {
            string input = inputs[i];
            char direction = input[0];
            int amount = int.Parse(input.Substring(1));

            int previousValue = value;

            if (direction == 'L')
            {
                value -= amount;
            }
            else if (direction == 'R')
            {
                value += amount;
            }

            // Handle wrapping (modulo 100, keeping it in 0-99 range)
            //value = ((value % 100) + 100) % 100;

            //while (value < 0) value += 100;
            //while (value >= 100) value -= 100;

            value = value % 100;
            if (value < 0) value += 100;

            Console.WriteLine($"Line {i + 1}: {input} -> {previousValue} {(direction == 'L' ? '-' : '+')} {amount} = {value}");

            if (value == 0)
            {
                zeroLines.Add(i + 1);
            }
        }

        Console.WriteLine("----------------------------");
        Console.WriteLine($"Final value: {value}");
        Console.WriteLine();

        if (zeroLines.Count > 0)
        {
            Console.WriteLine("Times the sum ended at 0:" + zeroLines.Count);
            //foreach (int line in zeroLines)
            //{
                //Console.WriteLine($"  - Line {line}");
            //}
        }
        else
        {
            Console.WriteLine("The sum never ended at 0.");
        }
    }
}
