using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Validation
{
    public class DomainExceptionValidation : Exception
    {
        public DomainExceptionValidation(string error) : base(error)
        {}


    //    DomainExceptionValidation.When(string.IsNullOrEmpty(name),
    //            "Invalid name. Name is required");

    //        DomainExceptionValidation.When(name.Length< 3,
    //"Invalid name, too short! Minimum 3 charecters");

        public static void When(bool hasError, string error)
        {
            if (hasError)
            {
                throw new DomainExceptionValidation(error);
            }
        }
    }
}
