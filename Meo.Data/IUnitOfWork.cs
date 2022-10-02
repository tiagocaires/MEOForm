using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meo.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
        bool Roolback();
    }
}
