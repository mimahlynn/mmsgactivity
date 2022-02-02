using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;
using APIDemo.DTO;
using TechTalk.SpecFlow.Assist;

namespace APIDemo.StepDefinitions
{
    [Binding]
    public class Actions
    {

        public RestClient RestClient = new RestClient("https://reqres.in");
        public RestRequest RestRequest = new RestRequest();
        public IRestResponse Response { get; set; }


        [Given("the user is connected to rest client")]
        public void ConnectToRestClient()
        {
            RestRequest.AddHeader("Accept","application/json");
            RestRequest.RequestFormat = DataFormat.Json;
        }

        [When(@"user create user with the following details")]
        public void WhenUserCreateUserWithTheFollowingDetails(Table table)
        {
            RestRequest = new RestRequest("/api/users", Method.POST);

            dynamic dataTable = table.CreateDynamicInstance();

            RestRequest.AddJsonBody(new { name = dataTable.name.ToString(), job = dataTable.job.ToString() });
            Response = RestClient.Execute(RestRequest);
            Console.WriteLine(Response.Content.ToString());
        }


        

        [When(@"user register with the following details")]
        public void WhenUserCreateRegisterWithTheFollowingDetails(Table table)
        {
            RestRequest = new RestRequest("/api/register", Method.POST);

            dynamic dataTable = table.CreateDynamicInstance();

            RestRequest.AddJsonBody(new { email = dataTable.email.ToString(), password = dataTable.password.ToString() });
            Response = RestClient.Execute(RestRequest);
            Console.WriteLine(Response.Content.ToString());

        }




        [When("the user calls get api with parameter (.*)")]
        public void GetAPI(string parameter)
        {
            RestRequest = new RestRequest(parameter, Method.GET);
            Response = RestClient.Execute(RestRequest);
        }


        [When("the user calls delete (.*)")]
        public void DeleteAPI(string parameter)
        {
            var restRequest = new RestRequest("parameter",Method.DELETE) ;
            Response = RestClient.Execute(RestRequest);
        }

        [When(@"the user login with the following details")]
        public void WhenTheUserLoginWithTheFollowingDetails(Table table)
        {
            RestRequest = new RestRequest("/api/login", Method.POST);

            dynamic dataTable = table.CreateDynamicInstance();

            RestRequest.AddJsonBody(new { email = dataTable.email.ToString(), password = dataTable.password.ToString() });
            Response = RestClient.Execute(RestRequest);
            Console.WriteLine(Response.Content.ToString());
        }


        [Then("list is not empty")]
        public void ListShouldNotBeEmpty()
        {
            Console.WriteLine(Response.Content.ToString());
            Response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);

        }

        [Then("list is empty")]
        public void ListShouldBeEmpty()
        {
            Console.WriteLine(Response.Content.ToString());
            Response.StatusCode = (System.Net.HttpStatusCode)404;
        }



        [Then("single user is displayed")]
        public void ListShoulHave()
        {
            Console.WriteLine(Response.Content.ToString());           
            Response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);  

        }


        [Then("user is created")]
        public void UserIsCreated()
        {            
            Console.WriteLine(Response.Content.ToString());
            Response.StatusCode = (System.Net.HttpStatusCode)201;

        }


        [Then("user is deleted")]
        public void UserIsDeleted()
        {
            Console.WriteLine(Response.Content.ToString());
            Response.StatusCode = (System.Net.HttpStatusCode)404;


        }

        [Then(@"user is registered")]
        public void ThenUserIsRegistered()
        {
            Console.WriteLine(Response.Content.ToString());
            Response.StatusCode = (System.Net.HttpStatusCode)200;
        }

        [Then(@"user is not registered")]
        public void ThenUserIsNotRegistered()
        {
            Console.WriteLine(Response.Content.ToString());
            Response.StatusCode = (System.Net.HttpStatusCode)400;
        }


        [Then(@"user login succesfully")]
        public void ThenUserLoginSuccesfully()
        {
            Console.WriteLine(Response.Content.ToString());
            Response.StatusCode = (System.Net.HttpStatusCode)200;
        }




    }
}
