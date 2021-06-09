using System;
using System.Threading.Tasks;
using covid19stats.Helpers;
using covid19stats.Models;
using covid19stats.Services;
using covid19stats.Views;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Rg.Plugins.Popup.Services;
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
        private string countryName = "India";
        private long totalcasesCountry;
        private long recoveredCountry;
        private long deathsCountry;
        private string updateDateCountry;
        private long worldPopulation;
        private bool isCountryDataLoading = true;
        private bool isGlobalDataLoading = true;
        #region Properties

        public string UpdateDate { get => updateDate; set => SetProperty(ref updateDate, value); }

        //global data
        public long Totalcases { get => totalcases; set => SetProperty(ref totalcases, value); }
        public long Recovered { get => recovered; set => SetProperty(ref recovered, value); }
        public long Deaths { get => deaths; set => SetProperty(ref deaths, value); }
        public long WorldPopulation { get => worldPopulation; set => SetProperty(ref worldPopulation, value); }

        //country data
        public string Flag { get => flag; set => SetProperty(ref flag, value); }
        public string CountryName { get => countryName; set => SetProperty(ref countryName, value); }
        public long TotalcasesCountry { get => totalcasesCountry; set => SetProperty(ref totalcasesCountry, value); }
        public long RecoveredCountry { get => recoveredCountry; set => SetProperty(ref recoveredCountry, value); }
        public long DeathsCountry { get => deathsCountry; set => SetProperty(ref deathsCountry, value); }
        public string UpdateDateCountry { get => updateDateCountry; set => SetProperty(ref updateDateCountry, value); }
        public bool IsCountryDataLoading { get => isCountryDataLoading; set => SetProperty(ref isCountryDataLoading, value); }
        public bool IsGlobalDataLoading { get => isGlobalDataLoading; set => SetProperty(ref isGlobalDataLoading, value); }

        #endregion

        #region Commands

        public IAsyncCommand SelectCountryCommand { get; set; }
        public IAsyncCommand RefreshGlobalDataCommand { get; set; }
        public IAsyncCommand RefreshCountryDataCommand { get; set; }

        #endregion

        public DashboardViewModel()
        {
            Initialize();
            LoadGlobalData();
            LoadCountryData();
        }



        #region Methods

        private void Initialize()
        {
            RefreshGlobalDataCommand = new AsyncCommand(() => Task.Run(() => LoadGlobalData()), allowsMultipleExecutions: false);
            RefreshCountryDataCommand = new AsyncCommand(() => Task.Run(() => LoadCountryData()), allowsMultipleExecutions: false);
            SelectCountryCommand = new AsyncCommand(OpenCountryBottomSheetAsync, allowsMultipleExecutions: false);
        }

        public async void LoadGlobalData()
        {
            try
            {
                IsGlobalDataLoading = true;
                string requrl = Constants.GetWorldsData;
                var responseString = await new RestServices().GetResponseFromAPI(requrl).ConfigureAwait(false);
                var responseData = JsonConvert.DeserializeObject<WorldDataModel>(responseString);
                App.AffectedCountriesCount = responseData.affectedCountries;
                Totalcases = responseData.cases;
                UpdateDate = DateTimeOffset.FromUnixTimeMilliseconds(responseData.updated).ToString("dd MMM yyyy, hh:mm tt");
                Recovered = responseData.recovered;
                Deaths = responseData.deaths;
                IsGlobalDataLoading = false;

            }
            catch (Exception)
            {
                IsGlobalDataLoading = false;

            }
        }

        public async void LoadCountryData(string country = "india")
        {
            try
            {
                IsCountryDataLoading = true;
                string requrl = $"{Constants.GetACountryData}{country}";
                var responseString = await new RestServices().GetResponseFromAPI(requrl).ConfigureAwait(false);
                var responseData = JsonConvert.DeserializeObject<CountryDataModel>(responseString);

                Flag = responseData.countryInfo.flag;
                CountryName = responseData.country;
                TotalcasesCountry = responseData.cases;
                UpdateDateCountry = DateTimeOffset.FromUnixTimeMilliseconds(responseData.updated).ToString("dd MMM yyyy, hh:mm tt");
                RecoveredCountry = responseData.recovered;
                DeathsCountry = responseData.deaths;
                IsCountryDataLoading = false;
            }
            catch (Exception)
            {
                IsCountryDataLoading = false;
            }
        }

        public async Task OpenCountryBottomSheetAsync()
        {
            await PopupNavigation.Instance.PushAsync(new CountryBottomSheet((res, val) =>
            {
                if (val)
                {
                    LoadCountryData(res);
                }
            }));
        }

        #endregion
    }
}
