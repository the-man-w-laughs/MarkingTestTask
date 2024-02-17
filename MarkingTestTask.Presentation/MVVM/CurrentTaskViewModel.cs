using MarkingTestTask.BLL.Contracts;
using MarkingTestTask.BLL.Dtos;
using Microsoft.Win32;
using System.ComponentModel;
using System.Windows;

namespace MarkingTestTask.Presentation.MVVM
{
    public class CurrentTaskViewModel : INotifyPropertyChanged
    {
        private ProductLayoutInfoDto _currentTaskInfo;
        public ProductLayoutInfoDto CurrentTaskInfo
        {
            get { return _currentTaskInfo; }
            set
            {
                _currentTaskInfo = value;
                OnPropertyChanged(nameof(CurrentTaskInfo));
            }
        }

        private bool _isImportCodesButtonBusy;
        private readonly IProductInfoRetrievalService _productInfoRetrievalService;
        private readonly ICodeImportService _codeImportService;

        public bool IsImportCodesButtonBusy
        {
            get => _isImportCodesButtonBusy;
            set => SetProperty(ref _isImportCodesButtonBusy, value, nameof(IsImportCodesButtonBusy));
        }

        public CurrentTaskViewModel(IProductInfoRetrievalService productInfoRetrievalService, ICodeImportService codeImportService)
        {
            _productInfoRetrievalService = productInfoRetrievalService;
            _codeImportService = codeImportService;
            ImportCodesCommand = new RelayCommand(async parameter => await ImportCodesAsync(), (_) => !IsImportCodesButtonBusy);

            LoadProductInfo();
        }

        private async void LoadProductInfo()
        {
            try
            {
                var result = await _productInfoRetrievalService.GetProductLayoutInfoAsync();
                CurrentTaskInfo = result;
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
                    var codes = _codeImportService.ImportCodesFromFile(selectedFilePath, CurrentTaskInfo.Gtin);
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



        public event PropertyChangedEventHandler PropertyChanged;

        public RelayCommand ImportCodesCommand { get; }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void SetProperty<T>(ref T field, T value, string propertyName)
        {
            if (!EqualityComparer<T>.Default.Equals(field, value))
            {
                field = value;
                OnPropertyChanged(propertyName);
            }
        }
    }
}
