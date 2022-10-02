using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meo.Model.Factory
{
    public class QuestionFactory
    {
        public static Question Create(string pDescription, int pCampaignId)
        {
            return new Question
            {
                Description = pDescription,
                CampaignId = pCampaignId,
                Created = DateTime.UtcNow,
            };
        }
    }
}
