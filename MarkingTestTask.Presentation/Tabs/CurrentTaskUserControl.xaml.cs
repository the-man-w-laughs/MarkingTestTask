using MarkingTestTask.Presentation.MVVM;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;
using System.Windows.Controls;

namespace MarkingTestTask.Presentation.Tabs
{
    /// <summary>
    /// Interaction logic for CurrentTaskUserControl.xaml
    /// </summary>
    public partial class CurrentTaskUserControl : UserControl
    {
        public CurrentTaskUserControl()
        {
            if (DesignerProperties.GetIsInDesignMode(this))
                return;

            InitializeComponent();
            var currentTaskViewModel = Program.ServiceProvider.GetService<CurrentTaskViewModel>();
            DataContext = currentTaskViewModel;
        }
    }
}
