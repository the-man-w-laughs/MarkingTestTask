namespace MarkingTestTask.DAL.Models
{
    public class PalletModel
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public ICollection<BoxModel> Boxes { get; set; } = new List<BoxModel>();
    }
}
