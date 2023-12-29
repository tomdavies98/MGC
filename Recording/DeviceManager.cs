using ScreenRecorderLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGC.Recording
{
    public class DeviceManager: IDeviceManager
    {
        private List<string> _inputDeviceNames { get; set; }
        private List<string> _outputDeviceNames { get; set; }
        private Dictionary<string, string> _inputDeviceNameToId { get; set; }
        private Dictionary<string, string> _outputDeviceNameToId { get; set; }

        public DeviceManager()
        {
            _inputDeviceNameToId = new Dictionary<string, string>();
            _outputDeviceNameToId = new Dictionary<string, string>();
            RefreshDevices();
        }

        public void RefreshDevices()
        {
            var inputDevices = Recorder.GetSystemAudioDevices(AudioDeviceSource.InputDevices);
            var outputDevices = Recorder.GetSystemAudioDevices(AudioDeviceSource.OutputDevices);

            var inputNames = new List<string>();
            var outputNames = new List<string>();
            foreach (var inputEntry in inputDevices)
            {
                inputNames.Add(inputEntry.FriendlyName);
                _inputDeviceNameToId.Add(inputEntry.FriendlyName, inputEntry.DeviceName);
            }

            foreach (var ouputEntry in outputDevices)
            {
                outputNames.Add(ouputEntry.FriendlyName);
                _outputDeviceNameToId.Add(ouputEntry.FriendlyName, ouputEntry.DeviceName);
            }

            _inputDeviceNames = inputNames;
            _outputDeviceNames = outputNames;
        }

        public List<string> GetInputDeviceNames()
        {
            return _inputDeviceNames;
        }

        public List<string> GetOutputDeviceNames()
        {
            return _outputDeviceNames;
        }

        public string GetOutputDeviceId(string outputDeviceId)
        {
            if (_outputDeviceNameToId.TryGetValue(outputDeviceId, out var deviceId))
            {
                return deviceId;
            }

            return string.Empty;
        }

        public string GetInputDeviceId(string inputDeviceId)
        {
            if(_inputDeviceNameToId.TryGetValue(inputDeviceId, out var deviceId))
            {
                return deviceId;
            }

            return string.Empty;
        }
    }
}
