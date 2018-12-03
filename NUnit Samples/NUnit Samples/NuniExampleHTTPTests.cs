
using APIServices.DTOs;
using APIServices.Models;
using APIServices.Services;
using APIServices.Services.Implementations;
using NSubstitute;
using NUnit.Framework;
using NUnitSamples.Factories;
using System;
using System.Collections.Generic;
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
            var expected = 1234;

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
        public async Task CreatePerson_UnavailableError_ShouldReturnAnUnavailableCode()
        {
            var expected = Status.Unavailable;

            var personApi = ApiFactory.CreatePersonApiService();
            personApi.CreatePerson(Arg.Any<CreatePersonRequestDto>()).Returns(Task.FromResult(HttpResponseFactory.CreateNotAvailableMessage(null)));
            var personService = new PersonService(personApi);

            var actual = await personService.CreatePerson("Lorem", "Ipsum", "123 Nowhere St", "509-555-1234", "99206", "WA", 23, new DateTime(1980, 01, 01));

            Assert.AreEqual(expected, actual.StatusCode);
        }

        [Test]
        public async Task GetPersonByState_ShouldReturnSeveralPeople()
        {
            var expected = new List<Person>
            {
                new Person
                {
                        FirstName = "Lorem",
                        LastName = "Ipsum",
                        DateOfBirth = new DateTime(1995, 01, 01),
                        Address = "123 Nowhere St",
                        State = "WA",
                        ZipCode = "99206",
                        Age = 23,
                        Id = 1243,
                        PhoneNumer = "509-555-1234"
                },
                new Person
                {
                        FirstName = "Loremo",
                        LastName = "Ettu",
                        DateOfBirth = new DateTime(1995, 02, 01),
                        Address = "12321 Somewhere St",
                        State = "WA",
                        ZipCode = "99206",
                        Age = 23,
                        Id = 1253,
                        PhoneNumer = "509-555-1258"
                },
                new Person
                {
                        FirstName = "Alice",
                        LastName = "Charlie",
                        DateOfBirth = new DateTime(1995, 03, 01),
                        Address = "12321 Other St",
                        State = "WA",
                        ZipCode = "99206",
                        Age = 23,
                        Id = 1263,
                        PhoneNumer = "509-555-1258"
                }
            };

            var personService = new PersonService(ApiFactory.CreatePersonApiService());

            var actual = await personService.GetPeopleByState("WA");

            Assert.IsNotNull(actual);
            Assert.IsNotNull(actual.Response);
            Assert.AreEqual(expected.Count, actual.Response.Count);

            using (var ex = expected.GetEnumerator())
            using (var ac = actual.Response.GetEnumerator())
            {
                while(ex.MoveNext() && ac.MoveNext())
                {
                    Assert.AreEqual(ex.Current.FirstName, ac.Current.FirstName);
                    Assert.AreEqual(ex.Current.LastName, ac.Current.LastName);
                    Assert.AreEqual(ex.Current.Address, ac.Current.Address);
                    Assert.AreEqual(ex.Current.Age, ac.Current.Age);
                    Assert.AreEqual(ex.Current.Id, ac.Current.Id);
                    Assert.AreEqual(ex.Current.State, ac.Current.State);
                    // can test all properties
                }
            }

        }
    }
}
