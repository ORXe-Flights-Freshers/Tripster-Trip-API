using System;
using System.Collections.Generic;
using System.Text;
using Tavisca.Tripster.Contracts.Response;
using Tavisca.Tripster.Data.Models;

namespace Tavisca.Tripster.Contracts.Response
{
    public class UserResponse : ServiceResponse
    {
        public User User { get; set; }
    }
}
