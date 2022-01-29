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
using System.IO;
using Microsoft.Win32;

namespace ronas
{
    /// <summary>
    /// Interaktionslogik für addControl.xaml
    /// </summary>
    public partial class addControl : UserControl
    {
        public addControl(bool doEdit, string filename)
        {
            InitializeComponent();
            edited = doEdit;
            sourceFileNameOnEdit = filename;
            //etGewDate(filename);

            loadTemplate();
            if (doEdit)
            {
                loadData(filename);
                nameLabel.Content = null;
                dateLabel.Text = null;
            }

            addcontrolVerweis = this;

            Projektnummer.Visibility = Visibility.Hidden;

            if(detailsNumber.Text == "")
            {
                Projektnummer.Visibility = Visibility.Visible;
            }
            

        }
        public static addControl addcontrolVerweis;
        public bool test = true;
        public string sourceFileNameOnEdit;
        public bool edited;
        public string gewaehrleistungsEndeDatum;

        #region Initialize

        public void loadTemplate()
        {
            Status.Text = TemplateManager.DeserializeJson().projectState;
            Kuerzel.Text = TemplateManager.DeserializeJson().projectAbbrev;
            Projektnummer.Content = TemplateManager.DeserializeJson().projectNumber;
            Auftraggeber.Text = TemplateManager.DeserializeJson().projectChef;
            Architekt.Text = TemplateManager.DeserializeJson().projectArchitect;
            Fachplaner.Text = TemplateManager.DeserializeJson().projectFachplaner;
            Kleinprojekt.Text = TemplateManager.DeserializeJson().projectKleinprojekt;
            Leistungsphasen.Text = TemplateManager.DeserializeJson().projectLeistungsphasen;
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

            detailsNumber.Text = SettingsManager.DeserializeJson().baseProjectNumber + "/" + Convert.ToString(DateTime.Now.Year)[2] + Convert.ToString(DateTime.Now.Year)[3];
        }

        void loadData(string filenames)
        {
            detailsHeader.Text = ProjectManager.DeserializeJson(filenames).projectName;
            detailsState.Text = ProjectManager.DeserializeJson(filenames).projectState;
            detailsAbbrev.Text = ProjectManager.DeserializeJson(filenames).projectAbbrev;
            detailsNumber.Text = ProjectManager.DeserializeJson(filenames).projectNumber;
            detailsChef.Text = ProjectManager.DeserializeJson(filenames).projectChef;
            detailsArchitect.Text = ProjectManager.DeserializeJson(filenames).projectArchitect;
            detailsFachplaner.Text = ProjectManager.DeserializeJson(filenames).projectFachplaner;
            detailsKleinprojekt.Text = ProjectManager.DeserializeJson(filenames).projectKleinprojekt;
            detailsGewDauer.Text = ProjectManager.DeserializeJson(filenames).projectGewDauer;
            detailsSplitVertrag.Text = ProjectManager.DeserializeJson(filenames).projectSplitContract;
            detailsDescription.Text = ProjectManager.DeserializeJson(filenames).projectDescription;
            detailsComment.Text = ProjectManager.DeserializeJson(filenames).projectComments;
            detailsGewerke.Text = ProjectManager.DeserializeJson(filenames).projectGewerke;
            detailsBillFilename.Text = ProjectManager.DeserializeJson(filenames).projectRechnungName;
            detailsPaidDate.Text = ProjectManager.DeserializeJson(filenames).projectPaidDate;
            detailsPaidSum.Text = ProjectManager.DeserializeJson(filenames).projectPaidSum;
            detailsHomepage.Text = ProjectManager.DeserializeJson(filenames).projectHomepage;
            detailsLeistungsphasen.Text = ProjectManager.DeserializeJson(filenames).projectLP9; //detailsLeistungsphasen
            detailsLP9Date.Text = ProjectManager.DeserializeJson(filenames).projectLP9Date;
            detailsLP9Sum.Text = ProjectManager.DeserializeJson(filenames).projectLP9Paid;
            gewaehrleistungEnde.Text = ProjectManager.DeserializeJson(filenames).gewaerleistungEnde;

            /*abnahmeErfolgt.Text = ProjectManager.DeserializeJson(filenames).abnahmeDone; //Weitere Seite
            abnahmeProtDoc.Text = ProjectManager.DeserializeJson(filenames).abnahmeDocPath;
            abnahmeVom.Text = ProjectManager.DeserializeJson(filenames).abnahmeDate;
            revEingegangenAm.Text = ProjectManager.DeserializeJson(filenames).revisionEingangAm;
            revAusfertigung.Text = ProjectManager.DeserializeJson(filenames).revisionAusfertigung;
            revAbgegebenAm.Text = ProjectManager.DeserializeJson(filenames).revisionEingereichtAm;
            revVollstaendig.Text = ProjectManager.DeserializeJson(filenames).revisionVollstaendig;
            revWie.Text = ProjectManager.DeserializeJson(filenames).revisionEingereichtWie;*/
        }
        #endregion

