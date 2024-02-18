using MarkingTestTask.Presentation.MVVM;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;
using System.Windows.Controls;

namespace MarkingTestTask.Presentation.Tabs
{
    /// <summary>
    /// Interaction logic for ProductsUserControl.xaml
    /// </summary>
    public partial class ProductsUserControl : UserControl
    {
        public ProductsUserControl()
        {
            if (DesignerProperties.GetIsInDesignMode(this))
                return;

            InitializeComponent();
            DataContext = Program.ServiceProvider.GetService<ProductsViewModel>();
        }
    }
}
