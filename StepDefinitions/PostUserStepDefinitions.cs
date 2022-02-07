using System;
using TechTalk.SpecFlow;
using RestSharp;
using Newtonsoft.Json;
using APIDemo.DTO;
using APIDemo.Hooks;
using TechTalk.SpecFlow.Assist;


namespace APIDemo.StepDefinitions
{
    [Binding]
    public class PostUserStepDefinitions:TestInitialize
    {

        [Given(@"the user wants to post the data to (.*)")]
        public void GivenRequestURL(string url)
        {
            //Validate response
            RestRequest = new RestRequest(url, Method.POST);
        }


        [When(@"I create user with the following details")]
        public void WhenISendCreateUserRequest(Table table)
        {
            dynamic dataTable = table.CreateDynamicInstance();
            
            RestRequest.AddJsonBody(new { name = dataTable.name.ToString(), job = dataTable.job.ToString() });
            
            Response = RestClient.Execute(RestRequest);            
        }

        [When(@"I input the following details")]
        public void WhenIRegisterUser(Table table)
        {
            dynamic dataTable = table.CreateDynamicInstance();
            
            RestRequest.AddJsonBody(new { email = dataTable.email.ToString(), password = dataTable.password.ToString() });
            
            Response = RestClient.Execute(RestRequest);
        }

        [Then(@"validate user id is created with name (.*) and job (.*)")]
        public void ThenValidateUserIsCreated(string name,string job)
        {            
            var content = Response.Content;
            var list = JsonConvert.DeserializeObject<CreateUserDTO>(content);            
           
            //Validate response
            Response.StatusDescription.Should().Equals("Created");
            list.Id.Should().NotBe(null);
            list.Name.Should().Be(name);
            list.Job.Should().Be(job);          

        }

        [Then(@"validate response is successful")]
        public void ThenValidateUserIsSuccessfullyRegistered()
        {
            var content = Response.Content;

            //Validate response
            Response.StatusDescription.Should().Be("OK");
           
        }

        [Then(@"validate response is unsuccessful")]
        public void ThenValidateResponseIsUnsuccessful()
        {
            var content = Response.StatusDescription;
            
            //Validate response
            Response.StatusDescription.Should().Be("Bad Request");
           
        }


    }
}
