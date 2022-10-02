using Meo.Data;
using Meo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meo.XUnitTest
{
    public class FakeDB<T> : IUnitOfWork where T : AModelBase

    {
        public List<T> Context;
        public Task<bool> Commit()
        {
            return Task.FromResult(Context.Any());
        }

        public bool Roolback()
        {
            return true;
        }

        internal void Dispose()
        {

        }
    }
}
