
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

List<Match> matches = IPL.GetMatches();
List<Delivery> deliveries = IPL.GetDeliveries();
Dictionary<string, int> matchPlayedPerYear = IPL.GetMatchPlayedPerYear(matches);


foreach (var pair in matchPlayedPerYear) {
    Console.Write(pair.Key);
    Console.Write(" : ");
    Console.WriteLine(pair.Value);

}



