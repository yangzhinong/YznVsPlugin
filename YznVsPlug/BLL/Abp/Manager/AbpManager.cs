using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YznVsPlug.Models;
using YznVsPlug.Utils;

namespace YznVsPlug.BLL
{
#pragma warning disable VSTHRD010

    public partial class AbpManager
    {
        private string _subPath;
        private string _modelName;

        public AbpManager(string subPath, string modelName)
        {
            _subPath = subPath?.Trim();
            _modelName = modelName.ToFirstLettleUpcase();
        }

        public string GetServiceText(List<IAbpAppItem> items = null)
        {
            var lname = _modelName.ToFirstLettleLcase();
            var _name = _modelName.ToUnderLineStringcase();
            var name = _modelName;
            var baseClase = AbpSolutionBll.GetBaseClassName(AbpProjectType.Domain); ;
            string managerNameSpace = GetManagerNameSapce();
            var result = tpl.Replace("$name$", name)
                            .Replace("$_name$", _name)
                            .Replace("$lname$", lname)
                            .Replace("$manager.name.space$", managerNameSpace)
                            .Replace("$baseClass$", baseClase)
                            .Replace("$using$", VbpCoderSetting.GetValue().ManagerUsing)
                            //.Replace("$items$", GetServiceItemsCode(items))
                            .Replace("$root.name.space$", AbpSolutionBll.GetRootNameSpace())
                            ;
            return result;
        }

        public string GetManagerNameSapce()
        {
            var rootNameSpace = AbpSolutionBll.GetRootNameSpace();
            return string.IsNullOrWhiteSpace(_subPath) ? rootNameSpace : $"{rootNameSpace}.{_subPath}.{_modelName}s";
        }

        public string GetInterfaceText()
        {
            var lname = _modelName.ToFirstLettleLcase();
            var _name = _modelName.ToUnderLineStringcase();
            var name = _modelName;
            var baseClase = AbpSolutionBll.GetBaseClassName(AbpProjectType.Application); ;
            string managerNameSpace = GetManagerNameSapce();
            var result = tplInterface.Replace("$name$", name)
                            .Replace("$_name$", _name)
                            .Replace("$lname$", lname)
                            .Replace("$manager.name.space$", managerNameSpace)
                            .Replace("$baseClass$", baseClase)
                            //.Replace("$items$", GetInterfaceItemsCode(items))
                            .Replace("$root.name.space$", AbpSolutionBll.GetRootNameSpace())
                            ;
            return result;
        }

        public void InsertIntoSolution()
        {
            var name = _modelName.ToFirstLettleUpcase();
            var projectPath = AbpSolutionBll.GetProjectPath(AbpProjectType.Domain);
            var path = string.IsNullOrWhiteSpace(_subPath) ?
                                $"{name}s" :
                                $"{_subPath}\\{name}s";
            path = System.IO.Path.Combine(projectPath, path);
            System.IO.Directory.CreateDirectory(path);
            var fileService = System.IO.Path.Combine(path, $"{name}Manager.cs");
            var fileInterface = System.IO.Path.Combine(path, $"I{name}Manager.cs");
            AbpSolutionBll.InsertCodeFile(fileService, GetServiceText());
            AbpSolutionBll.InsertCodeFile(fileInterface, GetInterfaceText());
        }
    }
}