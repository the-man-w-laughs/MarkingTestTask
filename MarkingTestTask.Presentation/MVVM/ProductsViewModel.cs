using MarkingTestTask.DAL.Contracts;
using MarkingTestTask.DAL.Models;
using System.Collections.ObjectModel;
using System.Windows;

namespace MarkingTestTask.Presentation.MVVM
{
    public class ProductsViewModel : BaseViewModel
    {
        private readonly IProductModelRepository _productModelRepository;

        public ObservableCollection<ProductModel> Products { get; set; }

        public ProductsViewModel(IProductModelRepository productModelRepository)
        {
            _productModelRepository = productModelRepository;
            Products = new ObservableCollection<ProductModel>();
            LoadProductsFromDB();
        }

        private async void LoadProductsFromDB()
        {
            try
            {
                var products = await _productModelRepository.GetAllAsync();
                Products = new ObservableCollection<ProductModel>(products);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при загрузке продуктов: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }

}
