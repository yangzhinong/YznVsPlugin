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
    partial class AbpApplication
    {
        private string _subPath;
        private string _modelName;

        public AbpApplication(string subPath, string modelName)
        {
            _subPath = subPath?.Trim();
            _modelName = modelName.ToFirstLettleUpcase();
        }

        public string GetServiceText(List<IAbpAppItem> items = null)
        {
            var lname = _modelName.ToFirstLettleLcase();
            var _name = _modelName.ToUnderLineStringcase();
            var name = _modelName;
            var baseClase = AbpSolutionBll.GetBaseClassName(AbpProjectType.Application); ;
            string appNameSpace = GetAppServiceNameSapce();
            var oManager = new AbpManager(_subPath, _modelName);
            var result = tpl.Replace("$name$", name)
                            .Replace("$_name$", _name)
                            .Replace("$lname$", lname)
                            .Replace("$app.nameSapce$", appNameSpace)
                            .Replace("$baseClass$", baseClase)
                            .Replace("$items$", GetServiceItemsCode(items))
                            .Replace("$root.name.space$", AbpSolutionBll.GetRootNameSpace())
                            .Replace("$usingDto$", $"using {GetDtoNameSapce()};")
                            .Replace("$using$", VbpCoderSetting.GetValue().AppUsing)
                            .Replace("$usingManager$", $"using {oManager.GetManagerNameSapce()};");

            return result;
        }

        public string GetInterfaceText(List<IAbpAppItem> items = null)
        {
            var lname = _modelName.ToFirstLettleLcase();
            var _name = _modelName.ToUnderLineStringcase();
            var name = _modelName;
            var baseClase = AbpSolutionBll.GetBaseClassName(AbpProjectType.Application); ;
            string appNameSpace = GetAppServiceNameSapce();
            var result = tplInterface.Replace("$name$", name)
                            .Replace("$_name$", _name)
                            .Replace("$lname$", lname)
                            .Replace("$app.nameSapce$", appNameSpace)
                            .Replace("$baseClass$", baseClase)
                            .Replace("$items$", GetInterfaceItemsCode(items))
                            .Replace("$using$", VbpCoderSetting.GetValue().AppUsing)
                            .Replace("$root.name.space$", AbpSolutionBll.GetRootNameSpace())
                            .Replace("$usingDto$", $"using {GetDtoNameSapce()};");
            return result;
        }

        public string GetAppServiceNameSapce()
        {
            var rootNameSpace = AbpSolutionBll.GetRootNameSpace();
            return string.IsNullOrWhiteSpace(_subPath) ? rootNameSpace : $"{rootNameSpace}.{_subPath}.{_modelName}s";
        }

        private string GetServiceItemsCode(List<IAbpAppItem> items = null)
        {
            if (items == null) return "";
            var sbItemsCode = new System.Text.StringBuilder();
            items.ForEach(x =>
            {
                sbItemsCode.AppendLine(x.GetText());
            });
            return sbItemsCode.ToString();
        }

        private string GetInterfaceItemsCode(List<IAbpAppItem> items = null)
        {
            if (items == null) return "";
            var sbItemsCode = new StringBuilder();
            items.ForEach(x =>
            {
                sbItemsCode.AppendLine("\t\t" + x.GetInterfaceText());
            });
            return sbItemsCode.ToString();
        }

        public void InsertIntoSolution(List<IAbpCtlItem> ctlItems)
        {
            var name = _modelName.ToFirstLettleUpcase();
            var projectPath = AbpSolutionBll.GetProjectPath(AbpProjectType.Application);
            var path = string.IsNullOrWhiteSpace(_subPath) ?
                                $"{name}s" :
                                $"{_subPath}\\{name}s";
            path = System.IO.Path.Combine(projectPath, path);
            System.IO.Directory.CreateDirectory(path);
            var fileService = System.IO.Path.Combine(path, $"{name}Service.cs");
            var fileInterface = System.IO.Path.Combine(path, $"I{name}Service.cs");
            var fileServiceInterface = System.IO.Path.Combine(path, $"I{name}Service.cs");
            var appItems = ctlItems.Select(x => x.ToAppItem()).ToList();
            AbpSolutionBll.InsertCodeFile(fileService, GetServiceText(appItems));
            AbpSolutionBll.InsertCodeFile(fileInterface, GetInterfaceText(appItems));
            AbpSolutionBll.InsertCodeFile(fileServiceInterface, "");

            InsetDtoFiles(ctlItems, path);
        }

        private void InsetDtoFiles(List<IAbpCtlItem> ctlItems, string dtoBasePath)
        {
            var dtoPath = System.IO.Path.Combine(dtoBasePath, "Dto");
            System.IO.Directory.CreateDirectory(dtoPath);
            var dtos = ctlItems.SelectMany(x => x.Dtos).Distinct();
            foreach (var dto in dtos)
            {
                InsertDtoFile(dtoPath, dto);
            }
            var fileDtoMapperProfile = System.IO.Path.Combine(dtoPath, $"{_modelName}Profile.cs");
            AbpSolutionBll.InsertCodeFile(fileDtoMapperProfile,
                (new AbpAppDtoMapperProfile())
                        .GetText(AbpSolutionBll.GetRootNameSpace(), _subPath, _modelName));
        }

        public string GetDtosCode(List<IAbpCtlItem> ctlItems)
        {
            var dtos = ctlItems.SelectMany(x => x.Dtos).Distinct();
            var result = new StringBuilder();
            foreach (var dto in dtos)
            {
                result.AppendLine(GetDtoCode(dto));
            }
            return result.ToString();
        }

        private void InsertDtoFile(string path, string dtoName)
        {
            var fileDto = System.IO.Path.Combine(path, $"{dtoName}.cs");
            string code = GetDtoCode(dtoName);
            AbpSolutionBll.InsertCodeFile(fileDto, code);
        }

        private string GetDtoCode(string dtoName)
        {
            var code = tplDto.Replace("$root.name.space$", AbpSolutionBll.GetRootNameSpace())
                            .Replace("$dtoname$", dtoName)
                            .Replace("$dto.name.space$", GetDtoNameSapce());
            if (dtoName.StartsWith("Get") && dtoName.EndsWith("Input"))
            {
                code = code.Replace("$some.sample.code$", tplGetInputDtoSampleCode);
            }
            if (dtoName.StartsWith("Get") && dtoName.EndsWith("Output"))
            {
                code = code.Replace("$some.sample.code$", "public string Code {get;set;}");
            }
            if (dtoName.StartsWith("Put") || dtoName.StartsWith("Abandon"))
            {
                code = code.Replace("$some.sample.code$", "public byte[] RowVersion { get; set; }");
            }
            code = code.Replace("$some.sample.code$", "");
            return code;
        }

        public string GetDtoNameSapce()
        {
            var rootNameSpace = AbpSolutionBll.GetRootNameSpace();
            string dtoNameSpace;
            if (!string.IsNullOrWhiteSpace(_subPath))
            {
                dtoNameSpace = $"{rootNameSpace}.{_subPath.Trim()}.{_modelName}s.Dto";
            }
            else
            {
                dtoNameSpace = $"{rootNameSpace}.{_modelName}s.Dto";
            }

            return dtoNameSpace;
        }
    }
}