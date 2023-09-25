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

namespace WFA230921
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            btnDelete.Enabled = false;
            this.Icon = Properties.Resources.to_do_list;
            btnAdd.Click += BtnAdd_Click;
            btnDelete.Click += BtnDelete_Click;
            this.Load += MainForm_Load;
            this.FormClosing += MainForm_FormClosing;
            txtItem.GotFocus += TxtItem_GotFocus;
            lsbTodo.SelectedValueChanged += LsbTodo_SelectedValueChanged;
        }

        private void LsbTodo_SelectedValueChanged(object sender, EventArgs e)
        {
            btnDelete.Enabled = lsbTodo.SelectedItems.Count > 0;
        }

        private void TxtItem_GotFocus(object sender, EventArgs e)
        {
            lsbTodo.ClearSelected();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            var sw = new StreamWriter
                (@"..\..\Resources\todo.txt",
                false,
                Encoding.UTF8);
            foreach (string item in lsbTodo.Items)
            {
                sw.WriteLine(item);
            }
            sw.Close();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var sr = new StreamReader(@"..\..\Resources\todo.txt", Encoding.UTF8);
            while (!sr.EndOfStream)
            {
                lsbTodo.Items.Add(sr.ReadLine());
            }
            sr.Close();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            while (lsbTodo.SelectedItems.Count > 0)
            {
                lsbTodo.Items.Remove(lsbTodo.SelectedItems[0]);
            }
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
