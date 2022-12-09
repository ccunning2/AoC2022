using System.Text;

public static class ProblemReader {

    public static List<string> readString(String file) {
        List<string> listOfLines = new List<string>();
        foreach (string line in System.IO.File.ReadLines(file))
        {  
            listOfLines.Add(line);
        }  
        return listOfLines;
    }

    public static List<Int32> readInt(String file) {
        var listOfInts = new List<Int32>();

        foreach (string line in System.IO.File.ReadLines(file))
        {  
            listOfInts.Add(Int32.Parse(line));
            Console.WriteLine(Int32.Parse(line));
        }  
        return listOfInts;
    }

    public static List<List<int>> get2dListOfInts(string file) {
        List<List<int>> x = new List<List<int>>();
        foreach(string line in System.IO.File.ReadLines(file))
        {
            List<int> y = new List<int>();
            line.ToList().ForEach(c => y.Add(c - '0'));
            x.Add(y);
        }
        return x;
    }
}