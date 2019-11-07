using System;
using System.Collections.Generic;
using System.Text;

namespace Tavisca.Tripster.Contracts
{
   public  class FailureResponse<T>:Response
    {
          T Errors;
       // public Errorinfo ErrorInfo { get; set; }
        public FailureResponse()
        {
            Status = Status.failure;
        }

        public FailureResponse(T Error)
        {
            Errors = Error;
           
        }


    }
}
