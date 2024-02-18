using MarkingTestTask.BLL.Dtos;
using MarkingTestTask.DAL.Contracts;
using MarkingTestTask.DAL.Models;
using MarkingTestTask.Presentation.Mediator;
using System.Collections.ObjectModel;
using System.Windows;

namespace MarkingTestTask.Presentation.MVVM
{
    public class BoxesViewModel : BaseViewModel
    {
        private readonly IBoxModelRepository _boxModelRepository;
        private readonly ICodesImportMediator _codesImportMediator;

        private ObservableCollection<BoxModel> _boxes;
        public ObservableCollection<BoxModel> Boxes
        {
            get => _boxes;
            set => SetProperty(ref _boxes, value, nameof(Boxes));
        }

        public BoxesViewModel(IBoxModelRepository boxModelRepository, ICodesImportMediator codesImportMediator)
        {
            _boxModelRepository = boxModelRepository;
            _codesImportMediator = codesImportMediator;
            Boxes = new ObservableCollection<BoxModel>();
            _codesImportMediator.CodesImported += HandleCodesImported;

        }

        private void HandleCodesImported(object? sender, CodesImportedEventArgs e)
        {
            LoadBoxesFromDB(e.CurrentMissionInfo);
        }

        private async void LoadBoxesFromDB(MissionDto missionDto)
        {
            try
            {
                var boxes = await _boxModelRepository.GetAllByMissionId(missionDto.MissionId);
                Boxes = new ObservableCollection<BoxModel>(boxes);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при загрузке коробов: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }

}
