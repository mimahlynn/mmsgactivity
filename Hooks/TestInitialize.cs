using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;
using System.Net;
using System.IO;
using Microsoft.Extensions.Configuration;


namespace APIDemo.Hooks
{

    public class TestInitialize
    {

        public RestClient RestClient = new RestClient();
        public RestRequest RestRequest = new RestRequest();
        public IRestResponse Response { get; set; }
        public static Enum StatusCode;
        public string environmentURL { get; set; }

    

        [BeforeScenario]
        public void BeforeScenarioWithTag()
        {

            var config = new ConfigurationBuilder()
               .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
               .AddJsonFile("appsettings.json").Build();

            var section = config.GetSection(nameof(EnvironmentsConfig));
            var environmentsConfig = section.Get<EnvironmentsConfig>();

            environmentURL = environmentsConfig.EnvironmentURL;

            RestClient = new RestClient(environmentURL);

            RestRequest.AddHeader("Accept", "application/json");

            RestRequest.RequestFormat = DataFormat.Json;
        }

    }
}
