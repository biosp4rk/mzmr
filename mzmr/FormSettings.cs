using System;
using System.IO;
using System.Windows.Forms;

namespace mzmr
{
    public partial class FormSettings : Form
    {
        private FormMain main;

        public FormSettings(FormMain main)
        {
            InitializeComponent();

            this.main = main;
        }

        private void button_open_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Config files (*.cfg)|*.cfg";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                textBox_file.Text = openFile.FileName;
            }
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            string config = null;

            if (textBox_file.Text != "")
            {
                try
                {
                    config = File.ReadAllText(textBox_file.Text);
                }
                catch
                {
                    MessageBox.Show("File could not be read.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (textBox_string.Text != "")
            {
                config = textBox_string.Text;
            }
            else
            {
                Close();
                return;
            }

            Settings settings;
            try
            {
                settings = new Settings(config);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            main.SetStateFromSettings(settings);
            Close();
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            Close();
        }


    }
}
