using System.Windows.Controls;

using VKR.Utils;
using VKR.ViewModel;


namespace VKR.View;

/// <summary>
///     Логика взаимодействия для ColorPropertyControl.xaml
/// </summary>
public partial class ColorPropertyControl : UserControl
{
    private ColorPropertyControlVM _viewModel;

    public ColorPropertyControl()
    {
        InitializeComponent();
        _viewModel = (ColorPropertyControlVM?)VMLocator.Resolve<ColorPropertyControl>();
        DataContext = _viewModel;
    }
}
