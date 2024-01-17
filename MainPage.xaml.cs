using MyMauiApp.ViewModel;

namespace MyMauiApp;

public partial class MainPage
{
    public MainPage(MainViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}