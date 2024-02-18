namespace MarkingTestTask.DAL.Models
{
    public class MissionModel
    {
        public int Id { get; set; }
        public int MissionId { get; set; }
        public string Volume { get; set; } = string.Empty;
        public int BoxFormat { get; set; }
        public int PalletFormat { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Gtin { get; set; } = string.Empty;

        public ICollection<BoxModel> Boxes { get; set; } = new List<BoxModel>();
        public ICollection<PalletModel> Pallets { get; set; } = new List<PalletModel>();
        public ICollection<ProductModel> Products { get; set; } = new List<ProductModel>();
    }

}
