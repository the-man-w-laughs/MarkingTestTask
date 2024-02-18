using MarkingTestTask.DAL.BaseRepository;
using MarkingTestTask.DAL.Models;

namespace MarkingTestTask.DAL.Contracts
{
    public interface IMissionModelRepository : IBaseRepository<MissionModel>
    {
        Task<MissionModel?> GetMissionById(int missionId);
    }
}
