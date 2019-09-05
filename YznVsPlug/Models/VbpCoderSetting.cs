using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YznVsPlug.Models
{
    public class VbpCoderSetting
    {
        public string ModelName { get; set; }
        public string CtlSubPath { get; set; }
        public string AppSubPath { get; set; }
        public string CtlUsing { get; set; }
        public string AppUsing { get; set; }
        public string ManagerUsing { get; set; }
        public string DtoUsing { get; set; }

        private static VbpCoderSetting _setting;

        public static VbpCoderSetting GetValue()
        {
            if (_setting != null) return _setting;
            var _settingFile = GetSettingFileName();
            _setting = new VbpCoderSetting();
            try
            {
                if (File.Exists(_settingFile))
                {
                    var json = File.ReadAllText(_settingFile);
                    _setting = JsonConvert.DeserializeObject<VbpCoderSetting>(json);
                }
            }
            catch { }

            return _setting;
        }

        public static string GetSettingFileName()
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                                    "AbpCoderSetting.txt");
        }

        public static void SaveSetting()
        {
            File.WriteAllText(GetSettingFileName(), JsonConvert.SerializeObject(_setting));
        }
    }
}