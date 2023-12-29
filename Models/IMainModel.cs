using ScreenRecorderLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGC.Models
{
    public interface IMainModel
    {
        void StartRecording(string fullOutputFolder);
        void StopRecording();
        void SetRecorderOptionsAndCreateNewRecorder(RecorderOptions recorderOptions);
        bool IsRecording();
    }
}
