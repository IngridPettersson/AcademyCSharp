using StatesPontusProject.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StatesPontusProject.Models
{
    public class SettingsService
    {
        public static List<Settings> userSettings = new List<Settings>();

        internal void AddSettings(SettingsCreateVM createVM)
        {
            userSettings.Add(new Settings
            {
                Email = createVM.Email,
                CompanyName = createVM.CompanyName
            });
        }
    }
}
