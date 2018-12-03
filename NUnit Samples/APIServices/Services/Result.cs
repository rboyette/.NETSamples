using System;
using System.Collections.Generic;
using System.Text;

namespace APIServices.Services
{
    public class Result<T>
    {
        public bool IsSucess { get; set; }
        public T Response { get; set; }
        public Status StatusCode { get;set; } 
    }

    public enum Status
    {
        Success = 1,
        NotFound = 2,
        BadRequest = 4,
        Unavailable = 5,
        Unknown = 6
    }
}
