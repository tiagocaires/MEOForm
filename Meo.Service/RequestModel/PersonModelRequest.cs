using Meo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meo.Service.RequestModel
{
    public class PersonModelRequest
    {
        public string Name { get; set; }
        public DateTime? Birth { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
    }
}
