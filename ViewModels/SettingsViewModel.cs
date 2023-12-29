using MGC.Models;
using MGC.Recording;
using MGC.Settings;
using Microsoft.WindowsAPICodePack.Dialogs;
using ScreenRecorderLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MGC.ViewModels
{
    public class SettingsViewModel : INotifyPropertyChanged
    {
        private ICommand _inputVolumeChanged;
        public ICommand InputVolumeChanged
        {
            get
            {
                return _inputVolumeChanged;
            }
            set
            {
                _inputVolumeChanged = value;
                OnPropertyChanged(nameof(InputVolumeChanged));
            }
        }

        private ICommand _outputVolumeChanged;
        public ICommand OutputVolumeChanged
        {
            get
            {
                return _outputVolumeChanged;
            }
            set
            {
                _outputVolumeChanged = value;
                OnPropertyChanged(nameof(OutputVolumeChanged));
            }
        }

        private ICommand _openFileDirectorySearchCommand;
        public ICommand OpenFileDirectorySearchCommand
        {
            get
            {
                return _openFileDirectorySearchCommand;
            }
            set
            {
                _openFileDirectorySearchCommand = value;
                OnPropertyChanged(nameof(OpenFileDirectorySearchCommand));
            }
        }
        private ICommand _saveSettings;
        public ICommand SaveSettings
        {
            get
            {
                return _saveSettings;
            }
            set
            {
                _saveSettings = value;
                OnPropertyChanged(nameof(SaveSettings));
            }
        }

        private ICommand _resetSettings;
        public ICommand ResetSettings
        {
            get
            {
                return _resetSettings;
            }
            set
            {
                _resetSettings = value;
                OnPropertyChanged(nameof(ResetSettings));
            }
        }

        private string _fileOutputDirectory;
        public string FileOutputDirectory
        {
            get
            {
                return _fileOutputDirectory;
            }
            set
            {
                _fileOutputDirectory = value;
                OnPropertyChanged(nameof(FileOutputDirectory));
            }
        }

        private string _selectInputDevice;
        public string SelectedInputDevice
        {
            get
            {
                return _selectInputDevice;
            }
            set
            {
                _selectInputDevice = value;
                OnPropertyChanged(nameof(SelectedInputDevice));
            }
        }

        private List<string> _inputDevices;
        public List<string> InputDevices
        {
            get
            {
                return _inputDevices;
            }
            set
            {
                _inputDevices = value;
                OnPropertyChanged(nameof(InputDevices));
            }
        }

        private string _selectOutputDevice;
        public string SelectedOutputDevice
        {
            get
            {
                return _selectOutputDevice;
            }
            set
            {
                _selectOutputDevice = value;
                OnPropertyChanged(nameof(SelectedOutputDevice));
            }
        }

        private List<string> _outputDevices;
        public List<string> OutputDevices
        {
            get
            {
                return _outputDevices;
            }
            set
            {
                _outputDevices = value;
                OnPropertyChanged(nameof(OutputDevices));
            }
        }

        private List<RecorderMode> _recorderModes;
        public List<RecorderMode> RecorderModes
        {
            get
            {
                return _recorderModes;
            }
            set
            {
                _recorderModes = value;
                OnPropertyChanged(nameof(RecorderModes));
            }
        }

        private RecorderMode _selectedRecorderMode;
        public RecorderMode SelectedRecorderMode
        {
            get
            {
                return _selectedRecorderMode;
            }
            set
            {
                _selectedRecorderMode = value;
                OnPropertyChanged(nameof(SelectedRecorderMode));
            }
        }

        private bool _notificationsEnabled;
        public bool NotificationsEnabled
        {
            get
            {
                return _notificationsEnabled;
            }
            set
            {
                _notificationsEnabled = value;
                OnPropertyChanged(nameof(NotificationsEnabled));
            }
        }

        private bool _notificationsChimes;
        public bool NotificationsChimes
        {
            get
            {
                return _notificationsChimes;
            }
            set
            {
                _notificationsChimes = value;
                OnPropertyChanged(nameof(NotificationsChimes));
            }
        }

        private bool _throttlingEnabled;
        public bool ThrottlingEnabled
        {
            get
            {
                return _throttlingEnabled;
            }
            set
            {
                _throttlingEnabled = value;
                OnPropertyChanged(nameof(ThrottlingEnabled));
            }
        }

        private bool _hardwareEncoding;
        public bool HardwareEncoding
        {
            get
            {
                return _hardwareEncoding;
            }
            set
            {
                _hardwareEncoding = value;
                OnPropertyChanged(nameof(HardwareEncoding));
            }
        }

        private bool _lowLatency;
        public bool LowLatency
        {
            get
            {
                return _lowLatency;
            }
            set
            {
                _lowLatency = value;
                OnPropertyChanged(nameof(LowLatency));
            }
        }

        private bool _mp4FastStart;
        public bool Mp4FastStart
        {
            get
            {
                return _mp4FastStart;
            }
            set
            {
                _mp4FastStart = value;
                OnPropertyChanged(nameof(Mp4FastStart));
            }
        }

        private List<AudioChannels> _audioChannels;
        public List<AudioChannels> AudioChannels
        {
            get
            {
                return _audioChannels;
            }
            set
            {
                _audioChannels = value;
                OnPropertyChanged(nameof(AudioChannels));
            }
        }

        private AudioChannels _selectedAudioChannel;
        public AudioChannels SelectedAudioChannel
        {
            get
            {
                return _selectedAudioChannel;
            }
            set
            {
                _selectedAudioChannel = value;
                OnPropertyChanged(nameof(SelectedAudioChannel));
            }
        }

        private int _audioInputVolume;
        public int AudioInputVolume
        {
            get
            {
                return _audioInputVolume;
            }
            set
            {
                _audioInputVolume = value;
                OnPropertyChanged(nameof(AudioInputVolume));
            }
        }

        private int _audioOutputVolume;
        public int AudioOutputVolume
        {
            get
            {
                return _audioOutputVolume;
            }
            set
            {
                _audioOutputVolume = value;
                OnPropertyChanged(nameof(AudioOutputVolume));
            }
        }

        private int _selectedVideoQuality;
        public int SelectedVideoQuality
        {
            get
            {
                return _selectedVideoQuality;
            }
            set
            {
                _selectedVideoQuality = value;
                OnPropertyChanged(nameof(SelectedVideoQuality));
            }
        }

        private int _videoQuality;
        public int VideoQuality
        {
            get
            {
                return _videoQuality;
            }
            set
            {
                _videoQuality = value;
                OnPropertyChanged(nameof(VideoQuality));
            }
        }

        private H264BitrateControlMode _selectedVideoBitrateMode;
        public H264BitrateControlMode SelectedVideoBitrateMode
        {
            get
            {
                return _selectedVideoBitrateMode;
            }
            set
            {
                _selectedVideoBitrateMode = value;
                OnPropertyChanged(nameof(SelectedVideoBitrateMode));
            }
        }

        private string _bitrateValue;
        public string BitrateValue
        {
            get
            {
                return _bitrateValue;
            }
            set
            {
                _bitrateValue = value;
                OnPropertyChanged(nameof(BitrateValue));
            }
        }

        private AudioBitrate _selectedAudioBitrate;
        public AudioBitrate SelectedAudioBitrate
        {
            get
            {
                return _selectedAudioBitrate;
            }
            set
            {
                _selectedAudioBitrate = value;
                OnPropertyChanged(nameof(SelectedAudioBitrate));
            }
        }

        private List<AudioBitrate> _audioBitrates;
        public List<AudioBitrate> AudioBitrates
        {
            get
            {
                return _audioBitrates;
            }
            set
            {
                _audioBitrates = value;
                OnPropertyChanged(nameof(AudioBitrates));
            }
        }

        private List<H264BitrateControlMode> _videoBitrates;
        public List<H264BitrateControlMode> VideoBitrateModes
        {
            get
            {
                return _videoBitrates;
            }
            set
            {
                _videoBitrates = value;
                OnPropertyChanged(nameof(VideoBitrateModes));
            }
        }

        private int _selectedFrameRate;
        public int SelectedFrameRate
        {
            get
            {
                return _selectedFrameRate;
            }
            set
            {
                _selectedFrameRate = value;
                OnPropertyChanged(nameof(SelectedFrameRate));
            }
        }

        private List<int> _frameRates;
        public List<int> FrameRates
        {
            get
            {
                return _frameRates;
            }
            set
            {
                _frameRates = value;
                OnPropertyChanged(nameof(FrameRates));
            }
        }

        private bool _fixedFrameRate;
        public bool FixedFrameRate
        {
            get
            {
                return _fixedFrameRate;
            }
            set
            {
                _fixedFrameRate = value;
                OnPropertyChanged(nameof(FixedFrameRate));
            }
        }

        private H264Profile _selectedEncoderProfile;
        public H264Profile SelectedEncoderProfile
        {
            get
            {
                return _selectedEncoderProfile;
            }
            set
            {
                _selectedEncoderProfile = value;
                OnPropertyChanged(nameof(SelectedEncoderProfile));
            }
        }

        private List<H264Profile> _encoderProfile;
        public List<H264Profile> EncoderProfile
        {
            get
            {
                return _encoderProfile;
            }
            set
            {
                _encoderProfile = value;
                OnPropertyChanged(nameof(EncoderProfile));
            }
        }

        private bool _audioEnabled;
        public bool AudioEnabled
        {
            get
            {
                return _audioEnabled;
            }
            set
            {
                _audioEnabled = value;
                OnPropertyChanged(nameof(AudioEnabled));
            }
        }

        private bool _audioOutputEnabled;
        public bool AudioOutputEnabled
        {
            get
            {
                return _audioOutputEnabled;
            }
            set
            {
                _audioOutputEnabled = value;
                OnPropertyChanged(nameof(AudioOutputEnabled));
            }
        }

        private bool _audioInputEnabled;
        public bool AudioInputEnabled
        {
            get
            {
                return _audioInputEnabled;
            }
            set
            {
                _audioInputEnabled = value;
                OnPropertyChanged(nameof(AudioInputEnabled));
            }
        }

        private ISettingsManager _settingsManager;
      
        private IDeviceManager _deviceManager { get; set; }
        public SettingsViewModel(IDeviceManager deviceManager, ISettingsManager settingsManager, MGCSettings mgcSettings)
        {
            _settingsManager = settingsManager;
            InputVolumeChanged = new RelayCommand(t => InputVolumeValueChange());
            OutputVolumeChanged = new RelayCommand(t => OutputVolumeValueChange());

            OpenFileDirectorySearchCommand = new RelayCommand(t => OpenFileDirectorySearch());
            SaveSettings = new RelayCommand(t => SaveSettingsJson());
            ResetSettings = new RelayCommand(t => ResetSettingsJson());
            VideoBitrateModes = new List<H264BitrateControlMode> { H264BitrateControlMode.CBR, H264BitrateControlMode.Quality, H264BitrateControlMode.UnconstrainedVBR };
            FrameRates = new List<int>() { 30, 60 };
            EncoderProfile = new List<H264Profile>() { H264Profile.Baseline, H264Profile.High, H264Profile.Main };
            VideoQuality = 100;
            _deviceManager = deviceManager;
            GetSettings();

            if(mgcSettings != null)
            {
                SetConfigSettingValues(mgcSettings);
            }
            else
            {
                SetDefaultSettingsValues();
            }

        }

        private void InputVolumeValueChange()
        {
            AudioOutputVolume = 100 - AudioInputVolume;
        }

        private void OutputVolumeValueChange()
        {
            AudioInputVolume = 100 - AudioOutputVolume;
        }

        private void OpenFileDirectorySearch()
        {
            FileOutputDirectory = GetFolderDirectory();
        }

        private string GetFolderDirectory()
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.InitialDirectory = FileOutputDirectory ?? "C:\\Users";
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                return dialog.FileName;
            }

            return "";
        }

        private void ResetSettingsJson()
        {

        }

        private void SaveSettingsJson()
        {
            try
            {
                var audioSettings = new AudioSettings()
                {
                    AudioChannel = SelectedAudioChannel,
                    Bitrate = SelectedAudioBitrate,
                    AudioEnabled = AudioEnabled,
                    AudioInputEnabled = AudioInputEnabled,
                    AudioOutputEnabled = AudioOutputEnabled,
                    InputVolume = AudioInputVolume,
                    OutputVolume = AudioOutputVolume,
                    SelectedInputDeviceName = SelectedInputDevice,
                    SelectedOutputDeviceName = SelectedOutputDevice
                };

                var videoSettings = new VideoSettings()
                {
                    BitrateMode = SelectedVideoBitrateMode,
                    Quality = VideoQuality,
                    BitRate = Convert.ToInt32(BitrateValue),
                    FrameRate = SelectedFrameRate,
                    IsFixedFrameRate = FixedFrameRate,
                    EncoderProfile = SelectedEncoderProfile
                };

                var generalSettings = new GeneralSettings()
                {
                    EnableMp4FastStart = Mp4FastStart,
                    FileOutputDirectory = FileOutputDirectory,
                    EnableLowLatency = LowLatency,
                    EnableHardwareEncoding = HardwareEncoding,
                    EnabledThrottling = ThrottlingEnabled,
                    Notifications = NotificationsEnabled,
                    EnableSounds = NotificationsChimes,
                    RecorderMode = SelectedRecorderMode
                    //EnableShadowPlay =
                };

                var macroSettings = new MacroSettings()
                {

                };

                _settingsManager.SaveSettings(audioSettings, generalSettings, macroSettings, videoSettings);
            }
            catch(Exception e)
            {
                throw new Exception("Something went wrong while trying to save json settings:", e);
            }
        }

        private void SetConfigSettingValues(MGCSettings mgcSettings)
        {
            var videoConfig = mgcSettings.Video;
            var audioConfig = mgcSettings.Audio;
            var generalConfig = mgcSettings.General;
            var macroConfig = mgcSettings.Macro;

            //General settings
            Mp4FastStart = generalConfig.EnableMp4FastStart;
            LowLatency = generalConfig.EnableLowLatency;
            HardwareEncoding = generalConfig.EnableHardwareEncoding;
            ThrottlingEnabled = generalConfig.EnabledThrottling;
            NotificationsEnabled = generalConfig.Notifications;
            NotificationsChimes = generalConfig.EnableSounds;
            SelectedRecorderMode = generalConfig.RecorderMode;
            FileOutputDirectory = generalConfig.FileOutputDirectory;

            //Video settings
            SelectedVideoBitrateMode = videoConfig.BitrateMode;
            SelectedVideoQuality = videoConfig.Quality;
            BitrateValue = videoConfig.BitRate.ToString();
            SelectedFrameRate = videoConfig.FrameRate;
            SelectedEncoderProfile = videoConfig.EncoderProfile;
            FixedFrameRate = videoConfig.IsFixedFrameRate;

            //Audio settings
            AudioEnabled = audioConfig.AudioEnabled;
            AudioOutputEnabled = audioConfig.AudioOutputEnabled;
            AudioInputEnabled = audioConfig.AudioInputEnabled;
            var savedDeviceName = audioConfig.SelectedInputDeviceName;
            var savedOutputDeviceName = audioConfig.SelectedOutputDeviceName;
            var inputDevices = _deviceManager.GetInputDeviceNames();
            var matchedInputDevice = inputDevices.Where(t => t == savedDeviceName).FirstOrDefault();
            var matchedOutputDevice = OutputDevices.Where(t => t == savedOutputDeviceName).FirstOrDefault();

            if(!string.IsNullOrEmpty(matchedInputDevice))
            {
                SelectedInputDevice = matchedInputDevice;
            }
            else
            {
                SelectedInputDevice = inputDevices.FirstOrDefault() == null ? "" : inputDevices.FirstOrDefault();
            }

            if(!string.IsNullOrEmpty(matchedOutputDevice))
            {
                SelectedOutputDevice = matchedOutputDevice;
            }
            else
            {
                SelectedOutputDevice = OutputDevices.FirstOrDefault() == null ? "" : OutputDevices.FirstOrDefault();
            }
            
            AudioInputVolume = (int)audioConfig.InputVolume;
            AudioOutputVolume = (int)audioConfig.OutputVolume;
            SelectedAudioBitrate = audioConfig.Bitrate;
            SelectedAudioChannel = audioConfig.AudioChannel;
            //Macro settings
        }


        private void SetDefaultSettingsValues()
        {
            SelectedVideoBitrateMode = H264BitrateControlMode.Quality;
            SelectedRecorderMode = RecorderMode.Video;
            SelectedAudioChannel = ScreenRecorderLib.AudioChannels.Stereo;
            SelectedAudioBitrate = AudioBitrate.bitrate_128kbps;

        }

        public void GetSettings()
        {
            SelectedEncoderProfile = H264Profile.Main;
            SelectedFrameRate = FrameRates[1];

            RecorderModes = new List<RecorderMode> { RecorderMode.Slideshow, RecorderMode.Screenshot, RecorderMode.Video };

            AudioChannels = new List<AudioChannels> { ScreenRecorderLib.AudioChannels.Stereo, ScreenRecorderLib.AudioChannels.Mono, ScreenRecorderLib.AudioChannels.FivePointOne};

            BitrateValue = "13500";
            AudioBitrates = new List<AudioBitrate>() { AudioBitrate.bitrate_96kbps, AudioBitrate.bitrate_128kbps, AudioBitrate.bitrate_160kbps, AudioBitrate.bitrate_192kbps };

            InputDevices = _deviceManager.GetInputDeviceNames();
            OutputDevices = _deviceManager.GetOutputDeviceNames();
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
