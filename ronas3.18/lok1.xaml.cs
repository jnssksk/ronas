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
using Microsoft.Win32;
using System.IO;
using System.Collections;

namespace ronas
{
    /// <summary>
    /// Interaktionslogik für Page1.xaml
    /// </summary>
    public partial class lok1 : Page
    {
        public lok1()
        {
            InitializeComponent();
        }

        private void BackClick(object sender, MouseButtonEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void SaveClick(object sender, MouseButtonEventArgs e)
        {
            Main page = new Main();         //Mit unserer Key Datenbank zuvor abgleichen
            NavigationService.Navigate(page);
            SettingsManager.SerializeJson(true, SettingsManager.DeserializeJson().prodKey, SettingsManager.DeserializeJson().local, SettingsManager.DeserializeJson().firstInstance, SettingsManager.DeserializeJson().templatePageOpened, SettingsManager.DeserializeJson().mainOpened ,  SettingsManager.DeserializeJson().serverPath, SettingsManager.DeserializeJson().notificationEnabled, false, SettingsManager.DeserializeJson().showOldProjects, SettingsManager.DeserializeJson().baseProjectNumber);
            //SettingsManager.SerializeJson(SettingsManager.DeserializeJson().setupDone, prodKeyEntry.Text, SettingsManager.DeserializeJson().local, SettingsManager.DeserializeJson().firstInstance, SettingsManager.DeserializeJson().templatePageOpened, SettingsManager.DeserializeJson().mainOpened, SettingsManager.DeserializeJson().serverPath, SettingsManager.DeserializeJson().notificationEnabled);
        }

    }
}
