using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meo.Model
{
    public abstract class AModelBase
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
    }
}
