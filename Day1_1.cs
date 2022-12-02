internal class Day1_1
{
    public static void Run()
    {
        var data = ProblemReader.readString(@"./day1.txt");

        var max = 0;
        var sum = 0;
        foreach (string s in data)
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                if (sum > max)
                {
                    max = sum;
                }
                sum = 0;
                continue;
            }
            var num = int.Parse(s);
            sum += num;
        }
        Console.WriteLine(max);
    }
}