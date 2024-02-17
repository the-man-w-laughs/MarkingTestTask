using MarkingTestTask.DAL.BaseRepository;
using MarkingTestTask.DAL.Models;

namespace MarkingTestTask.DAL.Contracts
{
    public class PalletModelRepository : BaseRepository<MarkingTestTaskDBContext, PalletModel>, IPalletModelRepository
    {
        public PalletModelRepository(MarkingTestTaskDBContext context)
            : base(context) { }
    }
}
