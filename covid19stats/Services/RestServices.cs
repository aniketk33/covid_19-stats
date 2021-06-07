using System;
using System.Threading.Tasks;
using covid19stats.Helpers;

namespace covid19stats.Services
{
    public class RestServices
    {
        //commmon method for api call
        public async Task<string> GetResponseFromAPI(string uri)
        {
            string result = string.Empty;
            try
            {
                string requestURI = $"{Constants.BaseUrl}{uri}";
                result = await new HttpServices().GetDataFromServer(requestURI);
                return result;
            }
            catch (Exception)
            {
                return result;
            }
        }

        //sort covid data based on parameter value continent wise
        public async Task<string> SortContinentDataParameterWise(string input)
        {
            string result = string.Empty;
            try
            {
                string append = $"/v3/covid-19/continents?sort={input}";
                string requestURI = $"{Constants.BaseUrl}{append}";
                result = await new HttpServices().GetDataFromServer(requestURI);
                return result;
            }
            catch (Exception)
            {
                return result;
            }
        }
    }
}
