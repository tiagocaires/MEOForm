using Meo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meo.Service.ViewModel
{
    public class PersonViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? Birth { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
    }
}
