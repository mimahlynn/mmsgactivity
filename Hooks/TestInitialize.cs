using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;

namespace APIDemo.Hooks
{
    [Binding]
    public class TestInitialize
    {

        public RestClient RestClient = new RestClient();
        public RestRequest RestRequest = new RestRequest();
        public IRestResponse Response { get; set; }

        [BeforeScenario]
        public void BeforeScenarioWithTag()
        {
            RestClient = new RestClient("https://reqres.in/");

            RestRequest.AddHeader("Accept", "application/json");

            RestRequest.RequestFormat = DataFormat.Json;

            Console.WriteLine("BeforeScenario");
        }

    }
}
