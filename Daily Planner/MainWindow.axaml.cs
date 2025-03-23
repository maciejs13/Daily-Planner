using System.Net.Mime;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Layout;
using Avalonia.Media;

namespace Daily_Planner;


public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private int liczbaZadan = 0;
    private int liczbaZadanZrobionych = 0;
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
        
        var checkBox = new CheckBox
        {
            Content = "Zrobione",
            HorizontalAlignment = HorizontalAlignment.Center,
            VerticalAlignment = VerticalAlignment.Center,
            Margin = new Thickness(5)
        };
        
        checkBox.Checked += (s, e) => MarkAsDone(newTextBlock);
        checkBox.Unchecked += (s, e) => MarkAsNotDone(newTextBlock);

        var rowCount = ListaZadanGrid.RowDefinitions.Count;

        ListaZadanGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });

        Grid.SetRow(newTextBlock, rowCount);  
        Grid.SetColumn(newTextBlock, 0);     

        Grid.SetRow(checkBox, rowCount);     
        Grid.SetColumn(checkBox, 1);  

        ListaZadanGrid.Children.Add(newTextBlock);
        ListaZadanGrid.Children.Add(checkBox);
        
        liczbaZadan++;
        
        LiczbaZadan.Text = $"Liczba zadań: {liczbaZadan}\n";
        
    }
    
    
    private void MarkAsDone(TextBlock textBlock)
    {
        textBlock.TextDecorations = TextDecorations.Strikethrough;
        liczbaZadanZrobionych++;
        LiczbaZadanZrobionych.Text = $"Liczba zadań zrobionych: {liczbaZadanZrobionych}";

    }

    private void MarkAsNotDone(TextBlock textBlock)
    {
        textBlock.TextDecorations = null;
        liczbaZadanZrobionych--;
        LiczbaZadanZrobionych.Text = $"Liczba zadań zrobionych: {liczbaZadanZrobionych}";
    }
    
}



