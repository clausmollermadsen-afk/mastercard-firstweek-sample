using System.Text.Json.Serialization;

namespace Master.Firstweek.Client.Model;

#pragma warning disable CS8618
public class EndUserOutput
{
    /// <summary>
    ///     End user identifier.
    /// </summary>
    /// <value>End user identifier.</value>
    /* <example>0001789937234</example> */
    [JsonPropertyName("id")]
    public string Id { get; set; }
}

#pragma warning restore CS8618