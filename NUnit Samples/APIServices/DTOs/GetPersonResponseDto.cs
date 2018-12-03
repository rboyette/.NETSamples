using System;
using System.Collections.Generic;
using System.Text;

namespace APIServices.DTOs
{
    public class GetPersonResponseDto
    {
        public List<PersonDto> People { get; set; }
    }

    public class PersonDto
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
    }
}
