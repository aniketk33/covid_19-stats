using System;
namespace covid19stats.Helpers
{
    public static class Constants
    {
        public static string BaseUrl = "https://corona.lmao.ninja";

        //list of countries data present: v3/covid-19/apple/countries
        //list of countries subregion data present: v3/covid-19/apple/countries/country

        //url for continents: /v3/covid-19/continents
        //sort continent : v3/covid-19/continents?sort={parameter name}
        //country data: /v3/covid-19/countries
        //get specific country data /v3/covid-19/countries/{country name}
        //get usa state data /v3/covid-19/states

        //get vaccine details: /v3/covid-19/vaccine
        //get vaccine coverage data for countries v3/covid-19/vaccine/coverage/countries
        //get vaccine coverage data for a particular country v3/covid-19/vaccine/coverage/countries/{country name}

        //get cases, deaths data for a month /v3/covid-19/historical

        //get overall world's data v3/covid-19/all
    }
}
