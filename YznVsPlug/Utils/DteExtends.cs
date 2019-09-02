using EnvDTE;
using EnvDTE80;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YznVsPlug.Utils
{
    public static class DteExtends
    {
        public static string GetActiveDocumentText(this DTE2 dte)
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            var doc = dte.ActiveDocument.Object("TextDocument") as TextDocument;
            var editPoint = doc.StartPoint.CreateEditPoint();
            var result = editPoint.GetText(doc.EndPoint);
            return result;
        }

        public static Projects GetAllProjects(this DTE2 dte)
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            return ((EnvDTE.SolutionClass)dte.Solution).Projects;
        }

        static internal string[] GetProjectFilesInSolution()
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            IVsSolution sol = ServiceProvider.GlobalProvider.GetService(typeof(SVsSolution)) as IVsSolution;
            uint numProjects;
            ErrorHandler.ThrowOnFailure(sol.GetProjectFilesInSolution((uint)__VSGETPROJFILESFLAGS.GPFF_SKIPUNLOADEDPROJECTS, 0, null, out numProjects));
            string[] projects = new string[numProjects];
            ErrorHandler.ThrowOnFailure(sol.GetProjectFilesInSolution((uint)__VSGETPROJFILESFLAGS.GPFF_SKIPUNLOADEDPROJECTS, numProjects, projects, out numProjects));
            //GetProjectFilesInSolution also returns solution folders, so we want to do some filtering
            //things that don't exist on disk certainly can't be project files
            return projects.Where(p => !string.IsNullOrEmpty(p) && System.IO.File.Exists(p)).ToArray();
        }
    }
}