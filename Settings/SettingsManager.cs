using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ScreenRecorderLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGC.Settings
{
    public class SettingsManager: ISettingsManager
    {
        private string _jsonSettingsLocation { get; set; }
        private string _settingsName = "MGCSettings.json";
        public SettingsManager(string jsonSettingsLocation)
        {
            _jsonSettingsLocation = jsonSettingsLocation;
        }

        public void SaveSettings(AudioSettings audioOptions, GeneralSettings generalOptions, MacroSettings macroOptions, VideoSettings videoOptions)
        {
            var mgcSettings =  new MGCSettings(generalOptions,audioOptions,videoOptions, macroOptions);
            SaveSettings(mgcSettings);
        }

        public void SaveSettings(MGCSettings mgcSettings)
        {
            var serializedSettings = SerializeSettings(mgcSettings);
            var savePath = Path.Combine(_jsonSettingsLocation, _settingsName);
            File.WriteAllText(savePath, serializedSettings);
        }

        public MGCSettings LoadSettings()
        {
            var savePath = Path.Combine(_jsonSettingsLocation, _settingsName);
            if(File.Exists(savePath))
            {
                var jsonFile = JObject.Parse(File.ReadAllText(savePath));
                return jsonFile.ToObject<MGCSettings>();
            }
  
            return null;
        }

        public string SerializeSettings(MGCSettings mgcSettings)
        {
            return JsonConvert.SerializeObject(mgcSettings);
        }

    }
}
