using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using YznVsPlug.Utils;
using EnvDTE80;
using EnvDTE;
using System.Text.RegularExpressions;

namespace YznVsPlug.Dlgs
{
    public partial class DlgJson2Dto : Form
    {
        private readonly string _srcFile = "";
        private readonly DTE2 _dte;

        public DlgJson2Dto(DTE2 dte)
        {
            InitializeComponent();
            _dte = dte;
            _srcFile = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Json2DtoBasSrc.txt");
        }

        private void DlgJson2Dto_Load(object sender, EventArgs e)
        {
            txtJson.Text = Clipboard.GetText();
            txtSrc.Text = getLastSrc();
        }

        private string getLastSrc()
        {
            if (File.Exists(_srcFile))
                return File.ReadAllText(_srcFile);
            else
                return "";
        }

        private void DlgJson2Dto_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (File.Exists(_srcFile)) File.Delete(_srcFile);
            File.WriteAllText(_srcFile, txtSrc.Text);
        }

        private string JsonOutPutDtoPatch(string key)
        {
            key = key?.Trim()?.ToLower();
            switch (key)
            {
                case "id":
                    return "public Guid Id { get; set; }";
                case "rowversion":
                    return "public byte[] RowVersion { get; set; }";
                case "creatorname":
                    return "public string CreatorName { get; set; }";
                case "createtime":
                    return "public DateTime? CreateTime { get; set; }";
                case "modifiername":
                    return "public string ModifierName { get; set; }";
                case "modifytime":
                    return "public DateTime? ModifyTime { get; set; }";
                case "abandonername":
                    return "public string AbandonerName { get; set; }";
                case "abandontime":
                    return "public DateTime? AbandonTime { get; set; }";
            }
            return "";
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtJson.Text))
            {
                MessageBox.Show("请先设置Json文本");
                return;
            }
            Dictionary<string, object> dic = new Dictionary<string, object>();
            try
            {
                dic = txtJson.Text.JsonToDictionary();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Json文本 无效, 请检查." + ex.Message);
            }

            var docText = txtSrc.Text;
            var lines = docText.GetPropertyLines();
            var sbOutput = new System.Text.StringBuilder();
            foreach (var key in dic.Keys)
            {
                var sFixedJsonProperty = JsonOutPutDtoPatch(key);
                if (!string.IsNullOrWhiteSpace(sFixedJsonProperty))
                {
                    sbOutput.Append(sFixedJsonProperty);
                    continue;
                }
                var bFind = false;
                foreach (var line in lines)
                {
                    if (line.Txt.Contains($" {key} ") && line.Txt.EndsWith("}"))
                    {
                        //是属性定义 形如 public string code {get;set;}
                        sbOutput.AppendLine(line.Txt);
                        bFind = true;
                    }
                }
                if (!bFind)
                {
                    sbOutput.AppendLine("// Not Found");
                    sbOutput.AppendLine($"public {dic[key].GetType().Name} {key}" + "{get;set;}");
                }
            }
            var result = sbOutput.ToString();
            if (!string.IsNullOrWhiteSpace(result))
            {
                Clipboard.SetText(sbOutput.ToString());
            }
            txtResult.Text = result;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BtnOpenModelFile_Click(object sender, EventArgs e)
        {
            Microsoft.VisualStudio.Shell.ThreadHelper.ThrowIfNotOnUIThread();

            foreach (string file in DteExtends.GetProjectFilesInSolution())
            {
                if (file.Contains(".Domain"))
                {
                    openFileDialog1.InitialDirectory = Path.GetDirectoryName(file);
                    break;
                }
            }
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtSrc.Text = File.ReadAllText(openFileDialog1.FileName);
            }
        }

        private void BtnExportExcelDto_Click(object sender, EventArgs e)
        {
            var bll = new BLL.ExportExcelDtoBll();
            txtResult.Text = bll.Execute(txtJson.Text, txtSrc.Text);
        }

        private void BtnQueryParamDto_Click(object sender, EventArgs e)
        {
            var bll = new BLL.QueryParamDtoBll();
            txtResult.Text = bll.Execute(txtJson.Text, txtSrc.Text);
        }

        private void BtnAddModel_Click(object sender, EventArgs e)
        {
            Microsoft.VisualStudio.Shell.ThreadHelper.ThrowIfNotOnUIThread();
            foreach (string file in DteExtends.GetProjectFilesInSolution())
            {
                if (file.Contains(".Domain"))
                {
                    openFileDialog1.InitialDirectory = Path.GetDirectoryName(file);
                    break;
                }
            }
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var lines = File.ReadAllLines(openFileDialog1.FileName);
                var bClassStart = false;
                var iRow = 1;
                var sb = new StringBuilder();
                sb.AppendLine(System.Environment.NewLine);
                foreach (var line in lines)
                {
                    if (!bClassStart && Regex.IsMatch(line, "\\sclass\\s"))
                    {
                        bClassStart = true;
                    }
                    if (bClassStart && iRow < lines.Length)
                    {
                        sb.AppendLine(line);
                    }
                    iRow++;
                }
                txtSrc.Text += sb.ToString();
            }
        }
    }
}