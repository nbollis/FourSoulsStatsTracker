using CommunityToolkit.Maui.Views;
namespace FourSoulsStatGUI;

public partial class AddPlayerPopup : Popup
{
    public AddPlayerPopup(PopupViewModel vm)
    {
        BindingContext = vm;
        InitializeComponent();
    }

    void OnOKButtonClicked(object? sender, EventArgs e) => Close();

}