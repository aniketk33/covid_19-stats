using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using covid19stats.Helpers;
using covid19stats.Models;
using covid19stats.Services;
using Newtonsoft.Json;
using Rg.Plugins.Popup.Services;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace covid19stats.ViewModels
{
    public class CountryBottomSheetViewModel : ObservableObject
    {
        private Action<dynamic, bool> Callback;
        private ObservableCollection<CountryDataModel> countrydata;
        private bool isLoading = true;
        List<CountryDataModel> tempcountryDataModelList;

        #region Properties

        public bool IsLoading { get => isLoading; set => SetProperty(ref isLoading, value); }
        public int totalaffected { get; set; } = App.AffectedCountriesCount;
        public ObservableCollection<CountryDataModel> CountryData { get => countrydata; set => SetProperty(ref countrydata, value); }

        #endregion

        #region Commands

        public IAsyncCommand<string> SelectCountryCommand { get; set; }

        #endregion

        public CountryBottomSheetViewModel(Action<dynamic, bool> callback)
        {
            Callback = callback;
            tempcountryDataModelList = new List<CountryDataModel>();
            SelectCountryCommand = new AsyncCommand<string>(SelectCountry, allowsMultipleExecutions: false);         
        }

        public CountryBottomSheetViewModel()
        {
        }

        public void OnAppearing()
        {
            Task.Run(async () => await GetCountriesList());
        }

        private async Task GetCountriesList()
        {
            try
            {
                IsLoading = true;
                string requrl = $"{Constants.GetAllCountryData}";
                var responseString = await new RestServices().GetResponseFromAPI(requrl).ConfigureAwait(false);
                var responseData = JsonConvert.DeserializeObject<List<CountryDataModel>>(responseString);
                CountryData = new ObservableCollection<CountryDataModel>(responseData);
                tempcountryDataModelList = new List<CountryDataModel>(responseData); 
                IsLoading = false;
            }
            catch (Exception)
            {

            }
        }

        private async Task SelectCountry(string country)
        {
            Callback(country, true);
            await PopupNavigation.Instance.PopAsync();
        }

        public void SearchCountry(string input)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(input))
                {
                    if (tempcountryDataModelList.Count != 0)
                    {
                        var searchList = tempcountryDataModelList.Where(x => x.country.ToLower().Contains(input.ToLower()) || x.continent.ToLower().Contains(input.ToLower())).ToList();
                        if (searchList != null && searchList.Count != 0)
                        {
                            CountryData = new ObservableCollection<CountryDataModel>(searchList);
                        }
                        else
                        {
                            CountryData = new ObservableCollection<CountryDataModel>(searchList);
                        }
                    }
                }
                else
                {
                    CountryData = new ObservableCollection<CountryDataModel>(tempcountryDataModelList);
                }
            }
            catch (Exception ex)
            {

            }
        }

    }
}
