using System.Windows;
using System.Windows.Controls;

namespace HIVMedicalSystem.WPFApplication.Components;

public partial class Button : UserControl
{
    public Button()
    {
        InitializeComponent();
    }
    
    public static readonly DependencyProperty ButtonTextProperty =
        DependencyProperty.Register(nameof(ButtonTextValue), typeof(string), typeof(Button), new PropertyMetadata());

    public static readonly DependencyProperty ButtonColorProperty =
        DependencyProperty.Register(nameof(ButtonColor), typeof(string), typeof(Button), new PropertyMetadata());
    public string ButtonTextValue
    {
        get => (string)GetValue(ButtonTextProperty);
        set => SetValue(ButtonTextProperty, value);
    }

    public string ButtonColor
    {
        get => (string)GetValue(ButtonColorProperty);
        set => SetValue(ButtonColorProperty, value);
    }
    
    public event RoutedEventHandler? Click;

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        Click?.Invoke(this, e);
    }
}