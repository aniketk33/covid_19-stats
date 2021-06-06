using System;
using System.Threading.Tasks;
using covid19stats.Helpers;

namespace covid19stats.Services
{
    public class GetWorldCovidData
    {
        //world's covid data
        public async Task<string> GetWorldsData()
        {
            string result = string.Empty;
            try
            {
                string append = "/v3/covid-19/all";
                string requestURI = $"{Constants.BaseUrl}{append}";
                result = await new HttpServices().GetDataFromServer(requestURI);
                return result;
            }
            catch (Exception)
            {
                return "";
            }
        }

        //list of countries data present
        public async Task<string> GetCountryList()
        {
            string result = string.Empty;
            try
            {
                string append = "/v3/covid-19/apple/countries";
                string requestURI = $"{Constants.BaseUrl}{append}";
                result = await new HttpServices().GetDataFromServer(requestURI);
                return result;
            }
            catch (Exception)
            {
                return "";
            }
        }

        //list of sub regions of a particular country
        public async Task<string> GetCountrySubregion(string country)
        {
            string result = string.Empty;
            try
            {
                string append = $"/v3/covid-19/apple/countries/{country}";
                string requestURI = $"{Constants.BaseUrl}{append}";
                result = await new HttpServices().GetDataFromServer(requestURI);
                return result;
            }
            catch (Exception)
            {
                return "";
            }
        }

        //list of sub regions of a particular country
        public async Task<string> GetSubregiondata(string country, string subregion)
        {
            string result = string.Empty;
            try
            {
                string append = $"/v3/covid-19/apple/countries/{country}/{subregion}";
                string requestURI = $"{Constants.BaseUrl}{append}";
                result = await new HttpServices().GetDataFromServer(requestURI);
                return result;
            }
            catch (Exception)
            {
                return "";
            }
        }

        //get all country covid data
        public async Task<string> GetAllCountryData()
        {
            string result = string.Empty;
            try
            {
                string append = "/v3/covid-19/countries";
                string requestURI = $"{Constants.BaseUrl}{append}";
                result = await new HttpServices().GetDataFromServer(requestURI);
                return result;
            }
            catch (Exception)
            {
                return "";
            }
        }

        //get a country covid data
        public async Task<string> GetACountryData(string country)
        {
            string result = string.Empty;
            try
            {
                string append = $"/v3/covid-19/countries/{country}";
                string requestURI = $"{Constants.BaseUrl}{append}";
                result = await new HttpServices().GetDataFromServer(requestURI);
                return result;
            }
            catch (Exception)
            {
                return "";
            }
        }

        //get all covid data continent wise
        public async Task<string> GetAllContinentData()
        {
            string result = string.Empty;
            try
            {
                string append = "/v3/covid-19/continents";
                string requestURI = $"{Constants.BaseUrl}{append}";
                result = await new HttpServices().GetDataFromServer(requestURI);
                return result;
            }
            catch (Exception)
            {
                return "";
            }
        }

        //sort covid data based on parameter value continent wise
        public async Task<string> SortContinentDataParameterWise(string input)
        {
            string result = string.Empty;
            try
            {
                string append = "/v3/covid-19/continents";
                string requestURI = $"{Constants.BaseUrl}{append}?sort={input}";
                result = await new HttpServices().GetDataFromServer(requestURI);
                return result;
            }
            catch (Exception)
            {
                return "";
            }
        }
    }
}
