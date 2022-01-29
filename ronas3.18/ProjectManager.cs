using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace ronas
{
    class ProjectManager
    {
        public string projectName { get; set; }
        public string projectState { get; set; }
        public string projectAbbrev { get; set; }
        public string projectNumber { get; set; }
        public string projectChef { get; set; }
        public string projectArchitect { get; set; }
        public string projectFachplaner { get; set; }
        public string projectKleinprojekt { get; set; }
        public string projectGewDauer { get; set; }
        public string projectEngineerContract { get; set; }
        public string projectSplitContract { get; set; }
        public string projectDescription { get; set; }
        public string projectComments { get; set; }
        public string projectGewerke { get; set; }
        public string projectRechnungName { get; set; }
        public string projectRechnungDate { get; set; }
        public string projectPaidDate { get; set; }
        public string projectPaidSum { get; set; }
        public string projectHomepage { get; set; }
        public string projectReference { get; set; }
        public string projectLP9 { get; set; }
        public string projectLP9Date { get; set; }
        public string projectLP9Paid { get; set; }
        public string projectLP9Possible { get; set; }
        public string gewaerleistungEnde { get; set; }
        public string revisionBemerkung { get; set; }

        #region Gewerk1
        public string gewerkName1 { get; set; }
        public string abnahmeDone1 { get; set; } //5X
        public string abnahmeDate1 { get; set; } //5X (Abnahmeprotokoll vom)
        public string abnahmeDocPath1 { get; set; } //5x
        public string revisionEingangAm1 { get; set; } //5x
        public string revisionAusfertigung1 { get; set; } //5x (Anzahl der Ordner)
        public string revisionVollstaendig1 { get; set; } //5x 
        public string revisionEingereichtAm1 { get; set; } //5x (Datum)
        public string revisionEingereichtWie1 { get; set; } //5x (Post, Persoenlich, Abholung (Art und Weise))

        #endregion

        #region Gewerk2
        public string gewerkName2 { get; set; }
        public string abnahmeDone2 { get; set; } //5X
        
        public string abnahmeDate2 { get; set; } //5X (Abnahmeprotokoll vom)

        public string abnahmeDocPath2 { get; set; } //5x

        public string revisionEingangAm2 { get; set; } //5x

        public string revisionAusfertigung2 { get; set; } //5x (Anzahl der Ordner)

        public string revisionVollstaendig2 { get; set; } //5x 

        public string revisionEingereichtAm2 { get; set; } //5x (Datum)

        public string revisionEingereichtWie2 { get; set; } //5x (Post, Persoenlich, Abholung (Art und Weise))

        #endregion

        #region Gewerk3
        public string gewerkName3 { get; set; }
        public string abnahmeDone3 { get; set; } //5X

        public string abnahmeDate3 { get; set; } //5X (Abnahmeprotokoll vom)

        public string abnahmeDocPath3 { get; set; } //5x

        public string revisionEingangAm3 { get; set; } //5x

        public string revisionAusfertigung3 { get; set; } //5x (Anzahl der Ordner)

        public string revisionVollstaendig3 { get; set; } //5x 

        public string revisionEingereichtAm3 { get; set; } //5x (Datum)

        public string revisionEingereichtWie3 { get; set; } //5x (Post, Persoenlich, Abholung (Art und Weise))

        #endregion

        #region Gewerk4
        public string gewerkName4 { get; set; }
        public string abnahmeDone4 { get; set; } //5X

        public string abnahmeDate4 { get; set; } //5X (Abnahmeprotokoll vom)

        public string abnahmeDocPath4 { get; set; } //5x

        public string revisionEingangAm4 { get; set; } //5x

        public string revisionAusfertigung4 { get; set; } //5x (Anzahl der Ordner)

        public string revisionVollstaendig4 { get; set; } //5x 

        public string revisionEingereichtAm4 { get; set; } //5x (Datum)

        public string revisionEingereichtWie4 { get; set; } //5x (Post, Persoenlich, Abholung (Art und Weise))

        #endregion

        #region Gewerk5
        public string gewerkName5 { get; set; }
        public string abnahmeDone5 { get; set; } //5X

        public string abnahmeDate5 { get; set; } //5X (Abnahmeprotokoll vom)

        public string abnahmeDocPath5 { get; set; } //5x

        public string revisionEingangAm5 { get; set; } //5x

        public string revisionAusfertigung5 { get; set; } //5x (Anzahl der Ordner)

        public string revisionVollstaendig5 { get; set; } //5x 

        public string revisionEingereichtAm5 { get; set; } //5x (Datum)

        public string revisionEingereichtWie5 { get; set; } //5x (Post, Persoenlich, Abholung (Art und Weise))

        #endregion


        public static ProjectManager DeserializeJson(string filename)
        {
            string json = File.ReadAllText(SettingsManager.DeserializeJson().serverPath + filename);
            ProjectManager settings = JsonConvert.DeserializeObject<ProjectManager>(json);
            return settings;
        }

        public static void SerializeJson(string filename, string[] args)
        {
            if (!File.Exists(filename))
            {
                ProjectManager clearSettings = new ProjectManager
                {
                    projectName = "",
                    projectState = "",
                    projectAbbrev = "",
                    projectNumber = "",
                    projectChef = "",
                    projectArchitect = "",
                    projectFachplaner = "",
                    projectKleinprojekt = "",
                    projectGewDauer = "",
                    projectEngineerContract = "",
                    projectSplitContract = "",
                    projectDescription = "",
                    projectComments = "",
                    projectGewerke = "",
                    projectRechnungName = "",
                    projectRechnungDate = "",
                    projectPaidDate = "",
                    projectPaidSum = "",
                    projectHomepage = "",
                    projectReference = "",
                    projectLP9 = "",
                    projectLP9Date = "",
                    projectLP9Paid = "",
                    projectLP9Possible = "",
                    gewaerleistungEnde = "", //Datum
                    revisionBemerkung = "",

                    #region Gewerk1
                    gewerkName1 = "",
                    abnahmeDone1 = "",
                    abnahmeDate1 = "",
                    abnahmeDocPath1 = "",
                    revisionEingangAm1 = "",
                    revisionAusfertigung1 = "",
                    revisionVollstaendig1 = "",
                    revisionEingereichtAm1 = "",
                    revisionEingereichtWie1 = "",
                    #endregion

                    #region Gewerk2
                    gewerkName2 = "",
                    abnahmeDone2 = "",
                    abnahmeDate2 = "",
                    abnahmeDocPath2 = "",
                    revisionEingangAm2 = "",
                    revisionAusfertigung2 = "",
                    revisionVollstaendig2 = "",
                    revisionEingereichtAm2 = "",
                    revisionEingereichtWie2 = "",
                    #endregion

                    #region Gewerk3
                    gewerkName3 = "",
                    abnahmeDone3 = "",
                    abnahmeDate3 = "",
                    abnahmeDocPath3 = "",
                    revisionEingangAm3 = "",
                    revisionAusfertigung3 = "",
                    revisionVollstaendig3 = "",
                    revisionEingereichtAm3 = "",
                    revisionEingereichtWie3 = "",
                    #endregion

                    #region Gewerk4
                    gewerkName4 = "",
                    abnahmeDone4 = "",
                    abnahmeDate4 = "",
                    abnahmeDocPath4 = "",
                    revisionEingangAm4 = "",
                    revisionAusfertigung4 = "",
                    revisionVollstaendig4 = "",
                    revisionEingereichtAm4 = "",
                    revisionEingereichtWie4 = "",
                    #endregion

                    #region Gewerk5
                    gewerkName5 = "",
                    abnahmeDone5 = "",
                    abnahmeDate5 = "",
                    abnahmeDocPath5 = "",
                    revisionEingangAm5 = "",
                    revisionAusfertigung5 = "",
                    revisionVollstaendig5 = "",
                    revisionEingereichtAm5 = "",
                    revisionEingereichtWie5 = "",
                    #endregion

                };
                string cleanJson = JsonConvert.SerializeObject(clearSettings, Formatting.Indented);
                File.WriteAllText(SettingsManager.DeserializeJson().serverPath + filename, cleanJson);
            }

            string[] settingsArr = { DeserializeJson(filename).projectName, DeserializeJson(filename).projectState, DeserializeJson(filename).projectAbbrev, DeserializeJson(filename).projectNumber, DeserializeJson(filename).projectChef, DeserializeJson(filename).projectArchitect, DeserializeJson(filename).projectFachplaner, DeserializeJson(filename).projectKleinprojekt, DeserializeJson(filename).projectGewDauer, DeserializeJson(filename).projectEngineerContract, DeserializeJson(filename).projectSplitContract, DeserializeJson(filename).projectDescription, DeserializeJson(filename).projectComments, DeserializeJson(filename).projectGewerke, DeserializeJson(filename).projectRechnungDate, DeserializeJson(filename).projectPaidDate, DeserializeJson(filename).projectPaidSum, DeserializeJson(filename).projectHomepage, DeserializeJson(filename).projectReference, DeserializeJson(filename).projectLP9, DeserializeJson(filename).projectLP9Date, DeserializeJson(filename).projectLP9Paid, DeserializeJson(filename).projectLP9Possible, DeserializeJson(filename).gewaerleistungEnde, DeserializeJson(filename).revisionBemerkung, DeserializeJson(filename).gewerkName1, DeserializeJson(filename).abnahmeDone1, DeserializeJson(filename).abnahmeDate1, DeserializeJson(filename).abnahmeDocPath1, DeserializeJson(filename).revisionEingangAm1, DeserializeJson(filename).revisionAusfertigung1, DeserializeJson(filename).revisionVollstaendig1, DeserializeJson(filename).revisionEingereichtAm1, DeserializeJson(filename).revisionEingereichtWie1, DeserializeJson(filename).gewerkName2, DeserializeJson(filename).abnahmeDone2, DeserializeJson(filename).abnahmeDate2, DeserializeJson(filename).abnahmeDocPath2, DeserializeJson(filename).revisionEingangAm2, DeserializeJson(filename).revisionAusfertigung2, DeserializeJson(filename).revisionVollstaendig2, DeserializeJson(filename).revisionEingereichtAm2, DeserializeJson(filename).revisionEingereichtWie2, DeserializeJson(filename).gewerkName3, DeserializeJson(filename).abnahmeDone3, DeserializeJson(filename).abnahmeDate3, DeserializeJson(filename).abnahmeDocPath3, DeserializeJson(filename).revisionEingangAm3, DeserializeJson(filename).revisionAusfertigung3, DeserializeJson(filename).revisionVollstaendig3, DeserializeJson(filename).revisionEingereichtAm3, DeserializeJson(filename).revisionEingereichtWie3, DeserializeJson(filename).gewerkName4, DeserializeJson(filename).abnahmeDone4, DeserializeJson(filename).abnahmeDate4, DeserializeJson(filename).abnahmeDocPath4, DeserializeJson(filename).revisionEingangAm4, DeserializeJson(filename).revisionAusfertigung4, DeserializeJson(filename).revisionVollstaendig4, DeserializeJson(filename).revisionEingereichtAm4, DeserializeJson(filename).revisionEingereichtWie4, DeserializeJson(filename).gewerkName5, DeserializeJson(filename).abnahmeDone5, DeserializeJson(filename).abnahmeDate5, DeserializeJson(filename).abnahmeDocPath5, DeserializeJson(filename).revisionEingangAm5, DeserializeJson(filename).revisionAusfertigung5, DeserializeJson(filename).revisionVollstaendig5, DeserializeJson(filename).revisionEingereichtAm5, DeserializeJson(filename).revisionEingereichtWie5 };
            string[] temp = new string[90];
            
            int i = 0;
            foreach (string s in args)
            {
                
                if (s != "0")
                {
                    temp[i] = s;
                }
                else
                {
                    temp[i] = settingsArr[i];
                }
                i++;
            }

            ProjectManager settings = new ProjectManager
            {
                projectName = temp[0],
                projectState = temp[1],
                projectAbbrev = temp[2],
                projectNumber = temp[3],
                projectChef = temp[4],
                projectArchitect = temp[5],
                projectFachplaner = temp[6],
                projectKleinprojekt = temp[7],
                projectGewDauer = temp[8],
                projectEngineerContract = temp[9],
                projectSplitContract = temp[10],
                projectDescription = temp[11],
                projectComments = temp[12],
                projectGewerke = temp[13],
                projectRechnungName = temp[14],
                projectRechnungDate = temp[15],
                projectPaidDate = temp[16],
                projectPaidSum = temp[17],
                projectHomepage = temp[18],
                projectReference = temp[19],
                projectLP9 = temp[20],
                projectLP9Date = temp[21],
                projectLP9Paid = temp[22],
                projectLP9Possible = temp[23],
                gewaerleistungEnde = temp[24], //Datum
                revisionBemerkung = temp[25],

                #region Gewerk1
                gewerkName1 = temp[26],
                abnahmeDone1 = temp[27],
                abnahmeDate1 = temp[28],
                abnahmeDocPath1 = temp[29],
                revisionEingangAm1 = temp[30],
                revisionAusfertigung1 = temp[31],
                revisionVollstaendig1 = temp[32],
                revisionEingereichtAm1 = temp[33],
                revisionEingereichtWie1 = temp[34],
                #endregion

                #region Gewerk2
                gewerkName2 = temp[35],
                abnahmeDone2 = temp[36],
                abnahmeDate2 = temp[37],
                abnahmeDocPath2 = temp[38],
                revisionEingangAm2 = temp[39],
                revisionAusfertigung2 = temp[40],
                revisionVollstaendig2 = temp[41],
                revisionEingereichtAm2 = temp[42],
                revisionEingereichtWie2 = temp[43],
                #endregion

                #region Gewerk3
                gewerkName3 = temp[44],
                abnahmeDone3 = temp[45],
                abnahmeDate3 = temp[46],
                abnahmeDocPath3 = temp[47],
                revisionEingangAm3 = temp[48],
                revisionAusfertigung3 = temp[49],
                revisionVollstaendig3 = temp[50],
                revisionEingereichtAm3 = temp[51],
                revisionEingereichtWie3 = temp[52],
                #endregion

                #region Gewerk4
                gewerkName4 = temp[53],
                abnahmeDone4 = temp[54],
                abnahmeDate4 = temp[55],
                abnahmeDocPath4 = temp[56],
                revisionEingangAm4 = temp[57],
                revisionAusfertigung4 = temp[58],
                revisionVollstaendig4 = temp[59],
                revisionEingereichtAm4 = temp[60],
                revisionEingereichtWie4 = temp[61],
                #endregion

                #region Gewerk5
                gewerkName5 = temp[62],
                abnahmeDone5 = temp[63],
                abnahmeDate5 = temp[64],
                abnahmeDocPath5 = temp[65],
                revisionEingangAm5 = temp[66],
                revisionAusfertigung5 = temp[67],
                revisionVollstaendig5 = temp[68],
                revisionEingereichtAm5 = temp[69],
                revisionEingereichtWie5 = temp[70],
                #endregion

            };
            string json = JsonConvert.SerializeObject(settings, Formatting.Indented);
            File.WriteAllText(SettingsManager.DeserializeJson().serverPath + filename, json);
            
        }
    }
}
