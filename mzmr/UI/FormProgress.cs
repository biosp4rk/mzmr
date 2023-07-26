using Common.Log;
using mzmr.Randomizers;
using System;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mzmr.UI
{
    public enum RandomizationResult
    {
        Successful,
        Failed,
        Aborted,
    }

    public partial class FormProgress : Form
    {
        private static Size defaultSize = new Size(341, 145);
        private static Size expandedSize = new Size(641, 810);

        private RandomAll randomAll;
        private bool finished = false;

        private CancellationTokenSource cancelSource;

        public RandomizationResult Result { get; private set; }
        private LogLayer detailedLog = null;

        public FormProgress(RandomAll randAll)
        {
            InitializeComponent();

            randomAll = randAll;
            cancelSource = new CancellationTokenSource();
            Task.Run(() => Worker(cancelSource.Token));
            Size = defaultSize;
            detailLogView.Visible = false;
        }

        private void Worker(CancellationToken token)
        {
            finished = false;
            detailedLog = null;

            try
            {
                var randomResult = randomAll.Randomize(token);
                detailedLog = randomResult.DetailedLog;

                if (!token.IsCancellationRequested)
                    Result = randomResult.Success ? RandomizationResult.Successful : RandomizationResult.Failed;
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
            if (progressBar.InvokeRequired)
            {
                Invoke(new SetFinishedDelegate(SetFinished));
                return;
            }

            finished = true;
            if (Result == RandomizationResult.Successful)
                labelProgressInfo.Text = "Randomization Complete";
            else if (Result == RandomizationResult.Failed)
                labelProgressInfo.Text = "Randomization Failed";
            else if (Result == RandomizationResult.Aborted)
                labelProgressInfo.Text = "Randomization Cancelled";

            progressBar.Style = ProgressBarStyle.Continuous;
            //Hack to make progress bar set to full without doing any animation
            progressBar.Maximum = 101;
            progressBar.Value = 101;
            progressBar.Maximum = 100;

            buttonAction.Text = "OK";
            buttonDetails.Enabled = (detailedLog != null);
        }

        private void ButtonAction_Click(object sender, EventArgs e)
        {
            if (!finished)
            {
                Result = RandomizationResult.Aborted;
                cancelSource.Cancel();
            }
            else
                Close();
        }

        private void ButtonDetails_Click(object sender, EventArgs e)
        {
            if (detailLogView.Visible)
            {
                Size = defaultSize;
                detailLogView.Visible = false;
            }
            else
            {
                Size = expandedSize;
                detailLogView.Visible = true;
                detailLogView.Nodes.Clear();

                var node = GenerateTreeNode(detailedLog);
                if (node != null)
                    detailLogView.Nodes.Add(node);
            }
        }

        private TreeNode GenerateTreeNode(LogLayer aLog)
        {
            if (aLog == null)
                return null;

            var node = new TreeNode(aLog.Message);
            node.Nodes.AddRange(aLog.Children.Select(log => GenerateTreeNode(log)).ToArray());
            return node;
        }

    }
}
