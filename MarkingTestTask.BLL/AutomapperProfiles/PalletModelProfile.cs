using MarkingTestTask.DAL.Models;

namespace MarkingTestTask.BLL.AutomapperProfiles
{
    // Класс, представляющий профиль AutoMapper для маппинга между DTO и моделями файлов
    public class PalletModelProfile : BaseProfile
    {
        public PalletModelProfile()
        {
            CreateMap<PalletModel, PalletJsonDto>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
               .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Code))
               .ForMember(dest => dest.Boxes, opt => opt.MapFrom(src => src.Boxes));
        }
    }
}
