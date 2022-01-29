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

namespace ronas
{
    /// <summary>
    /// Interaktionslogik für secondaryAddContent.xaml
    /// </summary>
    public partial class secondaryAddContent : UserControl
    {
        public secondaryAddContent(bool doEdit, string filename)
        {
            InitializeComponent();
            if (doEdit)
            {
                LoadData(filename);
            }

            secondaryC = this;
            activeFileName = filename;
            if(activeFileName == "")
            {
                if(!File.Exists(SettingsManager.DeserializeJson().serverPath + "temp"))
                {
                    File.Create(SettingsManager.DeserializeJson().serverPath + "temp");
                }
                else
                {
                    LoadData("temp");
                }
            }
        }

        public static secondaryAddContent secondaryC;
        public string activeFileName;

        #region LoadData
        private void LoadData(string filenames)
        {

            #region Gewerk1
            Gewerk1.Text = ProjectManager.DeserializeJson(filenames).gewerkName1;
            Gew1Abnahme.Text = ProjectManager.DeserializeJson(filenames).abnahmeDone1; //Weitere Seite
            Gew1AbnahmePfad.Text = ProjectManager.DeserializeJson(filenames).abnahmeDocPath1;
            Gew1Protokoll.Text = ProjectManager.DeserializeJson(filenames).abnahmeDate1;
            Gew1EingangAm.Text = ProjectManager.DeserializeJson(filenames).revisionEingangAm1;
            Gew1Ausfertigung.Text = ProjectManager.DeserializeJson(filenames).revisionAusfertigung1;
            Gew1AbgegebenAm.Text = ProjectManager.DeserializeJson(filenames).revisionEingereichtAm1;
            Gew1RevVollst.Text = ProjectManager.DeserializeJson(filenames).revisionVollstaendig1;
            Gew1ueber.Text = ProjectManager.DeserializeJson(filenames).revisionEingereichtWie1;
            #endregion

            #region Gewerk2
            Gewerk2.Text = ProjectManager.DeserializeJson(filenames).gewerkName2;
            Gew2Abnahme.Text = ProjectManager.DeserializeJson(filenames).abnahmeDone2; //Weitere Seite
            Gew2AbnahmePfad.Text = ProjectManager.DeserializeJson(filenames).abnahmeDocPath2;
            Gew2Protokoll.Text = ProjectManager.DeserializeJson(filenames).abnahmeDate2;
            Gew2EingangAm.Text = ProjectManager.DeserializeJson(filenames).revisionEingangAm2;
            Gew2Ausfertigung.Text = ProjectManager.DeserializeJson(filenames).revisionAusfertigung2;
            Gew2AbgegebenAm.Text = ProjectManager.DeserializeJson(filenames).revisionEingereichtAm2;
            Gew2RevVollst.Text = ProjectManager.DeserializeJson(filenames).revisionVollstaendig2;
            Gew2ueber.Text = ProjectManager.DeserializeJson(filenames).revisionEingereichtWie2;
            #endregion

            #region Gewerk3
            Gewerk3.Text = ProjectManager.DeserializeJson(filenames).gewerkName3;
            Gew3Abnahme.Text = ProjectManager.DeserializeJson(filenames).abnahmeDone3; //Weitere Seite
            Gew3AbnahmePfad.Text = ProjectManager.DeserializeJson(filenames).abnahmeDocPath3;
            Gew3Protokoll.Text = ProjectManager.DeserializeJson(filenames).abnahmeDate3;
            Gew3EingangAm.Text = ProjectManager.DeserializeJson(filenames).revisionEingangAm3;
            Gew3Ausfertigung.Text = ProjectManager.DeserializeJson(filenames).revisionAusfertigung3;
            Gew3AbgegebenAm.Text = ProjectManager.DeserializeJson(filenames).revisionEingereichtAm3;
            Gew3RevVollst.Text = ProjectManager.DeserializeJson(filenames).revisionVollstaendig3;
            Gew3ueber.Text = ProjectManager.DeserializeJson(filenames).revisionEingereichtWie3;
            #endregion

            #region Gewerk4
            Gewerk4.Text = ProjectManager.DeserializeJson(filenames).gewerkName4;
            Gew4Abnahme.Text = ProjectManager.DeserializeJson(filenames).abnahmeDone4; //Weitere Seite
            Gew4AbnahmePfad.Text = ProjectManager.DeserializeJson(filenames).abnahmeDocPath4;
            Gew4Protokoll.Text = ProjectManager.DeserializeJson(filenames).abnahmeDate4;
            Gew4EingangAm.Text = ProjectManager.DeserializeJson(filenames).revisionEingangAm4;
            Gew4Ausfertigung.Text = ProjectManager.DeserializeJson(filenames).revisionAusfertigung4;
            Gew4AbgegebenAm.Text = ProjectManager.DeserializeJson(filenames).revisionEingereichtAm4;
            Gew4RevVollst.Text = ProjectManager.DeserializeJson(filenames).revisionVollstaendig4;
            Gew4ueber.Text = ProjectManager.DeserializeJson(filenames).revisionEingereichtWie4;
            #endregion

            #region Gewerk5
            Gewerk5.Text = ProjectManager.DeserializeJson(filenames).gewerkName5;
            Gew5Abnahme.Text = ProjectManager.DeserializeJson(filenames).abnahmeDone5; //Weitere Seite
            Gew5AbnahmePfad.Text = ProjectManager.DeserializeJson(filenames).abnahmeDocPath5;
            Gew5Protokoll.Text = ProjectManager.DeserializeJson(filenames).abnahmeDate5;
            Gew5EingangAm.Text = ProjectManager.DeserializeJson(filenames).revisionEingangAm5;
            Gew5Ausfertigung.Text = ProjectManager.DeserializeJson(filenames).revisionAusfertigung5;
            Gew5AbgegebenAm.Text = ProjectManager.DeserializeJson(filenames).revisionEingereichtAm5;
            Gew5RevVollst.Text = ProjectManager.DeserializeJson(filenames).revisionVollstaendig5;
            Gew5ueber.Text = ProjectManager.DeserializeJson(filenames).revisionEingereichtWie5;
            #endregion

        }
        #endregion

        #region Buttons
        private void showLessClick(object sender, RoutedEventArgs e)
        {

            addControl.addcontrolVerweis.MainContentScrollViewer.VerticalScrollBarVisibility = ScrollBarVisibility.Visible;
            addControl.addcontrolVerweis.MainContentScrollViewer.IsEnabled = true;

            if (activeFileName == "")
            {
                string[] projectInfos = {
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "", 

                
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

                string filename = SettingsManager.DeserializeJson().serverPath + "temp";

                ProjectManager.SerializeJson("temp", projectInfos);
            }
        }
        #endregion

        private void GewProtDateChanged(object sender, TextChangedEventArgs e)
        {
            addControl.addcontrolVerweis.setGewDate(this);
        }
    }
}
