namespace MarkingTestTask.DAL.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public int BoxId { get; set; }
        public int MissionId { get; set; }
        public MissionModel? Mission { get; set; } = null;
        public BoxModel? Box { get; set; } = null;
    }
}
