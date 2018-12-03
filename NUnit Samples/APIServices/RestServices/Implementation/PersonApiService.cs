using APIServices.DTOs;
using APIServices.RestServices.Apis;
using APIServices.RestServices.Interfaces;
using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace APIServices.RestServices.Implementation
{
    public class PersonApiService : IPersonApiService
    {
        private readonly IPersonApi _personApiService;

        public PersonApiService()
        {
            _personApiService = RestService.For<IPersonApi>("http://localhost:1786/");
        }

        public async Task<HttpResponseMessage> CreatePerson(CreatePersonRequestDto requestBody)
        {
            return await _personApiService.CreatePerson(requestBody);
        }

        public async Task<HttpResponseMessage> GetPeopleByState(string state)
        {
            return await _personApiService.GetPeopleByState(state);
        }

        public async Task<HttpResponseMessage> GetPeopleByZipCode(string zipCode)
        {
            return await _personApiService.GetPeopleByZipCode(zipCode);
        }

        public async Task<HttpResponseMessage> GetPersonById(int id)
        {
            return await _personApiService.GetPersonById(id);
        }

        public async Task<HttpResponseMessage> GetPersonByName(string firstName, string lastName)
        {
            return await _personApiService.GetPersonByName(firstName, lastName);
        }
    }
}
