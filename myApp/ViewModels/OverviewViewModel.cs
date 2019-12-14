using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Extensions;

namespace myApp.ViewModels
{
    public class OverviewViewModel : IOverviewViewModel
    {
        private readonly IRestClient _client;

        public OverviewViewModel(IRestClient client)
        {
            _client = client;
        }

        public void GetNetatmoToken()
        {
            var client = new RestClient("https://api.netatmo.com/oauth2/authorize");
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddParameter("application/x-www-form-urlencoded", "grant_type=client_credentials&client_id=abc&client_secret=123", ParameterType.RequestBody);
            IRestResponse response = _client.Execute(request);
        }

        public void GetWeather()
        {
            var client = new RestClient("https://community-open-weather-map.p.rapidapi.com/");
            var request = new RestRequest("weather?callback=test&id=2172797&units=%2522metric%2522%20or%20%2522imperial%2522&mode=xml%252C%20html&q=Schleitheim", DataFormat.Json);
            request.AddHeader("x-rapidapi-host", "community-open-weather-map.p.rapidapi.com");
            request.AddHeader("x-rapidapi-key", "0e2dbb84afmsh5804022d412f734p1a4d04jsnde57770ddfcb");
            //IRestResponse response = client.Execute(request);
            var response = client.Get(request).Content.
        }
    }
}
