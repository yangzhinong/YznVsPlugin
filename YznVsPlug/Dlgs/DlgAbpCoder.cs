using EnvDTE80;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YznVsPlug.BLL;
using YznVsPlug.Models;

namespace YznVsPlug.Dlgs
{
    public partial class DlgAbpCoder : Form
    {
        private readonly DTE2 _dte;
        private VbpCoderSetting _setting;

        public DlgAbpCoder(DTE2 dte)
        {
            InitializeComponent();
            _dte = dte;
        }

        private void DlgAbpCoder_Load(object sender, EventArgs e)
        {
            BtnSelectAll_Click(this, null);

            _setting = VbpCoderSetting.GetValue();
        }

        private void BtnGenCtl_Click(object sender, EventArgs e)
        {
            var modelName = txtModel.Text?.Trim();
            if (string.IsNullOrWhiteSpace(modelName))
            {
                MessageBox.Show("必须填如实体名称", "tip");
                return;
            }
#pragma warning disable VSTHRD010
            var ctlItems = GetWaitCreateCtlItems(modelName);
            var oCtl = new AptCtl(txtSubCtlPath.Text?.Trim(), modelName);

            if (rbClipBorad.Checked)
            {
                Clipboard.SetText(oCtl.GetText(ctlItems));
            }
            if (rbInsetToSolution.Checked)
            {
                oCtl.InsertIntoSolution(ctlItems);
            }
            MessageBox.Show("Success!");
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private List<IAbpCtlItem> GetWaitCreateCtlItems(string modelName)
        {
            List<IAbpCtlItem> abpCtlItems = new List<IAbpCtlItem>();
            for (var i = 0; i < clbCreateOptions.Items.Count; i++)
            {
                if (clbCreateOptions.GetItemChecked(i))
                {
                    var txt = clbCreateOptions.GetItemText(clbCreateOptions.Items[i]);
                    switch (txt)
                    {
                        case "Post":
                            abpCtlItems.Add(new AbpCtlPost(modelName));
                            break;

                        case "Get":
                            abpCtlItems.Add(new AbpCtlGet(modelName));
                            break;

                        case "GetById":
                            abpCtlItems.Add(new AbpCtlGetById(modelName));
                            break;

                        case "Put":
                            abpCtlItems.Add(new AbpCtlPut(modelName));
                            break;

                        case "Import":
                            abpCtlItems.Add(new AbpCtlImport(modelName));
                            break;

                        case "Export":
                            abpCtlItems.Add(new AbpCtlExport(modelName));
                            break;

                        case "Abandon":
                            abpCtlItems.Add(new AbpCtlAbandon(modelName));
                            break;
                    }
                }
            }
            return abpCtlItems;
        }

        private void BtnGenApp_Click(object sender, EventArgs e)
        {
            var modelName = txtModel.Text?.Trim();
            if (string.IsNullOrWhiteSpace(modelName))
            {
                MessageBox.Show("必须填如实体名称", "tip");
                return;
            }
#pragma warning disable VSTHRD010
            var ctlItems = GetWaitCreateCtlItems(modelName);
            var oApp = new AbpApplication(txtSubAppPath.Text?.Trim(), modelName);
            var appItems = ctlItems.Select(x => x.ToAppItem()).ToList();
            if (rbClipBorad.Checked)
            {
                var code = oApp.GetInterfaceText(appItems) +
                           Environment.NewLine +
                           oApp.GetServiceText(appItems) +
                           Environment.NewLine +
                           oApp.GetDtosCode(ctlItems);
                Clipboard.SetText(code);
            }
            if (rbInsetToSolution.Checked)
            {
                oApp.InsertIntoSolution(ctlItems);
            }
            MessageBox.Show("Success!");
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            txtSubCtlPath.Text = txtSubAppPath.Text;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            txtSubAppPath.Text = txtSubCtlPath.Text;
        }

        private void BtnSelectAll_Click(object sender, EventArgs e)
        {
            for (var i = 0; i < clbCreateOptions.Items.Count; i++)
            {
                clbCreateOptions.SetItemChecked(i, true);
            }
        }

        private void BtnSelectNone_Click(object sender, EventArgs e)
        {
            for (var i = 0; i < clbCreateOptions.Items.Count; i++)
            {
                clbCreateOptions.SetItemChecked(i, false);
            }
        }

        private void BtnSelectInv_Click(object sender, EventArgs e)
        {
            for (var i = 0; i < clbCreateOptions.Items.Count; i++)
            {
                clbCreateOptions.SetItemChecked(i, !clbCreateOptions.GetItemChecked(i));
            }
        }

        private void BtnSelectSubCtlPath_Click(object sender, EventArgs e)
        {
            var path = AbpSolutionBll.GetProjectPath(AbpProjectType.WebHost);
            path = Path.Combine(path, "Controllers");
            var items = new List<string>();
            foreach (var p in Directory.GetDirectories(path))
            {
                items.Add(p.Split("\\".ToCharArray()).Last());
            }
            var dlg = new DlgSelectItem(items);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                txtSubCtlPath.Text = dlg.GetSelected();
            }
        }

        private void BtnSelectSubAppPath_Click(object sender, EventArgs e)
        {
            var path = AbpSolutionBll.GetProjectPath(AbpProjectType.Application);
            //path = Path.Combine(path, "Controllers");
            var items = new List<string>();
            foreach (var p in Directory.GetDirectories(path))
            {
                items.Add(p.Split("\\".ToCharArray()).Last());
            }
            var dlg = new DlgSelectItem(items);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                txtSubAppPath.Text = dlg.GetSelected();
            }
        }

        private void DlgAbpCoder_FormClosing(object sender, FormClosingEventArgs e)
        {
            _setting.ModelName = txtModel.Text?.Trim();
            _setting.CtlSubPath = txtSubCtlPath.Text?.Trim();
            _setting.AppSubPath = txtSubAppPath.Text?.Trim();
            VbpCoderSetting.SaveSetting();
        }

        private void BtnGenManager_Click(object sender, EventArgs e)
        {
            var modelName = txtModel.Text?.Trim();
            if (string.IsNullOrWhiteSpace(modelName))
            {
                MessageBox.Show("必须填如实体名称", "tip");
                return;
            }
#pragma warning disable VSTHRD010
            var oManager = new AbpManager(txtSubAppPath.Text?.Trim(), modelName);
            if (rbClipBorad.Checked)
            {
                var code = oManager.GetInterfaceText() +
                          System.Environment.NewLine +
                          oManager.GetServiceText();
                Clipboard.SetText(code);
            }
            if (rbInsetToSolution.Checked)
            {
                oManager.InsertIntoSolution();
            }
            MessageBox.Show("Success!");
        }

        private void BtnUsing_Click(object sender, EventArgs e)
        {
            var dlg = new DlgUsingSetting();
            dlg.ShowDialog();
            dlg.Close();
        }
    }
}