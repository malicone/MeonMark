using MeonMark.ViewModels;

namespace MeonMark.Views;

public partial class MainView : ContentPage
{
	public MainView( MainViewModel viewModel )
	{
        InitializeComponent();
        viewModel.Navigation = Navigation;
        BindingContext = viewModel;
    }
}