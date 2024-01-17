using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MyMauiApp.ViewModel;

public partial class MainViewModel(IConnectivity connectivity) : ObservableObject
{
    private IConnectivity _connectivity = connectivity;
    
    [ObservableProperty]
    private ObservableCollection<string> _items = new ObservableCollection<string>();
    
    [ObservableProperty] 
    private string _text = string.Empty;

    [RelayCommand]
    private async Task Add()
    {
        if (string.IsNullOrWhiteSpace(Text))
        {
            await Shell.Current.DisplayAlert("Error", "Please enter some text.", "OK");
            return;
        }

        if (_connectivity.NetworkAccess != NetworkAccess.Internet)
        {
            await Shell.Current.DisplayAlert("No Internet", "Please check your internet connection and try again.", "OK");
            return;
        }
        
        Items.Add(Text);
        Text = string.Empty;
    }

    [RelayCommand]
    private void Delete(string item)
    {
        Items.Remove(item);
    }

    [RelayCommand]
    private async Task Tap(string s)
    {
        await Shell.Current.GoToAsync(nameof(DetailPage) + $"?Text={s}");
    }
}