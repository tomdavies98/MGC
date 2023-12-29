using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGC.Settings
{
    public interface ISettingsManager
    {
        void SaveSettings(AudioSettings audioOptions, GeneralSettings generalOptions, MacroSettings macroOptions, VideoSettings videoOptions);
        void SaveSettings(MGCSettings mgcSettings);
        MGCSettings LoadSettings();
    }
}
