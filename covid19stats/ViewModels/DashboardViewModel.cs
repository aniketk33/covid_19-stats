using System;
using System.Threading.Tasks;
using covid19stats.Helpers;
using covid19stats.Models;
using covid19stats.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xamarin.CommunityToolkit.ObjectModel;

namespace covid19stats.ViewModels
{
    public class DashboardViewModel : ObservableObject
    {
        private string updateDate;
        private long totalcases;
        private long recovered;
        private long deaths;
        private string flag = "https://disease.sh/assets/img/flags/in.png";
        private string countryName ="India";
        private long totalcasesCountry;
        private long recoveredCountry;
        private long deathsCountry;
        private string updateDateCountry;
        #region Properties

        public string UpdateDate { get => updateDate; set => SetProperty(ref updateDate, value); }

        //global data
        public long Totalcases { get => totalcases; set => SetProperty(ref totalcases, value);}
        public long Recovered { get => recovered; set => SetProperty(ref recovered, value);}
        public long Deaths { get => deaths; set => SetProperty(ref deaths, value);}

        //country data
        public string Flag { get => flag; set => SetProperty(ref flag, value);}
        public string CountryName { get => countryName; set => SetProperty(ref countryName, value);}
        public long TotalcasesCountry { get => totalcasesCountry; set => SetProperty(ref totalcasesCountry, value);}
        public long RecoveredCountry { get => recoveredCountry; set => SetProperty(ref recoveredCountry, value);}
        public long DeathsCountry { get => deathsCountry; set => SetProperty(ref deathsCountry, value);}
        public string UpdateDateCountry { get => updateDateCountry; set => SetProperty(ref updateDateCountry, value);}

        #endregion


        public DashboardViewModel()
        {
            LoadGlobalData();
            LoadCountryData();
        }

        #region Methods

        public async void LoadGlobalData()
        {
            try
            {
                string requrl = Constants.GetWorldsData;
                var responseString = await new RestServices().GetResponseFromAPI(requrl);
                var responseData = JsonConvert.DeserializeObject<WorldDataModel>(responseString);
                Totalcases = responseData.cases;
                UpdateDate = DateTimeOffset.FromUnixTimeMilliseconds(responseData.updated).ToString("dd MMM yyyy, hh:mm tt");
                Recovered = responseData.recovered;
                Deaths = responseData.deaths;

            }
            catch (Exception)
            {

            }
        }

        public async void LoadCountryData()
        {
            try
            {
                string requrl = $"{Constants.GetACountryData}india";
                var responseString = await new RestServices().GetResponseFromAPI(requrl);
                var responseData = JsonConvert.DeserializeObject<CountryDataModel>(responseString);

                TotalcasesCountry = responseData.cases;
                UpdateDateCountry = DateTimeOffset.FromUnixTimeMilliseconds(responseData.updated).ToString("dd MMM yyyy, hh:mm tt");
                RecoveredCountry = responseData.recovered;
                DeathsCountry = responseData.deaths;

            }
            catch (Exception)
            {

            }
        }

        #endregion
    }
}
