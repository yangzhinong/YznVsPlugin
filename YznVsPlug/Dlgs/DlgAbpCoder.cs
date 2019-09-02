using EnvDTE80;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YznVsPlug.Dlgs
{
    public partial class DlgAbpCoder : Form
    {
        private readonly DTE2 _dte;

        public DlgAbpCoder(DTE2 dte)
        {
            InitializeComponent();
            _dte = dte;
        }

        private void DlgAbpCoder_Load(object sender, EventArgs e)
        {
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}