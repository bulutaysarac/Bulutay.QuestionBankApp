using AutoMapper;
using Bulutay.QuestionBankApp.Front.Models;

namespace Bulutay.QuestionBankApp.Front.Mappings
{
    public class LectureModelProfile : Profile
    {
        public LectureModelProfile()
        {
            CreateMap<LectureListModel, LectureUpdateModel>().ReverseMap();
        }
    }
}
