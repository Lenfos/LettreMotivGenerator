using System.Windows;
using LettreMotivGenerator.MVVM.Model;
using LettreMotivGenerator.MVVM.ViewModel;
using UserControl = System.Windows.Controls.UserControl;

namespace LettreMotivGenerator.MVVM.View;

public partial class TextView : UserControl
{
    private TextViewModel vm;
    private DataRoot dataroot;
    public TextView()
    {
        InitializeComponent();

        this.Loaded += (s, e) =>
        {
            if (DataContext is TextViewModel vm)
            {
                this.vm = vm;
                Initialized();
            }
        };
    }


    private void Initialized()
    {
        dataroot = vm.Data;
        
        InputBox.Text = dataroot.Text;
    }
    private void SaveButton_OnClick(object sender, RoutedEventArgs e)
    {
        dataroot.Text = InputBox.Text;
        vm.Data = dataroot;
    }
}