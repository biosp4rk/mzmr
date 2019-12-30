using System;
using System.Windows.Forms;

namespace mzmr
{
    public partial class FormAppSettings : Form
    {
        public FormAppSettings()
        {
            InitializeComponent();

            checkBox_autoLoadROM.Checked = Properties.Settings.Default.autoLoadRom;
            checkBox_rememberSettings.Checked = Properties.Settings.Default.rememberSettings;
            checkBox_saveLogFile.Checked = Properties.Settings.Default.saveLogFile;
            checkBox_saveMapImages.Checked = Properties.Settings.Default.saveMapImages;
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.autoLoadRom = checkBox_autoLoadROM.Checked;
            Properties.Settings.Default.rememberSettings = checkBox_rememberSettings.Checked;
            Properties.Settings.Default.saveLogFile = checkBox_saveLogFile.Checked;
            Properties.Settings.Default.saveMapImages = checkBox_saveMapImages.Checked;
            Properties.Settings.Default.Save();
            Close();
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            Close();
        }


    }
}
