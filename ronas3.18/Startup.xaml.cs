using System;
using System.Collections.Generic;
using System.IO;
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
    public partial class Startup : Page
    {
        public Startup()
        {
            InitializeComponent();
            // DEAKTIVIERT DAS TUTORIAL //
            SettingsManager.SerializeJson(SettingsManager.DeserializeJson().setupDone, SettingsManager.DeserializeJson().prodKey, SettingsManager.DeserializeJson().local, SettingsManager.DeserializeJson().firstInstance, SettingsManager.DeserializeJson().templatePageOpened, true, SettingsManager.DeserializeJson().serverPath, SettingsManager.DeserializeJson().notificationEnabled, false, SettingsManager.DeserializeJson().showOldProjects, SettingsManager.DeserializeJson().baseProjectNumber);

            startupVerweis = this;
        }

        public static Startup startupVerweis;

        private void sqlClick(object sender, MouseButtonEventArgs e)
        {
            sql0 page = new sql0();
            NavigationService.Navigate(page);
            SettingsManager.SerializeJson(SettingsManager.DeserializeJson().setupDone, SettingsManager.DeserializeJson().prodKey, false, SettingsManager.DeserializeJson().firstInstance, SettingsManager.DeserializeJson().templatePageOpened, SettingsManager.DeserializeJson().mainOpened, SettingsManager.DeserializeJson().serverPath, SettingsManager.DeserializeJson().notificationEnabled, false, SettingsManager.DeserializeJson().showOldProjects, SettingsManager.DeserializeJson().baseProjectNumber);
        }

        private void lokClick(object sender, MouseButtonEventArgs e)
        {
            projectNumberMessageBox pm = new projectNumberMessageBox();
            startupMessageBoxGrid.Children.Add(pm);
            startupMessageBoxGrid.Visibility = Visibility.Visible;
        }

        public void navigateLocal()
        {
            //lok1 page = new lok1();
            //NavigationService.Navigate(page);  Nur wenn es Verifikation gibt. Bei privater Weitergabe wird kein Key benötigt, deshalb auch kein Fenster wo dieser eingegeben wird
            SettingsManager.SerializeJson(SettingsManager.DeserializeJson().setupDone, SettingsManager.DeserializeJson().prodKey, true, true, SettingsManager.DeserializeJson().templatePageOpened, SettingsManager.DeserializeJson().mainOpened, @"./Projekte/", SettingsManager.DeserializeJson().notificationEnabled, false, SettingsManager.DeserializeJson().showOldProjects, SettingsManager.DeserializeJson().baseProjectNumber);
            if (!Directory.Exists("./Projekte"))
            {
                DirectoryInfo di = Directory.CreateDirectory("./Projekte");
            }
            Main page = new Main();
            NavigationService.Navigate(page);


            //Gibt es Verifikation, diese Zeile in "lok1.xaml.cs" zusammen mit "SettingsManager.SerializeJson(SettingsManager.DeserializeJson().setupDone, prodKeyEntry.Text, SettingsManager.DeserializeJson().local, SettingsManager.DeserializeJson().firstInstance, SettingsManager.DeserializeJson().templatePageOpened, SettingsManager.DeserializeJson().mainOpened, SettingsManager.DeserializeJson().serverPath, SettingsManager.DeserializeJson().notificationEnabled);"
            SettingsManager.SerializeJson(true, SettingsManager.DeserializeJson().prodKey, SettingsManager.DeserializeJson().local, SettingsManager.DeserializeJson().firstInstance, SettingsManager.DeserializeJson().templatePageOpened, SettingsManager.DeserializeJson().mainOpened, SettingsManager.DeserializeJson().serverPath, SettingsManager.DeserializeJson().notificationEnabled, false, SettingsManager.DeserializeJson().showOldProjects, SettingsManager.DeserializeJson().baseProjectNumber);
            //
        }
    }
}
