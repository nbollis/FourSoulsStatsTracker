using FourSoulsDataConnection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourSoulsGUI
{
    public static class IconLocator
    {
        public static string? FindIconPath(ICharPlayer charPlayer)
        {
            string iconDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources\Images");

            if (charPlayer is Player)
                return null;
            else if (charPlayer is Character)
            {
                string characterDirectory = Path.Combine(iconDirectory, "CharacterCards");
                var files = Directory.GetFiles(characterDirectory);
                // TODO: Consider how this will handle bumbo and bumbo the weird
                return files.FirstOrDefault(p => p.Contains(charPlayer.Name));
            }
            else
                throw new NotImplementedException();
        }
    }
}
