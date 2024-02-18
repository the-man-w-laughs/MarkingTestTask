
using MarkingTestTask.BLL.Dtos;

namespace MarkingTestTask.BLL.Contracts
{
    public interface IBoxPalletPopulationService
    {
        Task PopulateBoxesAndPalletsAsync(ProductLayoutInfoDto productLayoutInfo, List<string> codes);
    }
}
