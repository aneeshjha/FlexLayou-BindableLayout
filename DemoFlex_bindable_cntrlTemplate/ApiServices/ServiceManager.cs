using System;
using System.Net.Http;
using System.Threading.Tasks;
using Acr.UserDialogs;
using DemoFlex_bindable_cntrlTemplate.FlexlayoutSamples.Models;
using Newtonsoft.Json;
using Xamarin.Essentials;

namespace DemoFlex_bindable_cntrlTemplate.ApiServices
{
    public class ServiceManager
    {
        public ServiceManager()
        {
        }

        public async Task<NewsData> GetNewsApi()
        {
            try
            {
                if (Connectivity.NetworkAccess != NetworkAccess.Internet)
                {
                    //You are offline, notify the user
                    using (UserDialogs.Instance.Loading())
                    {
                        UserDialogs.Instance.Toast("Please check your connectivity", TimeSpan.FromSeconds(5));
                    }
                    return null;
                }
                var httpClient = new HttpClient();
                var response = await httpClient.GetStringAsync("https://newsapi.org/v2/top-headlines?country=in&pageSize=10&apiKey=5a64425a1f424500ac782a8cdaa4bfd9");
                var result = JsonConvert.DeserializeObject<NewsData>(response);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
    }
}
