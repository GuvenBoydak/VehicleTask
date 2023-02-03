using Newtonsoft.Json;

namespace VehicleTask.Test.Dtos;

public class CustomResponseDto<T>
{
    public T Data { get; set; }

    [JsonProperty("statusCode")] 
    public int StatusCode { get; set; }

    [JsonProperty("error")] 
    public List<string> Error { get; set; }
}