using Meo.Service.Interface;
using Meo.Service.RequestModel;
using Meo.Service.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Meo.WebAPI.Controllers
{
    [ApiController]
    [Route("api/campaign")]
    public class CampaignController : ControllerBase
    {
        private readonly ILogger<CampaignController> _logger;
        private readonly ICampaignService _campaignService;
        private readonly IFormService _formService;

        public CampaignController(ILogger<CampaignController> logger, ICampaignService campaignService, IFormService formService)
        {
            _logger = logger;
            _campaignService = campaignService;
            _formService = formService;
        }

        [HttpGet("active")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CampaignViewModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetActiveCampaign()
        {
            return await _campaignService.GetActiveCampaign();
        }

        [HttpGet("")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<CampaignViewModel>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll()
        {
            return await _campaignService.GetAll();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CampaignViewModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById(int id)
        {
            return await _campaignService.GetId(id);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public Task<IActionResult> Create([FromBody] CampaignModelRequest campaignModelRequest)
        {
            return _campaignService.Create(campaignModelRequest, Url.RouteUrl(0));
        }

        [HttpPost("{id}/reply-form")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(String))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public Task<IActionResult> ReplyForm(int id, [FromBody] FormModelRequest formModelRequest)
        {
            formModelRequest.CampaignId = id;
            return _formService.Create(formModelRequest);
        }
    }
}
