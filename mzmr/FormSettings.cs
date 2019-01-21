using System;
using System.Collections.Generic;
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

        private void button_open_settings_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Config files (*.cfg)|*.cfg";
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

        private void button_open_custom_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "All files (*.*)|*.*";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    textBox_custom.Text = File.ReadAllText(openFile.FileName);
                }
                catch
                {
                    MessageBox.Show("File could not be read.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private Dictionary<int, ItemType> ParseCustomAssignments(string text)
        {
            Dictionary<int, ItemType> customAssignments = new Dictionary<int, ItemType>();
            StringReader sr = new StringReader(text);
            string line;
            int lineNum = 1;

            while ((line = sr.ReadLine()) != null)
            {
                if (line == "") { continue; }

                string[] pair = line.Split('=');
                if (pair.Length < 2)
                {
                    throw new FormatException(
                        string.Format("Line {0} does not have an equal sign: {1}", lineNum, line));
                }

                // get location number
                int locNum;
                if (!int.TryParse(pair[0], out locNum) || locNum < 0 || locNum > 99)
                {
                    throw new FormatException(
                        string.Format("Line {0} does not have a valid location number: {1}", lineNum, line));
                }
                if (customAssignments.ContainsKey(locNum))
                {
                    throw new FormatException(
                        string.Format("Location {0} defined more than once", locNum));
                }

                // get item type
                ItemType type;
                try
                {
                    type = Item.FromString(pair[1].Trim());
                }
                catch (FormatException)
                {
                    throw new FormatException(
                        string.Format("Line {0} does not have a valid item type: {1}", lineNum, line));
                }

                customAssignments.Add(locNum, type);
                lineNum++;
            }

            if (customAssignments.Count == 0)
            {
                throw new FormatException("No item assignments defined");
            }

            // check for too many of one item
            Dictionary<ItemType, int> itemCounts = new Dictionary<ItemType, int>();
            foreach (ItemType type in customAssignments.Values)
            {
                if (itemCounts.ContainsKey(type))
                {
                    itemCounts[type]++;
                }
                else
                {
                    itemCounts.Add(type, 1);
                }

                if (itemCounts[type] > type.MaxNumber())
                {
                    throw new FormatException(
                        string.Format("File has too many assignments for {0}", type.ToString()));
                }
            }

            return customAssignments;
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            if (textBox_settings.Text != "")
            {
                try
                {
                    Settings settings = new Settings(textBox_settings.Text);
                    main.SetStateFromSettings(settings);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (textBox_custom.Text != "")
            {
                try
                {
                    main.customAssignments = ParseCustomAssignments(textBox_custom.Text);
                }
                catch (FormatException ex)
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
