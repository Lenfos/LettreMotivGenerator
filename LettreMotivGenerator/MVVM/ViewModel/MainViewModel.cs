using LettreMotivGenerator.Core;

namespace LettreMotivGenerator.MVVM.ViewModel;

public class MainViewModel : ObservableObject
{
    private object _currentView;

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
        HomeVM = new HomeViewModel();
        MyInfosVM = new MyInfosViewModel();
        CompanyInfosVM = new CompanyInfosViewModel();
        GenerateVM = new GenerateViewModel();
        
        CurrentView = HomeVM;
        
        HomeViewCommand = new RelayCommand(o => CurrentView = HomeVM);
        MyInfosViewCommand = new RelayCommand(o => CurrentView = MyInfosVM);
        CompanyInfosViewCommand = new RelayCommand(o => CurrentView = CompanyInfosVM);
        GenerateViewCommand = new RelayCommand(o => CurrentView = GenerateVM);
        
    }
}