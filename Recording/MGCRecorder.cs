using ScreenRecorderLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGC.Recording
{
    public class MGCRecorder: IMGCRecorder
    {
        private RecorderOptions _recorderOptions { get; set; }
        private Recorder _recorder;
        private Stream _outStream;
        private bool _isRecording { get; set; }

        public MGCRecorder()
        {

        }

        public bool IsRecording()
        {
            return _isRecording;
        }
        
        public void SetRecorderOptionsAndCreateNewRecorder(RecorderOptions recorderOptions)
        {
            _recorderOptions = recorderOptions;
            _recorder = Recorder.CreateRecorder(recorderOptions);
        }

        public void CreateRecording(string fullOutputFolder)
        {
            if(_recorder == null)
             _recorder = Recorder.CreateRecorder();
            var nowTime = DateTime.Now;
            var fullOutputPath = $"{fullOutputFolder}\\MGC{nowTime.Day}{nowTime.Month}{nowTime.Year}{nowTime.Hour}{nowTime.Minute}{nowTime.Second}.mp4";
            _recorder.OnRecordingComplete += Rec_OnRecordingComplete;
            _recorder.OnRecordingFailed += Rec_OnRecordingFailed;
            _recorder.OnStatusChanged += Rec_OnStatusChanged;
            //Record to a file
            _isRecording = true;
            _recorder.Record(fullOutputPath);
            //..Or to a stream
            //_outStream = new MemoryStream();
            //_rec.Record(_outStream);
        }

        public void EndRecording()
        {
            _isRecording = false;
            if (_recorder != null)
            {
                _recorder.Stop();
                _recorder.Dispose();
                _recorder = null;
            }
        }

        private void Rec_OnRecordingComplete(object sender, RecordingCompleteEventArgs e)
        {
            //Get the file path if recorded to a file
            string path = e.FilePath;
            //or do something with your stream
            //... something ...
            _outStream?.Dispose();
        }
        private void Rec_OnRecordingFailed(object sender, RecordingFailedEventArgs e)
        {
            string error = e.Error;
            // throw new Exception(e.Error);
            _outStream?.Dispose();
        }

        private void Rec_OnStatusChanged(object sender, RecordingStatusEventArgs e)
        {
            RecorderStatus status = e.Status;
        }

    }
}
