using MarkingTestTask.DAL.BaseRepository;
using MarkingTestTask.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace MarkingTestTask.DAL.Contracts
{
    public class BoxModelRepository : BaseRepository<MarkingTestTaskDBContext, BoxModel>, IBoxModelRepository
    {
        private readonly MarkingTestTaskDBContext _context;

        public BoxModelRepository(MarkingTestTaskDBContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<List<BoxModel>> GetAllByMissionId(int missionId)
        {
            var mission = await _context.Missions.FirstOrDefaultAsync(m => m.MissionId == missionId);

            if (mission != null)
            {
                return await _context.Boxes.Where(box => box.MissionId == mission.Id).ToListAsync();
            }
            else
            {
                return new List<BoxModel>();
            }
        }

    }
}
