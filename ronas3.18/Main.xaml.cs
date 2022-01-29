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
    /// Interaktionslogik für Page1.xaml
    /// </summary>
    public partial class Main : Page
    {
        public int currentObj = 0;
        public bool showingNoti = false;
        public bool startupFinished = false;
        public bool sortEven = false;
        public string activeProject = "";
        public static Main main;
        public List<Button> buttonList = new List<Button>();
        public Dictionary<string, Button> buttonRegister = new Dictionary<string, Button>();

        public Main()
        {
            InitializeComponent();

            if(File.Exists(SettingsManager.DeserializeJson().serverPath + "temp"))
            {
                File.Delete(SettingsManager.DeserializeJson().serverPath + "temp");
            }

            generateAllButtons(SettingsManager.DeserializeJson().lastSortedByDate, SettingsManager.DeserializeJson().showOldProjects);

            if (!SettingsManager.DeserializeJson().setupDone)
            {
                SettingsManager.SerializeJson(true, SettingsManager.DeserializeJson().prodKey, SettingsManager.DeserializeJson().local, SettingsManager.DeserializeJson().firstInstance, SettingsManager.DeserializeJson().templatePageOpened, SettingsManager.DeserializeJson().mainOpened , SettingsManager.DeserializeJson().serverPath, SettingsManager.DeserializeJson().notificationEnabled, SettingsManager.DeserializeJson().lastSortedByDate, SettingsManager.DeserializeJson().showOldProjects, SettingsManager.DeserializeJson().baseProjectNumber);

            }

            if (SettingsManager.DeserializeJson().notificationEnabled)
            {
                dateAlerts();
            }

            if (!SettingsManager.DeserializeJson().mainOpened)
            {
                tutorial();
                SettingsManager.SerializeJson(SettingsManager.DeserializeJson().setupDone, SettingsManager.DeserializeJson().prodKey, SettingsManager.DeserializeJson().local, SettingsManager.DeserializeJson().firstInstance, SettingsManager.DeserializeJson().templatePageOpened, true, SettingsManager.DeserializeJson().serverPath, SettingsManager.DeserializeJson().notificationEnabled, SettingsManager.DeserializeJson().lastSortedByDate, SettingsManager.DeserializeJson().showOldProjects, SettingsManager.DeserializeJson().baseProjectNumber);
            }

            if (!SettingsManager.DeserializeJson().lastSortedByDate)
            {
                SortBtn.Source = new BitmapImage(new Uri(@"sortAToZ.png", UriKind.Relative));
            }
            main = this;

        }

        #region Tutorial

        private void tutorial()
        {
            TutorialGrid.Visibility = Visibility.Visible;
            foreach( Grid e in GridArray())
            {
                e.Visibility = Visibility.Hidden;
            }
            GridArray()[currentObj].Visibility = Visibility.Visible;
        }

        private void DetectClick(object sender, MouseButtonEventArgs e)
        {
            if(currentObj < GridArray().Length - 1)
            {
                ++currentObj;
                GridArray()[currentObj - 1].Visibility = Visibility.Hidden;
                GridArray()[currentObj].Visibility = Visibility.Visible;

            }
            else
            {
                TutorialGrid.Visibility = Visibility.Hidden;
            }
        }

        public Grid[] GridArray()
        {
            Grid[] GridArray = { projektlisteTut, SucheTut, hinzuTut };
            return GridArray;
        }

        #endregion

        #region Alerts
        private void dateAlerts()
        {
            //AlertStackPanel ist das Panel in dem die Alerts unten im Bild sind. AlertScrollViewer ist der Scrollviewer dieses Panels
            //alertsClearPanel ist das Panel in dem der X-Button (alerts Löschen) ist.

            int numOfProjects = Directory.GetFiles(SettingsManager.DeserializeJson().serverPath, "*", SearchOption.AllDirectories).Length; //Zählt die Anzahl der Projekte

            DirectoryInfo di = new DirectoryInfo(SettingsManager.DeserializeJson().serverPath); //Dateipfad des Projekteordners
            for (int i = 0; i < numOfProjects; i++) //Wiederholt die Erstellung der Knöpfe für die Anzahl der gespeicherten Projekte
            {
                FileInfo fi = di.GetFiles()[i];
                string filenamesClean = fi.ToString().Substring(0, fi.ToString().Length - 5);
                try
                {
                    DateTime Date = Convert.ToDateTime(ProjectManager.DeserializeJson(fi.ToString()).gewaerleistungEnde);
                    TimeSpan currentDif = Date - DateTime.Today;

                    if (DateTime.Today.AddDays(30) > Date  && DateTime.Today < Date)
                    {
                        Button alertButton = new Button();
                        string underlyingButtonName = fi.ToString().Substring(0, fi.ToString().Length - 5);
                        alertButton.Foreground = new SolidColorBrush(Colors.White);
                        alertButton.Background = new SolidColorBrush(Color.FromRgb(238, 95, 62));
                        alertButton.Content = filenamesClean + " läuft in " + currentDif.TotalDays + " Tagen aus";
                        alertButton.Height = 35;
                        alertButton.Width = 1200;
                        alertButton.Style = Resources["alertButtons"] as Style;
                        Button underlyingButton = buttonRegister[underlyingButtonName];
                        alertButton.Click += (ss, ee) => { MainContent uc = new MainContent(fi.ToString()); MainContentGrid.Children.Add(uc); buttonClickEffect(underlyingButton); };
                        alertButton.BorderThickness = new Thickness(0);
                        alertButton.MouseEnter += (ss, ee) => { alertButton.Background = new SolidColorBrush(Colors.Red); };
                        alertButton.MouseLeave += (ss, ee) => { alertButton.Background = new SolidColorBrush(Color.FromRgb(238, 95, 62)); };
                        alertStackPanel.Children.Add(alertButton);
                        
                        foreach(KeyValuePair<string, Button> kvp in buttonRegister)
                        {
                            Console.WriteLine(kvp.Key, kvp.Value);
                        }
                    }
                }
                catch
                {
                    Console.WriteLine("Exception");
                }
            }

            if (alertStackPanel.Children.Count < 3) //Der Scrollviewer ist maximal 3 Btns hoch. 
            {
                alertClearPanel.Margin = new Thickness(0, 0, 0, alertStackPanel.Children.Count * 35);
            }
            else
            {
                alertClearPanel.Margin = new Thickness(0, 0, 0, 105);
            }

            if (alertStackPanel.Children.Count > 3)
            {
                ScrollWinAlerts.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
            }

            if (alertStackPanel.Children.Count >= 1)
            {
                Button cancelButton = new Button();
                cancelButton.Click += (ss, ee) => { alertStackPanel.Children.Clear(); alertScrollbarRect.Visibility = Visibility.Hidden; alertClearPanel.Children.Clear();  SettingsManager.SerializeJson(SettingsManager.DeserializeJson().setupDone, SettingsManager.DeserializeJson().prodKey, SettingsManager.DeserializeJson().local, SettingsManager.DeserializeJson().firstInstance, SettingsManager.DeserializeJson().templatePageOpened, SettingsManager.DeserializeJson().mainOpened, SettingsManager.DeserializeJson().serverPath, false, SettingsManager.DeserializeJson().lastSortedByDate, SettingsManager.DeserializeJson().showOldProjects, SettingsManager.DeserializeJson().baseProjectNumber); };
                cancelButton.Height = 30;
                cancelButton.Width = 30;
                cancelButton.Content = "X";
                cancelButton.Cursor = Cursors.Hand;
                cancelButton.FontWeight = FontWeights.Bold;
                cancelButton.BorderThickness = new Thickness(0);
                cancelButton.ToolTip = "Benachrichtigungen löschen";
                cancelButton.HorizontalAlignment = HorizontalAlignment.Right;
                cancelButton.Background = new SolidColorBrush(Colors.Transparent);
                cancelButton.Foreground = new SolidColorBrush(Colors.White);
                cancelButton.Style = Resources["alertButtons"] as Style;
                cancelButton.MouseEnter += (ss, ee) => { cancelButton.FontSize = cancelButton.FontSize + 5; };
                cancelButton.MouseLeave += (ss, ee) => { cancelButton.FontSize = cancelButton.FontSize + -5;  };
                alertClearPanel.Children.Add(cancelButton);
                alertScrollbarRect.Visibility = Visibility.Visible;
                if(alertStackPanel.Children.Count <= 3)
                {
                    alertScrollbarRect.Height = alertStackPanel.Children.Count * 30;
                }
                else
                {
                    alertScrollbarRect.Height = 100;
                }
                

            }



        }

        #endregion

        #region AllButtonCreation

        public void generateAllButtons(bool sortByDate, bool showOldProjects)
        {

            bool activeIsOld = false;
            main = this;
            string[,] projects = new string[Directory.GetFiles(SettingsManager.DeserializeJson().serverPath, "*", SearchOption.AllDirectories).Length, 2];
            List<DateTime> dates = new List<DateTime>();
            Dictionary<DateTime, string> projectsDic = new Dictionary<DateTime, string>();

            foreach (string file in Directory.GetFiles(SettingsManager.DeserializeJson().serverPath, "*.json"))
            {
                int i = 0;
                while (dates.Contains(Convert.ToDateTime(ProjectManager.DeserializeJson(System.IO.Path.GetFileName(file)).gewaerleistungEnde).AddSeconds(i)))
                {
                    i++;
                }
                dates.Add(Convert.ToDateTime(ProjectManager.DeserializeJson(System.IO.Path.GetFileName(file)).gewaerleistungEnde).AddSeconds(i));


                projectsDic.Add(Convert.ToDateTime(ProjectManager.DeserializeJson(System.IO.Path.GetFileName(file)).gewaerleistungEnde).AddSeconds(i), ProjectManager.DeserializeJson(System.IO.Path.GetFileName(file)).projectName);
            }

            if (sortByDate)
            {
                dates.Sort((x, y) => DateTime.Compare(x.Date, y.Date));
            }


            for (int e = 0; e < dates.Count; e++)
            {
                projects[e, 0] = projectsDic[dates[e]];
                projects[e, 1] = Convert.ToString(dates[e]);
            }


            int numOfProjects = projects.GetLength(0);
            for (int i = 0; i < numOfProjects; i++) //Wiederholt die Erstellung der Knöpfe für die Anzahl der gespeicherten Projekte
            {
                string filenames = projects[i, 0] + ".json";
                string filesnamesClean = filenames.Remove(filenames.Length - 5, 5);
                string buttonnames = filesnamesClean.Replace(" ", string.Empty); //Bereinigt den Dateinamen von Leerzeichen
                Button DynamicButton = new Button();
                DynamicButton.Content = filesnamesClean;
                DynamicButton.Name = buttonnames;
                DynamicButton.Background = new SolidColorBrush(Colors.Transparent);
                DynamicButton.Style = Resources["ButtonVorlage"] as Style;

                Console.WriteLine("Adding: ... " , buttonnames, DynamicButton);
                if (!buttonRegister.ContainsKey(buttonnames))
                {
                    buttonRegister.Add(buttonnames, DynamicButton);
                }



                try
                {
                    DateTime Date = Convert.ToDateTime(projects[i, 1]); //Speichert das Gewährleistungsende des jeweiligen Projekts
                    if (DateTime.Today < Date)
                    {
                        DynamicButton.Foreground = new SolidColorBrush(Colors.White);
                    }
                    else
                    {
                        DynamicButton.Foreground = new SolidColorBrush(Colors.IndianRed);
                        if (!SettingsManager.DeserializeJson().showOldProjects)
                        {
                            activeIsOld = true;
                        }
                        
                    }
                }
                catch
                {
                    DynamicButton.Foreground = new SolidColorBrush(Colors.White);
                }
                DynamicButton.Height = 60;
                DynamicButton.Width = 300;
                DynamicButton.BorderBrush = new SolidColorBrush(Colors.Transparent);
                DynamicButton.FontWeight = FontWeights.Bold;
                DynamicButton.Click += (ss, ee) => { projectButtonClicked(filenames, DynamicButton); };

                if (!activeIsOld)
                {
                    ListPanel.Children.Add(DynamicButton); //ListPanel ist das StackPanel im Scrollviewer
                }

                activeIsOld = false;
            }

        }

        private void projectButtonClicked(string filenames, Button DynamicButton)
        {
            MainContent uc = new MainContent(filenames);
            SettingsBtn.Visibility = Visibility.Visible;
            addBtn.Visibility = Visibility.Visible;
            MainContentGrid.Children.Add(uc);
            editBtn.Visibility = Visibility.Visible;
            delButton.Visibility = Visibility.Visible;
            activeProject = filenames;
            buttonClickEffect(DynamicButton);
        }

#endregion

        #region MenuButtons
        private void addClick(object sender, RoutedEventArgs e)
        {
            MainContentGrid.Children.Clear();
            addControl addPage = new addControl(false, "");
            MainContentGrid.Children.Add(addPage);
            addBtn.Visibility = Visibility.Collapsed;
            editBtn.Visibility = Visibility.Collapsed;
            delButton.Visibility = Visibility.Collapsed;
        }

        private void settingsClick(object sender, RoutedEventArgs e)
        {
            settings page = new settings();
            NavigationService.Navigate(page);

        }

        private void deleteClick(object sender, MouseButtonEventArgs e)
        {
            deleteBox db = new deleteBox();
            Main.main.MainMessageboxGrid.Children.Add(db);

            MainMessageboxGrid.Visibility = Visibility.Visible;
        }

        private void editClick(object sender, MouseButtonEventArgs e)
        {
            MainContentGrid.Children.Clear();
            addControl addPage = new addControl(true, activeProject);
            MainContentGrid.Children.Add(addPage);
            //saveBtn.Visibility = Visibility.Visible;
            editBtn.Visibility = Visibility.Collapsed;
            addBtn.Visibility = Visibility.Collapsed;
            SettingsBtn.Visibility = Visibility.Collapsed;
        }

        private void saveClick(object sender, MouseButtonEventArgs e)
        {
            MainContentGrid.Children.Clear();
            addBtn.Visibility = Visibility.Visible;
            SettingsBtn.Visibility = Visibility.Visible;

        }

        private void searchClick(object sender, RoutedEventArgs e)
        {
            SearchEntry.Focus();
        }

        private void searchBtnCloseClick(object sender, RoutedEventArgs e)
        {
            if (SearchEntry.Text != "")
            {
                SearchEntry.Text = "";
            }
        }

        #endregion

        #region Search
        private void searchChanged(object sender, TextChangedEventArgs e)
        {
            ListPanel.Children.Clear();
            int numOfProjects = Directory.GetFiles(SettingsManager.DeserializeJson().serverPath).Length; //Zählt die Anzahl der Projekte
            DirectoryInfo di = new DirectoryInfo(SettingsManager.DeserializeJson().serverPath); //Dateipfad des Projekteordners
            string searchword = SearchEntry.Text.ToLower();
            if (searchword != "")
            {
                for (int i = 0; i < numOfProjects; i++)
                {
                    FileInfo fi = di.GetFiles()[i]; // fi ist der name des aktuellen Dateiennamens im Directory "di"
                    string filenamesClean = fi.ToString().Substring(0, fi.ToString().Length - 5); //Holt den aktuellen Dateinamen und bereinigt das .json
                    string projectNum = ProjectManager.DeserializeJson(fi.ToString()).projectNumber; //Holt die Projektnummer des aktuellen Projektes
                    DateTime Date = Convert.ToDateTime(ProjectManager.DeserializeJson(fi.ToString()).gewaerleistungEnde); //Speichert das Gewährleistungsende des jeweiligen Projekts

                    if (!SettingsManager.DeserializeJson().showOldProjects)
                    {
                        if ((filenamesClean.ToLower().Contains(searchword) || projectNum.Contains(searchword)) && DateTime.Today < Date) //Entweder ProjektName oder Nummer sind enthalten
                        {
                            string filenames = fi.ToString();
                            string buttonnames = filenamesClean.Replace(" ", string.Empty); //Bereinigt den Dateinamen von Leerzeichen
                            Button DynamicButton = new Button();
                            DynamicButton.Content = filenamesClean;
                            DynamicButton.Name = buttonnames;
                            DynamicButton.Foreground = new SolidColorBrush(Colors.White);
                            DynamicButton.Background = new SolidColorBrush(Colors.Transparent);
                            DynamicButton.Height = 60;
                            DynamicButton.Width = 300;
                            DynamicButton.BorderBrush = new SolidColorBrush(Colors.Transparent);
                            DynamicButton.FontWeight = FontWeights.Bold;
                            DynamicButton.Style = Resources["ButtonVorlage"] as Style;
                            //DynamicButton.Click += (ss, ee) => { projectDetails page = new projectDetails(filenames); NavigationService.Navigate(page); };
                            DynamicButton.Click += (ss, ee) => { MainContent uc = new MainContent(filenames); MainContentGrid.Children.Add(uc); editBtn.Visibility = Visibility.Visible; delButton.Visibility = Visibility.Visible; activeProject = filenames; buttonClickEffect(DynamicButton); };
                            try
                            {
                                string DateStr = ProjectManager.DeserializeJson(filenames).gewaerleistungEnde;

                                if (DateTime.Today < Date)
                                {
                                    DynamicButton.Foreground = new SolidColorBrush(Colors.White);
                                }
                                else
                                {
                                    DynamicButton.Foreground = new SolidColorBrush(Colors.IndianRed);
                                }
                            }
                            catch
                            {
                                DynamicButton.Foreground = new SolidColorBrush(Colors.White);
                            }
                            ListPanel.Children.Add(DynamicButton); //ListPanel ist das StackPanel im Scrollviewer
                        }
                    }
                    else
                    {
                        if (filenamesClean.ToLower().Contains(searchword) || projectNum.Contains(searchword)) //Entweder ProjektName oder Nummer sind enthalten
                        {
                            string filenames = fi.ToString();
                            string buttonnames = filenamesClean.Replace(" ", string.Empty); //Bereinigt den Dateinamen von Leerzeichen
                            Button DynamicButton = new Button();
                            DynamicButton.Content = filenamesClean;
                            DynamicButton.Name = buttonnames;
                            DynamicButton.Foreground = new SolidColorBrush(Colors.White);
                            DynamicButton.Background = new SolidColorBrush(Colors.Transparent);
                            DynamicButton.Height = 60;
                            DynamicButton.Width = 250;
                            DynamicButton.BorderBrush = new SolidColorBrush(Colors.Transparent);
                            DynamicButton.FontWeight = FontWeights.Bold;
                            //DynamicButton.Click += (ss, ee) => { projectDetails page = new projectDetails(filenames); NavigationService.Navigate(page); };
                            DynamicButton.Click += (ss, ee) => { MainContent uc = new MainContent(filenames); MainContentGrid.Children.Add(uc); editBtn.Visibility = Visibility.Visible; delButton.Visibility = Visibility.Visible; activeProject = filenames; };
                            try
                            {
                                string DateStr = ProjectManager.DeserializeJson(filenames).gewaerleistungEnde;

                                if (DateTime.Today < Date)
                                {
                                    DynamicButton.Foreground = new SolidColorBrush(Colors.White);
                                }
                                else
                                {
                                    DynamicButton.Foreground = new SolidColorBrush(Colors.IndianRed);
                                }
                            }
                            catch
                            {
                                DynamicButton.Foreground = new SolidColorBrush(Colors.White);
                            }
                            ListPanel.Children.Add(DynamicButton); //ListPanel ist das StackPanel im Scrollviewer
                        }
                    }
                }
            }
            else
            {
                generateAllButtons(SettingsManager.DeserializeJson().lastSortedByDate, SettingsManager.DeserializeJson().showOldProjects);
            }
        }
        #endregion

        #region Sortieren
        private void sortierenNach(object sender, SelectionChangedEventArgs e)
        {
            int numOfProjects = Directory.GetFiles("./Projekte/", "*", SearchOption.AllDirectories).Length; //Zählt die Anzahl der Projekte
            DirectoryInfo di = new DirectoryInfo("./Projekte/"); //Dateipfad des Projekteordners
            var unsortDict = new Dictionary<string, int>();
            var sortList = new List<int>();
            for (int i = 0; i < numOfProjects; i++)
            {
                FileInfo fi = di.GetFiles()[i];
                string currentfilename = fi.ToString();
                int endDate = Convert.ToInt32(ProjectManager.DeserializeJson(currentfilename).gewaerleistungEnde);
                unsortDict.Add(currentfilename, endDate);
            }

            for (int i = 0; i < numOfProjects; i++)
            {

                sortList.Add(unsortDict.Values.Min());
                unsortDict.Remove("10");
            }


        }

        #endregion

        #region Notification Achtung! Aktuell nicht im Programm vorhanden
        /*private void NotificationClick(object sender, MouseButtonEventArgs e)
        {
            showingNoti = !showingNoti;
            if (showingNoti)
            {
                NotiPanel.IsEnabled = true;
                UserControl noti = new Notifications();
                noti.Visibility = Visibility.Visible;
                NotiPanel.Children.Add(noti);

            }
            else
            {
                NotiPanel.Children.Clear();
            }
        }*/

        public void notificationProjectClick(string filename)
        {
            MainContent uc = new MainContent(filename);
            MainContentGrid.Children.Add(uc);
            //projectDetails page = new projectDetails(filename);
            //NavigationService.Navigate(page);
        }
        #endregion

        #region Effekte
        private void ScrollWinScrolled(object sender, ScrollChangedEventArgs e)
        {
            if(ScrollWin.VerticalOffset >= 75)
            {
                Head.Visibility = Visibility.Hidden;
                ScrollHead.Visibility = Visibility.Visible;
            }
            else
            {
                Head.Visibility = Visibility.Visible;
                ScrollHead.Visibility = Visibility.Hidden;
            }
        }

        private void sortClick(object sender, MouseButtonEventArgs e)
        {
            if (!SettingsManager.DeserializeJson().lastSortedByDate)
            {
                SettingsManager.SerializeJson(SettingsManager.DeserializeJson().setupDone, SettingsManager.DeserializeJson().prodKey, SettingsManager.DeserializeJson().local, SettingsManager.DeserializeJson().firstInstance, SettingsManager.DeserializeJson().templatePageOpened, SettingsManager.DeserializeJson().mainOpened, SettingsManager.DeserializeJson().serverPath, SettingsManager.DeserializeJson().notificationEnabled, true, SettingsManager.DeserializeJson().showOldProjects, SettingsManager.DeserializeJson().baseProjectNumber);
                ListPanel.Children.Clear();
                generateAllButtons(true, SettingsManager.DeserializeJson().showOldProjects);
                SortBtn.Source = new BitmapImage(new Uri(@"sortDate.png", UriKind.Relative));
            }
            else
            {
                SettingsManager.SerializeJson(SettingsManager.DeserializeJson().setupDone, SettingsManager.DeserializeJson().prodKey, SettingsManager.DeserializeJson().local, SettingsManager.DeserializeJson().firstInstance, SettingsManager.DeserializeJson().templatePageOpened, SettingsManager.DeserializeJson().mainOpened, SettingsManager.DeserializeJson().serverPath, SettingsManager.DeserializeJson().notificationEnabled, false, SettingsManager.DeserializeJson().showOldProjects, SettingsManager.DeserializeJson().baseProjectNumber);
                ListPanel.Children.Clear();
                generateAllButtons(false, SettingsManager.DeserializeJson().showOldProjects);
                SortBtn.Source = new BitmapImage(new Uri(@"sortAToZ.png", UriKind.Relative));
            }

        }

        private void buttonClickEffect(Button btn)
        {
            if (!buttonList.Contains(btn))
            {
                buttonList.Add(btn);
            }


            try
            {
                if (buttonList.ElementAt(0) != buttonList.ElementAt(1))
                {
                    buttonList.ElementAt(0).Background = new SolidColorBrush(Colors.Transparent); //ElementAt(0) ist immer der vorherig geclickte Button
                    buttonList.RemoveAt(0);
                }
            }
            catch
            {

            }

            btn.Background = new SolidColorBrush(Color.FromRgb(33, 33, 33));
        }


        #endregion

        #region Delete
        public void deleteProject()
        {
            System.IO.File.Delete(SettingsManager.DeserializeJson().serverPath + activeProject);
            //Refresh//
            ListPanel.Children.Clear();
            generateAllButtons(SettingsManager.DeserializeJson().lastSortedByDate, SettingsManager.DeserializeJson().showOldProjects);
            //-----//

            MainContentGrid.Children.Clear();
            editBtn.Visibility = Visibility.Hidden;
            delButton.Visibility = Visibility.Hidden;
            MainMessageboxGrid.Visibility = Visibility.Collapsed;
        }
        #endregion


    }
}
