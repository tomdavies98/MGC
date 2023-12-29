using ScreenRecorderLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGC.Settings
{
    public class GeneralSettings
    {
        public string FileOutputDirectory { get; set; }
        public bool EnableMp4FastStart { get; set; }
        public bool EnableLowLatency { get; set; }
        public bool EnableHardwareEncoding { get; set; }
        public bool EnabledThrottling { get; set; }
        public bool Notifications { get; set; }
        public bool EnableSounds { get; set; }
        public bool EnableShadowPlay { get; set; }
        public RecorderMode RecorderMode { get; set; }


    }
}
