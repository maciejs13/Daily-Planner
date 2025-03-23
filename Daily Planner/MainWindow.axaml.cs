using Avalonia.Controls;

namespace Daily_Planner;

public class Zadanie
{
    private bool _czyUkonczone = false;
    
    public string Nazwa { get; set; }
    public string Kategorie { get; set; }
}
 
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }
}