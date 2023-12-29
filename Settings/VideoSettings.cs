using ScreenRecorderLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGC.Settings
{
    public class VideoSettings
    {
        public H264BitrateControlMode BitrateMode { get; set; }
        public int Quality { get; set; }
        public int BitRate { get; set; }
        public int FrameRate { get; set; }
        public bool IsMP4FastStart { get; set; }
        public bool IsLowLatency { get; set; }
        public bool IsHardwareEncodingEnabled { get; set; }
        public bool IsThrottlingDisabled { get; set; }
        public bool IsFixedFrameRate { get; set; }
        public H264Profile EncoderProfile { get; set; }

    }
}
