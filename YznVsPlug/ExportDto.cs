using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using EnvDTE;
using EnvDTE80;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using YznVsPlug.Models;
using YznVsPlug.Utils;
using Task = System.Threading.Tasks.Task;

namespace YznVsPlug
{
    /// <summary>
    /// Command handler
    /// </summary>
    internal sealed class ExportDto
    {
        /// <summary>
        /// Command ID.
        /// </summary>
        public const int CommandId = 4130;

        /// <summary>
        /// Command menu group (command set GUID).
        /// </summary>
        public static readonly Guid CommandSet = new Guid("be95096d-19d1-4ea0-b5fc-6a1927f49de6");

        /// <summary>
        /// VS Package that provides this command, not null.
        /// </summary>
        private readonly AsyncPackage package;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExportDto"/> class.
        /// Adds our command handlers for menu (commands must exist in the command table file)
        /// </summary>
        /// <param name="package">Owner package, not null.</param>
        /// <param name="commandService">Command service to add command to, not null.</param>
        private ExportDto(AsyncPackage package, OleMenuCommandService commandService)
        {
            this.package = package ?? throw new ArgumentNullException(nameof(package));
            commandService = commandService ?? throw new ArgumentNullException(nameof(commandService));

            var menuCommandID = new CommandID(CommandSet, CommandId);
            var menuItem = new MenuCommand(this.Execute, menuCommandID);
            commandService.AddCommand(menuItem);
        }

        /// <summary>
        /// Gets the instance of the command.
        /// </summary>
        public static ExportDto Instance
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the service provider from the owner package.
        /// </summary>
        private Microsoft.VisualStudio.Shell.IAsyncServiceProvider ServiceProvider
        {
            get
            {
                return this.package;
            }
        }

        /// <summary>
        /// Initializes the singleton instance of the command.
        /// </summary>
        /// <param name="package">Owner package, not null.</param>
        public static async Task InitializeAsync(AsyncPackage package)
        {
            // Switch to the main thread - the call to AddCommand in ExportDto's constructor requires
            // the UI thread.
            await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync(package.DisposalToken);

            OleMenuCommandService commandService = await package.GetServiceAsync(typeof(IMenuCommandService)) as OleMenuCommandService;
            Instance = new ExportDto(package, commandService);
        }

        /// <summary>
        /// This function is the callback used to execute the command when the menu item is clicked.
        /// See the constructor to see how the menu item is associated with this function using
        /// OleMenuCommandService service and MenuCommand class.
        /// </summary>
        /// <param name="sender">Event sender.</param>
        /// <param name="e">Event args.</param>
        private void Execute(object sender, EventArgs e)
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            var wikiExportString = System.Windows.Forms.Clipboard.GetText();
            if (string.IsNullOrWhiteSpace(wikiExportString))
            {
                System.Windows.Forms.MessageBox.Show("You must set Wiki Export string to Clipboard!", "tip");
            }
            var dte = Package.GetGlobalService(typeof(DTE)) as DTE2;
            var sbOutput = new System.Text.StringBuilder();

            Dictionary<string, string> dicExport = SplitExportKeys(wikiExportString);
            var docText = GetActiveDocumentText(dte);
            var lines = GetPropertyLines(docText);
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