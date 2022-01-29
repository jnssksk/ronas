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
using System.Windows.Forms;
using System.IO;

namespace ronas
{
    /// <summary>
    /// Interaktionslogik für settings.xaml
    /// </summary>
    public partial class settings : Page
    {
        public settings()
        {
            InitializeComponent();

            if (SettingsManager.DeserializeJson().showOldProjects)
            {
                showOldLabel.Foreground = new SolidColorBrush(Color.FromRgb(136, 241, 133));
            }

            if (SettingsManager.DeserializeJson().local)
            {
                filepathBtn.Visibility = Visibility.Hidden;
                filepathBtn.IsEnabled = false;
            }
            else
            {
                filepathBtn.Visibility = Visibility.Visible;
                filepathBtn.IsEnabled = true;
            }
        }


        public bool showingfpWin = false;

        #region Effects
        private void templateBtnEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            templateBtn.BorderThickness = new Thickness(2);
        }

        private void templateBtnLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            templateBtn.BorderThickness = new Thickness(0);
        }

        private void filepathEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            filepathBtn.BorderThickness = new Thickness(2);
        }

        private void filepathLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            filepathBtn.BorderThickness = new Thickness(0);
        }

        #endregion

        #region ClickEvents
        private void BackClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void projektVorlageClick(object sender, RoutedEventArgs e)
        {
            projektVorlagePage page = new projektVorlagePage();
            NavigationService.Navigate(page);
        }

        private void standardClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            System.Windows.Controls.UserControl resetControl = new ResetMessageBox();
            settingsMainGrid.Children.Add(resetControl);
        }

        private void filePathBtnClick(object sender, RoutedEventArgs e)
        {
            showChange();
        }

        #endregion

        #region Program Pfad Ändern

        private void showChange()
        {
            
            filePathChangeStackPanel.Visibility = Visibility.Visible;
            changeFilePathWin noti = new changeFilePathWin();
            noti.Visibility = Visibility.Visible;
            settingsMainGrid.Children.Add(noti);
        }

        #endregion

        #region ProgramReset
        private void programFullReset()
        {
            DirectoryInfo di = new DirectoryInfo(SettingsManager.DeserializeJson().serverPath + "/Projekte/");
            foreach(FileInfo fi in di.GetFiles())
            {
                fi.Delete();
            }
            if (!SettingsManager.DeserializeJson().local)
            {
                di.Delete();
            }
            templateSetStandard();
            SettingsManager.SerializeJson(false, "", false, false, false, false, "./", true, false, true, "");
            Startup page = new Startup();
            NavigationService.Navigate(page);
        }

        private void templateSetStandard()
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

        private void showOldClicked(object sender, MouseButtonEventArgs e)
        {
            if (!SettingsManager.DeserializeJson().showOldProjects)
            {
                showOldLabel.Foreground = new SolidColorBrush(Color.FromRgb(136, 241, 133));
            }
            else
            {
                showOldLabel.Foreground = new SolidColorBrush(Color.FromRgb(238, 95, 62));
            }
            SettingsManager.SerializeJson(SettingsManager.DeserializeJson().setupDone, SettingsManager.DeserializeJson().prodKey, SettingsManager.DeserializeJson().local, SettingsManager.DeserializeJson().firstInstance, SettingsManager.DeserializeJson().templatePageOpened, SettingsManager.DeserializeJson().mainOpened, SettingsManager.DeserializeJson().serverPath, SettingsManager.DeserializeJson().notificationEnabled, SettingsManager.DeserializeJson().lastSortedByDate, !SettingsManager.DeserializeJson().showOldProjects, SettingsManager.DeserializeJson().baseProjectNumber);

            Main.main.ListPanel.Children.Clear();
            Main.main.generateAllButtons(SettingsManager.DeserializeJson().lastSortedByDate, SettingsManager.DeserializeJson().showOldProjects);
        }
    }

}
