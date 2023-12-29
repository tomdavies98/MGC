using ScreenRecorderLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGC.Recording
{
    public interface IMGCRecorder
    {
        void CreateRecording(string fullOutputPath);
        void EndRecording();
        void SetRecorderOptionsAndCreateNewRecorder(RecorderOptions recorderOptions);
        bool IsRecording();
    }
}
