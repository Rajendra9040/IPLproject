
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

List<Match> matches = IPL.GetMatches();
List<Delivery> deliveries = IPL.GetDeliveries();
Dictionary<string, int> matchPlayedPerYear = IPL.GetMatchPlayedPerYear(matches);
Dictionary<string, int> matchesWonOFAllTeams = IPL.GetMatchesWonOFAllTeams(matches);
Dictionary<string, int> extraRunConcededOfTeams = IPL.GetExtraRunConcededOfTeams("2016", matches, deliveries);


foreach (var pair in matchPlayedPerYear) {
    Console.Write(pair.Key);
    Console.Write(" : ");
    Console.WriteLine(pair.Value);
}

Console.WriteLine("----------------------------");

foreach (var pair in matchesWonOFAllTeams) {
    Console.Write(pair.Key);
    Console.Write(" : ");
    Console.WriteLine(pair.Value);
}

Console.WriteLine("----------------------------");

foreach (var pair in extraRunConcededOfTeams) {
    Console.Write(pair.Key);
    Console.Write(" : ");
    Console.WriteLine(pair.Value);
}
