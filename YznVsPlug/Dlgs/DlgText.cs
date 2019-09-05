using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YznVsPlug.Utils;

namespace YznVsPlug.Dlgs
{
    public partial class DlgText : Form
    {
        public DlgText(string s)
        {
            InitializeComponent();
            txt.Text = s.ReplaceLF2CrLF();
        }

        private void DlgText_Load(object sender, EventArgs e)
        {
        }
    }
}