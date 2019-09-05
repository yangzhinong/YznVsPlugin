using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YznVsPlug.Models;

namespace YznVsPlug.Dlgs
{
    public partial class DlgUsingSetting : Form
    {
        public DlgUsingSetting()
        {
            InitializeComponent();
        }

        private void DlgUsingSetting_Load(object sender, EventArgs e)
        {
            var _setting = VbpCoderSetting.GetValue();
            txtApplication.Text = _setting.AppUsing;
            txtController.Text = _setting.CtlUsing;
            txtDto.Text = _setting.DtoUsing;
            txtManager.Text = _setting.ManagerUsing;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            var setting = VbpCoderSetting.GetValue();
            setting.AppUsing = txtApplication.Text;
            setting.CtlUsing = txtController.Text;
            setting.DtoUsing = txtDto.Text;
            setting.ManagerUsing = txtManager.Text;
            VbpCoderSetting.SaveSetting();
            DialogResult = DialogResult.OK;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}