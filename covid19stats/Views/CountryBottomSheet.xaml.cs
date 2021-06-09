using System;
using System.Collections.Generic;
using covid19stats.ViewModels;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;

namespace covid19stats.Views
{
    public partial class CountryBottomSheet : PopupPage
    {
        CountryBottomSheetViewModel vm;
        public CountryBottomSheet(Action<dynamic, bool> callback)
        {
            InitializeComponent();
            vm = new CountryBottomSheetViewModel(callback);
            BindingContext = vm;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            vm.OnAppearing();
        }

        void SearchBar_TextChanged(System.Object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            vm.SearchCountry(e.NewTextValue);
        }
    }
}
