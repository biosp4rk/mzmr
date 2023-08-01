using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mzmr.UI
{
    public partial class FormSettings : Form
    {
        public Settings Settings { get; private set; }
        public string Config
        {
            set => textBox_settings.Text = value;
        }

        private Timer timer;

        public FormSettings()
        {
            InitializeComponent();

            timer = new Timer();
            timer.Interval = 2000;
            timer.Tick += Timer_Tick;
        }

        private void Button_copy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBox_settings.Text);
            label_copied.Visible = true;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            label_copied.Visible = false;
        }

        private void Button_apply_Click(object sender, EventArgs e)
        {
            try
            {
                Settings = new Settings(textBox_settings.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void Button_cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

    }
}
