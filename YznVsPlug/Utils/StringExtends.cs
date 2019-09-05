using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using YznVsPlug.Models;

namespace YznVsPlug.Utils
{
    public static class StringExtends
    {
        public static Dictionary<string, object> JsonToDictionary(this string jo)
        {
            var values = JsonConvert.DeserializeObject<Dictionary<string, object>>(jo);
            var values2 = new Dictionary<string, object>();
            foreach (KeyValuePair<string, object> d in values)
            {
                // if (d.Value.GetType().FullName.Contains("Newtonsoft.Json.Linq.JObject"))
                if (d.Value is JObject)
                {
                    values2.Add(d.Key.ToFirstLettleUpcase(), JsonToDictionary(d.Value.ToString()));
                }
                else
                {
                    values2.Add(d.Key.ToFirstLettleUpcase(), d.Value);
                }
            }
            return values2;
        }

        public static string ToFirstLettleUpcase(this string s)
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                return s;
            }
            return $"{ s.Substring(0, 1).ToUpper()}{s.Substring(1)}";
        }

        public static string ReplaceLF2CrLF(this string s)
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                return s;
            }
            return Regex.Replace(s, "(?<!\r)\n", "\r\n");
        }

        public static string ToFirstLettleLcase(this string s)
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                return s;
            }
            return $"{ s.Substring(0, 1).ToLower()}{s.Substring(1)}";
        }

        public static string ToUnderLineStringcase(this string s)
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                return s;
            }
            return $"_{ s.Substring(0, 1).ToLower()}{s.Substring(1)}";
        }

        public static List<LineNoAndText> GetPropertyLines(this string txt)
        {
            var lst = new List<LineNoAndText>();
            if (string.IsNullOrWhiteSpace(txt)) return lst;
            var lines = Regex.Split(txt, "\r\n|\r|\n").ToList();
            var isClassStart = false;
            var iRow = 1;
            foreach (var line in lines)
            {
                if (line.Contains(" class ") && !Regex.IsMatch(line, "^\\s?//"))
                {
                    isClassStart = true;
                    continue;
                }

                if (isClassStart)
                {
                    if (!Regex.IsMatch(line, "(/// <[s/].*)|(\\[.*)"))
                    {
                        //不是注释行 <summary></summary> 和 Attribute行,
                        //只取///<summary里的内容行信息和属性信息
                        var li = line?.Trim();
                        if (li != null && li.Length > 3)
                        {
                            lst.Add(new LineNoAndText { No = iRow++, Txt = li });
                        }
                    }
                }
            }
            return lst;
        }
    }
}