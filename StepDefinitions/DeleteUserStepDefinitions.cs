using System;
using TechTalk.SpecFlow;
using APIDemo.Hooks;
using RestSharp;
using Newtonsoft.Json;


namespace APIDemo.StepDefinitions
{
    [Binding]
    public class DeleteUserStepDefinitions:TestInitialize
    {
        [When(@"the user wants to delete the data from (.*)")]
        public void WhenTheUserWantsToDeleteTheDataFromApiUser(string url)
        {
            RestRequest = new RestRequest(url, Method.DELETE);

            Response = RestClient.Execute(RestRequest);

           
        }

        [Then(@"I should see that data is deleted")]
        public void ThenIShouldSeeThatDataIsDeleted()
        {
            var content = Response.StatusDescription;

            //Validate response
            Response.StatusDescription.Should().Be("No Content");
        }




    }
}
