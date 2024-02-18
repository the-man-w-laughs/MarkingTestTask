using MarkingTestTask.DAL.Contracts;
using MarkingTestTask.DAL.Models;
using System.Collections.ObjectModel;
using System.Windows;

namespace MarkingTestTask.Presentation.MVVM
{
    public class BoxesViewModel : BaseViewModel
    {
        private readonly IBoxModelRepository _boxModelRepository;

        public ObservableCollection<BoxModel> Boxes { get; set; }

        public BoxesViewModel(IBoxModelRepository boxModelRepository)
        {
            _boxModelRepository = boxModelRepository;
            Boxes = new ObservableCollection<BoxModel>();
            LoadBoxesFromDB();
        }

        private async void LoadBoxesFromDB()
        {
            try
            {
                var boxes = await _boxModelRepository.GetAllAsync();
                Boxes = new ObservableCollection<BoxModel>(boxes);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при загрузке коробов: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }

}
