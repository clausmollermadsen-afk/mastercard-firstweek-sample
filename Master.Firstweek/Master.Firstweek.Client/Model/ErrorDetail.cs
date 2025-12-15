namespace Master.Firstweek.Client.Model;

#pragma warning disable CS8618

public class ErrorDetail
{
    public string Source { get; set; }

    public string ReasonCode { get; set; }

    public string Description { get; set; }

    public bool Recoverable { get; set; }

    public string Details { get; set; }
}

#pragma warning restore CS8618