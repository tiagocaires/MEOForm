using Meo.Service.RequestModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meo.Service.Interface
{
    public interface ICampaignService
    {
        Task<IActionResult> GetActiveCampaign();
        Task<IActionResult> GetAll();
        Task<IActionResult> GetId(int id);
        Task<IActionResult> Create(CampaignModelRequest campaignRequest, string uri);
    }
}
