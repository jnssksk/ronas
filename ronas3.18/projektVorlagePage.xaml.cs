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
    /// Interaktionslogik für projektVorlagePage.xaml
    /// </summary>
    public partial class projektVorlagePage : Page
    {
        public projektVorlagePage()
        {
            InitializeComponent();
            Status.Text = TemplateManager.DeserializeJson().projectState;
            Kuerzel.Text = TemplateManager.DeserializeJson().projectAbbrev;
            Projektnummer.Text = TemplateManager.DeserializeJson().projectNumber;
            Auftraggeber.Text = TemplateManager.DeserializeJson().projectChef;
            Architekt.Text = TemplateManager.DeserializeJson().projectArchitect;
            Fachplaner.Text = TemplateManager.DeserializeJson().projectFachplaner;
            Kleinprojekt.Text = TemplateManager.DeserializeJson().projectKleinprojekt;
            Honorarangebot.Text = TemplateManager.DeserializeJson().projectGewDauer;
            Ingenieurvertrag.Text = TemplateManager.DeserializeJson().projectEngineerContract;
            Splitvertrag.Text = TemplateManager.DeserializeJson().projectSplitContract;
            Beschreibung.Text = TemplateManager.DeserializeJson().projectDescription;
            Bemerkung.Text = TemplateManager.DeserializeJson().projectComments;
            Gewerke.Text = TemplateManager.DeserializeJson().projectGewerke;
            SchlussrechnungName.Text = TemplateManager.DeserializeJson().projectRechnungName;
            SchlussrechnungDatum.Text = TemplateManager.DeserializeJson().projectRechnungDate;
            Zahlungseingang.Text = TemplateManager.DeserializeJson().projectPaidDate;
            ZahlungseingangSumme.Text = TemplateManager.DeserializeJson().projectPaidSum;
            Homepage.Text = TemplateManager.DeserializeJson().projectHomepage;
            Referenzen.Text = TemplateManager.DeserializeJson().projectReference;
            LP9.Text = TemplateManager.DeserializeJson().projectLP9Date; //DATUM
            LP9_Möglich.Text = TemplateManager.DeserializeJson().projectLP9Possible;
            LP9_Zahlung.Text = TemplateManager.DeserializeJson().projectLP9Paid; //Summe
            Leistungsphasen.Text = TemplateManager.DeserializeJson().projectLeistungsphasen;
            if (!SettingsManager.DeserializeJson().templatePageOpened)
            {
                TutGrid.Visibility = Visibility.Visible;
                SettingsManager.SerializeJson(SettingsManager.DeserializeJson().setupDone, SettingsManager.DeserializeJson().prodKey, SettingsManager.DeserializeJson().local, SettingsManager.DeserializeJson().firstInstance, true, SettingsManager.DeserializeJson().mainOpened, SettingsManager.DeserializeJson().serverPath, SettingsManager.DeserializeJson().notificationEnabled, SettingsManager.DeserializeJson().lastSortedByDate, SettingsManager.DeserializeJson().showOldProjects, SettingsManager.DeserializeJson().baseProjectNumber);
            }
        }


        private void SaveClick(object sender, MouseButtonEventArgs e)
        {
                string projectState = detailsState.Text; //Bereinigt den String von System.Windows.Controls.ComboBoxItem:
                string projectAbbrev = detailsAbbrev.Text;
                string projectNumber = detailsNumber.Text;
                string projectChef = detailsChef.Text;
                string projectArchitect = detailsArchitect.Text;
                string projectFachplaner = detailsFachplaner.Text;
                string projectKleinprojekt = detailsKleinprojekt.Text; //Bereinigt den String von System.Windows.Controls.ComboBoxItem:
                string gewDauer = detailsGewDauer.Text;
                string projectEngineerContract = detailsEngineerContract.Text;
                string projectSplitContract = detailsSplitContract.Text; //Bereinigt den String von System.Windows.Controls.ComboBoxItem:
                string projectDescription = detailsDescription.Text;
                string projectComments = detailsComment.Text;
                string projectGewerke = detailsGewerke.Text;
                string projectRechnungName = detailsBillFilename.Text;
                string projectRechnungDate = detailsBillDate.Text;
                string projectPaidDate = detailsPaidDate.Text;
                string projectPaidSum = detailsPaidSum.Text;
                string projectHomepage = detailsHomepage.Text;
                string projectReference = detailsReferenzen.Text;
                string projectLP9Date = detailsLP9Date.Text;
                string projectLP9Paid = detailsLP9Sum.Text;
                string projectLP9Possible = detailsLP9Possible.Text;
                string projectLeistungsphasen = detailsLP.Text;
                TemplateManager.SerializeJson(projectState, projectAbbrev, projectNumber, projectChef, projectArchitect, projectFachplaner, projectKleinprojekt, gewDauer, projectEngineerContract, projectSplitContract, projectDescription, projectComments, projectGewerke, projectRechnungName, projectRechnungDate, projectPaidDate, projectPaidSum, projectHomepage, projectReference, projectLP9Date, projectLP9Paid, projectLP9Possible, projectLeistungsphasen);
                NavigationService.GoBack();
        }

        private void BackClick(object sender, MouseButtonEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void standardClick(object sender, MouseButtonEventArgs e)
        {
            string projectState = "Status";
            string projectAbbrev = "Kürzel";
            string projectNumber = "Projektnummer";
            string projectChef = "Auftraggeber";
            string projectArchitect = "Architekt";
            string projectFachplaner = "weitere Fachplaner";
            string projectKleinprojekt = "Kleinprojekt"; //Bereinigt den String von System.Windows.Controls.ComboBoxItem:
            string gewDauer = "Gew. Dauer in Jahren";
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
            string projectLP9Paid = "LP-9 Zahlung am";
            string projectLP9Possible = "LP-9 möglich";
            string projectLeistungsphasen = "Leistungsphasen";
            TemplateManager.SerializeJson(projectState, projectAbbrev, projectNumber, projectChef, projectArchitect, projectFachplaner, projectKleinprojekt, gewDauer, projectEngineerContract, projectSplitContract, projectDescription, projectComments, projectGewerke, projectRechnungName, projectRechnungDate, projectPaidDate, projectPaidSum, projectHomepage, projectReference, projectLP9Date, projectLP9Paid, projectLP9Possible, projectLeistungsphasen);
            Status.Text = TemplateManager.DeserializeJson().projectState;
            Kuerzel.Text = TemplateManager.DeserializeJson().projectAbbrev;
            Projektnummer.Text = TemplateManager.DeserializeJson().projectNumber;
            Auftraggeber.Text = TemplateManager.DeserializeJson().projectChef;
            Architekt.Text = TemplateManager.DeserializeJson().projectArchitect;
            Fachplaner.Text = TemplateManager.DeserializeJson().projectFachplaner;
            Kleinprojekt.Text = TemplateManager.DeserializeJson().projectKleinprojekt;
            detailsGewDauer.Text = TemplateManager.DeserializeJson().projectGewDauer;
            Ingenieurvertrag.Text = TemplateManager.DeserializeJson().projectEngineerContract;
            Splitvertrag.Text = TemplateManager.DeserializeJson().projectSplitContract;
            Beschreibung.Text = TemplateManager.DeserializeJson().projectDescription;
            Bemerkung.Text = TemplateManager.DeserializeJson().projectComments;
            Gewerke.Text = TemplateManager.DeserializeJson().projectGewerke;
            SchlussrechnungName.Text = TemplateManager.DeserializeJson().projectRechnungName;
            SchlussrechnungDatum.Text = TemplateManager.DeserializeJson().projectRechnungDate;
            Zahlungseingang.Text = TemplateManager.DeserializeJson().projectPaidDate;
            ZahlungseingangSumme.Text = TemplateManager.DeserializeJson().projectPaidSum;
            Homepage.Text = TemplateManager.DeserializeJson().projectHomepage;
            Referenzen.Text = TemplateManager.DeserializeJson().projectReference;
            LP9.Text = TemplateManager.DeserializeJson().projectLP9Date; //DATUM
            LP9_Möglich.Text = TemplateManager.DeserializeJson().projectLP9Possible;
            LP9_Zahlung.Text = TemplateManager.DeserializeJson().projectLP9Paid; //Summe
            NavigationService.GoBack();
        }

        private void TutRectClick(object sender, MouseButtonEventArgs e)
        {
            TutGrid.Visibility = Visibility.Hidden;
        }

    }
}
