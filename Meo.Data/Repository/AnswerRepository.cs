using Meo.Data.Repository.Interface;
using Meo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meo.Data.Repository
{
    public class AnswerRepository : Repository<Answer>, IAnswerRepository
    {
        public AnswerRepository(MeoContext db) : base(db)
        {
        }
    }
}
