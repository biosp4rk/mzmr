using System;
using System.IO;
using System.Windows.Forms;

namespace mzmr
{
    public partial class FormSettings : Form
    {
        private readonly FormMain main;

        public FormSettings(FormMain main)
        {
            InitializeComponent();

            this.main = main;
        }

        private void button_open_settings_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "JSON files (*.json)|*.json";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    textBox_settings.Text = File.ReadAllText(openFile.FileName);
                }
                catch
                {
                    MessageBox.Show("File could not be read.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            if (textBox_settings.Text != "")
            {
                try
                {
                    Settings settings = Settings.LoadSettings(textBox_settings.Text);
                    main.SetStateFromSettings(settings);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            Close();
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
