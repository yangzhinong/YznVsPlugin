using EnvDTE80;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using YznVsPlug.Models;
using YznVsPlug.Utils;

namespace YznVsPlug.BLL
{
    public class ExportExcelDtoBll
    {
        public string Execute(string txtSrc, string txtBase)
        {
            Dictionary<string, string> dicExport = SplitExportKeys(txtSrc);
            var lines = GetPropertyLines(txtBase);
            var sbOutput = new System.Text.StringBuilder();
            foreach (var key in dicExport.Keys)
            {
                if (AuitProcess(sbOutput, key, dicExport[key])) continue;
                var isFinded = false;
                foreach (var line in lines)
                {
                    Regex reg = new Regex("///? (.*)\\b");
                    if (reg.IsMatch(line.Txt))
                    {
                        if (reg.Match(line.Txt).Groups[1].Value == key)
                        {
                            var nextLine = lines.FirstOrDefault(x => x.No == line.No + 1);
                            if (nextLine != null)
                            {
                                sbOutput.AppendLine($"[Display(Name=\"{dicExport[key]}\")]");
                                sbOutput.AppendLine(nextLine.Txt);
                                isFinded = true;
                            }
                        }
                    }
                }
                if (!isFinded)
                {
                    sbOutput.AppendLine($"//NotFound {key}({dicExport[key]}),"); //没找到继续保持原样.
                }
            }
            var result = sbOutput.ToString();
            if (!string.IsNullOrWhiteSpace(result))
            {
                System.Windows.Forms.Clipboard.SetText(result);
            }
            return result;
        }

        /// <summary>
        /// 匹配: 编号、名称（姓名）、测试,  这样的中文,取字名个关键字
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private static Dictionary<string, string> SplitExportKeys(string str)
        {
            //
            var sRegx = @"(\w+)([（(]\w+[）)])?(?=[、,，])?";
            var dicExport = new Dictionary<string, string>();
            foreach (Match match in Regex.Matches(str, sRegx, RegexOptions.Multiline))
            {
                GroupCollection groups = match.Groups;
                var key = groups[1].Value;
                var value = groups[2].Value;
                if (string.IsNullOrWhiteSpace(value))
                {
                    value = key;
                }
                else
                {
                    var sReg2 = "[（(](\\w+)[）)]";
                    value = Regex.Match(value, sReg2).Groups[1].Value;
                }
                if (!dicExport.ContainsKey(key))
                {
                    dicExport.Add(key, value);
                }
            }

            return dicExport;
        }

        private String GetActiveDocumentText(DTE2 dte)
        {
            return dte.GetActiveDocumentText();
        }

        private List<LineNoAndText> GetPropertyLines(string txt)
        {
            return txt.GetPropertyLines();
        }

        private Boolean AuitProcess(StringBuilder sb, string fieldName, string dispalyName)
        {
            var bDone = false;
            if (Regex.IsMatch(fieldName, "^创建(人|者)"))
            {
                sb.AppendLine($"[Display(Name=\"{dispalyName}\")");
                sb.AppendLine("public string CreatorName { get; set; }");
                bDone = true;
            }
            if (Regex.IsMatch(fieldName, "^创建") && Regex.IsMatch(fieldName, "日期$|时间$"))
            {
                sb.AppendLine($"[Display(Name=\"{dispalyName}\")");
                sb.AppendLine("public DateTime? CreateTime { get; set; }");
                bDone = true;
            }
            if (Regex.IsMatch(fieldName, "^修改(人|者)"))
            {
                sb.AppendLine($"[Display(Name=\"{dispalyName}\")");
                sb.AppendLine("public string ModifierName { get; set; }");
                bDone = true;
            }
            if (Regex.IsMatch(fieldName, "^修改") && Regex.IsMatch(fieldName, "日期$|时间$"))
            {
                sb.AppendLine($"[Display(Name=\"{dispalyName}\")");
                sb.AppendLine("public DateTime? ModifyTime { get; set; }");
                bDone = true;
            }
            return bDone;
        }
    }
}