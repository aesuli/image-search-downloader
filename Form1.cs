// Copyright (C) 2016 Andrea Esuli (andrea@esuli.it)
//
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace ImageSearchDownloader
{
    public partial class Form1 : Form
    {
        private int[] selectedSearchEngines = null;
        private List<ISearchEngine> searchEngines;
        private QueryProcessor queryProcessor;

        public Form1()
        {
            InitializeComponent();
            ResetFolderSelectButton();
            ResetSelectSearchEngineButton();
            ResetSearchEngines();
            queryProcessor = null;
        }

        private void ResetSearchEngines()
        {
            searchEngines = new List<ISearchEngine>();

            searchEngines.Add(new BingSearchEngine());
            searchEngines.Add(new GoogleSearchEngine());
        }

        private void FolderSelectButton_Click(object sender, EventArgs e)
        {
            var dialogResult = folderBrowserDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                folderSelectButton.Text = Resources.targetFolderButtonText + folderBrowserDialog.SelectedPath;
            }
            else
                ResetFolderSelectButton();
        }

        private void ResetFolderSelectButton()
        {
            folderSelectButton.Text = Resources.defaultFolderButtonText;
            folderBrowserDialog.SelectedPath = null;
        }

        private void ButtonSelectSearchEngine_Click(object sender, EventArgs e)
        {
            using (var searchEngineSelectionDialog = new SearchEngineSelectionDialog(searchEngines, selectedSearchEngines))
            {
                var dialogResult = searchEngineSelectionDialog.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    selectedSearchEngines = searchEngineSelectionDialog.SelectedSearchEngines;
                    if (selectedSearchEngines == null)
                        buttonSelectSearchEngine.Text = Resources.defaultButtonSelectSearchEngineText;
                    else
                    {
                        string label = "";
                        foreach (var index in selectedSearchEngines)
                        {
                            label += searchEngines[index].Name + " ";
                        }
                        buttonSelectSearchEngine.Text = Resources.selectedSearchEngine +
                                                        label.TrimEnd();
                    }
                }
            }
        }

        private void ResetSelectSearchEngineButton()
        {
            buttonSelectSearchEngine.Text = Resources.defaultButtonSelectSearchEngineText;
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxQueries.Clear();
        }

        private void buttonDownload_Click(object sender, EventArgs e)
        {
            if (buttonDownload.Text == Resources.startDownloadText)
            {
                if (folderBrowserDialog.SelectedPath.Length == 0)
                {
                    MessageBox.Show("Please select a destination directory");
                    return;
                }
                if (selectedSearchEngines ==null)
                {
                    MessageBox.Show("Please select a search engine");
                    return;
                }

                var dialogResult = MessageBox.Show("Note that by downloading an image from the Web you do not gain any right on it."
                    + Environment.NewLine + "For each downloaded image you have to agree with its owner a license of usage."
                    + Environment.NewLine + "In order to ease the process of finding the owner of the image, this program saves the original URL of the image and also the URL of the page containing it."
                    + Environment.NewLine + "THIS PROGRAM IS ONLY A TOOL TO DOWNLOAD IMAGES. THIS PROGRAM DOES NOT GIVE YOU ANY RIGHT ON THEM."
                    , "Attention", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2);
                if (dialogResult == DialogResult.Cancel)
                    return;

                if (queryProcessor != null && queryProcessor.PendingQueries.Count > 0)
                    queryProcessor.Stop();


                textBoxQueries.Enabled = false;
                buttonClear.Enabled = false;
                buttonDownload.Enabled = false;
                checkBoxDownloadPage.Enabled = false;
                numericUpDownMaxResults.Enabled = false;
                folderSelectButton.Enabled = false;
                buttonSelectSearchEngine.Enabled = false;
                label1.Enabled = false;

                try
                {
                    var destination = new DirectoryInfo(folderBrowserDialog.SelectedPath);
                    queryProcessor = new QueryProcessor(searchEngines.ToArray(), selectedSearchEngines, destination, checkBoxDownloadPage.Checked, (int)numericUpDownMaxResults.Value, QueryNotification, DownloadNotification, StopNotification);

                    using (var readme = File.CreateText(destination.FullName + Path.DirectorySeparatorChar + "ReadMe.txt"))
                    {
                        readme.WriteLine("Note that by downloading an image from the Web you do not gain any right on it.");
                        readme.WriteLine("For each downloaded image you have to agree with its owner a license of usage.");
                        readme.WriteLine("In order to ease the process of finding the owner of the image, this program saves the original URL of the image and also the URL of the page containing it.");
                        readme.WriteLine("THIS PROGRAM IS ONLY A TOOL TO DOWNLOAD IMAGES. THIS PROGRAM DOES NOT GIVE YOU ANY RIGHT ON THEM.");
                    }

                    var queries = textBoxQueries.Text.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var query in queries)
                        queryProcessor.AddQuery(query);

                    queryProcessor.Start();
                    buttonDownload.Text = Resources.stopDownloadText;
                    buttonDownload.Enabled = true;
                }
                catch
                {
                    StopNotification(this, null);
                }
            }
            else
            {
                if (queryProcessor != null)
                {
                    buttonDownload.Enabled = false;
                    queryProcessor.Stop();
                }
            }
        }

        private void DownloadNotification(object sender, string e)
        {

            if (InvokeRequired)
            {
                try
                {
                    Invoke(new EventHandler<string>(DownloadNotification), new object[] { this, e });
                }
                catch
                {
                } return;
            }

            textBoxLog.AppendText("Downloaded image: " + e + Environment.NewLine);

        }

        private void QueryNotification(object sender, string e)
        {
            if (InvokeRequired)
            {
                try
                {
                    Invoke(new EventHandler<string>(QueryNotification), new object[] { this, e });
                }
                catch
                {
                } return;
            }

            textBoxLog.Clear();
            textBoxLog.AppendText("Processing query: " + e + Environment.NewLine);

            if (queryProcessor != null)
            {
                var sb = new StringBuilder();
                var queries = queryProcessor.PendingQueries;
                foreach (var query in queries)
                    sb.AppendLine(query);
                textBoxQueries.Text = sb.ToString();
            }
        }

        private void StopNotification(object sender, EventArgs e)
        {
            Stop();
        }

        private void Stop()
        {
            if (InvokeRequired)
            {
                try
                {
                    Invoke(new MethodInvoker(Stop));
                }
                catch
                {
                }
                return;
            }
            buttonDownload.Enabled = false;
            if (queryProcessor != null)
            {
                var sb = new StringBuilder();
                var queries = queryProcessor.PendingQueries;
                foreach (var query in queries)
                    sb.AppendLine(query);
                textBoxQueries.Text = sb.ToString();
            }

            buttonDownload.Text = Resources.startDownloadText;
            buttonDownload.Enabled = true;
            textBoxQueries.Enabled = true;
            buttonClear.Enabled = true;
            checkBoxDownloadPage.Enabled = true;
            numericUpDownMaxResults.Enabled = true;
            folderSelectButton.Enabled = true;
            buttonSelectSearchEngine.Enabled = true;
            label1.Enabled = true;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (queryProcessor != null)
                queryProcessor.Stop();
        }

    }
}
