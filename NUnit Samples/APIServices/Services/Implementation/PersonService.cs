using APIServices.DTOs;
using APIServices.Models;
using APIServices.RestServices.Apis;
using APIServices.RestServices.Interfaces;
using APIServices.Services.Interfaces;
using Newtonsoft.Json;
using Refit;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace APIServices.Services.Implementations
{
    public class PersonService : IPersonService
    {
        private readonly IPersonApiService _personApiService;
        public PersonService(IPersonApiService personApiService)
        {
            _personApiService = personApiService;
        }

        public async Task<Result<int>> CreatePerson(string firstName, string lastName, string address, string phoneNumber, string zipCode, string state, int age, DateTime dateOfBirth)
        {
            var result = new Result<int>();

            var requestBody = new CreatePersonRequestDto
            {
                FirstName = firstName,
                LastName = lastName,
                Address = address,
                Age = age,
                PhoneNumer = phoneNumber,
                State = state,
                ZipCode = zipCode,
                DateOfBirth = dateOfBirth
            };

            var response = await _personApiService.CreatePerson(requestBody);
            if (response.IsSuccessStatusCode)
            {
                var responseDto = JsonConvert.DeserializeObject<CreatePersonResponseDto>(await response.Content.ReadAsStringAsync());
                result.Response = responseDto.Id;
                result.IsSucess = true;
                result.StatusCode = Status.Success;
            }
            else if (response.StatusCode == HttpStatusCode.ServiceUnavailable)
                result.StatusCode = Status.Unavailable;
            else
                result.StatusCode = Status.Unknown;
            return result;
        }

        public async Task<Result<List<Person>>> GetPeopleByName(string firstName, string lastName)
        {
            var result = new Result<List<Person>>();
            var response = await _personApiService.GetPersonByName(firstName, lastName);
            if (response.IsSuccessStatusCode)
            {
                var responseDto = JsonConvert.DeserializeObject<GetPersonResponseDto>(await response.Content.ReadAsStringAsync());
                result.Response = Person.FromDto(responseDto);
                result.IsSucess = true;
                result.StatusCode = Status.Success;
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
                result.StatusCode = Status.NotFound;
            else if (response.StatusCode == HttpStatusCode.BadRequest)
                result.StatusCode = Status.BadRequest;
            else if (response.StatusCode == HttpStatusCode.ServiceUnavailable)
                result.StatusCode = Status.Unavailable;
            else
                result.StatusCode = Status.Unknown;
            return result;
        }

        public async Task<Result<List<Person>>> GetPeopleByState(string state)
        {
            var result = new Result<List<Person>>();
            var response = await _personApiService.GetPeopleByState(state);
            if (response.IsSuccessStatusCode)
            {
                var responseDto = JsonConvert.DeserializeObject<GetPersonResponseDto>(await response.Content.ReadAsStringAsync());
                result.Response = Person.FromDto(responseDto);
                result.IsSucess = true;
                result.StatusCode = Status.Success;
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
                result.StatusCode = Status.NotFound;
            else if (response.StatusCode == HttpStatusCode.BadRequest)
                result.StatusCode = Status.BadRequest;
            else if (response.StatusCode == HttpStatusCode.ServiceUnavailable)
                result.StatusCode = Status.Unavailable;
            else
                result.StatusCode = Status.Unknown;
            return result;
        }

        public async Task<Result<List<Person>>> GetPeopleByZipCode(string zipCode)
        {
            var result = new Result<List<Person>>();
            var response = await _personApiService.GetPeopleByZipCode(zipCode);
            if (response.IsSuccessStatusCode)
            {
                var responseDto = JsonConvert.DeserializeObject<GetPersonResponseDto>(await response.Content.ReadAsStringAsync());
                result.Response = Person.FromDto(responseDto);
                result.IsSucess = true;
                result.StatusCode = Status.Success;
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
                result.StatusCode = Status.NotFound;
            else if (response.StatusCode == HttpStatusCode.BadRequest)
                result.StatusCode = Status.BadRequest;
            else if (response.StatusCode == HttpStatusCode.ServiceUnavailable)
                result.StatusCode = Status.Unavailable;
            else
                result.StatusCode = Status.Unknown;
            return result;
        }

        public async Task<Result<Person>> GetPerson(int id)
        {
            var result = new Result<Person>();
            var response = await _personApiService.GetPersonById(id);
            if (response.IsSuccessStatusCode)
            {
                var responseDto = JsonConvert.DeserializeObject<PersonDto>(await response.Content.ReadAsStringAsync());
                result.Response = Person.FromDto(responseDto);
                result.IsSucess = true;
                result.StatusCode = Status.Success;
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
                result.StatusCode = Status.NotFound;
            else if (response.StatusCode == HttpStatusCode.BadRequest)
                result.StatusCode = Status.BadRequest;
            else if (response.StatusCode == HttpStatusCode.ServiceUnavailable)
                result.StatusCode = Status.Unavailable;
            else
                result.StatusCode = Status.Unknown;
            return result;
        }
    }
}
