using CommunityToolkit.Maui.Views;
namespace FourSoulsStatGUI;

public partial class SimplePopup : Popup
{
    public SimplePopup(PopupViewModel vm)
    {
        BindingContext = vm;
        InitializeComponent();
    }

    void OnOKButtonClicked(object? sender, EventArgs e) => Close();
    void OnYesButtonClicked(object? sender, EventArgs e) => Close(true);
    void OnNoButtonClicked(object? sender, EventArgs e) => Close(false);
}