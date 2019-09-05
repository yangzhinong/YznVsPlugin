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
    public partial class DlgSelectItem : Form
    {
        public string GetSelected()
        {
            return (string)listBox1.SelectedItem;
        }

        public DlgSelectItem(List<string> items)
        {
            InitializeComponent();
            foreach (var item in items)
            {
                listBox1.Items.Add(item);
            }
        }

        private void DlgSelectItem_Load(object sender, EventArgs e)
        {
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void ListBox1_DoubleClick(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}