        #region Save

        private void saveClick(object sender, MouseButtonEventArgs e)
        {

            string projectName = detailsHeader.Text;

            string[] projectInfos = {
                detailsHeader.Text,
                detailsState.Text,
                detailsAbbrev.Text,
                detailsNumber.Text,
                detailsChef.Text,
                detailsArchitect.Text,
                detailsFachplaner.Text,
                detailsKleinprojekt.Text,
                detailsGewDauer.Text,
                "detailsEngineerContract.Text (Platzhalter)",
                detailsSplitVertrag.Text,
                detailsDescription.Text,
                detailsComment.Text,
                detailsGewerke.Text,
                detailsBillFilename.Text,
                detailsBillDate.Text,
                detailsPaidDate.Text,
                detailsPaidSum.Text,
                detailsHomepage.Text,
                "detailsReferences (Platzhalter).Text",
                detailsLeistungsphasen.Text,
                detailsLP9Date.Text,
                detailsLP9Sum.Text,
                "detailsLP9Possible (Platzhalter).Text",
                gewaehrleistungsEndeDatum,
                "revBemerkung.Text (Platzhalter)",


                #region Gewerk1
                secondaryAddContent.secondaryC.Gewerk1.Text,
                secondaryAddContent.secondaryC.Gew1Abnahme.Text,
                secondaryAddContent.secondaryC.Gew1Protokoll.Text,
                secondaryAddContent.secondaryC.Gew1AbnahmePfad.Text,
                secondaryAddContent.secondaryC.Gew1EingangAm.Text,
                secondaryAddContent.secondaryC.Gew1Ausfertigung.Text,
                secondaryAddContent.secondaryC.Gew1RevVollst.Text,
                secondaryAddContent.secondaryC.Gew1AbgegebenAm.Text,
                secondaryAddContent.secondaryC.Gew1ueber.Text,
#endregion

                #region Gewerk2
                secondaryAddContent.secondaryC.Gewerk2.Text,
                secondaryAddContent.secondaryC.Gew2Abnahme.Text,
                secondaryAddContent.secondaryC.Gew2Protokoll.Text,
                secondaryAddContent.secondaryC.Gew2AbnahmePfad.Text,
                secondaryAddContent.secondaryC.Gew2EingangAm.Text,
                secondaryAddContent.secondaryC.Gew2Ausfertigung.Text,
                secondaryAddContent.secondaryC.Gew2RevVollst.Text,
                secondaryAddContent.secondaryC.Gew2AbgegebenAm.Text,
                secondaryAddContent.secondaryC.Gew2ueber.Text,
                #endregion

                #region Gewerk3
                secondaryAddContent.secondaryC.Gewerk3.Text,
                secondaryAddContent.secondaryC.Gew3Abnahme.Text,
                secondaryAddContent.secondaryC.Gew3Protokoll.Text,
                secondaryAddContent.secondaryC.Gew3AbnahmePfad.Text,
                secondaryAddContent.secondaryC.Gew3EingangAm.Text,
                secondaryAddContent.secondaryC.Gew3Ausfertigung.Text,
                secondaryAddContent.secondaryC.Gew3RevVollst.Text,
                secondaryAddContent.secondaryC.Gew3AbgegebenAm.Text,
                secondaryAddContent.secondaryC.Gew3ueber.Text,
                #endregion

                #region Gewerk4
                secondaryAddContent.secondaryC.Gewerk4.Text,
                secondaryAddContent.secondaryC.Gew4Abnahme.Text,
                secondaryAddContent.secondaryC.Gew4Protokoll.Text,
                secondaryAddContent.secondaryC.Gew4AbnahmePfad.Text,
                secondaryAddContent.secondaryC.Gew4EingangAm.Text,
                secondaryAddContent.secondaryC.Gew4Ausfertigung.Text,
                secondaryAddContent.secondaryC.Gew4RevVollst.Text,
                secondaryAddContent.secondaryC.Gew4AbgegebenAm.Text,
                secondaryAddContent.secondaryC.Gew4ueber.Text,
                #endregion

                #region Gewerk5
                secondaryAddContent.secondaryC.Gewerk5.Text,
                secondaryAddContent.secondaryC.Gew5Abnahme.Text,
                secondaryAddContent.secondaryC.Gew5Protokoll.Text,
                secondaryAddContent.secondaryC.Gew5AbnahmePfad.Text,
                secondaryAddContent.secondaryC.Gew5EingangAm.Text,
                secondaryAddContent.secondaryC.Gew5Ausfertigung.Text,
                secondaryAddContent.secondaryC.Gew5RevVollst.Text,
                secondaryAddContent.secondaryC.Gew5AbgegebenAm.Text,
                secondaryAddContent.secondaryC.Gew5ueber.Text,
#endregion
            };

            string filename = "/" + projectName + ".json";
            if (edited && !ProjectManager.DeserializeJson(sourceFileNameOnEdit).projectName.Equals(projectName + ".json"))
            {
                File.Delete(SettingsManager.DeserializeJson().serverPath + sourceFileNameOnEdit);
            }
            //setGewDate(filename);
            ProjectManager.SerializeJson(filename, projectInfos);
            SettingsManager.SerializeJson(SettingsManager.DeserializeJson().setupDone, SettingsManager.DeserializeJson().prodKey, SettingsManager.DeserializeJson().local, SettingsManager.DeserializeJson().firstInstance, SettingsManager.DeserializeJson().templatePageOpened, SettingsManager.DeserializeJson().mainOpened, SettingsManager.DeserializeJson().serverPath, SettingsManager.DeserializeJson().notificationEnabled, SettingsManager.DeserializeJson().lastSortedByDate, SettingsManager.DeserializeJson().showOldProjects, (Convert.ToInt32(SettingsManager.DeserializeJson().baseProjectNumber) + 1).ToString());

            Main.main.ListPanel.Children.Clear();
            Main.main.generateAllButtons(SettingsManager.DeserializeJson().lastSortedByDate, SettingsManager.DeserializeJson().showOldProjects);
            Main.main.MainContentGrid.Children.Clear();
            Main.main.delButton.Visibility = Visibility.Collapsed;
            Main.main.SettingsBtn.Visibility = Visibility.Visible;
            Main.main.addBtn.Visibility = Visibility.Visible;

            File.Delete(SettingsManager.DeserializeJson().serverPath + "temp");
        }

