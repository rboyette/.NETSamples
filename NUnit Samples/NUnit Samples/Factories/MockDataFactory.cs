using APIServices.DTOs;
using APIServices.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUnitSamples.Factories
{
    public class MockDataFactory
    {
        public static PersonDto CreateMockPeron()
        {
            return new PersonDto
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
            };
        }

        public static CreatePersonResponseDto CreateNewPersonId()
        {
            return new CreatePersonResponseDto
            {
                Id = 1234
            };
        }

        public static GetPersonResponseDto GetPeople()
        {
            return new GetPersonResponseDto
            {
                People = new List<PersonDto>
                {
                    new PersonDto
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
                    new PersonDto
                    {
                         FirstName = "Loremo",
                         LastName = "Ettu",
                         DateOfBirth = new DateTime(1995, 02, 01),
                         Address = "12321 Somewhere St",
                         State = "WA",
                         ZipCode = "99206",
                         Age = 23,
                         Id = 1243,
                         PhoneNumer = "509-555-1258"
                    },
                    new PersonDto
                    {
                         FirstName = "Alice",
                         LastName = "Charlie",
                         DateOfBirth = new DateTime(1995, 03, 01),
                         Address = "12321 Other St",
                         State = "WA",
                         ZipCode = "99206",
                         Age = 23,
                         Id = 1243,
                         PhoneNumer = "509-555-1258"
                    },
                }
            };
        }
    }
}
