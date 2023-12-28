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

                    Match match = new Match();

                    match.SetId(splitLine[ID]);
                    match.SetSession(splitLine[SESSION]);
                    match.SetCity(splitLine[CITY]);
                    match.SetDate(splitLine[DATE]);
                    match.SetTeam1(splitLine[TEAM1]);
                    match.SetTeam2(splitLine[TEAM2]);
                    match.SetTossWinner(splitLine[TOSS_WINNER]);
                    match.SetTossDecision(splitLine[TOSS_DECISION]);
                    match.SetResult(splitLine[RESULT]);
                    match.SetDlApplied(splitLine[DL_APPLIED]);
                    match.SetWinner(splitLine[WINNER]);
                    match.SetWinByRuns(splitLine[WIN_BY_RUNS]);
                    match.SetWinByWickets(splitLine[WIN_BY_WICKETS]);
                    match.SetPlayerOfMatch(splitLine[PLAYER_OF_MATCH]);
                    match.SetVenue(splitLine[VENUE]);

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

                    Delivery delivery = new Delivery();

                    delivery.SetMatchId(splitLine[MATCH_ID]);
                    delivery.SetInning(splitLine[INNING]);
                    delivery.SetBatingTeam(splitLine[BATTING_TEAM]);
                    delivery.SetBowlingTeam(splitLine[BOWLING_TEAM]);
                    delivery.SetOver(splitLine[OVER]);
                    delivery.SetBall(splitLine[BALL]);
                    delivery.SetBatsman(splitLine[BATSMAN]);
                    delivery.SetNonStriker(splitLine[NON_STRIKER]);
                    delivery.SetBowler(splitLine[BOWLER]);
                    delivery.SetIsSuperOver(splitLine[IS_SUPER_OVER]);
                    delivery.SetWideRuns(splitLine[WIDE_RUNS]);
                    delivery.SetByeRuns(splitLine[BYE_RUNS]);
                    delivery.SetLegByRuns(splitLine[LEG_BYE_RUNS]);
                    delivery.SetNoBallRuns(splitLine[NO_BALL_RUNS]);
                    delivery.SetPenaltyRuns(splitLine[PENALTY_RUNS]);
                    delivery.SetBatsmanRuns(splitLine[BATSMAN_RUNS]);
                    delivery.SetExtraRuns(splitLine[EXTRA_RUNS]);
                    delivery.SetTotalRuns(splitLine[TOTAL_RUNS]);

                    deliveries.Add(delivery);

                } 
                
            }

        } catch(FileNotFoundException e) {
            Console.WriteLine(e.Message);
        }

        return deliveries;
    }
    
    public static Dictionary<string, int> GetMatchPlayedPerYear(List<Match> matches) {
        Dictionary<string, int> matchPlayedPerYear = [];

        string? session;

        foreach (Match match in matches) {
            session = match.GetSession();
            if (session != null) {
                matchPlayedPerYear[session] = matchPlayedPerYear.GetValueOrDefault(session, 0) + 1;
            }
        }

        return matchPlayedPerYear;
    }

    public static Dictionary<string, int> GetMatchesWonOFAllTeams(List<Match> matches) {
        Dictionary<string, int> matchesWonOFAllTeams = [];

        foreach(Match match in matches) {
            string? winner = match.GetWinner();
            
            if(winner != null) {
                matchesWonOFAllTeams[winner] = matchesWonOFAllTeams.GetValueOrDefault(winner, 0)+1;
            }
        }
        
        return matchesWonOFAllTeams;
    }

     public static Dictionary<string, int> GetExtraRunConcededOfTeams(string year, List<Match> matches, List<Delivery> deliveries) {
        Dictionary<string, int> extraRunConcededOfTeams = [];
        HashSet<string?> matchIdsOfCurrentYear = [];

        foreach (Match match in matches) {
            if (match.GetSession() == year) {
                matchIdsOfCurrentYear.Add(match.GetId());
            }
        }

        if (matchIdsOfCurrentYear.Count == 0) {
            throw new MatchNotPlayedException("Match not played this year");
        }
        int extraRunOfCurrentDelivery;

        foreach (Delivery delivery in deliveries){
            if (matchIdsOfCurrentYear.Contains(delivery.GetMatchId())){
                string? bowlingTeam = delivery.GetBowlingTeam();
            
                extraRunOfCurrentDelivery = int.Parse(delivery.GetExtraRuns());

                if (bowlingTeam != null && extraRunConcededOfTeams.ContainsKey(bowlingTeam)){
                    extraRunConcededOfTeams[bowlingTeam] = extraRunConcededOfTeams[bowlingTeam]+extraRunOfCurrentDelivery;
                } else {
                    extraRunConcededOfTeams.Add(bowlingTeam, extraRunOfCurrentDelivery);
                }
            }
        }

        return extraRunConcededOfTeams;
    }

}


class MatchNotPlayedException : Exception {
    public MatchNotPlayedException(string message) : base(message) {

    }
}