        #endregion

        #region Update SaveButton

        private void AnySelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AnyChange();
        }

        private void projectNameChanged(object sender, TextChangedEventArgs e)
        {
            //AnyChange();
        }

        private void AnyChange()
        {
            if (detailsHeader.Text != "" && detailsState.SelectedItem != null && detailsKleinprojekt.SelectedItem != null && detailsSplitVertrag.SelectedItem != null && detailsHomepage.SelectedItem != null)
            {
                this.saveBtn.Source = new BitmapImage(new Uri(@"SaveBtnG.png", UriKind.Relative));
                this.saveBtn.Cursor = Cursors.Hand;
            }
            else
            {
                this.saveBtn.Source = new BitmapImage(new Uri(@"SaveBtnInactive.png", UriKind.Relative));
                this.saveBtn.Cursor = Cursors.Arrow;
            }
        }
#endregion

        #region Header Effects
        private void nameChanged(object sender, TextChangedEventArgs e)
        {
            if(detailsHeader.Text == "")
            {
                nameLabel.Content = "Name";
            }
            else
            {
                nameLabel.Content = "";
            }
            

        }

        private void numberChanged(object sender, TextChangedEventArgs e)
        {
            if (detailsNumber.Text == "")
            {
                Projektnummer.Content = "Nummer";
                Projektnummer.Visibility = Visibility.Visible;
            }
            else
            {
                Projektnummer.Content = "";
            }
        }


