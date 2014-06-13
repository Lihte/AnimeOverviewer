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
        private List<SerializableKeyValuePair<string, bool>> directories;
        private EpisodeList episodeList;

        public AnimeOverviewer()
        {
            InitializeComponent();
        }

        #region Events
        
        private void AnimeOverviewer_Load(object sender, EventArgs e)
        {
            directories = new List<SerializableKeyValuePair<string, bool>>();
            InitializeDirectoryList();

            episodeList = new EpisodeList(directories);
            InitializeEpisodeListView();
        }

        private void AnimeOverviewer_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Rebuild directories.xml when closing program
            ObjectXMLSerializer <List<SerializableKeyValuePair<string, bool>>>.Save(directories, "directories.xml");
        }

        private void btnAddDirectory_Click(object sender, EventArgs e)
        {
            // Show the Folder Browser dialog. If the user clicks OK, 
            // add the directory the user choses to the directory list
            // if it does not already exist
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                if (directories.Any(d => d.Key == folderBrowserDialog1.SelectedPath) == false)
                {
                    listViewDirectory.Items.Add(new ListViewItem(folderBrowserDialog1.SelectedPath));
                    directories.Add(new SerializableKeyValuePair<string, bool>(folderBrowserDialog1.SelectedPath, false));
                    episodeList.InitializeList(directories);
                    UpdateEpisodeListView();
                }
                else
                {
                    MessageBox.Show("Path directory already in list.");
                }
            }
        }

        private void btnRemoveDirectory_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem selected in listViewDirectory.SelectedItems)
            {
                directories.RemoveAll(d => d.Key == selected.Text);
                listViewDirectory.Items.Remove(selected);
            }
        }

        private void directoryListView_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            ListView list = (ListView)sender;
            ListViewItem item = list.Items[e.Index];

            for (int i = 0; i < directories.Count; i++)
            {
                if (directories[i].Key == item.Text)
                {
                    if (directories[i].Value == true)
                        directories[i].Value = false;
                    else
                        directories[i].Value = true;
                }
            }

            MessageBox.Show("Item Checked!");
        }
        
        #endregion

        private void InitializeEpisodeListView()
        {
            // Create and initialize column headers for episodeListView
            ColumnHeader columnHeader0 = new ColumnHeader() { Text = "No.", Width = 30 };
            ColumnHeader columnHeader1 = new ColumnHeader() { Text = "Title", Width = 100 };
            ColumnHeader columnHeader2 = new ColumnHeader() { Text = "Subgroup", Width = 100 };
            ColumnHeader columnHeader3 = new ColumnHeader() { Text = "Res.", Width = 50 };
            ColumnHeader columnHeader4 = new ColumnHeader() { Text = "Path", Width = -2 };

            // Add the column headers to episodeListView
            this.listViewEpisode.Columns.AddRange(new ColumnHeader[] { columnHeader0, columnHeader1, columnHeader2, columnHeader3, columnHeader4 });
            
            // Update the episode listview
            UpdateEpisodeListView();
        }

        private void UpdateEpisodeListView()
        {
            foreach (var ep in episodeList)
            {
                if (listViewEpisode.Items.Count > 0)
                {
                    ListViewItem checkForDuplicates = listViewEpisode.FindItemWithText(ep.Filepath, true, 0);
                    if (checkForDuplicates == null)
                        listViewEpisode.Items.Add(new ListViewItem(new string[] { ep.Number, ep.Title, ep.Subgroup, ep.Resolution, ep.Filepath }));
                }
                else
                    listViewEpisode.Items.Add(new ListViewItem(new string[] { ep.Number, ep.Title, ep.Subgroup, ep.Resolution, ep.Filepath }));
            }
        }

        private void InitializeDirectoryList()
        {
            // Add a column header to directoryListView
            this.listViewDirectory.Columns.Add("Directories");
            this.listViewDirectory.Columns[0].Width = listViewDirectory.Width - 4;

            // Load the directory list from directories.xml if it exists and isn't empty
            // If it doesn't exist, one will be created at the end of the program
            if (File.Exists("directories.xml"))
            {
                directories = ObjectXMLSerializer<List<SerializableKeyValuePair<string, bool>>>.Load("directories.xml");

                // Load directoryListView with Items from the directory list
                if (directories.Count > 0)
                {
                    foreach (var dir in directories)
                    {
                        listViewDirectory.Items.Add(new ListViewItem(dir.Key));
                    }
                }
            }
        }        
    }
}
