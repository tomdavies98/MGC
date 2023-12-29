
using System;
using MGC.Models;
using MGC.Recording;
using MGC.Settings;
using MGC.Views;
using ScreenRecorderLib;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using Timer = System.Windows.Forms.Timer;

namespace MGC.ViewModels
{
    public class MainViewModel: INotifyPropertyChanged
    {
        public const string NotRecordingColour = "#FF72FFE5";
        public const string RecordingColour = "#E81C46";
        
        private Timer _recordingTimer { get; set; }
        private Stopwatch _recordingStopWatch { get; set; }
        private const string _hidden = "Hidden";
        private const string _visible = "Visible";
        private string _recordingTimerCount = "00:00:00";
        public string RecordingTimerCount
        {
            get
            {
                return _recordingTimerCount;
            }
            set
            {
                _recordingTimerCount = value;
                OnPropertyChanged(nameof(RecordingTimerCount));
            }
        }
        
        private string _visibleStatus = "Hidden";
        public string VisibleStatus
        {
            get
            {
                return _visibleStatus;
            }
            set
            {
                _visibleStatus = value;
                OnPropertyChanged(nameof(VisibleStatus));
            }
        }
        
        private string _loadingGifVisibility = "Hidden";
        public string LoadingGifVisibility
        {
            get
            {
                return _loadingGifVisibility;
            }
            set
            {
                _loadingGifVisibility = value;
                OnPropertyChanged(nameof(LoadingGifVisibility));
            }
        }

        private ICommand _startRecording;
        public ICommand StartRecording 
        {
            get
            {
                return _startRecording;
            }
            set
            {
                _startRecording = value;
                OnPropertyChanged(nameof(StartRecording));
            }
        }
        
        private ICommand _openSettingsMenu;
        public ICommand OpenSettingsMenu
        {
            get
            {
                return _openSettingsMenu;
            }
            set
            {
                _openSettingsMenu = value;
                OnPropertyChanged(nameof(OpenSettingsMenu));
            }
        }

        private ICommand _stopRecording;
        public ICommand StopRecording
        {
            get
            {
                return _stopRecording;
            }
            set
            {
                _stopRecording = value;
                OnPropertyChanged(nameof(StopRecording));
            }
        }

        private string _fileOutputPath;
        public string FileOutputFolder
        {
            get
            {
                return _fileOutputPath;
            }
            set
            {
                _fileOutputPath = value;
                OnPropertyChanged(nameof(FileOutputFolder));
            }
        }
        private int _framerate;
        public int Framerate
        {
            get
            {
                return _framerate;
            }
            set
            {
                _framerate = value;
                OnPropertyChanged(nameof(Framerate));
            }
        }

        private int _qualityPercentage;
        public int QualityPercentage
        {
            get
            {
                return _qualityPercentage;
            }
            set
            {
                _qualityPercentage = value;
                OnPropertyChanged(nameof(QualityPercentage));
            }
        }

        private ISettingsManager _settingsManager { get; set; }
        private RecorderOptions _recordingOptions { get; set; }
        private MGCSettings _mgcSettings { get; set; }
        public IMainModel MainModel { get; set; }
        public MainViewModel(IMainModel mainModel, ISettingsManager settingsManager)
        {
            _settingsManager = settingsManager;
            LoadSettings();
            MainModel = mainModel;
            Framerate = 60;
            QualityPercentage = 100;
            FileOutputFolder = @"C:\Users\tomda\Desktop\Clips\";
            StartRecording = new RelayCommand(t => Start());
            StopRecording = new RelayCommand(t => CloseAndStopRecording());
            OpenSettingsMenu = new RelayCommand(t => StartSettingsMenu());
        }

        public void StartSettingsMenu()
        {
            LoadSettings();
            var deviceManager = new DeviceManager();
            var settingsViewModel = new SettingsViewModel(deviceManager, _settingsManager, _mgcSettings);
            var settingsView = new SettingsView(settingsViewModel);
            settingsView.Show();
        }

        public void LoadSettings()
        {
            var settings = _settingsManager.LoadSettings();
            if(settings == null)
            {
                settings = GetDefaultSettings();
            }
            _mgcSettings = settings;
            SetSettings(settings);
        }

