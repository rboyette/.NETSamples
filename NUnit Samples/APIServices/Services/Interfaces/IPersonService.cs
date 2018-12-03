using APIServices.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace APIServices.Services.Interfaces
{
    public interface IPersonService
    {
        Task<Result<Person>> GetPerson(int id);
        Task<Result<List<Person>>> GetPeopleByName(string firstName, string lastName);
        Task<Result<List<Person>>> GetPeopleByState(string state);
        Task<Result<List<Person>>> GetPeopleByZipCode(string zipCode);
        Task<Result<int>> CreatePerson(string firstName, string lastName, string address, string phoneNumber, string zipCode, string state, int age, DateTime dateOfBirth);
    }
}
