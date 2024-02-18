using MarkingTestTask.DAL.Models;

namespace MarkingTestTask.BLL.AutomapperProfiles
{
    // Класс, представляющий профиль AutoMapper для маппинга между DTO и моделями файлов
    public class BoxModelProfile : BaseProfile
    {
        public BoxModelProfile()
        {
            CreateMap<BoxModel, BoxJsonDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Code))
                .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Products));
        }
    }
}
