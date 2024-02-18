using MarkingTestTask.DAL.BaseRepository;
using MarkingTestTask.DAL.Models;

namespace MarkingTestTask.DAL.Contracts
{
    public interface IPalletModelRepository : IBaseRepository<PalletModel>
    {
        Task<List<PalletModel>> GetAllByMissionId(int missionId);
    }
}
