using MarkingTestTask.DAL.BaseRepository;
using MarkingTestTask.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace MarkingTestTask.DAL.Contracts
{
    public class MissionModelRepository : BaseRepository<MarkingTestTaskDBContext, MissionModel>, IMissionModelRepository
    {
        private readonly MarkingTestTaskDBContext _context;

        public MissionModelRepository(MarkingTestTaskDBContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<MissionModel?> GetMissionById(int missionId)
        {
            return await _context.Missions
                .Include(m => m.Pallets)
                .ThenInclude(p => p.Boxes)
                .ThenInclude(b => b.Products)
                .FirstOrDefaultAsync(m => m.MissionId == missionId);
        }
    }
}
