using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace DestructionEffects
{
    [KSPAddon(KSPAddon.Startup.EveryScene, false)]
    public class DESettings : MonoBehaviour
    {
        public static string settingsConfigURL = "GameData/DestructionEffects/settings.cfg";
        //=======configurable settings

        public static bool LegacyEffect = false;

        void Start()
        {
            LoadConfig();
        }

        public static void LoadConfig()
        {
            try
            {
                Debug.Log("== DestructionEffects: Loading settings.cfg ==");

                ConfigNode fileNode = ConfigNode.Load(settingsConfigURL);
                if (!fileNode.HasNode("DESettings")) return;

                ConfigNode settings = fileNode.GetNode("DESettings");

                LegacyEffect = bool.Parse(settings.GetValue("LegacyEffect"));
            }
            catch (NullReferenceException)
            {
                Debug.Log("== DestructionEffects : Failed to load settings config==");
            }
        }
    }
}
