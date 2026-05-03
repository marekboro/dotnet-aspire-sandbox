using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window, INotifyPropertyChanged
{
    public int Counter { get; private set; } = 3;

    public bool EnabledButtonTwo
    {
        get
        {
            if (Counter == 0) return true;
            return Counter % 3 != 0;
        }
    }

    public MainWindow()
    {
        InitializeComponent();
    }

    private void Remove_Two_OnClick(object sender, RoutedEventArgs e)
    {
        Add(-2);
    }

    private void Add_One_OnClick(object sender, RoutedEventArgs e)
    {
        Add(1);
    }

    private void Add(int number)
    {
        Counter += number;
        OnPropertyChanged(nameof(Counter));
        OnPropertyChanged(nameof(EnabledButtonTwo));
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}