internal class Day2 {

    /*
        A = X = Rock = 2
        B = Y = Paper = 0
        C = Z = Scissors = 1

    */
    private static Dictionary<String, int> ThemMap = new Dictionary<string, int>() {
        {"A", 2}, {"B", 0}, {"C", 1}
    };

    private static Dictionary<String, int> MeMap = new Dictionary<string, int>() {
        {"X", 2}, {"Y", 0}, {"Z", 1}
    };

    private static Dictionary<int, int> ScoreMap = new Dictionary<int, int>() {
        {2 , 1}, {0 ,2}, {1 ,3 }
    };
    /**
** Paper = 0, Scissors = 1, Rock = 2
** Will return if 'me' wins or not
*/
    private static bool didIWin(int them, int me) {
       if (me == 0 && them == 2) {
        return true;
       }
        return (them == 0 && me == 2) ? false : me > them;      
    }

    private static (int them, int me) ParseMoves(String s) {
        String[] split = s.Split(" ");
        return (ThemMap[split[0]], MeMap[split[1]]);
    }

    private static int howToLose(int them) {
     return them switch 
     {
        0 => 2,
        1 =>  0,
        _ => 1
        
     };
    }

    private static int howToWin(int them) {
     return (them + 1) % 3;   
    }

    private static int calculateScore(ValueTuple<int, int> moves) {
        if( moves.Item1 == moves.Item2) {
            return 3 + ScoreMap[moves.Item2]; //Tie
        }
        return ScoreMap[moves.Item2] + (didIWin(moves.Item1, moves.Item2) ? 6 : 0);
    }

    
    private static int calculateScore2(ValueTuple<int, int> moves) {
       switch (moves.Item2)
       {
        case 2: //X -- Need to lose
            return calculateScore((moves.Item1, howToLose(moves.Item1)));
        case 0: //Y -- Need to tie
            return calculateScore((moves.Item1, moves.Item1));
        case 1: //Z -- Need to win
        default:
            return calculateScore((moves.Item1, howToWin(moves.Item1)));
       } 
    }

    public static void Part1() {
        var input = ProblemReader.readString("./day2.txt");
        var totalScore = 0;
        foreach(string s in input) {
            //Get the moves
            var intTuple = ParseMoves(s); //Item1 is them, Item2 is me
            totalScore += calculateScore(intTuple);
        }
        Console.WriteLine(totalScore);

    }

    public static void Part2() {
        var input = ProblemReader.readString("./day2.txt");
        var totalScore = 0;
        foreach(string s in input) {
            //Get the moves
            var intTuple = ParseMoves(s); //Item1 is them, Item2 is me
            totalScore += calculateScore2(intTuple);
        }
        Console.WriteLine(totalScore);

    }
}