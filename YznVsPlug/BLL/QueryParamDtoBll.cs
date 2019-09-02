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
    public class QueryParamDtoBll

    {
        public string Execute(string txtSrc, string txtBase)
        {
            var json = txtSrc;
            if (string.IsNullOrWhiteSpace(json))
            {
                System.Windows.Forms.MessageBox.Show("You must set json string to Clipboard!", "tip");
            }
            var dic = Newtonsoft.Json.JsonConvert.DeserializeObject<List<RequestParamJson>>(json);

            var lines = txtBase.GetPropertyLines();
            var sbOutput = new StringBuilder();
            foreach (var item in dic)
            {
                item.code = item.code.ToFirstLettleUpcase();
                if (CodeProcess(sbOutput, item.code)) continue;
                var bFind = false;
                foreach (var line in lines)
                {
                    if (line.Txt.Contains($" {item.code} ") && line.Txt.EndsWith("}"))
                    {
                        //是属性定义 形如 public string code {get;set;}
                        sbOutput.AppendLine(ToNullAbleType(line.Txt));
                        bFind = true;
                    }
                }
                if (!bFind)
                {
                    sbOutput.AppendLine($@"public {item.type} {item.code}" + " { get; set;}");
                }
            }
            var result = sbOutput.ToString();
            if (!string.IsNullOrWhiteSpace(result))
            {
                System.Windows.Forms.Clipboard.SetText(sbOutput.ToString());
            }
            return result;
        }

        /// <summary>
        /// 传为Nuable表示
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        private string ToNullAbleType(string line)
        {
            var reg = "(public\\s)(\\w+)(\\s.*)";
            if (Regex.IsMatch(line, reg))
            {
                var m = Regex.Match(line, reg);
                var type = m.Groups[2].Value;
                if (type != "string" && !type.EndsWith("?"))
                {
                    return $"{m.Groups[1].Value}{type}?{m.Groups[3].Value}";
                }
            }
            return line;
        }

        private bool CodeProcess(StringBuilder sb, string key)
        {
            if (key == "Code")
            {
                sb.AppendLine(@"
        private string _code;
        public string Code { get => _code; set => _code = value?.ToUpper(); }
");
                return true;
            }
            return false;
        }
    }
}