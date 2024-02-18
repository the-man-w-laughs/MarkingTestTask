namespace MarkingTestTask.DAL.Models
{
    public class BoxModel
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public int PalletId { get; set; }
        public int MissionId { get; set; }
        public MissionModel? Mission { get; set; } = null;
        public PalletModel? Pallet { get; set; } = null;
        public ICollection<ProductModel> Products { get; set; } = new List<ProductModel>();
    }
}
