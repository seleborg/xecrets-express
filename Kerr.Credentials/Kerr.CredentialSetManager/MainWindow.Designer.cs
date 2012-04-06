namespace Kerr.CredentialSetManager
{
    partial class MainWindow
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
            System.Windows.Forms.Panel panel;
            System.Windows.Forms.Label filterLabel;
            System.Windows.Forms.Button load;
            System.Windows.Forms.ColumnHeader targetName;
            System.Windows.Forms.ColumnHeader userName;
            System.Windows.Forms.ColumnHeader password;
            System.Windows.Forms.ColumnHeader persistence;
            System.Windows.Forms.ColumnHeader lastWritten;
            System.Windows.Forms.ColumnHeader description;
            System.Windows.Forms.StatusStrip statusBar;
            System.Windows.Forms.LinkLabel label;
            this.m_rename = new System.Windows.Forms.Button();
            this.m_filter = new System.Windows.Forms.TextBox();
            this.m_showPasswords = new System.Windows.Forms.CheckBox();
            this.m_remove = new System.Windows.Forms.Button();
            this.m_add = new System.Windows.Forms.Button();
            this.m_edit = new System.Windows.Forms.Button();
            this.m_list = new System.Windows.Forms.ListView();
            panel = new System.Windows.Forms.Panel();
            filterLabel = new System.Windows.Forms.Label();
            load = new System.Windows.Forms.Button();
            targetName = new System.Windows.Forms.ColumnHeader();
            userName = new System.Windows.Forms.ColumnHeader();
            password = new System.Windows.Forms.ColumnHeader();
            persistence = new System.Windows.Forms.ColumnHeader();
            lastWritten = new System.Windows.Forms.ColumnHeader();
            description = new System.Windows.Forms.ColumnHeader();
            statusBar = new System.Windows.Forms.StatusStrip();
            label = new System.Windows.Forms.LinkLabel();
            panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel
            // 
            panel.Controls.Add(this.m_rename);
            panel.Controls.Add(filterLabel);
            panel.Controls.Add(this.m_filter);
            panel.Controls.Add(this.m_showPasswords);
            panel.Controls.Add(load);
            panel.Controls.Add(this.m_remove);
            panel.Controls.Add(this.m_add);
            panel.Controls.Add(this.m_edit);
            panel.Dock = System.Windows.Forms.DockStyle.Top;
            panel.Location = new System.Drawing.Point(0, 0);
            panel.Name = "panel";
            panel.Size = new System.Drawing.Size(798, 34);
            panel.TabIndex = 0;
            // 
            // m_rename
            // 
            this.m_rename.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_rename.AutoSize = true;
            this.m_rename.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.m_rename.Enabled = false;
            this.m_rename.Location = new System.Drawing.Point(663, 5);
            this.m_rename.Name = "m_rename";
            this.m_rename.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.m_rename.Size = new System.Drawing.Size(64, 23);
            this.m_rename.TabIndex = 6;
            this.m_rename.Text = "Rename";
            this.m_rename.Click += new System.EventHandler(this.RenameEventHandler);
            // 
            // filterLabel
            // 
            filterLabel.AutoSize = true;
            filterLabel.Location = new System.Drawing.Point(8, 9);
            filterLabel.Name = "filterLabel";
            filterLabel.Size = new System.Drawing.Size(68, 13);
            filterLabel.TabIndex = 0;
            filterLabel.Text = "Filter target:";
            // 
            // m_filter
            // 
            this.m_filter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_filter.Location = new System.Drawing.Point(79, 6);
            this.m_filter.Name = "m_filter";
            this.m_filter.Size = new System.Drawing.Size(307, 21);
            this.m_filter.TabIndex = 1;
            // 
            // m_showPasswords
            // 
            this.m_showPasswords.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_showPasswords.AutoSize = true;
            this.m_showPasswords.Location = new System.Drawing.Point(392, 9);
            this.m_showPasswords.Name = "m_showPasswords";
            this.m_showPasswords.Size = new System.Drawing.Size(106, 17);
            this.m_showPasswords.TabIndex = 2;
            this.m_showPasswords.Text = "Show passwords";
            // 
            // load
            // 
            load.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            load.AutoSize = true;
            load.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            load.Location = new System.Drawing.Point(500, 5);
            load.Name = "load";
            load.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            load.Size = new System.Drawing.Size(48, 23);
            load.TabIndex = 3;
            load.Text = "Load";
            load.Click += new System.EventHandler(this.LoadEventHandler);
            // 
            // m_remove
            // 
            this.m_remove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_remove.AutoSize = true;
            this.m_remove.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.m_remove.Enabled = false;
            this.m_remove.Location = new System.Drawing.Point(729, 5);
            this.m_remove.Name = "m_remove";
            this.m_remove.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.m_remove.Size = new System.Drawing.Size(64, 23);
            this.m_remove.TabIndex = 7;
            this.m_remove.Text = "Remove";
            this.m_remove.Click += new System.EventHandler(this.RemoveEventHandler);
            // 
            // m_add
            // 
            this.m_add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_add.AutoSize = true;
            this.m_add.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.m_add.Location = new System.Drawing.Point(572, 5);
            this.m_add.Name = "m_add";
            this.m_add.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.m_add.Size = new System.Drawing.Size(44, 23);
            this.m_add.TabIndex = 4;
            this.m_add.Text = "Add";
            this.m_add.Click += new System.EventHandler(this.AddEventHandler);
            // 
            // m_edit
            // 
            this.m_edit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_edit.AutoSize = true;
            this.m_edit.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.m_edit.Enabled = false;
            this.m_edit.Location = new System.Drawing.Point(618, 5);
            this.m_edit.Name = "m_edit";
            this.m_edit.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.m_edit.Size = new System.Drawing.Size(43, 23);
            this.m_edit.TabIndex = 5;
            this.m_edit.Text = "Edit";
            this.m_edit.Click += new System.EventHandler(this.EditEventHandler);
            // 
            // targetName
            // 
            targetName.Name = "targetName";
            targetName.Text = "Target Name";
            targetName.Width = 140;
            // 
            // userName
            // 
            userName.Name = "userName";
            userName.Text = "User Name";
            userName.Width = 140;
            // 
            // password
            // 
            password.Name = "password";
            password.Text = "Password";
            password.Width = 100;
            // 
            // persistence
            // 
            persistence.Name = "persistence";
            persistence.Text = "Persistence";
            persistence.Width = 100;
            // 
            // lastWritten
            // 
            lastWritten.Name = "lastWritten";
            lastWritten.Text = "Date Modified";
            lastWritten.Width = 140;
            // 
            // description
            // 
            description.Name = "description";
            description.Text = "Description";
            description.Width = 150;
            // 
            // statusBar
            // 
            statusBar.Location = new System.Drawing.Point(0, 382);
            statusBar.Name = "statusBar";
            statusBar.Size = new System.Drawing.Size(798, 22);
            statusBar.TabIndex = 2;
            statusBar.Text = "statusStrip1";
            // 
            // label
            // 
            label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            label.AutoSize = true;
            label.LinkArea = new System.Windows.Forms.LinkArea(18, 10);
            label.Location = new System.Drawing.Point(5, 386);
            label.Name = "label";
            label.Size = new System.Drawing.Size(155, 18);
            label.TabIndex = 3;
            label.TabStop = true;
            label.Tag = "http://weblogs.asp.net/kennykerr/";
            label.Text = "Copyright 2005 by Kenny Kerr";
            label.UseCompatibleTextRendering = true;
            label.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkClickedEventHandler);
            // 
            // m_list
            // 
            this.m_list.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            targetName,
            userName,
            password,
            persistence,
            lastWritten,
            description});
            this.m_list.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_list.FullRowSelect = true;
            this.m_list.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.m_list.HideSelection = false;
            this.m_list.LabelEdit = true;
            this.m_list.Location = new System.Drawing.Point(0, 34);
            this.m_list.Name = "m_list";
            this.m_list.Size = new System.Drawing.Size(798, 348);
            this.m_list.TabIndex = 1;
            this.m_list.UseCompatibleStateImageBehavior = false;
            this.m_list.View = System.Windows.Forms.View.Details;
            this.m_list.SelectedIndexChanged += new System.EventHandler(this.SelectionChangedEventHandler);
            this.m_list.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.AfterLabelEditEventHandler);
            // 
            // MainWindow
            // 
            this.AcceptButton = load;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 404);
            this.Controls.Add(label);
            this.Controls.Add(this.m_list);
            this.Controls.Add(panel);
            this.Controls.Add(statusBar);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(608, 191);
            this.Name = "MainWindow";
            this.Text = "Credential Set Manager - {0}";
            panel.ResumeLayout(false);
            panel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button m_remove;
        private System.Windows.Forms.TextBox m_filter;
        private System.Windows.Forms.ListView m_list;
        private System.Windows.Forms.CheckBox m_showPasswords;
        private System.Windows.Forms.Button m_add;
        private System.Windows.Forms.Button m_edit;
        private System.Windows.Forms.Button m_rename;
    }
}

