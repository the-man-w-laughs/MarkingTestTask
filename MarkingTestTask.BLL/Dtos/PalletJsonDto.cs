namespace MarkingTestTask.DAL.Models
{
    public class PalletJsonDto
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public ICollection<BoxJsonDto> Boxes { get; set; } = new List<BoxJsonDto>();
    }
}
