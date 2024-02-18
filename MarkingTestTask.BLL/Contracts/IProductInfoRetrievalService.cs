using MarkingTestTask.BLL.Dtos;

namespace MarkingTestTask.BLL.Contracts
{
    public interface IProductInfoRetrievalService
    {
        Task<ProductLayoutInfoDto> GetProductInfoAsync();
    }
}
