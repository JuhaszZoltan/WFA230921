using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFA230921
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.to_do_list;
            btnAdd.Click += BtnAdd_Click;
            btnDelete.Click += BtnDelete_Click;
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            lsbTodo.Items.Remove(lsbTodo.SelectedItem);
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtItem.Text))
            {
                if (chbImportant.Checked)
                {
                    txtItem.Text = $"[{txtItem.Text}]";
                    chbImportant.Checked = false;
                }
                lsbTodo.Items.Add(txtItem.Text);
                txtItem.Text = null;
            }
            else
            {
                MessageBox.Show(
                    caption: "ERROR!",
                    text: "U can not add nothing, u fckin idiot!",
                    icon: MessageBoxIcon.Error,
                    buttons: MessageBoxButtons.OK);
            }

        }
    }
}
