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
    /// Interaktionslogik für MainContent.xaml
    /// </summary>
    public partial class MainContent : UserControl
    {
        public MainContent(string filenames)
        {
            InitializeComponent();
            applyTemplate();
            loadData(filenames);
            delfilename = filenames;
            maincontent = this;
            detailsBillFilename.ToolTip = ProjectManager.DeserializeJson(delfilename).projectRechnungName;
            setFontSize();
        }

        public string delfilename;
        public static MainContent maincontent;
        

        #region LoadPage
        void applyTemplate()
        {
            Status.Text = TemplateManager.DeserializeJson().projectState;
            Kuerzel.Text = TemplateManager.DeserializeJson().projectAbbrev;
            //Projektnummer.Content = TemplateManager.DeserializeJson().projectNumber;
            Auftraggeber.Text = TemplateManager.DeserializeJson().projectChef;
            Architekt.Text = TemplateManager.DeserializeJson().projectArchitect;
            Fachplaner.Text = TemplateManager.DeserializeJson().projectFachplaner;
            Kleinprojekt.Text = TemplateManager.DeserializeJson().projectKleinprojekt;
            Honorarangebot.Text = TemplateManager.DeserializeJson().projectGewDauer;
            Splitvertrag.Text = TemplateManager.DeserializeJson().projectSplitContract;
            Beschreibung.Text = TemplateManager.DeserializeJson().projectDescription;
            Bemerkung.Text = TemplateManager.DeserializeJson().projectComments;
            Gewerke.Text = TemplateManager.DeserializeJson().projectGewerke;
            SchlussrechnungName.Text = TemplateManager.DeserializeJson().projectRechnungName;
            SchlussrechnungDatum.Text = TemplateManager.DeserializeJson().projectRechnungDate;
            Zahlungseingang.Text = TemplateManager.DeserializeJson().projectPaidDate;
            ZahlungseingangSumme.Text = TemplateManager.DeserializeJson().projectPaidSum;
            Homepage.Text = TemplateManager.DeserializeJson().projectHomepage;
            LP9.Text = TemplateManager.DeserializeJson().projectLP9Date; //DATUM
            LP9_Zahlung.Text = TemplateManager.DeserializeJson().projectLP9Paid; //Summe
            Leistungsphasen.Text = TemplateManager.DeserializeJson().projectLeistungsphasen;
        }

        void loadData(string filenames)
        {
            detailsHeader.Content = ProjectManager.DeserializeJson(filenames).projectName;
            detailsState.Content = ProjectManager.DeserializeJson(filenames).projectState;
            detailsAbbrev.Content = ProjectManager.DeserializeJson(filenames).projectAbbrev;
            detailsNumber.Content = ProjectManager.DeserializeJson(filenames).projectNumber;
            detailsChef.Content = ProjectManager.DeserializeJson(filenames).projectChef;
            detailsArchitect.Content = ProjectManager.DeserializeJson(filenames).projectArchitect;
            detailsFachplaner.Content = ProjectManager.DeserializeJson(filenames).projectFachplaner;
            detailsKleinprojekt.Content = ProjectManager.DeserializeJson(filenames).projectKleinprojekt;
            detailsGewDauer.Content = ProjectManager.DeserializeJson(filenames).projectGewDauer;
            detailsSplitVertrag.Content = ProjectManager.DeserializeJson(filenames).projectSplitContract;
            detailsDescription.Content = ProjectManager.DeserializeJson(filenames).projectDescription;
            detailsComment.Content = ProjectManager.DeserializeJson(filenames).projectComments;
            detailsGewerke.Content = ProjectManager.DeserializeJson(filenames).projectGewerke;
            detailsBillDate.Content = ProjectManager.DeserializeJson(filenames).projectRechnungDate;
            detailsPaidDate.Content = ProjectManager.DeserializeJson(filenames).projectPaidDate;
            detailsPaidSum.Content = ProjectManager.DeserializeJson(filenames).projectPaidSum;
            detailsHomepage.Content = ProjectManager.DeserializeJson(filenames).projectHomepage;
            detailsLeistungsphasen.Content = ProjectManager.DeserializeJson(filenames).projectLP9;
            detailsLP9Date.Content = ProjectManager.DeserializeJson(filenames).projectLP9Date;
            detailsLP9Sum.Content = ProjectManager.DeserializeJson(filenames).projectLP9Paid;
            gewaehrleistungEnde.Content = ProjectManager.DeserializeJson(filenames).gewaerleistungEnde;

            /*abnahmeErfolgt.Content = ProjectManager.DeserializeJson(filenames).abnahmeDone; //Weitere Seite
            abnahmeProtDoc.Content = ProjectManager.DeserializeJson(filenames).abnahmeDocPath;
            abnahmeVom.Content = ProjectManager.DeserializeJson(filenames).abnahmeDate;
            revEingegangenAm.Content = ProjectManager.DeserializeJson(filenames).revisionEingangAm;
            revAusfertigung.Content = ProjectManager.DeserializeJson(filenames).revisionAusfertigung;
            revAbgegebenAm.Content = ProjectManager.DeserializeJson(filenames).revisionEingereichtAm;
            revVollstaendig.Content = ProjectManager.DeserializeJson(filenames).revisionVollstaendig;
            revWie.Content = ProjectManager.DeserializeJson(filenames).revisionEingereichtWie;*/
        }

        #endregion

        #region Clickevents

        private void billFileClick(object sender, RoutedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(ProjectManager.DeserializeJson(delfilename).projectRechnungName);
            }
            catch
            {
                Console.WriteLine("Konnte Dokument nicht öffnen. Überprüfen sie den Dateipfad.");
            }
        }

        #endregion

        private void MainContentScroll(object sender, ScrollChangedEventArgs e)
        {
            
            if (MainContentScrollViewer.VerticalOffset >= 350)
            {
                showSecondary();
            }
        }

        private void setFontSize()
        {
            try
            {
                if(ProjectManager.DeserializeJson(delfilename).projectFachplaner.Length > 20)
                {
                    double SizeFachplaner = Math.Pow(ProjectManager.DeserializeJson(delfilename).projectFachplaner.Length, -0.9397) * 266.6666;
                    detailsFachplaner.FontSize = SizeFachplaner;
                }

                if(ProjectManager.DeserializeJson(delfilename).projectGewerke.Length > 20)
                {
                    double SizeGewerke = Math.Pow(ProjectManager.DeserializeJson(delfilename).projectGewerke.Length, -0.9397) * 266.6666;
                    detailsGewerke.FontSize = SizeGewerke;
                }

                if (ProjectManager.DeserializeJson(delfilename).projectDescription.Length > 20)
                {
                    double SizeDesc = Math.Pow(ProjectManager.DeserializeJson(delfilename).projectDescription.Length, -0.9397) * 266.6666;
                    detailsDescription.FontSize = SizeDesc;
                }
            }

            catch
            {

            }
        }

        private void showSecondary()
        {
            secondaryContent sc = new secondaryContent(delfilename);
            Main.main.MainContentGrid.Children.Add(sc);
            MainContentScrollViewer.ScrollToTop();
            MainContentScrollViewer.VerticalScrollBarVisibility = ScrollBarVisibility.Hidden;
            MainContentScrollViewer.IsEnabled = false;

        }

        private void showLessClick(object sender, RoutedEventArgs e)
        {
            MainContentScrollViewer.ScrollToBottom();
        }
    }
}
