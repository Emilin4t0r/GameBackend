using System.Net.Http;
using System.Threading.Tasks;

public class RealTimeCityBikeDataFetcher : ICityBikeDataFetcher
{
    public Task<int> GetBikeCountInStation(string stationName)
    {
        string url = "http://api.digitransit.fi/routing/v1/routers/hsl/bike_rental";
        HttpClient Client = new HttpClient();
        Client.GetStringAsync(url);
    }
} 