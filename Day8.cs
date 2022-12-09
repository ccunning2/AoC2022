public class Day8 {
    public static void Part1() {
        var forest = ProblemReader.get2dListOfInts("./day8.txt");
        //Let's represent trees by (x,y) tuple (x from the left, y from the top)
        //I'm going for intellectually lazy and excessively exhaustive here
        HashSet<(int, int)> trees = new HashSet<(int, int)>();
        addOuterEdges(forest, trees);
        lookFromLeft(forest, trees);
        lookFromTop(forest, trees);
        lookFromBottom(forest,trees);
        lookFromRight(forest, trees);
        Console.WriteLine(trees.Count);
    }

    public static void Part2() {
        var forest = ProblemReader.get2dListOfInts("./day8.txt");
        int max = 0;
        for (int y = 1; y < forest.Count; y++) {
            for (int x = 1; x < forest[0].Count; x++) {
                int currentTree = forest[y][x];
                //Look left
                int left = 0;
                for(int x2 = x-1; x2 >=0; x2--){
                    left++;
                    if (forest[y][x2] >= currentTree) {
                        break;
                    }
                }
                //Look right
                int right = 0;
                for(int x2 = x+1; x2 < forest[0].Count; x2++) {
                    right++;
                    if (forest[y][x2] >= currentTree) {
                        break;
                    }
                }
                //Look up
                int up = 0;
                for(int y2 = y-1; y2 >=0; y2--) {
                    up++;
                    if(forest[y2][x] >= currentTree) {
                        break;
                    }
                }
                //Look down
                int down = 0;
                for(int y2 = y+1; y2 < forest.Count; y2++) {
                    down++;
                    if(forest[y2][x] >= currentTree) {
                        break;
                    }
                }
                int score = left * right * up * down;
                if (score > max) {
                    max = score;
                }
            }
        }
        Console.WriteLine(max);
    }

    private static void lookFromRight(List<List<int>> forest, HashSet<(int, int)> trees) {

        for(int y = 1; y < forest.Count; y++) {
            int biggestSoFar = forest[y][forest.Count-1];
            for(int x = forest.Count-2; x > 0; x-- ) {
                var currentTree = forest[y][x];
                if (currentTree > biggestSoFar) {
                    trees.Add((x,y));
                    biggestSoFar = currentTree;
                } 
            }
        }
    }
    private static void lookFromBottom(List<List<int>> forest, HashSet<(int, int)> trees) {
        for(int x = 1; x < forest[0].Count; x++) {
            int biggestSoFar = forest[forest.Count-1][x];
            for(int y = forest.Count - 2; y > 0; y--) {
                var currentTree = forest[y][x];
                if (currentTree > biggestSoFar) {
                    trees.Add((x,y));
                    biggestSoFar = currentTree;
                } 
            }
        } 
    }
    private static void lookFromTop(List<List<int>> forest, HashSet<(int, int)> trees) {
        for(int x = 1; x < forest[0].Count; x++) {
            int biggestSoFar = forest[0][x];
            for(int y = 1; y < forest.Count; y++) {
                var currentTree = forest[y][x];
                if (currentTree > biggestSoFar) {
                    trees.Add((x,y));
                    biggestSoFar = currentTree;
                } 
            }
        }
    }
    private static void lookFromLeft(List<List<int>> forest, HashSet<(int, int)> trees) {
        for(int y = 1; y < forest.Count; y++) {
            int biggestSoFar = forest[y][0];
            for(int x = 1; x < forest[0].Count; x++ ) {
                var currentTree = forest[y][x];
                if (currentTree > biggestSoFar) {
                    trees.Add((x,y));
                    biggestSoFar = currentTree;
                } 
            }
        }
    }
    private static void addOuterEdges(List<List<int>> forest, HashSet<(int, int)> trees)
    {
        //Top edge and bottom edges
        int y = forest.Count -1;
        for (int x = 0; x< forest[0].Count; x++) {
            trees.Add((x, 0));
            trees.Add((x, y));
        }

        //Left and right edges
        
        for (int z = 0; z < forest.Count; z++) {
            trees.Add((0, z));
            trees.Add((forest[0].Count - 1, z));
        }

    } 
}