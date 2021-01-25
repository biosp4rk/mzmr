using mzmr.Randomizers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mzmr
{
    public enum RandomizationResult
    {
        Successful,
        Failed,
        Aborted,
    }

    public partial class FormProgress : Form
    {
        private RandomAll randomAll;
        private bool finished = false;

        private CancellationTokenSource cancelSource;

        public RandomizationResult Result { get; private set; }

        public FormProgress(RandomAll randAll)
        {
            InitializeComponent();

            randomAll = randAll;

            cancelSource = new CancellationTokenSource();
            
            Task.Run(() => Worker(cancelSource.Token));
        }

        private void Worker(CancellationToken token)
        {
            finished = false;

            try
            {
                var randomResult = randomAll.Randomize(token);

                if (token.IsCancellationRequested)
                {
                    return;
                }

                Result = randomResult ? RandomizationResult.Successful : RandomizationResult.Failed;
            }
            catch
            {
                Result = RandomizationResult.Failed;
            }

            finished = true;

            SetFinished();
        }

        private delegate void SetFinishedDelegate();
        private void SetFinished()
        {
            if(progressBar.InvokeRequired)
            {
                Invoke(new SetFinishedDelegate(SetFinished));
                return;
            }

            labelProgressInfo.Text = "Randomization complete";

            progressBar.Style = ProgressBarStyle.Continuous;
            //Hack to make progress bar set to full without doing any animation
            progressBar.Maximum = 101;
            progressBar.Value = 101;
            progressBar.Maximum = 100;

            button.Text = "OK";
        }

        private void button_Click(object sender, EventArgs e)
        {
            if (!finished)
            {
                Result = RandomizationResult.Aborted;

                cancelSource.Cancel();
            }

            this.Close();
        }
    }
}
