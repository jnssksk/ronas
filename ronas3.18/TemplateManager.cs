using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace ronas
{
    class TemplateManager
    {
        

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

        public string projectLP9Date { get; set; }

        public string projectLP9Paid { get; set; }

        public string projectLP9Possible { get; set; }

        public string projectLeistungsphasen { get; set; }


        public static TemplateManager DeserializeJson()
        {
            string json = File.ReadAllText("./TemplateSettings.json");
            TemplateManager settings = JsonConvert.DeserializeObject<TemplateManager>(json);
            return settings;
        }

        public static void SerializeJson(string setProjectState, string setProjectAbbrev, string setProjectNumber, string setProjectChef, string setProjectArchitect, string setProjectFachplaner, string setProjectKleinprojekt, string setProjectGewDauer, string setProjectEngineerContract, string setProjectSplitContract, string setProjectDescription, string setProjectComments, string setProjectGewerke, string setProjectRechnungName, string setProjectRechnungDate, string setProjectPaidDate, string setProjectPaidSum, string setProjectHomepage, string setProjectReference, string setProjectLP9Date, string setProjectLP9Paid, string setProjectLP9Possible, string setProjectLeistungsphasen)
        {
            TemplateManager settings = new TemplateManager
            {
                projectState = setProjectState,
                projectAbbrev = setProjectAbbrev,
                projectNumber = setProjectNumber,
                projectChef = setProjectChef,
                projectArchitect = setProjectArchitect,
                projectFachplaner = setProjectFachplaner,
                projectKleinprojekt = setProjectKleinprojekt,
                projectGewDauer = setProjectGewDauer,
                projectEngineerContract = setProjectEngineerContract,
                projectSplitContract = setProjectSplitContract,
                projectDescription = setProjectDescription,
                projectComments = setProjectComments,
                projectGewerke = setProjectGewerke,
                projectRechnungName = setProjectRechnungName,
                projectRechnungDate = setProjectRechnungDate,
                projectPaidDate = setProjectPaidDate,
                projectPaidSum = setProjectPaidSum,
                projectHomepage = setProjectHomepage,
                projectReference = setProjectReference,
                projectLP9Date = setProjectLP9Date,
                projectLP9Paid = setProjectLP9Paid,
                projectLP9Possible = setProjectLP9Possible,
                projectLeistungsphasen = setProjectLeistungsphasen
            };
            string json = JsonConvert.SerializeObject(settings, Formatting.Indented);
            if(SettingsManager.DeserializeJson().local)
                File.WriteAllText("./TemplateSettings.json", json);
            else
                File.WriteAllText(SettingsManager.DeserializeJson().serverPath.Remove(SettingsManager.DeserializeJson().serverPath .Length - 9, 9) + "/TemplateSettings.json", json);
        }
    }
}
