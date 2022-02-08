using System;
using TechTalk.SpecFlow;
using RestSharp;
using Newtonsoft.Json;
using APIDemo.DTO;
using APIDemo.Hooks;


namespace APIDemo.StepDefinitions
{
    [Binding]
    public class GETUsersStepDefinitions : TestInitialize
    {
        [When(@"the user wants to get the data from (.*)")]
        public void GivenIHaveAccessedTheWebsite(string url)
        {
            RestRequest = new RestRequest(url, Method.GET);
            Response = RestClient.Execute(RestRequest);
            
        }


        [Then(@"I should see that data is page (.*), First Name is (.*) and Last Name is (.*)")]
        public void ThenIShouldSeeData(int page,string firstName,string lastName)
        {
            var content = Response.Content;           
            var list = JsonConvert.DeserializeObject<ListOfUsersDTO>(content);
            var users = list.Data;

            //Validate Response
            list.Page.Should().Be(page);
            users[0].First_Name.Should().Be(firstName);
            users[0].Last_Name.Should().Be(lastName);
         }

        [Then(@"I should see that data contain First Name (.*)")]
        public void ThenIShouldSeeThatDataContainFirstName(string firstName)
        {

            var content = Response.Content;
            var list = JsonConvert.DeserializeObject<SingleUserDTO>(content);
            var users = list.Data;

            //Validate Response
            users.First_Name.Should().Be(firstName);
        }


        [Then(@"I should see that data is not found")]
        public void ThenIShouldSeeThatDataIsNotFound()
        {
            var content = Response.StatusCode.ToString();
            
            //Validate Response
            Console.WriteLine(content);
            content.Should().Be("NotFound");            

        }


    }
}
