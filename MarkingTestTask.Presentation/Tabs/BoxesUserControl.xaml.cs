using MarkingTestTask.Presentation.MVVM;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;
using System.Windows.Controls;

namespace MarkingTestTask.Presentation.Tabs
{
    /// <summary>
    /// Interaction logic for BoxesUserControl.xaml
    /// </summary>
    public partial class BoxesUserControl : UserControl
    {
        public BoxesUserControl()
        {
            if (DesignerProperties.GetIsInDesignMode(this))
                return;

            InitializeComponent();
            DataContext = Program.ServiceProvider.GetService<BoxesViewModel>();
        }
    }
}
