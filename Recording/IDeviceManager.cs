using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGC.Recording
{
    public interface IDeviceManager
    {

        void RefreshDevices();
        List<string> GetInputDeviceNames();
        List<string> GetOutputDeviceNames();
        string GetOutputDeviceId(string outputDeviceId);
        string GetInputDeviceId(string inputDeviceId);

    }
}
