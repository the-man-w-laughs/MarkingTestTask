using MarkingTestTask.Presentation.MVVM;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;
using System.Windows.Controls;

namespace MarkingTestTask.Presentation.Tabs
{
    /// <summary>
    /// Interaction logic for PalletsUserControl.xaml
    /// </summary>
    public partial class PalletsUserControl : UserControl
    {
        public PalletsUserControl()
        {
            if (DesignerProperties.GetIsInDesignMode(this))
                return;

            InitializeComponent();
            DataContext = Program.ServiceProvider.GetService<PalletsViewModel>();
        }
    }
}
