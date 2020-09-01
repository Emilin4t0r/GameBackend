using System;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Linq;

public class RealTimeCityBikeDataFetcher : ICityBikeDataFetcher
{
    HttpClient client = new HttpClient()
    {
        BaseAddress = new Uri(@"http://api.digitransit.fi/routing/v1/routers/hsl/bike_rental")
    };

    public async Task<int> GetBikeCountInStation(string stationName)
    {
        BikeRentalStationList list;
        try
        {
            if (stationName.Any(c => char.IsDigit(c)))
            {
                throw new ArgumentException();
            }
        }
        catch (ArgumentException argumentException)
        {
            Console.WriteLine("Invalid argument: " + argumentException);
            return -1;
        }
        finally
        {
            list = JsonConvert.DeserializeObject<BikeRentalStationList>(await client.GetStringAsync(client.BaseAddress));
        }
        try
        {
            if (!list.stations.Exists(item => item.name == stationName))
            {
                throw new NotFoundException();
            }
        }
        catch (NotFoundException notFound)
        {
            Console.WriteLine("Not found: " + notFound);
            return -1;
        }
        Console.WriteLine(list.stations.Find(item => item.name == stationName).bikesAvailable);
        return list.stations.Find(item => item.name == stationName).bikesAvailable;
    }

    public class NotFoundException : Exception
    {
        public NotFoundException()
        {
        }
    }
}
