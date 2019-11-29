using System;
using System.Collections.Generic;
using System.Text;

namespace Tavisca.Tripster.Contracts.Response
{
    public class ServiceResponse
    {
        public bool IsSuccess
        {
            get
            {
                return string.IsNullOrWhiteSpace(Message);
            }
            private set { }
        }
        public string Message { get; set; }
    }
}
