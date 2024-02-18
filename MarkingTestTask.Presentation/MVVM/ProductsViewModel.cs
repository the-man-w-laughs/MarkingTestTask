using MarkingTestTask.BLL.Dtos;
using MarkingTestTask.DAL.Contracts;
using MarkingTestTask.DAL.Models;
using MarkingTestTask.Presentation.Mediator;
using System.Collections.ObjectModel;
using System.Windows;

namespace MarkingTestTask.Presentation.MVVM
{
    public class ProductsViewModel : BaseViewModel
    {
        private readonly IProductModelRepository _productModelRepository;
        private readonly ICodesImportMediator _codesImportMediator;

        private ObservableCollection<ProductModel> _products;
        public ObservableCollection<ProductModel> Products
        {
            get => _products;
            set => SetProperty(ref _products, value, nameof(Products));
        }

        public ProductsViewModel(IProductModelRepository productModelRepository, ICodesImportMediator codesImportMediator)
        {
            _productModelRepository = productModelRepository;
            _codesImportMediator = codesImportMediator;
            Products = new ObservableCollection<ProductModel>();

            _codesImportMediator.CodesImported += HandleCodesImported;
        }

        private void HandleCodesImported(object? sender, CodesImportedEventArgs e)
        {
            LoadProductsFromDB(e.CurrentMissionInfo);
        }

        private async void LoadProductsFromDB(MissionDto missionModel)
        {
            try
            {
                var products = await _productModelRepository.GetAllByMissionId(missionModel.MissionId);
                Products = new ObservableCollection<ProductModel>(products);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при загрузке продуктов: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }

}
