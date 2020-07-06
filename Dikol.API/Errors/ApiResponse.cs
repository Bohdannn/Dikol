using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dikol.API.Errors
{
    public class ApiResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }

        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }

        private string GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "You have made a bad request.",
                401 => "You are not authorized.",
                404 => "Resource was not found.",
                500 => "Something has gone wrong on the website's server. ",
                _ => null
            };
        }

    }
}
