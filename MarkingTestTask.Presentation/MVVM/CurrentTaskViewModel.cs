using MarkingTestTask.BLL.Contracts;
using MarkingTestTask.BLL.Dtos;
using MarkingTestTask.Presentation.Mediator;
using Microsoft.Win32;
using System.Windows;

namespace MarkingTestTask.Presentation.MVVM
{
    public class CurrentTaskViewModel : BaseViewModel
    {
        private MissionDto _currentTaskInfo;
        public MissionDto CurrentMissionInfo
        {
            get => _currentTaskInfo;
            set => SetProperty(ref _currentTaskInfo, value, nameof(CurrentMissionInfo));
        }

        private bool _isImportCodesButtonBusy;
        private readonly IMissionInfoRetrievalService _productInfoRetrievalService;
        private readonly ICodeImportService _codeImportService;
        private readonly IBoxPalletPopulationService _boxPalletPopulationService;
        private readonly ICodesImportMediator _codesImportMediator;

        public RelayCommand ImportCodesCommand { get; }

        public bool IsImportCodesButtonBusy
        {
            get => _isImportCodesButtonBusy;
            set => SetProperty(ref _isImportCodesButtonBusy, value, nameof(IsImportCodesButtonBusy));
        }

        public CurrentTaskViewModel(IMissionInfoRetrievalService productInfoRetrievalService,
            ICodeImportService codeImportService,
            IBoxPalletPopulationService boxPalletPopulationService,
            ICodesImportMediator codesImportMediator)
        {
            _productInfoRetrievalService = productInfoRetrievalService;
            _codeImportService = codeImportService;
            _boxPalletPopulationService = boxPalletPopulationService;
            _codesImportMediator = codesImportMediator;
            ImportCodesCommand = new RelayCommand(async parameter => await ImportCodesAsync(), (_) => !IsImportCodesButtonBusy);

            LoadProductInfo();
        }

        private async void LoadProductInfo()
        {
            try
            {
                var result = await _productInfoRetrievalService.GetMissionInfoAsync();
                CurrentMissionInfo = result;
                _codesImportMediator.NotifyCodesImported(CurrentMissionInfo);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при загрузке информации о продукте: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async Task ImportCodesAsync()
        {
            try
            {
                IsImportCodesButtonBusy = true;

                var openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
                if (openFileDialog.ShowDialog() == true)
                {
                    var selectedFilePath = openFileDialog.FileName;
                    var codes = _codeImportService.ImportCodesFromFile(selectedFilePath, CurrentMissionInfo!.Gtin);
                    await _boxPalletPopulationService.PopulateBoxesAndPalletsAsync(CurrentMissionInfo, codes);
                    _codesImportMediator.NotifyCodesImported(CurrentMissionInfo);
                    MessageBox.Show("Коды успешно импортированы.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                IsImportCodesButtonBusy = false;
            }
        }
    }
}
