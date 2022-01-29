using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Windows.Navigation;
using System.Windows.Controls;

namespace ronas
{
    class SettingsManager
    {
        public bool setupDone { get; set; }
        public string prodKey { get; set; }
        public bool local { get; set; }
        public bool firstInstance { get; set; }
        public bool templatePageOpened { get; set; }
        public bool mainOpened { get; set; }
        public string serverPath { get; set; }
        public bool notificationEnabled { get; set; }
        public bool lastSortedByDate { get; set; }
        public bool showOldProjects { get; set; }
        public string baseProjectNumber { get; set; }

        public static SettingsManager DeserializeJson()
        {
            string json = File.ReadAllText(@"./Settings.json");
            SettingsManager settings = JsonConvert.DeserializeObject<SettingsManager>(json);
            return settings;
        }

        public static void SerializeJson(bool setSetupDone, string setProdKey, bool setLocal, bool setFirstInstance, bool setTemplatePageOpened, bool setMainOpened , string setServerPath, bool setNotificationEnabled, bool setLastSortedByDate, bool setShowOldProjects, string setBaseProjectNumber)
        {
            SettingsManager settings = new SettingsManager
            {
                setupDone = setSetupDone,
                prodKey = setProdKey,
                local = setLocal,
                firstInstance = setFirstInstance,
                templatePageOpened = setTemplatePageOpened,
                serverPath = setServerPath,
                mainOpened = setMainOpened,
                notificationEnabled = setNotificationEnabled,
                lastSortedByDate = setLastSortedByDate,
                showOldProjects = setShowOldProjects,
                baseProjectNumber = setBaseProjectNumber,

            };
            string json = JsonConvert.SerializeObject(settings, Formatting.Indented);
            File.WriteAllText(@"./Settings.json", json);
        }

    }
}
