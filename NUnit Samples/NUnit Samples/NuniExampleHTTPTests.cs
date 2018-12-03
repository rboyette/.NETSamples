
using APIServices.DTOs;
using APIServices.Models;
using APIServices.Services;
using APIServices.Services.Implementations;
using NSubstitute;
using NUnit.Framework;
using NUnitSamples.Factories;
using System;
using System.Net;
using System.Threading.Tasks;

namespace NUnit_Samples
{
    [TestFixture]
    public class NunitExampleHTTPTests
    {

        [Test]
        public async Task CreatePerson_ShouldReturnAnID()
        {
            var expected = 1243;

            var personService = new PersonService(ApiFactory.CreatePersonApiService());

            var actual = await personService.CreatePerson("Lorem", "Ipsum", "123 Nowhere St", "509-555-1234", "99206", "WA", 23, new DateTime(1980, 01, 01));

            Assert.AreEqual(expected, actual.Response);
        }

        [Test]
        public async Task CreatePerson_ServiceUnavailable_ShouldReturnServiceUnavailableCode()
        {
            var expected = Status.Unavailable;

            var personApi = ApiFactory.CreatePersonApiService();
            personApi.CreatePerson(Arg.Any<CreatePersonRequestDto>()).Returns(Task.FromResult(HttpResponseFactory.CreateNotAvailableMessage(null)));
            var personService = new PersonService(personApi);

            var actual = await personService.CreatePerson("Lorem", "Ipsum", "123 Nowhere St", "509-555-1234", "99206", "WA", 23, new DateTime(1980, 01, 01));

            Assert.AreEqual(expected, actual.StatusCode);
        }

        [Test]
        public async Task CreatePerson_UnknownError_ShouldReturnAnUnknownCode()
        {
            var expected = Status.Unknown;

            var personApi = ApiFactory.CreatePersonApiService();
            personApi.CreatePerson(Arg.Any<CreatePersonRequestDto>()).Returns(Task.FromResult(HttpResponseFactory.CreateNotAvailableMessage(null)));
            var personService = new PersonService(personApi);

            var actual = await personService.CreatePerson("Lorem", "Ipsum", "123 Nowhere St", "509-555-1234", "99206", "WA", 23, new DateTime(1980, 01, 01));

            Assert.AreEqual(expected, actual.StatusCode);
        }

        [Test]
        public async Task GetPersonById_ShouldReturnAPerson()
        {
            var expected = Person.FromDto(MockDataFactory.CreateMockPeron());

            var personService = new PersonService(ApiFactory.CreatePersonApiService());

        }
    }
}
