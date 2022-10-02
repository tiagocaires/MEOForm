using Meo.Data.Repository.Interface;
using Meo.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meo.Data.Repository
{
    public class CampaignRepository : Repository<Campaign>, ICampaignRepository
    {
        public CampaignRepository(MeoContext db) : base(db)
        {
        }

        public async override Task<Campaign> GetById(int id)
        {
            return await _dbFilter.Include(x => x.Questions).AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
