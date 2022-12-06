public class Day6 {
    public static void Part1() {
        var input = ProblemReader.readString("./day6.txt");
        foreach(string s in input) {
            var charray = s.ToList();
            for(int i = 4; i < charray.Count; i++) {
                var last4Unique = charray.GetRange(i-4, 4).Distinct().Count() == 4;
                if (last4Unique) {
                    Console.WriteLine(i);
                    break;
                }
            }
        }
    }
    public static void Part2() {
        var input = ProblemReader.readString("./day6.txt");
        foreach(string s in input) {
            var charray = s.ToList();
            for(int i = 14; i < charray.Count; i++) {
                var last14Unique = charray.GetRange(i-14, 14).Distinct().Count() == 14;
                if (last14Unique) {
                    Console.WriteLine(i);
                    break;
                }
            }
        }
    }
}