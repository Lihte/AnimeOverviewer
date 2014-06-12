using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml.Linq;
using System.Xml;
using System.Xml.Serialization;

namespace Animelist_v0._1
{
    public partial class AnimeOverviewer : Form
    {
        private List<string> directories = new List<string>();

        private EpisodeList episodeList = new EpisodeList();

        public AnimeOverviewer()
        {
            InitializeComponent();
        }

        private void Animelist_Load(object sender, EventArgs e)
        {
            InitializeDirectoryList();
            InitializeEpisodeList();
        }

        private void Animelist_FormClosing(object sender, FormClosingEventArgs e)
        {
            ObjectXMLSerializer<List<string>>.Save(directories, "directories.xml");
        }

        private void addDirectoryButton_Click(object sender, EventArgs e)
        {
            // Show the Folder Browser dialog. If the user clicks OK, 
            // add the directory the user choses to the directory list.
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                if (!directories.Contains(folderBrowserDialog1.SelectedPath))
                {
                    directoryListView.Items.Add(new ListViewItem(folderBrowserDialog1.SelectedPath));
                    directories.Add(folderBrowserDialog1.SelectedPath);
                    episodeList.InitializeList(directories);
                    UpdateEpisodeListView();
                }
                else
                {
                    MessageBox.Show("Path directory already in list.");
                }
            }
        }

        private void removeDirectoryButton_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem selected in directoryListView.SelectedItems)
            {
                directories.Remove(selected.Text);
                directoryListView.Items.Remove(selected);
            }
        }

        private void InitializeEpisodeList()
        {
            // Create and initialize column headers for episodeListView
            ColumnHeader columnHeader0 = new ColumnHeader() { Text = "No.", Width = 30 };
            ColumnHeader columnHeader1 = new ColumnHeader() { Text = "Title", Width = 100 };
            ColumnHeader columnHeader2 = new ColumnHeader() { Text = "Subgroup", Width = 100 };
            ColumnHeader columnHeader3 = new ColumnHeader() { Text = "Res.", Width = 50 };
            ColumnHeader columnHeader4 = new ColumnHeader() { Text = "Path", Width = -2 };

            // Add the column headers to episodeListView
            this.episodeListView.Columns.AddRange(new ColumnHeader[] { columnHeader0, columnHeader1, columnHeader2, columnHeader3, columnHeader4 });
            
            // Initialize the episodeList with files from directory paths and update the episode listview
            episodeList.InitializeList(directories);
            UpdateEpisodeListView();
        }

        private void UpdateEpisodeListView()
        {
            foreach (var ep in episodeList)
            {
                if (episodeListView.Items.Count > 0)
                {
                    ListViewItem checkForDuplicates = episodeListView.FindItemWithText(ep.Filepath, true, 0);
                    if (checkForDuplicates == null)
                        episodeListView.Items.Add(new ListViewItem(new string[] { ep.Number.ToString(), ep.Title, ep.Subgroup, ep.Resolution, ep.Filepath }));
                }
                else
                    episodeListView.Items.Add(new ListViewItem(new string[] { ep.Number.ToString(), ep.Title, ep.Subgroup, ep.Resolution, ep.Filepath }));
            }
        }

        private void InitializeDirectoryList()
        {
            // Add a column header to directoryListView
            this.directoryListView.Columns.Add("Directories");
            this.directoryListView.Columns[0].Width = directoryListView.Width - 4;

            // Load directory list from XML
            if (File.Exists("directories.xml"))
                directories = ObjectXMLSerializer<List<string>>.Load("directories.xml");

            // Load directoryListView with Items from directory list
            if (directories.Count != 0)
            {
                foreach (var dir in directories)
                {
                    directoryListView.Items.Add(new ListViewItem(dir));
                }
            }
        } 
    }
}
