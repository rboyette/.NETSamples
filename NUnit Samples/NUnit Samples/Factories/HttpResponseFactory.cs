using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;

namespace NUnitSamples.Factories
{
    public class HttpResponseFactory
    {
        
        public static HttpResponseMessage CreateOKResponseMessage(object o)
        {
            return new HttpResponseMessage
            {
                Content = new StringContent(JsonConvert.SerializeObject(o ?? new object())),
                StatusCode = HttpStatusCode.OK
            };
        }

        public static HttpResponseMessage CreateBadRequestMessage(object o)
        {
            return new HttpResponseMessage
            {
                Content = new StringContent(JsonConvert.SerializeObject(o ?? new object())),
                StatusCode = HttpStatusCode.BadRequest
            };
        }

        public static HttpResponseMessage CreateNotAvailableMessage(object o)
        {
            return new HttpResponseMessage
            {
                Content = new StringContent(JsonConvert.SerializeObject(o ?? new object())),
                StatusCode = HttpStatusCode.ServiceUnavailable
            };
        }

    }
}
