using System.Windows;
using System.Windows.Controls;
using LettreMotivGenerator.MVVM.Model;
using LettreMotivGenerator.MVVM.ViewModel;
using UserControl = System.Windows.Controls.UserControl;

namespace LettreMotivGenerator.MVVM.View;

public partial class MyInfosView : UserControl
{
    private MyInfosViewModel vm;
    private Myself myself;
    private DataRoot dataroot;
    
    public MyInfosView()
    {
        InitializeComponent();

        this.Loaded += (s, e) =>
        {
            if (DataContext is MyInfosViewModel vm)
            {
                this.vm = vm;
                Initialize();
            }
        };

    }

    private void Initialize()
    {
        dataroot = vm.Data;
        myself = dataroot.Myself;
        
        LastNameBox.Text = myself.LastName;
        FirstNameBox.Text = myself.FirstName;
        MailBox.Text = myself.Email;
        StreetBox.Text = myself.Street;
        CityBox.Text = myself.City;
        ZipCodeBox.Text = myself.ZipCode;
    }

    private void SaveButton_OnClick(object sender, RoutedEventArgs e)
    {
        myself.LastName = LastNameBox.Text;
        myself.FirstName = FirstNameBox.Text;
        myself.Email = FirstNameBox.Text;
        myself.Street = StreetBox.Text;
        myself.City = CityBox.Text;
        myself.ZipCode = ZipCodeBox.Text;
        
        dataroot.Myself = myself;
        vm.Data = dataroot;
    }
}