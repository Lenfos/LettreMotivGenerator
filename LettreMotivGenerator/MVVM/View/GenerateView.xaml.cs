using System.Windows;
using System.Windows.Controls;
using LettreMotivGenerator.MVVM.ViewModel;
using System.Windows.Forms;
using LettreMotivGenerator.MVVM.Model;
using Microsoft.Win32;
using UserControl = System.Windows.Controls.UserControl;

namespace LettreMotivGenerator.MVVM.View;

public partial class GenerateView : UserControl
{

    private string filePath;
    private GenerateViewModel vm;
    
    
    public GenerateView()
    {
        InitializeComponent();

        this.Loaded += (sender, args) =>
        {
            if (DataContext is GenerateViewModel vm)
            {
                this.vm = vm;

            }
        };
    }

    private void PickFilButton_OnClick(object sender, RoutedEventArgs e)
    {
        using var dialog = new FolderBrowserDialog
        {
            Description = "Sélectionnez un dossier",
            UseDescriptionForTitle = true,
            ShowNewFolderButton = true
        };
        
        DialogResult result = dialog.ShowDialog();

        if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(dialog.SelectedPath))
        {
            filePath = dialog.SelectedPath;
            PathBox.Text = filePath;
        }
    }

    private void GenerateButton_OnClick(object sender, RoutedEventArgs e)
    {
        DataRoot root = vm.Data;
        root.FilePath = filePath;
        
        vm.Data = root;
    }
}