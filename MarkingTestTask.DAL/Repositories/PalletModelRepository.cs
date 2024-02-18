using MarkingTestTask.DAL.BaseRepository;
using MarkingTestTask.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace MarkingTestTask.DAL.Contracts
{
    public class PalletModelRepository : BaseRepository<MarkingTestTaskDBContext, PalletModel>, IPalletModelRepository
    {
        private readonly MarkingTestTaskDBContext _context;

        public PalletModelRepository(MarkingTestTaskDBContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<List<PalletModel>> GetAllByMissionId(int missionId)
        {
            var mission = await _context.Missions.FirstOrDefaultAsync(m => m.MissionId == missionId);

            if (mission != null)
            {
                return await _context.Pallets.Where(pallet => pallet.MissionId == mission.Id).ToListAsync();
            }
            else
            {
                return new List<PalletModel>();
            }
        }

    }
}
