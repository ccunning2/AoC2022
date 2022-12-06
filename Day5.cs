using System;
using System.Text;
class Day5 {
    public static void Part1() {
        var input = ProblemReader.readString("./day5.txt");
        var parsedProblem = parseInput(input);
        var instructions = parsedProblem.Item1;
        var rowsOfCrates = parsedProblem.Item2;
        doMoves(instructions, rowsOfCrates);
        getMessage(rowsOfCrates);
    }

    public static void Part2() {
        var input = ProblemReader.readString("./day5.txt");
        var parsedProblem = parseInput(input);
        var instructions = parsedProblem.Item1;
        var rowsOfCrates = parsedProblem.Item2;
        doMoves2(instructions, rowsOfCrates);
        getMessage(rowsOfCrates);
    }
    private static void getMessage(List<List<char>> rowsOfCrates) {
            StringBuilder sb = new StringBuilder();
            foreach(List<char> row in rowsOfCrates) {
                sb.Append(row[0]);
            }
            Console.WriteLine(sb.ToString());
    }

    private static void doMoves(List<(int,int,int)> instructions, List<List<char>> crates) {
        foreach(var inst in instructions) {
            var qty = inst.Item1;
            var source = inst.Item2 - 1;
            var dest = inst.Item3 - 1; 
            //
            for(int i = 0; i< qty; i++) {
                crates[dest].Insert(0, crates[source][0]);
                crates[source].RemoveAt(0);
            }
        }
    } 

    private static void doMoves2(List<(int,int,int)> instructions, List<List<char>> crates) {
        foreach(var inst in instructions) {
            var qty = inst.Item1;
            var source = inst.Item2 - 1;
            var dest = inst.Item3 - 1; 
            //
            crates[dest].InsertRange(0, crates[source].GetRange(0, qty));
            crates[source].RemoveRange(0, qty);
        }
    } 
    private static (List<(int, int ,int)>, List<List<char>>) parseInput(List<string> input)
    {
        var instructions = new List<(int, int ,int)>();
        List<string> crates = new List<string>();
        var crateIndices = new List<int>();
        var crateParsing = true;
        foreach(string s in input) {
            if (crateParsing && s.Contains('1')) {
                crateParsing = false;
                //find the indices of the crate values
                findCrateIndices(s, crateIndices);
            }
            if (crateParsing)
            {
                crates.Add(s);
                //Then we're parsiong the crates
            } else {
                if( s.Contains('m')) {
                    findMoves(s, instructions);
                }
            }     
        }
        List<List<char>> crateRows = new List<List<char>>();
        foreach(int crate in crateIndices) {
            crateRows.Add(new List<char>());
        }
        fillCrates(crateIndices, crateRows, crates);
        return (instructions, crateRows);
    }

    private static void fillCrates(List<int> crateIndices, List<List<char>> crateRows, List<string> crates)
    {
        var numCrates = crateIndices.Count;
        for(int i = 0; i< crates.Count; i++) {
            var crateRow = crates[i];
            for(int j = 0; j < numCrates; j++) { //j is the crate number
                var index = crateIndices[j];
                var crateItem = crateRow[index];
                if (char.IsAsciiLetter(crateItem)) {
                    crateRows[j].Add(crateItem);
                }
            }
        }
    }

    private static void findMoves(string s, List<(int, int, int)> instructions)
    {
        string[] arr = s.Split(" ");
        instructions.Add((int.Parse(arr[1]), int.Parse(arr[3]), int.Parse(arr[5])));
    }

    private static void findCrateIndices(string s, List<int> crateIndices)
    {
        for(int i = 0; i< s.Length; i++) {
            if(s.ElementAt(i) != ' ') {
                crateIndices.Add(i);
            }
        }
    }
}