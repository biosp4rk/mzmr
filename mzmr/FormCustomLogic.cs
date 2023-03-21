using System;
using System.IO;
using System.Windows.Forms;

namespace mzmr
{
    public partial class FormCustomLogic : Form
    {
        public string LogicFile { get; set; }

        public FormCustomLogic()
        {
            InitializeComponent();
        }

        private void Button_open_settings_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFile = new OpenFileDialog())
            {
                openFile.Filter = "Logic Files (*.lgc)|*.lgc";
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    LogicFile = openFile.FileName;
                    textBox_customLogicPath.Text = LogicFile;

                    // Scroll text in textbox to end
                    textBox_customLogicPath.SelectionStart = textBox_customLogicPath.Text.Length - 1;
                    textBox_customLogicPath.SelectionLength = 0;
                    textBox_customLogicPath.ScrollToCaret();
                }
            }
        }

        private void Button_ok_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(LogicFile))
                MessageBox.Show("No logic file was specified", "Logic Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                Close();
        }

        private void Button_cancel_Click(object sender, EventArgs e)
        {
            LogicFile = "";
            Close();
        }

    }
}
