using CommunityToolkit.Maui.Views;
using FourSoulsCore;

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

        vm.ParseGameForCorrectness();
        if (vm.GameParsingErrors.Any())
        {
            // if only one error where no player has four souls
            if (vm.GameParsingErrors.Count == 1 && 
                vm.GameParsingErrors.First().Equals("No Player With Four Souls"))
            {
                // TODO: Mom's Heart PopUp
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
        if (playerName != null && FourSoulsGlobalData.AllPlayerNames.Contains(playerName))
        {
            popupVM.Messages.Add("Player with name already exists");
            SimplePopup simplePopup = new SimplePopup(popupVM);
            await this.ShowPopupAsync(simplePopup);
        }
        else
        {
            FourSoulsGlobalData.AddPlayer(playerName);
            vm.UpdatePlayerNames();
        }
    }
}