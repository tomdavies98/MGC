using MGC.Recording;
using ScreenRecorderLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGC.Models
{
    public class MainModel: IMainModel
    {
        public IMGCRecorder MGCRecorder { get; set; }
        public MainModel(IMGCRecorder mgcRecorder)
        {
            MGCRecorder = mgcRecorder;

        }
        public bool IsRecording()
        {
            return MGCRecorder.IsRecording();
        }
        public void StartRecording(string fullOutputFolder)
        {
            MGCRecorder.CreateRecording(fullOutputFolder);
        }

        public void StopRecording()
        {
            MGCRecorder.EndRecording();
        }
        public void SetRecorderOptionsAndCreateNewRecorder(RecorderOptions recorderOptions)
        {
            MGCRecorder.SetRecorderOptionsAndCreateNewRecorder(recorderOptions);
        }
    }
}