        private MGCSettings GetDefaultSettings()
        {
            var defaultSettings = new MGCSettings(
                new GeneralSettings()
                {
                    RecorderMode = RecorderMode.Video,
                    EnabledThrottling = false,
                    EnableHardwareEncoding = true,
                    EnableLowLatency = false,
                    EnableMp4FastStart = false
                },
                new AudioSettings()
                {
                    InputVolume = 0.5f,
                    OutputVolume = 0.5f,
                    Bitrate = AudioBitrate.bitrate_128kbps,
                    AudioChannel = AudioChannels.Stereo,
                    AudioEnabled = true,
                    SelectedInputDeviceName = Recorder.GetSystemAudioDevices(AudioDeviceSource.InputDevices).FirstOrDefault()?.ToString(),
                    SelectedOutputDeviceName = Recorder.GetSystemAudioDevices(AudioDeviceSource.OutputDevices).FirstOrDefault()?.ToString(),
                    AudioInputEnabled = true,
                    AudioOutputEnabled = true
                },
                new VideoSettings()
                {
                    BitrateMode = H264BitrateControlMode.Quality,
                    Quality = 100,
                    BitRate = 6000,
                    FrameRate = 60,
                    IsFixedFrameRate = true,
                    EncoderProfile = H264Profile.Main
                },
                new MacroSettings()
                {

                });

            return defaultSettings;
        }

        private AudioOptions CreateAudioOptions(AudioSettings audioSettings)
        {
            var inputVol = audioSettings.InputVolume > 1? audioSettings.InputVolume / 100 : 0.5f;
            var outputVol = audioSettings.OutputVolume > 1 ? audioSettings.OutputVolume / 100 : 0.5f;

            return new AudioOptions
            {
                InputVolume = inputVol,
                OutputVolume = outputVol,
                Bitrate = audioSettings.Bitrate,
                Channels = audioSettings.AudioChannel,
                IsAudioEnabled = audioSettings.AudioEnabled,
                AudioInputDevice = audioSettings.SelectedInputDeviceName,
                AudioOutputDevice = audioSettings.SelectedOutputDeviceName,
                IsInputDeviceEnabled = audioSettings.AudioInputEnabled,
                IsOutputDeviceEnabled = audioSettings.AudioOutputEnabled
            };
        }

        private OutputOptions CreateOutputOptions(RecorderMode recorderMode)
        {
            return new OutputOptions()
            {
                RecorderMode = recorderMode,

            };
        }

        private VideoEncoderOptions CreateVideoOptions(VideoSettings videoSettings)
        {
            return new VideoEncoderOptions
            {
                Bitrate = videoSettings.BitRate,
                Quality = videoSettings.Quality,
                IsFixedFramerate = videoSettings.IsFixedFrameRate,
                Framerate = videoSettings.FrameRate,
                
                Encoder = new H264VideoEncoder()
                {
                    BitrateMode = videoSettings.BitrateMode,
                    EncoderProfile = videoSettings.EncoderProfile
                },
            };
        }

        //RecorderMode = RecorderMode.Video,
        ////If throttling is disabled, out of memory exceptions may eventually crash the program,
        ////depending on encoder settings and system specifications.
        //IsThrottlingDisabled = false,
        ////Hardware encoding is enabled by default.
        //IsHardwareEncodingEnabled = true,
        ////Low latency mode provides faster encoding, but can reduce quality.
        //IsLowLatencyEnabled = false,
        ////Fast start writes the mp4 header at the beginning of the file, to facilitate streaming.
        //IsMp4FastStartEnabled = false,

        public void SetSettings(MGCSettings mgcSettings)
        {
            FileOutputFolder = mgcSettings.General.FileOutputDirectory;
            var generalSettings = mgcSettings.General;
            mgcSettings.Video.IsMP4FastStart = generalSettings.EnableMp4FastStart;
            mgcSettings.Video.IsLowLatency = generalSettings.EnableLowLatency;
            mgcSettings.Video.IsHardwareEncodingEnabled = generalSettings.EnableHardwareEncoding;
            mgcSettings.Video.IsThrottlingDisabled = generalSettings.EnabledThrottling;
            
            _recordingOptions = new RecorderOptions
            {
                AudioOptions = CreateAudioOptions(mgcSettings.Audio),
                VideoEncoderOptions = CreateVideoOptions(mgcSettings.Video),
                OutputOptions = CreateOutputOptions(generalSettings.RecorderMode)
            };
            
        }

