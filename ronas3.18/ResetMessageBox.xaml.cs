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
using System.Windows.Forms;

namespace ronas
{
    /// <summary>
    /// Interaktionslogik für ResetMessageBox.xaml
    /// </summary>
    public partial class ResetMessageBox : System.Windows.Controls.UserControl
    {
        public ResetMessageBox()
        {
            InitializeComponent();
        }

        private void confirmClick(object sender, MouseButtonEventArgs e)
        {
            programFullReset();
        }

        private void programFullReset()
        {
            if (!SettingsManager.DeserializeJson().local)
            {
                DirectoryInfo di = new DirectoryInfo(SettingsManager.DeserializeJson().serverPath + "\\");
                di.Delete(true);
            }
            else
            {
                DirectoryInfo di = new DirectoryInfo(SettingsManager.DeserializeJson().serverPath);
                foreach (FileInfo fi in di.GetFiles())
                {
                    fi.Delete();
                    templateSetStandard();
                }
            }
            
            SettingsManager.SerializeJson(false, "", false, false, false, false, "./", true, false, true, "");
            Startup page = new Startup();
            //NavigationService.Navigate(page);
            System.Windows.Forms.Application.Restart();
            System.Windows.Application.Current.Shutdown();
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

        private void backClick(object sender, MouseButtonEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }
    }
}
