using System;
using System.Collections.Generic;
using System.Text;

namespace Tavisca.Tripster.Contracts
{
    public  class SucessResponse<T>:Response
    {
       
        public T Response;
        public SucessResponse()
        {
            Status = Status.success;
        }

        public SucessResponse( T response )
        {
            Status = Status.success;
            Response = response;
        }
      

    }
}
