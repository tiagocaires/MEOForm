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
    public class QuestionService : IQuestionService
    {
        private readonly IMapper _mapper;
        private readonly IQuestionRepository _questionRepository;

        public QuestionService(IMapper mapper, IQuestionRepository questionRepository)
        {
            _mapper = mapper;
            _questionRepository = questionRepository;
        }

    }
}
