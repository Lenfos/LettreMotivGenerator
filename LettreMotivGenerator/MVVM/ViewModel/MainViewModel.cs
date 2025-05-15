using System.ComponentModel;
using LettreMotivGenerator.Core;
using LettreMotivGenerator.MVVM.Model;

namespace LettreMotivGenerator.MVVM.ViewModel;

public class MainViewModel : ObservableObject
{
    private object _currentView;
    private DataRoot _data;
    
    private Serialization _serialization;

    public DataRoot Data
    {
        get => _data;
        set
        {
            _data = value;
            SaveNewDataRoot();
            OnPropertyChanged();
        }
    }

    public object CurrentView
    {
        get{ return _currentView; }
        set
        {
            _currentView = value;
            OnPropertyChanged();
        }
    }

    public HomeViewModel HomeVM { get; set; }
    public MyInfosViewModel MyInfosVM { get; set; }
    public CompanyInfosViewModel CompanyInfosVM { get; set; }
    public GenerateViewModel GenerateVM { get; set; }
    
    
    public RelayCommand HomeViewCommand { get; set; }
    public RelayCommand MyInfosViewCommand { get; set; }
    public RelayCommand CompanyInfosViewCommand { get; set; }
    public RelayCommand GenerateViewCommand { get; set; }

    public MainViewModel()
    {
        _data = new DataRoot();
        _serialization = new Serialization();
        
        HomeVM = new HomeViewModel();
        MyInfosVM = new MyInfosViewModel(Data, this);
        CompanyInfosVM = new CompanyInfosViewModel(Data, this);
        GenerateVM = new GenerateViewModel(Data, this);
        
        MyInfosVM.PropertyChanged += MyInfosVMOnPropertyChanged;
        CompanyInfosVM.PropertyChanged += CompanyInfosVMOnPropertyChanged;
        GenerateVM.PropertyChanged += GenerateVMOnPropertyChanged;
        
        CurrentView = HomeVM;
        
        HomeViewCommand = new RelayCommand(o => CurrentView = HomeVM);
        MyInfosViewCommand = new RelayCommand(o => CurrentView = MyInfosVM);
        CompanyInfosViewCommand = new RelayCommand(o => CurrentView = CompanyInfosVM);
        GenerateViewCommand = new RelayCommand(o => CurrentView = GenerateVM);
        
        LoadDataRoot();
    }

    private void GenerateVMOnPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(GenerateVM.Data))
        {
            if (sender is GenerateViewModel vm)
            {
                Console.WriteLine("Saving Data");
                Data = vm.Data;
            }
        }
    }

    private void CompanyInfosVMOnPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(CompanyInfosVM.Data))
        {
            if (sender is CompanyInfosViewModel vm)
            {
                Data = vm.Data;
            }
        }
    }

    private void MyInfosVMOnPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(MyInfosVM.Data))
        {
            if (sender is MyInfosViewModel vm)
            {
                Data = vm.Data;
            }
        }
    }

    private void LoadDataRoot()
    {
        Data = _serialization.ReadFromFile<DataRoot>() ?? new DataRoot();
    }

    private void SaveNewDataRoot()
    {
        _serialization.WriteToFile(Data);
    }
}