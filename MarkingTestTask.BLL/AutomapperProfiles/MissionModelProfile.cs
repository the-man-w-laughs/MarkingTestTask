using MarkingTestTask.DAL.Models;

namespace MarkingTestTask.BLL.AutomapperProfiles
{
    // Класс, представляющий профиль AutoMapper для маппинга между DTO и моделями файлов
    public class MissionModelProfile : BaseProfile
    {
        public MissionModelProfile()
        {
            CreateMap<MissionModel, MissionJsonDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.MissionId, opt => opt.MapFrom(src => src.MissionId))
                .ForMember(dest => dest.Volume, opt => opt.MapFrom(src => src.Volume))
                .ForMember(dest => dest.BoxFormat, opt => opt.MapFrom(src => src.BoxFormat))
                .ForMember(dest => dest.PalletFormat, opt => opt.MapFrom(src => src.PalletFormat))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Gtin, opt => opt.MapFrom(src => src.Gtin))
                .ForMember(dest => dest.Pallets, opt => opt.MapFrom(src => src.Pallets));
        }
    }
}
