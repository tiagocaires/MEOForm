using AutoMapper;
using Meo.Data;
using Meo.Data.Repository;
using Meo.Data.Repository.Interface;
using Meo.Model;
using Meo.Model.Factory;
using Meo.Service.Interface;
using Meo.Service.RequestModel;
using Meo.Service.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meo.Service.Business
{
    public class FormService : IFormService
    {
        private readonly IMapper _mapper;
        private readonly IFormRepository _formRepository;
        private readonly ICampaignRepository _campaignRepository;
        private readonly IQuestionRepository _questionRepository;
        private readonly IPersonRepository _personRepository;

        public FormService(IMapper mapper, IFormRepository formRepository, ICampaignRepository campaignRepository, IQuestionRepository questionRepository, IPersonRepository personRepository)
        {
            _mapper = mapper;
            _formRepository = formRepository;
            _campaignRepository = campaignRepository;
            _questionRepository = questionRepository;
            _personRepository = personRepository;
        }

        public async Task<IActionResult> Create(FormModelRequest formRequest)
        {
            try
            {
                var campaign = await _campaignRepository.GetById(formRequest.CampaignId);
                if (campaign == null) return new BadRequestObjectResult("Campaign not found");

                var answers = new List<Answer>();
                foreach (var answer in formRequest.Answers)
                {
                    if (await _questionRepository.GetById(answer.QuestionId) == null)
                        return new BadRequestObjectResult("Question not found");
                    answers.Add(AnswerFactory.Create(0, answer.AnswerDescription, answer.QuestionId));
                }

                var person = PersonFactory.Create(formRequest.Person.Name, formRequest.Person.Email, formRequest.Person.Phone, formRequest.Person.Mobile, formRequest.Person.Birth);
                _personRepository.Add(person);
                await _personRepository.UnitOfWork.Commit();

                var form = FormFactory.Create(formRequest.CampaignId, person.Id, answers);
                _formRepository.Add(form);
                await _formRepository.UnitOfWork.Commit();

                return new CreatedResult("no-content", "Form sent successfully!");
            }
            catch (Exception)
            {
                return new BadRequestObjectResult("Internal Error. Please try in a moment..");
            }
        }
    }
}
