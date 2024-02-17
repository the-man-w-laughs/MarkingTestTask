using MarkingTestTask.DAL.BaseRepository;
using MarkingTestTask.DAL.Models;

namespace MarkingTestTask.DAL.Contracts
{
    public class BoxModelRepository : BaseRepository<MarkingTestTaskDBContext, BoxModel>, IBoxModelRepository
    {
        public BoxModelRepository(MarkingTestTaskDBContext context)
            : base(context) { }
    }
}
