namespace Animelist_v0._1
{
    partial class AnimeOverviewer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.listViewEpisode = new System.Windows.Forms.ListView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAddDirectory = new System.Windows.Forms.Button();
            this.btnRemoveDirectory = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.listViewDirectory = new System.Windows.Forms.ListView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.listViewEpisode);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(10, 10, 0, 10);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(10);
            this.splitContainer1.Size = new System.Drawing.Size(831, 571);
            this.splitContainer1.SplitterDistance = 411;
            this.splitContainer1.TabIndex = 0;
            // 
            // listViewEpisode
            // 
            this.listViewEpisode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewEpisode.FullRowSelect = true;
            this.listViewEpisode.Location = new System.Drawing.Point(10, 10);
            this.listViewEpisode.Name = "listViewEpisode";
            this.listViewEpisode.Size = new System.Drawing.Size(401, 551);
            this.listViewEpisode.TabIndex = 0;
            this.listViewEpisode.UseCompatibleStateImageBehavior = false;
            this.listViewEpisode.View = System.Windows.Forms.View.Details;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.listViewDirectory, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(10, 10);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 74.11765F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.88235F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 391F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(396, 551);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.flowLayoutPanel1, 2);
            this.flowLayoutPanel1.Controls.Add(this.btnAddDirectory);
            this.flowLayoutPanel1.Controls.Add(this.btnRemoveDirectory);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 121);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(390, 35);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // btnAddDirectory
            // 
            this.btnAddDirectory.AutoSize = true;
            this.btnAddDirectory.Location = new System.Drawing.Point(306, 3);
            this.btnAddDirectory.Name = "btnAddDirectory";
            this.btnAddDirectory.Size = new System.Drawing.Size(81, 23);
            this.btnAddDirectory.TabIndex = 0;
            this.btnAddDirectory.Text = "Add Directory";
            this.btnAddDirectory.UseVisualStyleBackColor = true;
            this.btnAddDirectory.Click += new System.EventHandler(this.btnAddDirectory_Click);
            // 
            // btnRemoveDirectory
            // 
            this.btnRemoveDirectory.AutoSize = true;
            this.btnRemoveDirectory.Location = new System.Drawing.Point(198, 3);
            this.btnRemoveDirectory.Name = "btnRemoveDirectory";
            this.btnRemoveDirectory.Size = new System.Drawing.Size(102, 23);
            this.btnRemoveDirectory.TabIndex = 1;
            this.btnRemoveDirectory.Text = "Remove Directory";
            this.btnRemoveDirectory.UseVisualStyleBackColor = true;
            this.btnRemoveDirectory.Click += new System.EventHandler(this.btnRemoveDirectory_Click);
            // 
            // listViewDirectory
            // 
            this.listViewDirectory.CheckBoxes = true;
            this.tableLayoutPanel1.SetColumnSpan(this.listViewDirectory, 2);
            this.listViewDirectory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewDirectory.FullRowSelect = true;
            this.listViewDirectory.Location = new System.Drawing.Point(0, 0);
            this.listViewDirectory.Margin = new System.Windows.Forms.Padding(0);
            this.listViewDirectory.Name = "listViewDirectory";
            this.listViewDirectory.Size = new System.Drawing.Size(396, 118);
            this.listViewDirectory.TabIndex = 0;
            this.listViewDirectory.UseCompatibleStateImageBehavior = false;
            this.listViewDirectory.View = System.Windows.Forms.View.Details;
            this.listViewDirectory.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.directoryListView_ItemCheck);
            // 
            // AnimeOverviewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 571);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "AnimeOverviewer";
            this.Text = "Animelist";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AnimeOverviewer_FormClosing);
            this.Load += new System.EventHandler(this.AnimeOverviewer_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView listViewEpisode;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListView listViewDirectory;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnAddDirectory;
        private System.Windows.Forms.Button btnRemoveDirectory;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}

