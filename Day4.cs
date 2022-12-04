class Day4 {

    class SectionAssignment {
        public int Begin { get; set; }
        public int End {get; set;}

        public SectionAssignment(string input) {
            string[] split = input.Split("-");
            Begin = int.Parse(split[0]);
            End = int.Parse(split[1]);
        }

        public bool contains(SectionAssignment other) {
            return other.Begin >= Begin && other.End <= End;
        }

        public bool eitherContains(SectionAssignment other) {
            return contains(other) || other.contains(this);
        }

        public bool overlap(SectionAssignment other) {
            return other.Begin >= Begin && other.Begin <= End;
        }

        public bool anyOverlap(SectionAssignment other) {
            return overlap(other) || other.overlap(this);
        }

    }


public static void Part1() {
    var input = ProblemReader.readString("./test.txt");

    List<(SectionAssignment, SectionAssignment)> assignmentList = parseInput(input);
    var count = 0;
    foreach(var assignment in assignmentList) {
     if (assignment.Item1.eitherContains(assignment.Item2)) {
        count++;
     }    
    }
    Console.WriteLine(count);
}

public static void Part2() {
    var input = ProblemReader.readString("./day4.txt");

    List<(SectionAssignment, SectionAssignment)> assignmentList = parseInput(input);
    var count = 0;
    foreach(var assignment in assignmentList) {
     if (assignment.Item1.anyOverlap(assignment.Item2)) {
        count++;
     }    
    }
    Console.WriteLine(count);
}
    private static List<(SectionAssignment, SectionAssignment)> parseInput(List<string> input)
    {
        var assignmentList = new List<(SectionAssignment, SectionAssignment)>();
        foreach(string s in input) {
            var split = s.Split(",");
            assignmentList.Add((new SectionAssignment(split[0]), new SectionAssignment(split[1])));
        }
        return assignmentList;
    }
}