        #endregion

        #region SecondaryContent

        private void MainContentScroll(object sender, ScrollChangedEventArgs e)
        {

            if (MainContentScrollViewer.VerticalOffset >= 350)
            {
                showSecondary();
            }
        }

        private void showSecondary()
        {
            secondaryAddContent sc = new secondaryAddContent(edited, sourceFileNameOnEdit);
            Main.main.MainContentGrid.Children.Add(sc);
            MainContentScrollViewer.ScrollToTop();
            MainContentScrollViewer.VerticalScrollBarVisibility = ScrollBarVisibility.Hidden;
            MainContentScrollViewer.IsEnabled = false;
        }
        #endregion

        #region ProjektnummerAbgleich

        private void detailsNumberTextChanged(object sender, TextChangedEventArgs e)
        {

            foreach(string file in Directory.GetFiles(SettingsManager.DeserializeJson().serverPath, "*.json"))
            {
                string filename = file.Remove(0, 11);
                if(ProjectManager.DeserializeJson(filename).projectNumber == detailsNumber.Text && detailsNumber.Text != "" && sourceFileNameOnEdit != filename)
                {
                    numberErrorLabel.Visibility = Visibility.Visible;
                    break;
                }
                else
                {
                    numberErrorLabel.Visibility = Visibility.Hidden;
                }
            }
        }
        #endregion

        #region Sonstiges
        private void scrollDown(object sender, RoutedEventArgs e)
        {
            MainContentScrollViewer.ScrollToBottom();
        }

        private void browseFileClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "All files (*.*)|*.*";
            dialog.Multiselect = false;
            if (dialog.ShowDialog() == true)
            {
                string filepath = dialog.FileName;
                detailsBillFilename.Text = filepath;
            }
        }
        #endregion

        public void setGewDate(secondaryAddContent secondaryInstance)
        {
            List<DateTime> dates = new List<DateTime>();
            try
            {
                if(secondaryInstance.Gew1Protokoll.Text != "")
                {
                    dates.Add(Convert.ToDateTime(secondaryInstance.Gew1Protokoll.Text));
                }

                if (secondaryInstance.Gew2Protokoll.Text != "")
                {
                    dates.Add(Convert.ToDateTime(secondaryInstance.Gew2Protokoll.Text));
                }


                if (secondaryInstance.Gew3Protokoll.Text != "")
                {
                    dates.Add(Convert.ToDateTime(secondaryInstance.Gew3Protokoll.Text));
                }

                if (secondaryInstance.Gew4Protokoll.Text != "")
                {
                    dates.Add(Convert.ToDateTime(secondaryInstance.Gew4Protokoll.Text));
                }

                if (secondaryInstance.Gew5Protokoll.Text != "")
                {
                    dates.Add(Convert.ToDateTime(secondaryInstance.Gew5Protokoll.Text));
                }

            }
            catch
            {

            }

            dates.Sort((x, y) => DateTime.Compare(x.Date, y.Date));

            try
            {
                dates.RemoveRange(0, dates.Count() - 1);

                string highestDateTemp = dates[0].Date.ToString();
                string highestDate = highestDateTemp.Substring(0,highestDateTemp.Length - 9);
                gewaehrleistungsEndeDatum = highestDate;
            }
            catch
            {

            }

            gewaehrleistungEnde.Text = gewaehrleistungsEndeDatum;

            
        }

    }
}
