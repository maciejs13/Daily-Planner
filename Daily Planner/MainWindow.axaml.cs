using System.Net.Mime;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Layout;

namespace Daily_Planner;


public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }
    
    public void DodajZadanie(object? sender, RoutedEventArgs e)
    {

        string nazwaZadania = nazwa.Text;
        
        var kategoria = "";

        if (Praca.IsSelected == true)
            kategoria = "praca";
        if (Relaks.IsSelected == true)
            kategoria = "relaks";
        if (Zakupy.IsSelected == true)
            kategoria = "zakupy";
        
        var newTextBlock = new TextBlock
        {
            


            Text = $"Nazwa zadania: {nazwaZadania} Kategoria: {kategoria}",
            HorizontalAlignment = HorizontalAlignment.Center,
            VerticalAlignment = VerticalAlignment.Center,
            Margin = new Thickness(5)

        };

        var rowCount = ListaZadanGrid.RowDefinitions.Count;

        ListaZadanGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });

        Grid.SetRow(newTextBlock, rowCount);

        ListaZadanGrid.Children.Add(newTextBlock);
    }
    
}

public class Zadanie
{
    public string Nazwa { get; set; }
    public string Kategorie { get; set; }
    public bool CzyUkonczone { get; set; } = false;

    
}

