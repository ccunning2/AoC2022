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
}