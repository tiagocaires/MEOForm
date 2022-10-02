using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meo.Model.Factory
{
    public class CampaignFactory
    {
        public static Campaign Create(string pDescription, DateTime pStart, DateTime pEnd, string pName)
        {
            return new Campaign
            {
                Description = pDescription,
                Start = pStart,
                End = pEnd,
                Name = pName,
                Created = DateTime.UtcNow,
            };
        }
    }
}
