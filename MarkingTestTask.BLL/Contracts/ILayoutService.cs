
namespace MarkingTestTask.BLL.Contracts
{
    public interface ILayoutService
    {
        Task CreateLayoutJsonFileAsync(int missionId);
    }
}