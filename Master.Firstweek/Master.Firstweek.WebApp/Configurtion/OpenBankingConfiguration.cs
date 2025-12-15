namespace Master.Firstweek.WebApp.Configurtion;

public record OpenBankingConfiguration
{
    public required Guid DestinationId { get; init; }
}