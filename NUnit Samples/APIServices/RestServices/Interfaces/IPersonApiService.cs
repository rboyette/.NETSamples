using APIServices.DTOs;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace APIServices.RestServices.Interfaces
{
    public interface IPersonApiService
    {
        Task<HttpResponseMessage> GetPersonById(int id);
        Task<HttpResponseMessage> GetPersonByName(string firstName, string lastName);
        Task<HttpResponseMessage> GetPeopleByState(string state);
        Task<HttpResponseMessage> GetPeopleByZipCode(string zipCode);
        Task<HttpResponseMessage> CreatePerson(CreatePersonRequestDto requestBody);
    }
}
