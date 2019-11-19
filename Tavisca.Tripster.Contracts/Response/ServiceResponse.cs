using System;
using System.Collections.Generic;
using System.Text;

namespace Tavisca.Tripster.Contracts.Response
{
    public class ServiceResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
