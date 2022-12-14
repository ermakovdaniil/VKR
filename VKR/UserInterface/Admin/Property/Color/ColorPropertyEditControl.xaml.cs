using VKR.Utils;
using VKR.ViewModel;


namespace VKR.View;

/// <summary>
///     Логика взаимодействия для ColorPropertyEditControl.xaml
/// </summary>
public partial class ColorPropertyEditControl
{
    private ColorPropertyEditControlVM _viewModel;

    public ColorPropertyEditControl()
    {
        InitializeComponent();
        _viewModel = (ColorPropertyEditControlVM?)VMLocator.Resolve<ColorPropertyEditControl>();
        DataContext = _viewModel;
    }
}
