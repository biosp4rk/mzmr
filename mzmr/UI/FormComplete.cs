using System;
using System.Windows.Forms;

namespace mzmr.UI
{
    public partial class FormComplete : Form
    {
        public FormComplete(int seed, string config, string logPath, string mapsPath)
        {
            InitializeComponent();

            textBox_seed.Text = seed.ToString();
            textBox_config.Text = config;
            if (logPath != null)
                textBox_logPath.Text = logPath;
            if (mapsPath != null)
                textBox_mapsPath.Text = mapsPath;
        }

        private void Button_ok_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
