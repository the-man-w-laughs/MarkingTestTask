using MarkingTestTask.DAL.BaseRepository;
using MarkingTestTask.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace MarkingTestTask.DAL.Contracts
{
    public class ProductModelRepository : BaseRepository<MarkingTestTaskDBContext, ProductModel>, IProductModelRepository
    {
        private readonly MarkingTestTaskDBContext _context;

        public ProductModelRepository(MarkingTestTaskDBContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<List<ProductModel>> GetAllByMissionId(int missionId)
        {
            var mission = await _context.Missions.FirstOrDefaultAsync(m => m.MissionId == missionId);

            if (mission != null)
            {
                return await _context.Products.Where(product => product.MissionId == mission.Id).ToListAsync();
            }
            else
            {
                return new List<ProductModel>();
            }
        }

    }
}
