using AutoMapper;
using Meo.Data;
using Meo.Data.Repository.Interface;
using Meo.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meo.Service.Business
{
    public class AnswerService : IAnswerService
    {
        private readonly IMapper _mapper;
        private readonly IAnswerRepository _ansewerRepository;

        public AnswerService(IMapper mapper, IAnswerRepository answerRepository)
        {
            _mapper = mapper;
            _ansewerRepository = answerRepository;
        }

    }
}
