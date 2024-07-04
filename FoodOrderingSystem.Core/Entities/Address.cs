
using Newtonsoft.Json;

namespace FoodOrderingSystem.Core.Entities;

public class Address
{
    [JsonProperty("country_code3")]
    public string CountryCode3 { get; set; }

    [JsonProperty("continent_code")]
    public string ContinentCode { get; set; }

    [JsonProperty("country")]
    public string Country { get; set; }

    [JsonProperty("longitude")]
    public string Longitude { get; set; }

    [JsonProperty("accuracy")]
    public int Accuracy { get; set; }

    [JsonProperty("timezone")]
    public string Timezone { get; set; }

    [JsonProperty("asn")]
    public int Asn { get; set; }

    [JsonProperty("organization")]
    public string Organization { get; set; }

    [JsonProperty("latitude")]
    public string Latitude { get; set; }

    [JsonProperty("ip")]
    public string Ip { get; set; }

    [JsonProperty("area_code")]
    public string AreaCode { get; set; }

    [JsonProperty("organization_name")]
    public string OrganizationName { get; set; }

    [JsonProperty("country_code")]
    public string CountryCode { get; set; }
}
