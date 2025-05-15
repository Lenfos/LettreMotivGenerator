using System.Windows;
using System.Windows.Controls;
using LettreMotivGenerator.MVVM.Model;
using LettreMotivGenerator.MVVM.ViewModel;
using UserControl = System.Windows.Controls.UserControl;

namespace LettreMotivGenerator.MVVM.View;

public partial class CompanyInfos : UserControl
{
    
    private CompanyInfosViewModel vm;
    private Company company;
    private DataRoot dataroot;
    public CompanyInfos()
    {
        InitializeComponent();

        this.Loaded += (sender, args) =>
        {
            if (DataContext is CompanyInfosViewModel vm)
            {
                this.vm = vm;
                Intialize();
            }
        };
    }

    private void Intialize()
    {
        dataroot = vm.Data;
        company = dataroot.Company;

        NameBox.Text = company.CompanyName;
        StreetBox.Text = company.Street ?? "";
        CityBox.Text = company.City ?? "";
        ZipCodeBox.Text = company.ZipCode ?? "";
    }

    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        company.CompanyName = NameBox.Text;
        company.Street = StreetBox.Text;
        company.City = CityBox.Text;
        company.ZipCode = ZipCodeBox.Text;
        
        dataroot.Company = company;
        vm.Data = dataroot;
    }
}