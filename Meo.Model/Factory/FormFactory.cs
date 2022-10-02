using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meo.Model.Factory
{
    public class FormFactory
    {
        public static Form Create(int pCampaignId, int pPersonId, List<Answer> pAnswers)
        {
            return new Form
            {
                CampaignId = pCampaignId,
                PersonId = pPersonId,
                Answers = pAnswers,
                Created = DateTime.UtcNow,
            };
        }
    }
}
