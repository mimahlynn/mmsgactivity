using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using APIDemo.Hooks;
using APIDemo.StepDefinitions;

namespace APIDemo.StepDefinitions
{
    [Binding]
    public class CommonValidation:TestInitialize
    {
        [Then(@"I should validate that data is (.*)")]
        public void ThenIShouldValidateThatDataIs(string status)
        {
            Console.WriteLine(StatusCode);
            status.ToLower();

            switch (StatusCode)
            {
                case System.Net.HttpStatusCode.OK:
                    status.Should().Be("processed");
                    break;
                case System.Net.HttpStatusCode.NoContent:
                    status.Should().Be("deleted");
                    break;
                case System.Net.HttpStatusCode.BadRequest:
                    status.Should().Be("not processed");
                    break;
                default:
                    break;
            }

        }

    }
}
