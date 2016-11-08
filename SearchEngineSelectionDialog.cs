using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ImageSearchDownloader
{
    public partial class SearchEngineSelectionDialog : Form
    {

        public SearchEngineSelectionDialog()
        {
            InitializeComponent();
        }

        public SearchEngineSelectionDialog(List<ISearchEngine> searchEngines,int [] selectedSearchEngine): this()
        {
            checkedListBox1.Items.Clear();
            foreach (var searchEngine in searchEngines)
                checkedListBox1.Items.Add(searchEngine.Name);
            if (selectedSearchEngine != null)
            {
                foreach (var index in selectedSearchEngine)
                {
                    checkedListBox1.SetItemChecked(index, true);
                }
            }
        }

        public int [] SelectedSearchEngines
        {
            get
            {
                if (checkedListBox1.CheckedIndices.Count == 0)
                    return null;
                var indices = new int[checkedListBox1.CheckedIndices.Count];
                int i = 0;
                foreach (int index in checkedListBox1.CheckedIndices)
                {
                    indices[i] = index;
                    ++i;
                }
                return indices;
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
