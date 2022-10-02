using AutoMapper;
using Meo.Model;
using Meo.Service.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meo.Service.Mapper
{
    internal class ClassMapper : Profile
    {
        public ClassMapper()
        {
            CreateMap<Campaign, CampaignViewModel>().ReverseMap();
            CreateMap<Question, QuestionViewModel>().ReverseMap();
            CreateMap<Form, FormViewModel>().ReverseMap();
            CreateMap<Person, PersonViewModel>().ReverseMap();
            CreateMap<Answer, AnswerViewModel>().ReverseMap();
        }
    }
}
