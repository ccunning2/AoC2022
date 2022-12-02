internal class Day1_2   
{
    public static void Run()
    {
        var data = ProblemReader.readString(@"./day1.txt");

        List<Int32> totals = new List<int>();
        var sum = 0;
        foreach (string s in data)
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                totals.Add(sum);
                sum = 0;
                continue;
            }
            var num = int.Parse(s);
            sum += num;
        }
        totals.Sort();
        var newSum = totals.GetRange(totals.Count - 3, 3).Sum();
        Console.WriteLine(newSum);
    }
}