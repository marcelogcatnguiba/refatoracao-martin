using Refactor.Domain.Entities;

List<Plays> plays = 
[
    new() { Name = "Hamlet", Type = "tragedy"},
    new() { Name = "As You Like It", Type = "comedy"},
    new() { Name = "Othello", Type = "tragedy"},
];

Invoices invoices = new() 
{
    Customer = "BigCo",
    Performances = 
    [
        new() { PlayId = "Hamlet", Audience = 55 },
        new() { PlayId = "As You Like It", Audience = 35 },
        new() { PlayId = "Othello", Audience = 40 },
    ]
};

System.Console.WriteLine(Statement(invoices!, plays!));

string Statement(Invoices invoices, List<Plays> plays)
{
    var totalAmouth = 0;
    decimal volumeCredits = 0 ;
    var result = $"Statement for {invoices.Customer}\n";

    foreach(var perf in invoices.Performances)
    {
        var play = plays.FirstOrDefault(x => x.Name.Equals(perf.PlayId));
        var thisAmouth = 0;
        
        switch (play!.Type)
        {
            case "tragedy":
            thisAmouth = 40000;
            if(perf.Audience > 30)
            {
                thisAmouth += 1000 * (perf.Audience - 30);
            }
            break;

            case "comedy":
            
            break;

            default:
            throw new Exception($"unknow play type: {play!.Type}");
        }

        // soma créditos por volume
        volumeCredits += Math.Max(perf.Audience - 30, 0);

        // soma um crédito extra para cada dez espectadores de comédia
        if("comedy" == play.Type)
        {
            volumeCredits += Math.Floor((decimal)perf.Audience / 5);
        }

        // exibe a linha para esta requisição
        result += $"{play.Name}: {thisAmouth/100:C} ({perf.Audience} seats)\n";
        totalAmouth += thisAmouth;
    }

    result += $"Amouth owed is {totalAmouth:C}\n";
    result += $"You earned {volumeCredits} credits\n";

    return result;
}