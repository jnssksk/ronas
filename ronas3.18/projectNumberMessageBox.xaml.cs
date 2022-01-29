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
    /// Interaktionslogik für projectNumberMessageBox.xaml
    /// </summary>
    public partial class projectNumberMessageBox : UserControl
    {
        public projectNumberMessageBox()
        {
            InitializeComponent();
        }

        private void confirmClick(object sender, MouseButtonEventArgs e)
        {
            int Number = Convert.ToInt32(projektNummerEntry.Text) + 1;


            Startup.startupVerweis.startupMessageBoxGrid.Visibility = Visibility.Collapsed;
            SettingsManager.SerializeJson(SettingsManager.DeserializeJson().setupDone, SettingsManager.DeserializeJson().prodKey, SettingsManager.DeserializeJson().local, SettingsManager.DeserializeJson().firstInstance, SettingsManager.DeserializeJson().templatePageOpened, SettingsManager.DeserializeJson().mainOpened, SettingsManager.DeserializeJson().serverPath, SettingsManager.DeserializeJson().notificationEnabled, false, SettingsManager.DeserializeJson().showOldProjects, Number.ToString() );
            Startup.startupVerweis.navigateLocal();
        }
    }
}
