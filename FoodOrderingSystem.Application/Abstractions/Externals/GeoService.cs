
using FoodOrderingSystem.Core.Entities;
using Newtonsoft.Json;

namespace FoodOrderingSystem.Application.Abstractions.Externals;

public class GeoService(HttpClient httpClient) : IGeoService
{
    private readonly HttpClient _httpClient = httpClient;
    public async Task<Address> GetLocationAsync()
    {
        var url = "https://get.geojs.io/v1/ip/geo.json";
        var response = await _httpClient.GetStringAsync(url);
        return JsonConvert.DeserializeObject<Address>(response)!;
    }
}
