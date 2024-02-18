
using MarkingTestTask.BLL.Dtos;

namespace MarkingTestTask.BLL.Contracts
{
    public interface IBoxPalletPopulationService
    {
        Task PopulateBoxesAndPalletsAsync(MissionDto missionDto, List<string> codes);
    }
}
