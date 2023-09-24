using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourSoulsGUI.Util
{
    public static class ClassExtensions
    {
        public static void AddRange<T>(this ObservableCollection<T> lista, IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                lista.Add(item);
            }
        }
    }
}
