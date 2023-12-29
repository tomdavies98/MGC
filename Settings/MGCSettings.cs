using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGC.Settings
{
    public class MGCSettings
    {
        public MGCSettings(GeneralSettings generalSettings, AudioSettings audioSettings, VideoSettings videoSettings, MacroSettings macroSettings)
        {
            General = generalSettings;
            Audio = audioSettings;
            Video = videoSettings;
            Macro = macroSettings;
        }

        public GeneralSettings General { get; set; }
        public AudioSettings Audio { get; set; }
        public VideoSettings Video { get; set; }
        public MacroSettings Macro { get; set; }

    }
}
