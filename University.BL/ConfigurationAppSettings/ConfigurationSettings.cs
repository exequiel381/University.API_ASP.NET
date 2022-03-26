using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.BL.ConfigurationAppSettings
{
    public static class ConfigurationSettings
    {
        /// <summary>
        /// AGREGAR LAS LOS ELEMENTOS EN EL APP.CONFIG PARA TENERLOS VISTOS
        /// </summary>
        /// <param name="key"> CLAVE LOS LOS ELEMENTOS EN APP.CONFIG</param>
        /// <returns></returns>
        public static string GetValue(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
        public static void AddValue(string key,string value)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings.Add(key, value);
            config.Save(ConfigurationSaveMode.Modified);
        }
        public static void ModifyValue(string key,string value)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings[key].Value = value;
            config.Save(ConfigurationSaveMode.Modified);
        }


    }
}
