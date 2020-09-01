using System.Threading.Tasks;

namespace Assign1
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            ICityBikeDataFetcher dataFetcher = new RealTimeCityBikeDataFetcher();
            Task<int> task = dataFetcher.GetBikeCountInStation("Kesäkatu");
            await task;
        }
    }
}