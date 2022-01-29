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

namespace ronas
{
    /// <summary>
    /// Interaktionslogik für Page1.xaml
    /// </summary>
    public partial class sql0 : Page
    {
        public sql0()
        {
            InitializeComponent();
        }

        private void BackClick(object sender, MouseButtonEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void yesClick(object sender, MouseButtonEventArgs e)
        {
            SettingsManager.SerializeJson(SettingsManager.DeserializeJson().setupDone, SettingsManager.DeserializeJson().prodKey, SettingsManager.DeserializeJson().local, false, SettingsManager.DeserializeJson().templatePageOpened, SettingsManager.DeserializeJson().mainOpened, SettingsManager.DeserializeJson().serverPath, SettingsManager.DeserializeJson().notificationEnabled, false, SettingsManager.DeserializeJson().showOldProjects, SettingsManager.DeserializeJson().baseProjectNumber);
            sql1 page = new sql1(false);
            NavigationService.Navigate(page);
        }

        private void noClick(object sender, MouseButtonEventArgs e)
        {
            sql1 page = new sql1(true);
            NavigationService.Navigate(page);
            SettingsManager.SerializeJson(SettingsManager.DeserializeJson().setupDone, SettingsManager.DeserializeJson().prodKey, SettingsManager.DeserializeJson().local, true, SettingsManager.DeserializeJson().templatePageOpened, SettingsManager.DeserializeJson().mainOpened, SettingsManager.DeserializeJson().serverPath, SettingsManager.DeserializeJson().notificationEnabled, false, SettingsManager.DeserializeJson().showOldProjects, SettingsManager.DeserializeJson().baseProjectNumber);
        }

        #region HoverEffects
        private void yesEnter(object sender, MouseEventArgs e)
        {
            networkYesRect.StrokeThickness = networkYesRect.StrokeThickness + 2;

        }

        private void yesLeave(object sender, MouseEventArgs e)
        {
            networkYesRect.StrokeThickness = networkYesRect.StrokeThickness + -2;
        }

        private void noEnter(object sender, MouseEventArgs e)
        {
            networkNoRect.StrokeThickness = networkNoRect.StrokeThickness + 2;
        }

        private void noLeave(object sender, MouseEventArgs e)
        {

            networkNoRect.StrokeThickness = networkNoRect.StrokeThickness + -2;
        }
        #endregion
    }
}
