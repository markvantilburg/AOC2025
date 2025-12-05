using System;
using System.IO;

class ValueCalculator
{
    static void Main()
    {
        string[] inputs = File.ReadAllLines("1.txt");

        int value = 50; // Starting value
        int zeroCount = 0;

        Console.WriteLine("Starting value: 50");
        Console.WriteLine("----------------------------");

        for (int i = 0; i < inputs.Length; i++)
        {
            string input = inputs[i];
            char direction = input[0];
            int amount = int.Parse(input.Substring(1));

            int previousValue = value;
            int hits = 0;

            if (direction == 'L')
            {
                // Moving left (decreasing)
                // We pass through 0 each time we wrap (go below 0)
                hits = CountZeroPasses(previousValue, -amount);
                value = previousValue - amount;
            }
            else
            {
                // Moving right (increasing)
                // We pass through 0 each time we wrap (go above 99)
                hits = CountZeroPasses(previousValue, amount);
                value = previousValue + amount;
            }

            // Handle wrapping (modulo 100, keeping it in 0-99 range)
            value = ((value % 100) + 100) % 100;

            // Count if we landed exactly on 0
            if (value == 0)
            {
                hits++;
            }

            zeroCount += hits;

            string hitNote = hits > 0 ? $" [0 count: {hits}]" : "";
            Console.WriteLine($"Line {i + 1}: {input} -> {previousValue} -> {value}{hitNote}");
        }

        Console.WriteLine("----------------------------");
        Console.WriteLine($"Final value: {value}");
        Console.WriteLine();
        Console.WriteLine($"Times 0 was passed or landed on: {zeroCount}");
    }

    static int CountZeroPasses(int start, int delta)
    {
        // Count how many times we pass through 0 (not landing on it) when moving from start by delta
        // On a 0-99 dial:
        // - Going right (delta > 0): we pass 0 when going from 99 -> 0 (crossing multiples of 100 upward)
        // - Going left (delta < 0): we pass 0 when going from 0 -> 99 (crossing multiples of 100 downward)
        
        if (delta == 0) return 0;
        
        int end = start + delta;
        
        // Count multiples of 100 strictly between start and end (open interval)
        // We don't count landing exactly on a multiple of 100, that's handled separately
        
        int low, high;
        if (delta > 0)
        {
            low = start;
            high = end;
        }
        else
        {
            low = end;
            high = start;
        }
        
        // Count multiples of 100 in (low, high) - strictly between, not including endpoints
        int passes = 0;
        
        // First multiple of 100 > low
        int firstMultiple = ((low / 100) + 1) * 100;
        if (low < 0 && low % 100 != 0)
        {
            firstMultiple = (low / 100) * 100;
        }
        
        for (int m = firstMultiple; m < high; m += 100)
        {
            if (m > low)
            {
                passes++;
            }
        }
        
        return passes;
    }
}