using APIServices.DTOs;
using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace APIServices.RestServices.Apis
{
    public interface IPersonApi
    {
        [Get("/api/Person/{id}")]
        Task<HttpResponseMessage> GetPersonById(int id);

        [Get("/api/Person?firstname={firstName}&lastname={lastName}")]
        Task<HttpResponseMessage> GetPersonByName(string firstName, string lastName);

        [Get("/api/Person?state={state}")]
        Task<HttpResponseMessage> GetPeopleByState(string state);

        [Get("/api/Person?zipcode={zipCode}")]
        Task<HttpResponseMessage> GetPeopleByZipCode(string zipCode);

        [Post("/api/Person")]
        Task<HttpResponseMessage> CreatePerson([Body] CreatePersonRequestDto requestBody);
    }
}
