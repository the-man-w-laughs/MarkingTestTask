using MarkingTestTask.DAL.Contracts;
using MarkingTestTask.DAL.Models;
using System.Collections.ObjectModel;
using System.Windows;

namespace MarkingTestTask.Presentation.MVVM
{
    public class PalletsViewModel : BaseViewModel
    {
        private readonly IPalletModelRepository _palletModelRepository;

        public ObservableCollection<PalletModel> Pallets { get; set; }

        public PalletsViewModel(IPalletModelRepository palletModelRepository)
        {
            _palletModelRepository = palletModelRepository;
            Pallets = new ObservableCollection<PalletModel>();
            LoadPalletsFromDB();
        }

        private async void LoadPalletsFromDB()
        {
            try
            {
                var pallets = await _palletModelRepository.GetAllAsync();
                Pallets = new ObservableCollection<PalletModel>(pallets);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при загрузке коробов: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }

}
