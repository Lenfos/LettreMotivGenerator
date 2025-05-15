using System.ComponentModel;
using LettreMotivGenerator.Core;
using LettreMotivGenerator.MVVM.Model;

namespace LettreMotivGenerator.MVVM.ViewModel;

public class GenerateViewModel : ObservableObject
{
    private DataRoot _data;
    private MainViewModel _mainVM;

    public DataRoot Data
    {
        get => _data;
        set
        {
            _data = value;
            OnPropertyChanged();
            GenerateFile();
        }
    }

    public GenerateViewModel(DataRoot data, MainViewModel mainVM)
    {
        _data = data;
        _mainVM = mainVM;
        
        _mainVM.PropertyChanged += MainVMOnPropertyChanged;
    }

    private void MainVMOnPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(_mainVM.Data))
        {
            if (sender is MainViewModel mvm)
            {
                _data = mvm.Data;
            }
        }
    }

    public void GenerateFile()
    {
        Console.WriteLine($"Generating");
    }
}