using System;
using System.Threading.Tasks;
using covid19stats.Helpers;

namespace covid19stats.Services
{
    public class GetVaccineData
    {
        //get vaccine details
        public async Task<string> GetVaccineDetails()
        {
            string result = string.Empty;
            try
            {
                string append = "/v3/covid-19/vaccine";
                string requestURI = $"{Constants.BaseUrl}{append}";
                result = await new HttpServices().GetDataFromServer(requestURI);
                return result;
            }
            catch (Exception)
            {
                return "";
            }
        }

        //get vaccine coverage data for countries
        public async Task<string> GetVaccineCoverageData()
        {
            string result = string.Empty;
            try
            {
                string append = "/v3/covid-19/vaccine/coverage/countries";
                string requestURI = $"{Constants.BaseUrl}{append}";
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
