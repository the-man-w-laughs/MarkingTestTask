namespace MarkingTestTask.DAL.Models
{
    public class PalletModel
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public int MissionId { get; set; }
        public MissionModel? Mission { get; set; } = null;
        public ICollection<BoxModel> Boxes { get; set; } = new List<BoxModel>();
    }
}
