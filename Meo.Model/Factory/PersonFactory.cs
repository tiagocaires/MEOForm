using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Meo.Model.Factory
{
    public class PersonFactory
    {
        public static Person Create(string pName, string pEmail, string pPhone, string pMobile, DateTime? pBirth)
        {
            return new Person
            {
                Name = pName,
                Email = pEmail,
                Birth = pBirth,
                Phone = pPhone,
                Mobile = pMobile,
                Created = DateTime.UtcNow,
            };
        }
    }
}
