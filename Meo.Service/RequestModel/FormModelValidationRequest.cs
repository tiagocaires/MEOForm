using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meo.Service.RequestModel
{
    public class FormModelValidationRequest : AModelRequest
    {
        public int CampaignId { get; set; }
        public PersonModelRequest Person { get; set; }
        public List<AnswerModelRequest> Answers { get; set; } = new List<AnswerModelRequest>();
    }
}
