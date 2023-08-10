using System;
using System.Windows.Forms;

namespace mzmr.UI
{
    public partial class FormSettings : Form
    {
        public Settings Settings { get; private set; }
        public string Config
        {
            set => textBox_current.Text = value;
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
            string config = textBox_current.Text.Trim();
            if (!string.IsNullOrEmpty(config))
            {
                Clipboard.SetText(config);
                label_copied.Visible = true;
                timer.Start();
            }
        }

        private void Button_paste_Click(object sender, EventArgs e)
        {
            string clipboard = Clipboard.GetText();
            if (clipboard != null)
                textBox_new.Text = clipboard.Trim();
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
                Settings = new Settings(textBox_new.Text.Trim());
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

        private void Button_close_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

    }
}
