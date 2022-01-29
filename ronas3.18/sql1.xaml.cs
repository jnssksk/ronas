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
using Microsoft.Win32;

namespace ronas
{
    /// <summary>
    /// Interaktionslogik für Page1.xaml
    /// </summary>
    public partial class sql1 : Page
    {
        public sql1(bool newInstanceChosen)
        {
            InitializeComponent();
            newInstance = newInstanceChosen;
            if (!newInstance)
            {
                errorLabel.Visibility = Visibility.Visible;
            }
        }

        public bool newInstance;

        #region Effects

        private void serverPathChanged(object sender, TextChangedEventArgs e)
        {
            if (newInstance)
            {
                if (Directory.Exists(serverPathLabel.Text))
                {
                    speicherortLabel.Foreground = new SolidColorBrush(Colors.White);
                    SaveBtn.Source = new BitmapImage(new Uri("SaveBtnGreen.png", UriKind.Relative));
                    SaveBtn.IsEnabled = true;
                }

                else
                {
                    speicherortLabel.Foreground = new SolidColorBrush(Colors.IndianRed);
                    SaveBtn.Source = new BitmapImage(new Uri("SaveBtn.png", UriKind.Relative));
                    SaveBtn.IsEnabled = false;
                }
            }
            else
            {
                if (Directory.Exists(serverPathLabel.Text) && serverPathLabel.Text.EndsWith("ronas"))
                {
                    speicherortLabel.Foreground = new SolidColorBrush(Colors.White);
                    SaveBtn.Source = new BitmapImage(new Uri("SaveBtnGreen.png", UriKind.Relative));
                    errorLabel.Visibility = Visibility.Hidden;
                    SaveBtn.IsEnabled = true;
                }
                else
                {
                    speicherortLabel.Foreground = new SolidColorBrush(Colors.IndianRed);
                    SaveBtn.Source = new BitmapImage(new Uri("SaveBtn.png", UriKind.Relative));
                    errorLabel.Visibility = Visibility.Visible;
                    SaveBtn.IsEnabled = false;
                }
            }
            
        }

        #endregion

