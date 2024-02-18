using MarkingTestTask.DAL.Models;

namespace MarkingTestTask.BLL.AutomapperProfiles
{
    // Класс, представляющий профиль AutoMapper для маппинга между DTO и моделями файлов
    public class ProductModelProfile : BaseProfile
    {
        public ProductModelProfile()
        {
            CreateMap<ProductModel, ProductJsonDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Code));
        }
    }
}
