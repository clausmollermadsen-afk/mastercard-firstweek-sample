namespace Master.Firstweek.WebApp.Data;

public class RequestResponseLog : EntityBase<RequestResponseLog>
{
    public required string Request { get; init; }

    public string? Response { get; set; }

    public string? Error { get; set; }

    public string? Exception { get; set; }
}