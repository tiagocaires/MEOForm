using AutoMapper;
using Meo.Data;
using Meo.Data.Repository.Interface;
using Meo.Model;
using Meo.Model.Factory;
using Meo.Service.Interface;
using Meo.Service.RequestModel;
using Meo.Service.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meo.Service.Business
{
    public class CampaignService : ICampaignService
    {
        private readonly IMapper _mapper;
        private readonly ICampaignRepository _campaignRepository;
        private readonly IQuestionRepository _questionRepository;

        public CampaignService(IMapper mapper, ICampaignRepository campaignRepository, IQuestionRepository questionRepository)
        {
            _mapper = mapper;
            _campaignRepository = campaignRepository;
            _questionRepository = questionRepository;
        }

        public async Task<IActionResult> GetAll()
        {
            try
            {
                var campaigns = _campaignRepository.QList(null).ToList();

                var campaignsViewModel = new List<CampaignViewModel>();
                foreach (var cp in campaigns)
                    campaignsViewModel.Add(_mapper.Map<CampaignViewModel>(cp));

                return new OkObjectResult(campaignsViewModel);
            }
            catch (Exception)
            {
                return new BadRequestObjectResult("Internal Error. Please try in a moment..");
            }
        }

        public async Task<IActionResult> GetId(int id)
        {
            try
            {
                var campaign = await _campaignRepository.GetById(id);

                if (campaign == null) return new NotFoundResult();

                return new OkObjectResult(_mapper.Map<CampaignViewModel>(campaign));
            }
            catch (Exception)
            {
                return new BadRequestObjectResult("Internal Error. Please try in a moment..");
            }
        }

        public async Task<IActionResult> GetActiveCampaign()
        {
            try
            {
                DateTime now = DateTime.UtcNow;

                var campaign = await _campaignRepository.QList(x => x.Start <= now && x.End >= now)
                    .Include(x => x.Questions)
                    .FirstOrDefaultAsync();

                return new OkObjectResult(_mapper.Map<CampaignViewModel>(campaign));
            }
            catch (Exception)
            {
                return new BadRequestObjectResult("Internal Error. Please try in a moment..");
            }
        }

        public async Task<IActionResult> Create(CampaignModelRequest campaignRequest, string uri)
        {
            try
            {
                var campaignModel = CampaignFactory.Create(campaignRequest.Description, campaignRequest.Start, campaignRequest.End, campaignRequest.Name);
                _campaignRepository.Add(campaignModel);
                await _campaignRepository.UnitOfWork.Commit();

                foreach (var questionRequest in campaignRequest.Questions)
                {
                    var questionModel = QuestionFactory.Create(questionRequest.Description, campaignModel.Id);
                    _questionRepository.Add(questionModel);
                    await _questionRepository.UnitOfWork.Commit();
                }

                return new CreatedResult($"{uri}/campaignModel.Id", campaignModel.Id);
            }
            catch (Exception)
            {
                return new BadRequestObjectResult("Internal Error. Please try in a moment..");
            }
        }
    }
}
