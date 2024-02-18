using MarkingTestTask.DAL.BaseRepository;
using MarkingTestTask.DAL.Models;

namespace MarkingTestTask.DAL.Contracts
{
    public interface IProductModelRepository : IBaseRepository<ProductModel>
    {
        Task<List<ProductModel>> GetAllByMissionId(int missionId);
    }
}
