using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GOpenUpdater.Bootsrapper
{
    public partial class UpdateForm : Form
    {
        private Updater _updater;
        private WebClient _wc;
        private UpdateDefinition _newUpdate;

        public UpdateForm()
        {
            InitializeComponent();

            _updater = new Updater();
            _wc = new WebClient();
            _wc.DownloadProgressChanged += wc_DownloadProgressChanged;
            _wc.DownloadFileCompleted += wc_DownloadFileCompleted;

            Task.Run(() => CheckForUpdate()).ContinueWith(y => CheckFinished());
        }

        private void wc_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            Invoke(new System.Action(() =>
            {
                lblPercetage.Text = "0%";
                prgUpdate.Value = 0;
            }));
        }

        private void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            Invoke(new Action(() =>
            {
                lblPercetage.Text = $"{e.ProgressPercentage}%";
                prgUpdate.Value = e.ProgressPercentage;
            }));
        }

        private async void CheckForUpdate()
        {
            if (await _updater.CheckForUpdateAsync())
            {
                _newUpdate = await _updater.GetLatestReleaseDefinitionAsync();
            }
        }

        private void CheckFinished()
        {
            if (_newUpdate == null)
            {
                Invoke(new Action(() => lblTagName.Text = "This version is already up-to-date."));
            }
            else
            {
                Invoke(new Action(() =>
                {
                    lblTagName.Text = _newUpdate.ReleaseTag;
                    lblReleaseDate.Text = _newUpdate.PublishedAt.ToString();
                    lblFileSize.Text = _newUpdate.Size.ToString();
                    cmdUpdate.Enabled = true;
                    cmdCancel.Enabled = true;
                }));
            }
        }

        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            _wc.DownloadFile(_newUpdate.DownloadUrl, "");
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
