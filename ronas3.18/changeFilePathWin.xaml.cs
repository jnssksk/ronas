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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ronas
{
    /// <summary>
    /// Interaktionslogik für changeFilePathWin.xaml
    /// </summary>
    public partial class changeFilePathWin : System.Windows.Controls.UserControl
    {
        public changeFilePathWin()
        {
            InitializeComponent();
        }

        private void filePathBrowseClick(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string folderpath = dialog.SelectedPath;
                filePathEntry.Text = folderpath;
            }
        }

        private void filePathEntryChanged(object sender, TextChangedEventArgs e)
        {
            if (Directory.Exists(filePathEntry.Text))
            {
                Color ConfirmGreen = (Color)ColorConverter.ConvertFromString("#31CD31");
                confirmBtn.IsEnabled = true;
                confirmBtn.Source = new BitmapImage(new Uri("SaveBtnGreen.png", UriKind.Relative));
                header.Foreground = new SolidColorBrush(ConfirmGreen);
            }
            else
            {
                confirmBtn.IsEnabled = false;
                confirmBtn.Source = new BitmapImage(new Uri("SaveBtn.png", UriKind.Relative));
                header.Foreground = new SolidColorBrush(Colors.IndianRed);
            }
        }

        private void backClick(object sender, MouseButtonEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }

        private void confirmClick(object sender, MouseButtonEventArgs e)
        {
            string sourceDirectory = SettingsManager.DeserializeJson().serverPath.Remove(SettingsManager.DeserializeJson().serverPath.Length - 9, 9);
            //string templSource = SettingsManager.DeserializeJson().serverPath + "\\TemplateSettings.json";
            string destinationDirectory = filePathEntry.Text + "\\ronas";

            
            Directory.Move(sourceDirectory, destinationDirectory);
            //File.Move(templSource, filePathEntry.Text + "/TemplateSettings.json");
            SettingsManager.SerializeJson(SettingsManager.DeserializeJson().setupDone, SettingsManager.DeserializeJson().prodKey, SettingsManager.DeserializeJson().local, SettingsManager.DeserializeJson().firstInstance, SettingsManager.DeserializeJson().templatePageOpened, SettingsManager.DeserializeJson().mainOpened, filePathEntry.Text + @"\ronas\Projekte\", SettingsManager.DeserializeJson().notificationEnabled, SettingsManager.DeserializeJson().lastSortedByDate, SettingsManager.DeserializeJson().showOldProjects, SettingsManager.DeserializeJson().baseProjectNumber);
            this.Visibility = Visibility.Hidden;
            this.IsEnabled = false;
        }
    }
}
