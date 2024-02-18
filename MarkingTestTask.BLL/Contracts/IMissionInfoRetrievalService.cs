using MarkingTestTask.BLL.Dtos;

namespace MarkingTestTask.BLL.Contracts
{
    public interface IMissionInfoRetrievalService
    {
        Task<MissionDto> GetMissionInfoAsync();
    }
}
