using System.Windows.Controls;
using LettreMotivGenerator.MVVM.Model;

namespace LettreMotivGenerator.MVVM.View;

public partial class MyInfosView : UserControl
{
    
    Myself myself;
    
    public MyInfosView()
    {
        InitializeComponent();
        myself = new Myself();
        
        
    }
}