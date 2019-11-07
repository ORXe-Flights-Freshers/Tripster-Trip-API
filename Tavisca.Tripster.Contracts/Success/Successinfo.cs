using System;
using System.Collections.Generic;
using System.Text;

namespace Tavisca.Tripster.Contracts
{
    public class Successinfo
    {

        public int SucessCode { get; set; }
        public string SucessMessage { get; set; }

        public Successinfo(int SuccessCode, string SuccessMessages)
        {
            SucessCode = SuccessCode;
            SucessMessage = SuccessMessages;
        }
    }
}
