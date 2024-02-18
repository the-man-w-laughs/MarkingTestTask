using MarkingTestTask.BLL.Contracts;
using MarkingTestTask.BLL.Dtos;
using MarkingTestTask.DAL.Contracts;
using MarkingTestTask.DAL.Models;
using MarkingTestTask.Presentation.Mediator;
using System.Collections.ObjectModel;
using System.Windows;

namespace MarkingTestTask.Presentation.MVVM
{
    public class PalletsViewModel : BaseViewModel
    {
        private readonly IPalletModelRepository _palletModelRepository;
        private readonly ICodesImportMediator _codesImportMediator;
        private readonly ILayoutService _layoutService;
        private ObservableCollection<PalletModel> _pallets;

        public ObservableCollection<PalletModel> Pallets
        {
            get => _pallets;
            set => SetProperty(ref _pallets, value, nameof(Pallets));
        }

        public RelayCommand CreateLayoutCommand { get; }

        private bool _isCreateLayoutButtonBusy;
        public bool IsCreateLayoutButtonBusy
        {
            get => _isCreateLayoutButtonBusy;
            set => SetProperty(ref _isCreateLayoutButtonBusy, value, nameof(IsCreateLayoutButtonBusy));
        }
        public MissionDto CurrentMissionModel { get; private set; }

        public PalletsViewModel(IPalletModelRepository palletModelRepository, ICodesImportMediator codesImportMediator, ILayoutService layoutService)
        {
            _palletModelRepository = palletModelRepository;
            _codesImportMediator = codesImportMediator;
            _layoutService = layoutService;
            Pallets = new ObservableCollection<PalletModel>();
            _codesImportMediator.CodesImported += HandleCodesImported;
            CreateLayoutCommand = new RelayCommand(async parameter => await CreateLayout(), (_) => !IsCreateLayoutButtonBusy);
        }

        public async Task CreateLayout()
        {
            try
            {
                IsCreateLayoutButtonBusy = true;
                await _layoutService.CreateLayoutJsonFileAsync(CurrentMissionModel.MissionId);
                MessageBox.Show("Файл макета успешно создан.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при создании файла макета: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                IsCreateLayoutButtonBusy = false;
            }
        }


        private void HandleCodesImported(object? sender, CodesImportedEventArgs e)
        {
            CurrentMissionModel = e.CurrentMissionInfo;
            LoadPalletsFromDB(e.CurrentMissionInfo);
        }

        private async void LoadPalletsFromDB(MissionDto missionDto)
        {
            try
            {
                var pallets = await _palletModelRepository.GetAllByMissionId(missionDto.MissionId);
                Pallets = new ObservableCollection<PalletModel>(pallets);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при загрузке коробов: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }

}
