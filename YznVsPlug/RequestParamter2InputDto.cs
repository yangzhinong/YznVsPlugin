using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Globalization;
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
    internal sealed class RequestParamter2InputDto
    {
        /// <summary>
        /// Command ID.
        /// </summary>
        public const int CommandId = 4131;

        /// <summary>
        /// Command menu group (command set GUID).
        /// </summary>
        public static readonly Guid CommandSet = new Guid("be95096d-19d1-4ea0-b5fc-6a1927f49de6");

        /// <summary>
        /// VS Package that provides this command, not null.
        /// </summary>
        private readonly AsyncPackage package;

        /// <summary>
        /// Initializes a new instance of the <see cref="RequestParamter2InputDto"/> class.
        /// Adds our command handlers for menu (commands must exist in the command table file)
        /// </summary>
        /// <param name="package">Owner package, not null.</param>
        /// <param name="commandService">Command service to add command to, not null.</param>
        private RequestParamter2InputDto(AsyncPackage package, OleMenuCommandService commandService)
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
        public static RequestParamter2InputDto Instance
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
            // Switch to the main thread - the call to AddCommand in RequestParamter2InputDto's constructor requires
            // the UI thread.
            await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync(package.DisposalToken);

            OleMenuCommandService commandService = await package.GetServiceAsync(typeof(IMenuCommandService)) as OleMenuCommandService;
            Instance = new RequestParamter2InputDto(package, commandService);
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
            var json = System.Windows.Forms.Clipboard.GetText();
            if (string.IsNullOrWhiteSpace(json))
            {
                System.Windows.Forms.MessageBox.Show("You must set json string to Clipboard!", "tip");
            }
            var dte = Package.GetGlobalService(typeof(DTE)) as DTE2;
            var dic = Newtonsoft.Json.JsonConvert.DeserializeObject<List<RequestParamJson>>(json);

            var docText = dte.GetActiveDocumentText();
            var lines = docText.GetPropertyLines();
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