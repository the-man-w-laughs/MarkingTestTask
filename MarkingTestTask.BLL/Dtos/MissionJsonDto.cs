namespace MarkingTestTask.DAL.Models
{
    public class MissionJsonDto
    {
        public int Id { get; set; }
        public int MissionId { get; set; }
        public string Volume { get; set; } = string.Empty;
        public int BoxFormat { get; set; }
        public int PalletFormat { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Gtin { get; set; } = string.Empty;
        public ICollection<PalletJsonDto> Pallets { get; set; } = new List<PalletJsonDto>();
    }

}
