using System.Linq.Expressions;

public class IPL {
    private static readonly String MATCH_FILE_PATH = "./data/matches.csv";
    private static readonly String DELIVERY_FILE_PATH = "./data/deliveries.csv";
    private static readonly int ID = 0;
    private static readonly int SESSION = 1;
    private static readonly  int CITY = 2;
    private static readonly int DATE = 3;
    private static readonly int TEAM1 = 4;
    private static readonly int TEAM2 = 5;
    private static readonly int TOSS_WINNER = 6;
    private static readonly int TOSS_DECISION = 7;
    private static readonly int RESULT = 8;
    private static readonly int DL_APPLIED = 9;
    private static readonly int WINNER = 10;
    private static readonly int WIN_BY_RUNS= 11;
    private static readonly int  WIN_BY_WICKETS = 12;
    private static readonly int PLAYER_OF_MATCH = 13;
    private static readonly int VENUE = 14;
    private static readonly int UMPIRE1 = 15;
    private static readonly int UMPIRE2 = 16;
    private static readonly int UMPIRE3 = 17;
    private static readonly int MATCH_ID = 0;
    private static readonly int INNING = 1;
    private static readonly int BATTING_TEAM = 2;
    private static readonly int BOWLING_TEAM = 3;
    private static readonly int OVER = 4;
    private static readonly int BALL = 5;
    private static readonly int BATSMAN = 6;
    private static readonly int NON_STRIKER = 7;
    private static readonly int BOWLER = 8;
    private static readonly int IS_SUPER_OVER = 9;
    private static readonly int WIDE_RUNS = 10;
    private static readonly int BYE_RUNS = 11;
    private static readonly int LEG_BYE_RUNS = 12;
    private static readonly int NO_BALL_RUNS = 13;
    private static readonly int PENALTY_RUNS = 14;
    private static readonly int BATSMAN_RUNS = 15;
    private static readonly int EXTRA_RUNS = 16;
    private static readonly int TOTAL_RUNS = 17;
    private static readonly int PLAYER_DISMISSED = 18;
    private static readonly int DISMISSAL_KIND = 19;
    private static readonly int FIELDER = 20;

    public static List<Match> GetMatches() {
        List<Match> matches = new List<Match>();

        try {
            using (StreamReader reader = new StreamReader(IPL.MATCH_FILE_PATH)) {
                reader.ReadLine(); // Skip header

                string? line;
                while ((line = reader.ReadLine()) != null) {
                    string[] splitLine = line.Split(',');

                    Match match = new Match {
                        id = splitLine[ID],
                        session = splitLine[SESSION],
                        city =  splitLine[CITY],
                        date = splitLine[DATE],
                        team1 = splitLine[TEAM1],
                        team2 = splitLine[TEAM2],
                        tossWinner = splitLine[TOSS_WINNER],
                        tossDecision = splitLine[TOSS_DECISION],
                        result = splitLine[RESULT],
                        dlApplied = splitLine[DL_APPLIED],
                        winner = splitLine[WINNER],
                        winByRuns = splitLine[WIN_BY_RUNS],
                        winByWickets = splitLine[WIN_BY_WICKETS],
                        playerOfMatch = splitLine[PLAYER_OF_MATCH],
                        venue = splitLine[VENUE],
                        umpire1 = splitLine[UMPIRE1],
                        umpire2 = splitLine[UMPIRE2],
                        umpire3 = splitLine[UMPIRE3]
                    };

                    matches.Add(match);
                }
            }
        }
        catch (FileNotFoundException e)
        {
            Console.WriteLine(e.Message);
        }

        return matches;
    }

    public static List<Delivery> GetDeliveries() {
        List<Delivery> deliveries = new List<Delivery>();

        try {
            using(StreamReader reader = new StreamReader(IPL.DELIVERY_FILE_PATH)) {
                reader.ReadLine(); // skip header

                String? line;
                String[] splitLine;

                while ((line = reader.ReadLine()) != null) {
                    splitLine = line.Split(",");

                    Delivery delivery = new Delivery {
                        matchId = splitLine[MATCH_ID],
                        inning = splitLine[INNING],
                        batingTeam = splitLine[BATTING_TEAM],
                        bowlingTeam = splitLine[BOWLING_TEAM],
                        over = splitLine[OVER],
                        ball = splitLine[BALL],
                        batsman = splitLine[BATSMAN],
                        nonStriker = splitLine[NON_STRIKER],
                        bowler = splitLine[BOWLER],
                        isSuperOver = splitLine[IS_SUPER_OVER],
                        wideRuns = splitLine[WIDE_RUNS],
                        byeRuns = splitLine[BYE_RUNS],
                        legByRuns = splitLine[LEG_BYE_RUNS],
                        noBallRuns = splitLine[NO_BALL_RUNS],
                        penaltyRuns = splitLine[PENALTY_RUNS],
                        batsmanRuns = splitLine[BATSMAN_RUNS],
                        extraRuns = splitLine[EXTRA_RUNS],
                        totalRuns = splitLine[TOTAL_RUNS],
                        playerDismissed = splitLine[PLAYER_DISMISSED],
                        dismissalKind = splitLine[DISMISSAL_KIND],
                        fielder = splitLine[FIELDER]
                    };

                    deliveries.Add(delivery);

                } 
                
            }

        } catch(FileNotFoundException e) {
            Console.WriteLine(e.Message);
        }

        return deliveries;
    }
}