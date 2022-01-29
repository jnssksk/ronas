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
    /// Interaktionslogik für secondaryContent.xaml
    /// </summary>
    public partial class secondaryContent : UserControl
    {
        public secondaryContent(string filename)
        {
            InitializeComponent();
            secondaryC = this;
            LoadData(filename);
        }

        #region LoadData
        private void LoadData(string filenames)
        {

            #region Gewerk1
            Gewerk1.Text = ProjectManager.DeserializeJson(filenames).gewerkName1;
            Gew1Abnahme.Content = ProjectManager.DeserializeJson(filenames).abnahmeDone1; //Weitere Seite
            Gew1AbnahmePfad.Content = ProjectManager.DeserializeJson(filenames).abnahmeDocPath1;
            Gew1Protokoll.Content = ProjectManager.DeserializeJson(filenames).abnahmeDate1;
            Gew1EingangAm.Content = ProjectManager.DeserializeJson(filenames).revisionEingangAm1;
            Gew1Ausfertigung.Content = ProjectManager.DeserializeJson(filenames).revisionAusfertigung1;
            Gew1AbgegebenAm.Content = ProjectManager.DeserializeJson(filenames).revisionEingereichtAm1;
            Gew1RevVollst.Content = ProjectManager.DeserializeJson(filenames).revisionVollstaendig1;
            Gew1ueber.Content = ProjectManager.DeserializeJson(filenames).revisionEingereichtWie1;

            #endregion

            #region Gewerk2
            Gewerk2.Text = ProjectManager.DeserializeJson(filenames).gewerkName2;
            Gew2Abnahme.Content = ProjectManager.DeserializeJson(filenames).abnahmeDone2; //Weitere Seite
            Gew2AbnahmePfad.Content = ProjectManager.DeserializeJson(filenames).abnahmeDocPath2;
            Gew2Protokoll.Content = ProjectManager.DeserializeJson(filenames).abnahmeDate2;
            Gew2EingangAm.Content = ProjectManager.DeserializeJson(filenames).revisionEingangAm2;
            Gew2Ausfertigung.Content = ProjectManager.DeserializeJson(filenames).revisionAusfertigung2;
            Gew2AbgegebenAm.Content = ProjectManager.DeserializeJson(filenames).revisionEingereichtAm2;
            Gew2RevVollst.Content = ProjectManager.DeserializeJson(filenames).revisionVollstaendig2;
            Gew2ueber.Content = ProjectManager.DeserializeJson(filenames).revisionEingereichtWie2;
            #endregion

            #region Gewerk3
            Gewerk3.Text = ProjectManager.DeserializeJson(filenames).gewerkName3;
            Gew3Abnahme.Content = ProjectManager.DeserializeJson(filenames).abnahmeDone3; //Weitere Seite
            Gew3AbnahmePfad.Content = ProjectManager.DeserializeJson(filenames).abnahmeDocPath3;
            Gew3Protokoll.Content = ProjectManager.DeserializeJson(filenames).abnahmeDate3;
            Gew3EingangAm.Content = ProjectManager.DeserializeJson(filenames).revisionEingangAm3;
            Gew3Ausfertigung.Content = ProjectManager.DeserializeJson(filenames).revisionAusfertigung3;
            Gew3AbgegebenAm.Content = ProjectManager.DeserializeJson(filenames).revisionEingereichtAm3;
            Gew3RevVollst.Content = ProjectManager.DeserializeJson(filenames).revisionVollstaendig3;
            Gew3ueber.Content = ProjectManager.DeserializeJson(filenames).revisionEingereichtWie3;
            #endregion

            #region Gewerk4
            Gewerk4.Text = ProjectManager.DeserializeJson(filenames).gewerkName4;
            Gew4Abnahme.Content = ProjectManager.DeserializeJson(filenames).abnahmeDone4; //Weitere Seite
            Gew4AbnahmePfad.Content = ProjectManager.DeserializeJson(filenames).abnahmeDocPath4;
            Gew4Protokoll.Content = ProjectManager.DeserializeJson(filenames).abnahmeDate4;
            Gew4EingangAm.Content = ProjectManager.DeserializeJson(filenames).revisionEingangAm4;
            Gew4Ausfertigung.Content = ProjectManager.DeserializeJson(filenames).revisionAusfertigung4;
            Gew4AbgegebenAm.Content = ProjectManager.DeserializeJson(filenames).revisionEingereichtAm4;
            Gew4RevVollst.Content = ProjectManager.DeserializeJson(filenames).revisionVollstaendig4;
            Gew4ueber.Content = ProjectManager.DeserializeJson(filenames).revisionEingereichtWie4;
            #endregion

            #region Gewerk5
            Gewerk5.Text = ProjectManager.DeserializeJson(filenames).gewerkName5;
            Gew5Abnahme.Content = ProjectManager.DeserializeJson(filenames).abnahmeDone5; //Weitere Seite
            Gew5AbnahmePfad.Content = ProjectManager.DeserializeJson(filenames).abnahmeDocPath5;
            Gew5Protokoll.Content = ProjectManager.DeserializeJson(filenames).abnahmeDate5;
            Gew5EingangAm.Content = ProjectManager.DeserializeJson(filenames).revisionEingangAm5;
            Gew5Ausfertigung.Content = ProjectManager.DeserializeJson(filenames).revisionAusfertigung5;
            Gew5AbgegebenAm.Content = ProjectManager.DeserializeJson(filenames).revisionEingereichtAm5;
            Gew5RevVollst.Content = ProjectManager.DeserializeJson(filenames).revisionVollstaendig5;
            Gew5ueber.Content = ProjectManager.DeserializeJson(filenames).revisionEingereichtWie5;
            #endregion

        }
        #endregion

        public static secondaryContent secondaryC;

        #region Buttons
        private void showLessClick(object sender, RoutedEventArgs e)
        {
            
            MainContent.maincontent.MainContentScrollViewer.VerticalScrollBarVisibility = ScrollBarVisibility.Visible;
            MainContent.maincontent.MainContentScrollViewer.IsEnabled = true;
   
        }
        #endregion

    }
}
