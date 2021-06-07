using System;
using Xamarin.Forms;

namespace covid19stats.AppResources
{
    public class ColorResource : Application
    {
        public static void SetThemeColor()
        {
            //theme colors
            Current.Resources["PrimaryColor"] = Color.FromHex("#2460A7");//deep blue
            Current.Resources["SecondaryColor"] = Color.FromHex("#85B3D1");//northern sky
            Current.Resources["TertiaryColor"] = Color.FromHex("#B3C7D6");//baby blue
            Current.Resources["AlternateColor"] = Color.FromHex("#D9B48F");//coffee

            //them wise text color
            Current.Resources["PrimaryTextColor"] = Color.FromHex("#B3C7D6");
            Current.Resources["SecondaryTextColor"] = Color.FromHex("#D9B48F");
            Current.Resources["TertiaryTextColor"] = Color.FromHex("#2460A7");
            Current.Resources["AlternateTextColor"] = Color.FromHex("#85B3D1");

            //other colors
            Current.Resources["SuccessTextColor"] = Color.FromHex("#31f014");
            Current.Resources["FailureTextColor"] = Color.FromHex("#EC1D5C");

        }
    }
}
