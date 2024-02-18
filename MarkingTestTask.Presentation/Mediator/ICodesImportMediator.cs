using MarkingTestTask.BLL.Dtos;

namespace MarkingTestTask.Presentation.Mediator
{
    public interface ICodesImportMediator
    {
        event EventHandler<CodesImportedEventArgs> CodesImported;

        void NotifyCodesImported(MissionDto currentTaskInfo);
    }
}
