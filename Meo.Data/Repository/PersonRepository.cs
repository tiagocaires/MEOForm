using Meo.Data.Repository.Interface;
using Meo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meo.Data.Repository
{
    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        public PersonRepository(MeoContext db) : base(db)
        {
        }
    }
}