        private void SetRecordingOptions(MGCSettings _mgcSettings)
        {
            var inputDevices = Recorder.GetSystemAudioDevices(AudioDeviceSource.InputDevices);
            var outputDevices = Recorder.GetSystemAudioDevices(AudioDeviceSource.OutputDevices);

            var inputNames = new List<string>();
            var outputNames = new List<string>();
            var inputDictionary = new Dictionary<string, string>();
            var outputDictionary = new Dictionary<string, string>();
            
            foreach (var inputEntry in inputDevices)
            {
                inputNames.Add(inputEntry.FriendlyName);
                inputDictionary.Add(inputEntry.FriendlyName, inputEntry.DeviceName);
            }

            foreach (var ouputEntry in outputDevices)
            {
                outputNames.Add(ouputEntry.FriendlyName);
                outputDictionary.Add(ouputEntry.FriendlyName, ouputEntry.DeviceName);
            }

            var selectedInputName = inputNames.First(t => t.Contains(_mgcSettings.Audio.SelectedInputDeviceName));
            var selectedOutputName = outputNames.First(t => t.Contains(_mgcSettings.Audio.SelectedOutputDeviceName));
            
            var selectedInput = inputDictionary[selectedInputName];
            var selectedOutput = outputDictionary[selectedOutputName];

            _recordingOptions = new RecorderOptions
            {
                OutputOptions = new OutputOptions()
                {
                    RecorderMode = RecorderMode.Video,
                },
                
                AudioOptions = new AudioOptions
                {
                    InputVolume = (float)_mgcSettings.Audio.InputVolume/10,
                    OutputVolume = (float)_mgcSettings.Audio.OutputVolume/101,
                    Bitrate = _mgcSettings.Audio.Bitrate,
                    Channels = _mgcSettings.Audio.AudioChannel,
                    IsAudioEnabled = _mgcSettings.Audio.AudioEnabled,
                    AudioOutputDevice = selectedOutput,
                    AudioInputDevice = selectedInput,
                    IsInputDeviceEnabled = _mgcSettings.Audio.AudioInputEnabled,
                    IsOutputDeviceEnabled = _mgcSettings.Audio.AudioOutputEnabled,
                },
                VideoEncoderOptions = new VideoEncoderOptions
                {
                    //Fast start writes the mp4 header at the beginning of the file, to facilitate streaming.
                    IsMp4FastStartEnabled = false,
                    //If throttling is disabled, out of memory exceptions may eventually crash the program,
                    //depending on encoder settings and system specifications.
                    IsThrottlingDisabled = _mgcSettings.General.EnabledThrottling == true ? false : true,
                    //Hardware encoding is enabled by default.
                    IsHardwareEncodingEnabled = _mgcSettings.General.EnableHardwareEncoding,
                    //Low latency mode provides faster encoding, but can reduce quality.
                    IsLowLatencyEnabled = true,
                    //BitrateMode = BitrateControlMode.UnconstrainedVBR,
                    Bitrate = _mgcSettings.Video.BitRate,
                    Quality = _mgcSettings.Video.Quality,
                    Framerate = _mgcSettings.Video.FrameRate,
                    // Framerate = _mgcSettings.Video.FrameRate * 2,
                    IsFixedFramerate = _mgcSettings.Video.IsFixedFrameRate,
                    Encoder = new H264VideoEncoder()
                    {
                        BitrateMode = _mgcSettings.Video.BitrateMode,
                        EncoderProfile = H264Profile.Main
                    }
                },
                //MouseOptions = new MouseOptions
                //{
                //    //Displays a colored dot under the mouse cursor when the left mouse button is pressed.	
                //    IsMouseClicksDetected = true,
                //    MouseClickDetectionColor = "#FFFF00",
                //    MouseRightClickDetectionColor = "#FFFF00",
                //    MouseClickDetectionRadius = 30,
                //    MouseClickDetectionDuration = 100,

                //    IsMousePointerEnabled = true,
                //    /* Polling checks every millisecond if a mouse button is pressed.
                //       Hook works better with programmatically generated mouse clicks, but may affect
                //       mouse performance and interferes with debugging.*/
                //    MouseClickDetectionMode = MouseDetectionMode.Hook
                //}
            };
        }

        public void Start()
        {
            LoadSettings();
            //if (_recordingOptions == null)
            SetRecordingOptions(_mgcSettings);
            StartRecordingVideo(FileOutputFolder, Framerate, QualityPercentage);
        }

        public void StartRecordingVideo(string outputFolder, int frameRate, int qualityPercentage)
        {
            VisibleStatus = _visible;
            MainModel.SetRecorderOptionsAndCreateNewRecorder(_recordingOptions);
            MainModel.StartRecording(outputFolder);

            _recordingTimer = new Timer();
            _recordingTimer.Interval = (800);
            _recordingTimer.Tick += new EventHandler(Timer_Tick);
            _recordingStopWatch = new Stopwatch();
            _recordingTimer.Start();
            _recordingStopWatch.Start();
        }
        
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (!MainModel.IsRecording())
            {
                StopRecordingTimers();
                return;
            }
            
            RecordingTimerCount = _recordingStopWatch.Elapsed.ToString("hh\\:mm\\:ss");
        }

        private void StopRecordingTimers()
        {
            if (_recordingTimer != null)
            {
                _recordingTimer.Stop();
                _recordingTimer = null;
            }

            if (_recordingStopWatch != null)
            {
                _recordingStopWatch.Stop();
                _recordingStopWatch.Reset();
                _recordingStopWatch = null;
            }
        }

        public void CloseAndStopRecording()
        {
            //Recorder.Dispose();
            VisibleStatus = _hidden;
            LoadingGifVisibility = _visible;

            Thread stopRecordingWorker = new Thread(() =>
            {
                MainModel.StopRecording();
                StopRecordingTimers();
                LoadingGifVisibility = _hidden;
            });

            stopRecordingWorker.Start();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
