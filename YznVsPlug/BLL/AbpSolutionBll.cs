using System.IO;
using YznVsPlug.Utils;
using System.Collections.Generic;
using System;
using System.Linq;
using Microsoft.VisualStudio.Shell;

namespace YznVsPlug.BLL
{
    public class AbpSolutionBll
    {
        private static Dictionary<AbpProjectType, string> _allProjectPaths = new Dictionary<AbpProjectType, string>();

        public static string GetProjectPath(AbpProjectType abpProjectType)
        {
#pragma warning disable VSTHRD010
            var projects = GetALLProjectPath();
            foreach (var key in projects.Keys)
            {
                if (key == abpProjectType)
                {
                    return projects[key];
                }
            }

            return null;
        }

        public static Dictionary<AbpProjectType, string> GetALLProjectPath()
        {
            if (_allProjectPaths.Count() > 0) return _allProjectPaths;
#pragma warning disable VSTHRD010
            string[] files = DteExtends.GetProjectFilesInSolution();
            foreach (AbpProjectType t in Enum.GetValues(typeof(AbpProjectType)))
            {
                var file = files.FirstOrDefault(x => x.EndsWith($".{t.ToString()}.csproj"));
                if (!string.IsNullOrWhiteSpace(file))
                {
                    _allProjectPaths.Add(t, Path.GetDirectoryName(file));
                }
            }
            return _allProjectPaths;
        }

        public static string GetRootNameSpace()
        {
            var name = GetProjectPath(AbpProjectType.Domain)
                                .Split('\\')
                                .Last();
            return name.Substring(0, name.Length - AbpProjectType.Domain.ToString().Length - 1);
        }

        public static string GetBaseClassName(AbpProjectType abpProjectType)
        {
            var path = GetProjectPath(abpProjectType);
            var file = System.IO.Directory.GetFiles(path).FirstOrDefault(x => x.EndsWith("Base.cs"));
            if (file != null)
            {
                return Path.GetFileNameWithoutExtension(file);
            }
            return "";
        }

        public static void InsertCodeFile(string fileName, string code, bool replaceFileForce = false)
        {
            if (System.IO.File.Exists(fileName) && replaceFileForce)
            {
                try
                {
                    System.IO.File.Delete(fileName);
                    System.IO.File.WriteAllText(fileName, code);
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show($"创建或删除{fileName}失败:{ex.Message}");
                }
            }
            else if (!System.IO.File.Exists(fileName))
            {
                System.IO.File.WriteAllText(fileName, code);
            }
        }
    }
}