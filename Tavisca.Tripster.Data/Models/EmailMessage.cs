using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.RegularExpressions;

namespace Tavisca.Tripster.Data.Models
{
    public class EmailMessage
    {

        [ValidateList(ErrorMessage = "Invalid Receiver's Address")]
        public List<string> To { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Subject Can't be Empty")]
        [DataType(DataType.Text, ErrorMessage = "Body Can only be Text")]
        public string Subject { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Body Can't be Empty")]
        [DataType(DataType.Text, ErrorMessage = "Body Can only be Text")]
        public string Body { get; set; }
    }
    public sealed class ValidateList : ValidationAttribute
    {
        public override bool IsValid(object lists)
        {
            string pattern = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
         @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
         @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            var list = lists as IList<string>;
            Regex regex = new Regex(pattern);
            if (list != null)
            {
                if ((list.Count) > 0)
                {

                    foreach (var item in list)
                    {
                        if (!regex.IsMatch(item))
                        {
                            return false;
                        }
                    }
                    return true;
                }
            }
            return false;
        }
    }
}
