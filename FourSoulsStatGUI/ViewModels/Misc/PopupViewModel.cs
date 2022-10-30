using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FourSoulsCore.MVVMBase;

namespace FourSoulsStatGUI
{
    public class PopupViewModel : BaseViewModel
    {
        private string inputText;

        public ObservableCollection<string> Messages { get; set; }

        public string InputText
        {
            get => inputText;
            set => SetProperty(ref inputText, value);
        }

        public PopupViewModel()
        {
            Messages = new ObservableCollection<string>();
        }

        public void AddMessages(IEnumerable<string> messages)
        {
            foreach (var message in messages)
            {
                Messages.Add(message);
            }
        }
    }
}
