using CommunityToolkit.Maui.Views;
using FourSoulsDataConnection;

namespace FourSoulsStatGUI.Pages;

public partial class EnterGamePage : ContentPage
{
	public EnterGamePage()
	{
		InitializeComponent();
	}

    private async void SaveGameButton_OnClicked(object sender, EventArgs e)
    {
        var vm = BindingContext as EnterGamePageViewModel ??
                 throw new ArgumentException("Binding context of EnterGamePage is not EnterGamePageViewModel");
        
        vm.PauseGameTimer();
        vm.AdjustAndParseGameData();

        if (vm.GameParsingErrors.Any())
        {
            // if only one error where no player has four souls
            if (vm.GameParsingErrors.Count == 1 &&
                vm.GameParsingErrors.First().Equals("No Player With Four Souls"))
            {
                // TODO: Mom's Heart PopUp
                // TODO: This will need to set the winner's GameData Win to 1
            }
            else
            {
                PopupViewModel popupVM = new();
                popupVM.AddMessages(vm.GameParsingErrors);
                SimplePopup simplePopup = new SimplePopup(popupVM);
                await this.ShowPopupAsync(simplePopup);
            }
        }
        else // No Errors Present
        {
            vm.SaveGame();
        }
    }

    private async void AddPlayer_OnClicked(object sender, EventArgs e)
    {
        var vm = BindingContext as EnterGamePageViewModel ??
                 throw new ArgumentException("Binding context of EnterGamePage is not EnterGamePageViewModel");
        PopupViewModel popupVM = new();
        AddPlayerPopup addPlayerPopup = new AddPlayerPopup(popupVM);
        await this.ShowPopupAsync(addPlayerPopup);

        string playerName = ((PopupViewModel)addPlayerPopup.BindingContext).InputText;
        if (playerName == "")
            popupVM.Messages.Add("Cannot Add Empty Name");
        if (playerName != null && DataBaseOperations.AllPlayerNames.Contains(playerName))
            popupVM.Messages.Add("Player with name already exists");
        if (popupVM.Messages.Any())
        {
            SimplePopup simplePopup = new SimplePopup(popupVM);
            await this.ShowPopupAsync(simplePopup);
        }
        else
        {
            DataBaseOperations.AddPlayer(playerName);
            vm.UpdatePlayerNames();
        }
    }
}