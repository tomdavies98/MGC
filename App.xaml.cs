using MGC.Models;
using MGC.Recording;
using MGC.Settings;
using MGC.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MGC
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var docFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var mgcSettingsFolder = "MGCSettings";
            var mgcSettingsPath = Path.Combine(docFolder, mgcSettingsFolder);

            if (!Directory.Exists(mgcSettingsPath))
            {
                Directory.CreateDirectory(mgcSettingsPath);
            }

            var jsonSettingsLocation = mgcSettingsPath;
            var settingsManager = new SettingsManager(jsonSettingsLocation);
            var mgcRecorder = new MGCRecorder();
            var mainModel = new MainModel(mgcRecorder);
            var mainVm = new MainViewModel(mainModel, settingsManager);
            var mainWin = new MainWindow(mainVm);
            mainWin.Show();
        }
    }
}
