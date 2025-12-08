using System;

public class p2b
{
    public static void Main()
    {
        long sum = 0;

        //string ranges = "11-22,95-115,998-1012,1188511880-1188511890,222220-222224,1698522-1698528,446443-446449,38593856-38593862,565653-565659,824824821-824824827,2121212118-2121212124";
        string ranges = "1061119-1154492,3-23,5180469-5306947,21571-38630,1054-2693,141-277,2818561476-2818661701,21177468-21246892,40-114,782642-950030,376322779-376410708,9936250-10074071,761705028-761825622,77648376-77727819,2954-10213,49589608-49781516,9797966713-9797988709,4353854-4515174,3794829-3861584,7709002-7854055,7877419320-7877566799,953065-1022091,104188-122245,25-39,125490-144195,931903328-931946237,341512-578341,262197-334859,39518-96428,653264-676258,304-842,167882-252124,11748-19561";
        foreach (var val in ranges.Split(','))
        {
            var bounds = val.Split('-');
            long start = long.Parse(bounds[0]);
            long end = long.Parse(bounds[1]);
            for (long i = start; i <= end; i++)
            {
                // Console.WriteLine(i);
                string numberValue = i.ToString();

                if (CheckAllSameDigits(numberValue))
                {
                    Console.WriteLine(numberValue);
                    sum += i;
                    Console.WriteLine("sum is now: " + sum);
                }
            }
        }
        Console.WriteLine("The total is: " + sum);
    }

    public static bool CheckAllSameDigits(string i)
    {
        if (AllSame(i))
        {
            return true;
        }

        int len = i.Length;
        for (int parts = 2; parts <= 9; parts++)
        {
            if (len % parts != 0) continue;
            int partLen = len / parts;
            var first = i.AsSpan(0, partLen);
            bool ok = true;
            for (int p = 1; p < parts; p++)
            {
                if (!first.SequenceEqual(i.AsSpan(p * partLen, partLen)))
                {
                    ok = false;
                    break;
                }
            }
            if (ok) return true;
        }

        return false;

        //return i.Substring(0, half) == i.Substring(i.Length - half);
    }

    public static bool AllSame(ReadOnlySpan<char> s)
    {
        if (s.Length == 1) return false;
        //if (s.IsEmpty) return true;
        char first = s[0];
        for (int i = 1; i < s.Length; i++)
        {
            if (s[i] != first) return false;
        }
        return true;
    }
}
