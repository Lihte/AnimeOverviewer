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
        private List<SerializeableDirectory> directories;
        private EpisodeList episodeList;

        // Used to make sure Item Check status isn't changed when form loads
        private bool formIsLoaded = false;

        public AnimeOverviewer()
        {
            InitializeComponent();
        }

        #region Events
        
        private void AnimeOverviewer_Load(object sender, EventArgs e)
        {
            directories = new List<SerializeableDirectory>();
            InitializeDirectoryList();

            episodeList = new EpisodeList(directories);
            InitializeEpisodeListView();

            formIsLoaded = true;
        }

        private void AnimeOverviewer_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Rebuild directories.xml when closing program
            ObjectXMLSerializer <List<SerializeableDirectory>>.Save(directories, "directories.xml");
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
                    directories.Add(new SerializeableDirectory(folderBrowserDialog1.SelectedPath, false));
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
                foreach (ListViewItem item in listViewEpisode.Items)
                {
                    if (item.SubItems[4].Text.Contains(selected.Text))
                    {
                        listViewEpisode.Items.Remove(item);
                    }
                }
                
                foreach (Episode episode in episodeList)
                {
                    if (episode.Filepath.Contains(selected.Text))
                    {
                        episodeList.Remove(episode);
                    }
                }

                directories.RemoveAll(d => d.Key == selected.Text);
                listViewDirectory.Items.Remove(selected);
            }
        }

        private void listViewDirectory_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            ListViewItem item = listViewDirectory.Items[e.Index];

            if (formIsLoaded)
            {
                for (int i = 0; i < directories.Count; i++)
                {
                    if (directories[i].Key == item.Text)
                    {
                        if (directories[i].Value == true)
                        {
                            directories[i].Value = false;
                            MessageBox.Show("Item Unchecked!");
                        }
                        else
                        {
                            directories[i].Value = true;
                            MessageBox.Show("Item Checked!");
                        }
                    }
                } 
            }
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
                directories = ObjectXMLSerializer<List<SerializeableDirectory>>.Load("directories.xml");

                // Load directoryListView with Items from the directory list
                if (directories.Count > 0)
                {
                    foreach (var dir in directories)
                    {
                        listViewDirectory.Items.Add(new ListViewItem(dir.Key) { Checked = dir.Value });
                    }
                }
            }
        }        
    }
}
