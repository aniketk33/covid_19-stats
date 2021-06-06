using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace covid19stats.Services
{
    public class HttpServices : HttpClient
    {
        public async Task<string> GetDataFromServer(string requestUri)
        {
            string serviceResult = string.Empty;
            HttpResponseMessage response = null;
            try
            {
                CookieContainer cookies = new CookieContainer();
                //Check network connection is available or not
                var NetworkAvailable = Connectivity.NetworkAccess;
                if (NetworkAvailable == NetworkAccess.Internet)
                {
                    HttpClientHandler handler = new HttpClientHandler();
                    var httpClient = new HttpClient(handler);
                    httpClient.BaseAddress = new Uri(requestUri);
                    Uri uri = new Uri(requestUri);
                    var cancelSource = new CancellationTokenSource();
                    var content = httpClient.GetAsync(uri);
                    response = await content;
                    if (response.IsSuccessStatusCode)
                    {
                        serviceResult = await response.Content.ReadAsStringAsync();
                    }
                    else
                    {
                        throw new Exception("please try again after sometime");
                    }
                }
                else
                {
                    // message need to modify
                    throw new Exception("please try again after sometime");
                }
            }
            catch (HttpRequestException rex)
            {
                Debug.WriteLine(rex.ToString());   
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());               
            }
            return serviceResult;
        }
    }
}
