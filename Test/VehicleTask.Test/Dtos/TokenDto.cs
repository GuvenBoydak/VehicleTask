using Newtonsoft.Json;

namespace VehicleTask.Test.Dtos;

public class TokenDto
{
    [JsonProperty("expiration")]
    public DateTime Expiration { get; set; }
    [JsonProperty("accessToken")]
    public string AccessToken { get; set; }
}