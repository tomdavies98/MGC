using MGC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MGC
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainViewModel ViewModel { get; set; }
        private System.Windows.Forms.NotifyIcon MyNotifyIcon;
        private string IconPath = @"..\..\..\Resources\mgcBanner.ico";
        public MainWindow(MainViewModel mainVm)
        {
            DataContext = ViewModel = mainVm;

            System.Windows.Forms.NotifyIcon ni = new System.Windows.Forms.NotifyIcon();
            ni.Icon = new System.Drawing.Icon(IconPath);
            ni.Visible = true;
            ni.DoubleClick +=
                delegate (object sender, EventArgs args)
                {
                    this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                    this.Show();
                    this.WindowState = WindowState.Normal;
                };
            InitializeComponent();
        }

        protected override void OnStateChanged(EventArgs e)
        {
            if (WindowState == System.Windows.WindowState.Minimized)
                this.Hide();

            base.OnStateChanged(e);
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void Minimize_Window(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Close_App(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Hide_App_To_System_Tray(object sender, RoutedEventArgs e)
        {
            //this.WindowState = WindowState.Maximized;
        }
    }
}
