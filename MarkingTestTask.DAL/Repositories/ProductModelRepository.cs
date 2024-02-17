using MarkingTestTask.DAL.BaseRepository;
using MarkingTestTask.DAL.Models;

namespace MarkingTestTask.DAL.Contracts
{
    public class ProductModelRepository : BaseRepository<MarkingTestTaskDBContext, ProductModel>, IProductModelRepository
    {
        public ProductModelRepository(MarkingTestTaskDBContext context)
            : base(context) { }
    }
}
