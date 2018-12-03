using APIServices.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace APIServices.Models
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumer { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public int Id { get; set; }

        public static Person FromDto(PersonDto dto)
        {
            if (dto == null)
                return null;

            return new Person
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Age = dto.Age,
                Address = dto.Address,
                DateOfBirth = dto.DateOfBirth,
                PhoneNumer = dto.PhoneNumer,
                State = dto.State,
                ZipCode = dto.ZipCode,
                Id = dto.Id
            };
        }

        public static List<Person> FromDto(GetPersonResponseDto dto)
        {
            if (dto == null)
                return null;
            return dto.People.Select(Person.FromDto).ToList();
        }
    }
}
