using Meo.Service.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meo.Service.RequestModel
{
    public class CampaignModelRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public List<QuestionModelRequest> Questions { get; set; } = new List<QuestionModelRequest>();
    }
}
