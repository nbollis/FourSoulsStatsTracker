using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourSoulsGUI
{
    public class EnterGamePageModel : EnterGamePageViewModel
    {
        public static EnterGamePageModel Instance => new EnterGamePageModel();

        public EnterGamePageModel() : base()
        {

        }
    }
}
