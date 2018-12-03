using APIServices.DTOs;
using APIServices.RestServices.Interfaces;
using APIServices.Services.Interfaces;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NUnitSamples.Factories
{
    public class ApiFactory
    {
        public static IPersonApiService CreatePersonApiService()
        {
            // NSubstitute doesn't really support async returns, so Task.FromResult is the workaround
            // Or use Moq
            var personApiService = Substitute.For<IPersonApiService>();
            personApiService.CreatePerson(Arg.Any<CreatePersonRequestDto>()).Returns(Task.FromResult(HttpResponseFactory.CreateOKResponseMessage(MockDataFactory.CreateNewPersonId())));
            personApiService.GetPersonById(1243).Returns(Task.FromResult(HttpResponseFactory.CreateOKResponseMessage(MockDataFactory.CreateMockPeron())));
            personApiService.GetPeopleByState(Arg.Any<string>()).Returns(Task.FromResult(HttpResponseFactory.CreateOKResponseMessage(MockDataFactory.GetPeople())));
            personApiService.GetPeopleByZipCode(Arg.Any<string>()).Returns(Task.FromResult(HttpResponseFactory.CreateOKResponseMessage(MockDataFactory.GetPeople())));
            personApiService.GetPersonByName(Arg.Any<string>(), Arg.Any<string>()).Returns(Task.FromResult(HttpResponseFactory.CreateOKResponseMessage(MockDataFactory.CreateMockPeron())));

            return personApiService;
        }
    }
}
