using MarkingTestTask.BLL.Dtos;

namespace MarkingTestTask.Presentation.Mediator
{
    public class CodesImportMediator : ICodesImportMediator
    {
        private static readonly CodesImportMediator _instance = new CodesImportMediator();
        public static CodesImportMediator Instance => _instance;

        public event EventHandler<CodesImportedEventArgs> CodesImported;

        public void NotifyCodesImported(MissionDto currentTaskInfo)
        {
            CodesImported?.Invoke(this, new CodesImportedEventArgs(currentTaskInfo));
        }
    }
}
