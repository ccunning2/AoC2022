class Day3 {

private static int UPPER_CASE_OFFSET = -38;
private static int LOWER_CASE_OFFSET = -96;

private static (string, string) parseInputLine(String s) {
   return (s.Substring(0, s.Length/2), s.Substring(s.Length/2)); 
} 

private static char getMatchingItem(string sack1, string sack2) {
    return sack1.Where(x => sack2.Contains(x)).First();
}

    public static void Part1() {
        var input = ProblemReader.readString("./day3.txt");
        var total = 0;
        input.ForEach(s => {
            var sack = parseInputLine(s);
            var match = getMatchingItem(sack.Item1, sack.Item2);
            total += (int) match + (Char.IsAsciiLetterUpper(match) ? UPPER_CASE_OFFSET : LOWER_CASE_OFFSET);
        });
        Console.WriteLine(total);
    }

    public static void Part2() {

        var input = ProblemReader.readString("./day3.txt");
        var total = 0;
        var counter = 0;
        string[] elfGroup = new string[3]; 
        input.ForEach(s => {
            // if(elfGroup.Any(x => x == null)) {
            //    elfGroup.
            // }
            elfGroup[counter] = s;
            //Increment and reset if necessary
            counter++;
            if (counter == 3) {
                var badge = findBadge(elfGroup);
                total += (int) badge + (Char.IsAsciiLetterUpper(badge) ? UPPER_CASE_OFFSET : LOWER_CASE_OFFSET);
                elfGroup = new string[3];
                counter = 0;
            }
        }); 
        Console.WriteLine(total);
    }

    private static char findBadge(string[] elfGroup)
    {
        return elfGroup[0]
        .Where(x => elfGroup[1].Contains(x))
        .Where(x => elfGroup[2].Contains(x))
        .First();
    }
}