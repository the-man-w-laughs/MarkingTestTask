namespace MarkingTestTask.DAL.Models
{
    public class BoxJsonDto
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public ICollection<ProductJsonDto> Products { get; set; } = new List<ProductJsonDto>();
    }
}
