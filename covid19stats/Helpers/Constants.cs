using System;
namespace covid19stats.Helpers
{
    public static class Constants
    {
        public static string BaseUrl = "https://corona.lmao.ninja";


        #region APIs

        public static string GetWorldsData = "/v3/covid-19/all"; //world's covid data
        public static string GetCountryList = "/v3/covid-19/apple/countries"; //list of countries data present
        public static string GetCountrySubregion = $"/v3/covid-19/apple/countries/"; //list of sub regions of a particular country
        public static string GetSubregiondata = $"/v3/covid-19/apple/countries"; //list of sub region data of a particular country
        public static string GetAllCountryData = "/v3/covid-19/countries"; //get all country covid data
        public static string GetACountryData = "/v3/covid-19/countries/"; //get a country covid data
        public static string GetAllContinentData = "/v3/covid-19/continents"; //get all covid data continent wise        

        public static string VaccineDetails = "/v3/covid-19/vaccine"; //get vaccine details
        public static string VaccineCoverageDataOfCountries = "/v3/covid-19/vaccine/coverage/countries"; //vaccine coverage for countries

        #endregion

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