        #region ClickEvents
        private void SaveClick(object sender, MouseButtonEventArgs e)
        {
            if (newInstance)
            {
                if (serverPathLabel.Text.EndsWith(@"\"))
                {
                    SettingsManager.SerializeJson(SettingsManager.DeserializeJson().setupDone, SettingsManager.DeserializeJson().prodKey, SettingsManager.DeserializeJson().local, SettingsManager.DeserializeJson().firstInstance, SettingsManager.DeserializeJson().templatePageOpened, SettingsManager.DeserializeJson().mainOpened, serverPathLabel.Text + @"\Projekte\", SettingsManager.DeserializeJson().notificationEnabled, false, SettingsManager.DeserializeJson().showOldProjects, SettingsManager.DeserializeJson().baseProjectNumber);
                }
                else
                {
                    SettingsManager.SerializeJson(SettingsManager.DeserializeJson().setupDone, SettingsManager.DeserializeJson().prodKey, SettingsManager.DeserializeJson().local, SettingsManager.DeserializeJson().firstInstance, SettingsManager.DeserializeJson().templatePageOpened, SettingsManager.DeserializeJson().mainOpened, serverPathLabel.Text + @"\Projekte\", SettingsManager.DeserializeJson().notificationEnabled, false, SettingsManager.DeserializeJson().showOldProjects, SettingsManager.DeserializeJson().baseProjectNumber);
                }
                if (!Directory.Exists(serverPathLabel.Text + "/Projekte"))
                {
                    DirectoryInfo di = Directory.CreateDirectory(serverPathLabel.Text + @"/ronas");
                    DirectoryInfo diSub = Directory.CreateDirectory(serverPathLabel.Text + @"/ronas" + @"/Projekte");
                }
            

            Main page = new Main();
            NavigationService.Navigate(page);

            setTemplatefirst();
            }
            else
            {
                if (serverPathLabel.Text.EndsWith(@"\"))
                {
                    SettingsManager.SerializeJson(SettingsManager.DeserializeJson().setupDone, SettingsManager.DeserializeJson().prodKey, SettingsManager.DeserializeJson().local, SettingsManager.DeserializeJson().firstInstance, SettingsManager.DeserializeJson().templatePageOpened, SettingsManager.DeserializeJson().mainOpened, serverPathLabel.Text + @"\Projekte\", SettingsManager.DeserializeJson().notificationEnabled, false, SettingsManager.DeserializeJson().showOldProjects, SettingsManager.DeserializeJson().baseProjectNumber);
                }
                else
                {
                    SettingsManager.SerializeJson(SettingsManager.DeserializeJson().setupDone, SettingsManager.DeserializeJson().prodKey, SettingsManager.DeserializeJson().local, SettingsManager.DeserializeJson().firstInstance, SettingsManager.DeserializeJson().templatePageOpened, SettingsManager.DeserializeJson().mainOpened, serverPathLabel.Text + @"\Projekte\", SettingsManager.DeserializeJson().notificationEnabled, false, SettingsManager.DeserializeJson().showOldProjects, SettingsManager.DeserializeJson().baseProjectNumber);
                }
                Main page = new Main();
                NavigationService.Navigate(page);
            }

            SettingsManager.SerializeJson(SettingsManager.DeserializeJson().setupDone, SettingsManager.DeserializeJson().prodKey, SettingsManager.DeserializeJson().local, SettingsManager.DeserializeJson().firstInstance, SettingsManager.DeserializeJson().templatePageOpened, SettingsManager.DeserializeJson().mainOpened, SettingsManager.DeserializeJson().serverPath, SettingsManager.DeserializeJson().notificationEnabled, false, SettingsManager.DeserializeJson().showOldProjects, projektNummerEntry.Text);

        }

        private void BackClick(object sender, MouseButtonEventArgs e)
        {
            NavigationService.GoBack();
        }

        #endregion

        #region Extras
        private void serverPathBrowse(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string folderpath = dialog.SelectedPath;
                serverPathLabel.Text = folderpath;
            }
        }


        private void setTemplatefirst()
        {
            string projectState = "Status";
            string projectAbbrev = "Kürzel";
            string projectNumber = "Projektnummer";
            string projectChef = "Auftraggeber";
            string projectArchitect = "Architekt";
            string projectFachplaner = "weitere fachplaner";
            string projectKleinprojekt = "Kleinprojekt"; //Bereinigt den String von System.Windows.Controls.ComboBoxItem:
            string projectBillOffer = "Honorarangebot";
            string projectEngineerContract = "Ingenieurvertrag";
            string projectSplitContract = "Splitvertrag"; //Bereinigt den String von System.Windows.Controls.ComboBoxItem:
            string projectDescription = "Beschreibung";
            string projectComments = "Bemerkungen";
            string projectGewerke = "beauftragte Gewerke";
            string projectRechnungName = "Schlussrechnung Dateiname";
            string projectRechnungDate = "Schlussrechnung Datum";
            string projectPaidDate = "Zahlungseingang am";
            string projectPaidSum = "Zahlungseingang Net.";
            string projectHomepage = "Auf Homepage";
            string projectReference = "In Referenzen";
            string projectLP9Date = "LP-9 Datum";
            string projectLP9Paid = "LP-9 Zahlungseingang";
            string projectLP9Possible = "LP-9 möglich";
            string projectLeistungsphasen = "Leistungsphasen";

            TemplateManager.SerializeJson(projectState, projectAbbrev, projectNumber, projectChef, projectArchitect, projectFachplaner, projectKleinprojekt, projectBillOffer, projectEngineerContract, projectSplitContract, projectDescription, projectComments, projectGewerke, projectRechnungName, projectRechnungDate, projectPaidDate, projectPaidSum, projectHomepage, projectReference, projectLP9Date, projectLP9Paid, projectLP9Possible, projectLeistungsphasen);

        }
        #endregion
    }
}
