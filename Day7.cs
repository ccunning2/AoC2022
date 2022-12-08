using System.Linq;

class Day7 {
    class Directory {
        public List<File> files {get; set;}

        public List<Directory> directories { get; set;}

        public long TotalSize {get; set;}

        public string Name {get; set;}

        public bool SizeSet = false;

        public long SetTotalSize() {
            if (!SizeSet) {
                long fileSum = files.Sum(f => f.Size);
                //Need to add files in all directories
                foreach( var d in directories) {
                    fileSum += d.SetTotalSize();
                }
                TotalSize = fileSum;
                SizeSet = true;
            }
            return TotalSize;
        }

    }

    class File {
        public string Name { get; set; }
        public long Size { get; set; }
    }
    public static void Part1() {
        var input = ProblemReader.readString("./day7.txt");
        HashSet<Directory> directorySet = new HashSet<Directory>();
        var topDir = buildDirectory(input, directorySet);
        topDir.SetTotalSize();

        var sum = directorySet.Where(d => d.TotalSize <= 100000).Sum(d => d.TotalSize);
        Console.WriteLine(sum);
    }
    public static void Part2() {

        var input = ProblemReader.readString("./day7.txt");
        HashSet<Directory> directorySet = new HashSet<Directory>();
        var topDir = buildDirectory(input, directorySet);
        topDir.SetTotalSize();

        long neededSize = 30000000;
        var currentUnusedSpace = 70000000 - topDir.TotalSize;
        //So we need to free up...:
        var needToFreeUp = neededSize - currentUnusedSpace;

        var directoryToDeleteSize = directorySet.Where(d => d.TotalSize >= needToFreeUp).Min(d => d.TotalSize);
        Console.WriteLine(directoryToDeleteSize);
    }
    private static Directory buildDirectory(List<string> input, HashSet<Directory> directorySet)
    {
        Directory top = new Directory {
            Name = "/",
            directories = new List<Directory>(),
            files = new List<File>()
        };
        directorySet.Add(top);
        Stack<Directory> q = new Stack<Directory>();
        Directory? currentDirectory = null;
        
        foreach(string s in input) {
            if (s.StartsWith('$')) {
                //Then it's a command
                var commandSplit = s.Split(" ");
                var command = commandSplit[1];
                switch (command)
                {
                    case "cd":
                        var param = commandSplit[2];
                        if (param == "/") {
                            //Pop all the directories, go back to top
                            q.Clear();
                            q.Push(top);
                            currentDirectory = top;
                        } else if (param == "..") {
                            //Find that directory
                            q.Pop();
                            currentDirectory = q.Peek();
                        } else {
                            currentDirectory = currentDirectory.directories.Find(d => d.Name == param);
                            q.Push(currentDirectory);
                        }
                        break;
                    case "ls":
                        break;
                    default:
                        Console.WriteLine($"Unknown: {command}");
                        break;
                }
            } else { // Then we're listing
                var listingSplit = s.Split(" ");
                long fileSize;
                if (long.TryParse(listingSplit[0], out fileSize)) { //then we got a file
                    if (currentDirectory.files.Count(f => f.Name == listingSplit[1]) == 0) {
                       currentDirectory.files.Add(new File {Size = fileSize, Name = listingSplit[1]}); 
                    }
                } else { //then we have a directory
                    if (listingSplit[0] != "dir") {
                        throw new Exception("Oops u goofed");
                    }
                    var dirName = listingSplit[1];
                    if (currentDirectory.directories.Count(d => d.Name == dirName) == 0) {
                        var newDir = new Directory {Name = dirName, files = new List<File>(), directories = new List<Directory>()};
                        currentDirectory.directories.Add(newDir);
                        directorySet.Add(newDir);
                    }
                }
            }
        }
        return top;
    }
}