using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meo.Model
{
    public class Form : AModelBase
    {
        public Campaign Campaign { get; set; }
        public int CampaignId { get; set; }
        public Person Person { get; set; }
        public int PersonId { get; set; }
        public List<Answer> Answers { get; set; } = new List<Answer>();
    }
}