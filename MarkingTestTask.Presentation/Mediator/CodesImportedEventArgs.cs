using MarkingTestTask.BLL.Dtos;

namespace MarkingTestTask.Presentation.Mediator
{
    public class CodesImportedEventArgs : EventArgs
    {
        public MissionDto CurrentMissionInfo { get; }

        public CodesImportedEventArgs(MissionDto currentTaskInfo)
        {
            CurrentMissionInfo = currentTaskInfo;
        }
    }
}
