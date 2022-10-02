using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meo.Model
{
    public class Question : AModelBase
    {
        public string Description { get; set; }
        public Campaign Campaign { get; set; }
        public int CampaignId { get; set; }
    }
}
