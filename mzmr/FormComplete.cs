using System;
using System.Windows.Forms;

namespace mzmr
{
    public partial class FormComplete : Form
    {
        public FormComplete(int seed, string config)
        {
            InitializeComponent();

            textBox_seed.Text = seed.ToString();
            textBox_config.Text = config;
        }

        private void Button_ok_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
