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
using System.Windows.Threading;
using System.IO;

namespace ronas
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            if (SettingsManager.DeserializeJson().setupDone)
            {
                MainFrame.Content = new Main();
            }
            else
            {
                MainFrame.Content = new Startup();
            }
            SettingsManager.SerializeJson(SettingsManager.DeserializeJson().setupDone, SettingsManager.DeserializeJson().prodKey, SettingsManager.DeserializeJson().local, SettingsManager.DeserializeJson().firstInstance, SettingsManager.DeserializeJson().templatePageOpened, SettingsManager.DeserializeJson().mainOpened, SettingsManager.DeserializeJson().serverPath, true, SettingsManager.DeserializeJson().lastSortedByDate, SettingsManager.DeserializeJson().showOldProjects, SettingsManager.DeserializeJson().baseProjectNumber);
        }

        #region TitleBar
        private void exitClick(object sender, MouseButtonEventArgs e)
        {
            SettingsManager.SerializeJson(SettingsManager.DeserializeJson().setupDone, SettingsManager.DeserializeJson().prodKey, SettingsManager.DeserializeJson().local, SettingsManager.DeserializeJson().firstInstance, SettingsManager.DeserializeJson().templatePageOpened, SettingsManager.DeserializeJson().mainOpened, SettingsManager.DeserializeJson().serverPath, true, SettingsManager.DeserializeJson().lastSortedByDate, SettingsManager.DeserializeJson().showOldProjects, SettingsManager.DeserializeJson().baseProjectNumber);
            Application.Current.Shutdown();
        }

        private void minimizeClick(object sender, MouseButtonEventArgs e)
        {
            //System.Threading.Thread.Sleep(500);
            this.WindowState = WindowState.Minimized;
        }

        private void titlebarDrag(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        #endregion

        #region Effects
        private void exitEnter(object sender, MouseEventArgs e)
        {
            exitBtn.Fill = new SolidColorBrush(Colors.Red);
        }

        private void exitLeave(object sender, MouseEventArgs e)
        {
            exitBtn.Fill = new SolidColorBrush(Color.FromRgb(238, 95, 62));
        }

        private void minimizeEnter(object sender, MouseEventArgs e)
        {
            minimizeBtn.Fill = new SolidColorBrush(Color.FromRgb(241, 167, 0));
        }

        private void minimizeLeave(object sender, MouseEventArgs e)
        {
            minimizeBtn.Fill = new SolidColorBrush(Color.FromRgb(248, 188, 58));
        }

        #endregion
    }
}
