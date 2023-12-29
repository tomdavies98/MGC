using ScreenRecorderLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGC.Settings
{
    public class AudioSettings
    {
        public AudioChannels AudioChannel { get; set; }
        public AudioBitrate Bitrate { get; set; }
        public bool AudioEnabled { get; set; }
        public bool AudioOutputEnabled { get; set; }
        public bool AudioInputEnabled { get; set; }
        public float InputVolume { get; set; }
        public float OutputVolume { get; set; }
        public string SelectedInputDeviceName { get; set; }
        public string SelectedOutputDeviceName { get; set; }

    }
}
