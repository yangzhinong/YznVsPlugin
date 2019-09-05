using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YznVsPlug.Models;
using YznVsPlug.Utils;

#pragma warning disable VSTHRD010

namespace YznVsPlug.BLL
{
    internal class AptCtl
    {
        private const string tpl = @"
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
$usingAppService$
$usingDto$
$using$

namespace $ctl.nameSapce$ {
    /// <summary>
    ///
    /// </summary>
    /// <remarks>
    /// </remarks>
    [ApiVersion(""1.0"")]
    [Route(""/api/v{version:apiVersion}/$lname$s"")]
    public class $name$Controller : $baseClass$ {
        private readonly IStringLocalizer<$name$Controller> _localizer;
        private readonly I$name$Service $_name$Service;

        public $name$Controller(IStringLocalizer<$name$Controller> localizer,
                              I$name$Service $lname$Service) {
            _localizer = localizer;
            $_name$Service = $lname$Service;
        }
        $items$
    }
}";

        private string _rootSpaceName;
        private string _baseClase;
        private string _subPath;
        private string _modelName;

        public AptCtl(string subPath, string modelName)
        {
            _rootSpaceName = AbpSolutionBll.GetRootNameSpace();
            _baseClase = AbpSolutionBll.GetBaseClassName(AbpProjectType.WebHost); ;
            _subPath = subPath;
            _modelName = modelName;
        }

        public string GetText(List<IAbpCtlItem> ctlItems = null)
        {
            var lname = _modelName.ToFirstLettleLcase();
            var _name = _modelName.ToUnderLineStringcase();
            var name = _modelName.ToFirstLettleUpcase();
            var ctlNameSpace = string.IsNullOrWhiteSpace(_subPath) ? _rootSpaceName : $"{_rootSpaceName}.{_subPath}";
            var oAbpAppliation = new AbpApplication(_subPath, _modelName);
            var result = tpl.Replace("$name$", name)
                            .Replace("$_name$", _name)
                            .Replace("$lname$", lname)
                            .Replace("$ctl.nameSapce$", ctlNameSpace)
                            .Replace("$baseClass$", _baseClase)
                            .Replace("$usingDto$", $"using {oAbpAppliation.GetDtoNameSapce()};")
                            .Replace("$using$", VbpCoderSetting.GetValue().CtlUsing)
                            .Replace("$usingAppService$", $"using {oAbpAppliation.GetAppServiceNameSapce()};");

            result = result.Replace("$items$", Items2Code(ctlItems));

            return result;
        }

        private string Items2Code(List<IAbpCtlItem> ctlItems)
        {
            var sbItems = new System.Text.StringBuilder();
            if (ctlItems != null && ctlItems.Count > 0)
            {
                ctlItems.ForEach(x =>
                {
                    sbItems.AppendLine(x.GetText());
                });
            }
            return sbItems.ToString();
        }

        public void InsertIntoSolution(List<IAbpCtlItem> ctlItems, bool replaceFileForce = false)
        {
            var code = GetText(ctlItems);
            var projectPath = AbpSolutionBll.GetProjectPath(AbpProjectType.WebHost);
            var path = string.IsNullOrWhiteSpace(_subPath) ?
                                "Controllers" :
                                $"Controllers\\{_subPath}";
            path = System.IO.Path.Combine(projectPath, path);
            System.IO.Directory.CreateDirectory(path);
            var fileCtl = System.IO.Path.Combine(path, $"{_modelName}Controller.cs");
            AbpSolutionBll.InsertCodeFile(fileCtl, code, replaceFileForce);
        }
    }
}