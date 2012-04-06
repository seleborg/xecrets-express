using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Security;
using System.Security.Principal;

namespace Kerr.CredentialSetManager
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();

            Text = string.Format(Text,
                                 WindowsIdentity.GetCurrent().Name);

            m_genericGroup = new ListViewGroup("Generic Credentials");
            m_list.Groups.Add(m_genericGroup);

            m_domainPasswordGroup = new ListViewGroup("Domain Password Credentials");
            m_list.Groups.Add(m_domainPasswordGroup);

            m_domainCertificateGroup = new ListViewGroup("Domain Certificate Credentials");
            m_list.Groups.Add(m_domainCertificateGroup);

            m_domainVisiblePasswordGroup = new ListViewGroup("Domain Visible Password Credentials");
            m_list.Groups.Add(m_domainVisiblePasswordGroup);
        }

        protected override void OnClosed(EventArgs args)
        {
            base.OnClosed(args);

            ClearList();
        }

        protected override void OnLoad(EventArgs args)
        {
            base.OnLoad(args);

            LoadCredentials();
        }

        private void LinkClickedEventHandler(object sender,
                                             LinkLabelLinkClickedEventArgs args)
        {
            Control control = sender as Control;
            Debug.Assert(null != control);

            using (Process process = new Process())
            {
                process.StartInfo.FileName = control.Tag.ToString();
                process.Start();
            }
        }

        private void SelectionChangedEventHandler(object sender, 
                                                  EventArgs args)
        {
            m_remove.Enabled = 0 < m_list.SelectedItems.Count;
            m_edit.Enabled = 1 == m_list.SelectedItems.Count;
        }

        private void AddEventHandler(object sender,
                                     EventArgs args)
        {
            using (AddCredentialDialog dialog = new AddCredentialDialog())
            {
                if (DialogResult.OK == dialog.ShowDialog(this))
                {
                    AddCredentialToList(dialog.Credential);
                    m_rename.Enabled = true;
                }
            }
        }

        private void EditEventHandler(object sender, 
                                      EventArgs args)
        {
            Debug.Assert(1 == m_list.SelectedItems.Count);

            using (EditCredentialDialog dialog = new EditCredentialDialog())
            {
                ListViewItem item = m_list.SelectedItems[0];

                dialog.Credential = item.Tag as Credential;

                if (DialogResult.OK == dialog.ShowDialog(this))
                {
                    using (Credential credential = dialog.Credential)
                    {
                        ((IDisposable)item.Tag).Dispose();
                        int index = item.Index;
                        item.Remove();

                        ListViewItem newItem = AddCredentialToList(credential);
                        newItem.Selected = true;
                    }                    
                }
            }
        }

        private void RenameEventHandler(object sender,
                                        EventArgs args)
        {
            m_list.Focus();
            m_list.FocusedItem.BeginEdit();
        }

        private void AfterLabelEditEventHandler(object sender,
                                                LabelEditEventArgs args)
        {
            args.CancelEdit = true;

            try
            {
                if (null != args.Label && 0 < args.Label.Length)
                {
                    Credential credential = m_list.FocusedItem.Tag as Credential;

                    credential.ChangeTargetName(args.Label);
                    args.CancelEdit = false;

                    // TODO: update date modified column
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message,
                                Text,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void RemoveEventHandler(object sender,
                                        EventArgs args)
        {
            Debug.Assert(0 < m_list.SelectedItems.Count);

            if (DialogResult.Yes == MessageBox.Show("Are you sure you want to delete the selected credentials?",
                                                    Text,
                                                    MessageBoxButtons.YesNo,
                                                    MessageBoxIcon.Question))
            {
                ListViewItem[] selectedItems = new ListViewItem[m_list.SelectedItems.Count];

                m_list.SelectedItems.CopyTo(selectedItems,
                                            0);

                foreach (ListViewItem item in selectedItems)
                {
                    Credential credential = item.Tag as Credential;
                    credential.Delete();
                    credential.Dispose();

                    item.Remove();
                }

                if (0 == m_list.Items.Count)
                {
                    m_rename.Enabled = false;
                }
            }
        }

        private void LoadEventHandler(object sender,
                                      EventArgs args)
        {
            LoadCredentials();
        }

        private void LoadCredentials()
        {
            using (CredentialSet credentials = new CredentialSet(m_filter.Text))
            {
                ClearList();

                foreach (Credential credential in credentials)
                {
                    AddCredentialToList(credential);
                }
            }

            if (0 < m_list.Items.Count)
            {
                m_rename.Enabled = true;
            }
        }

        private ListViewItem AddCredentialToList(Credential credential)
        {
            string[] text = new string[7];

            int column = -1;

            text[++column] = credential.TargetName;
            text[++column] = credential.UserName;

            if (m_showPasswords.Checked)
            {
                IntPtr bstr = Marshal.SecureStringToBSTR(credential.Password);

                try
                {
                    text[++column] = Marshal.PtrToStringBSTR(bstr);
                }
                finally
                {
                    Marshal.FreeBSTR(bstr);
                }
            }
            else
            {
                if (1 == credential.SecrectLength)
                {
                    text[++column] = "1 byte";
                }
                else
                {
                    text[++column] = string.Format("{0} bytes",
                                                   credential.SecrectLength);
                }
            }

            text[++column] = credential.Persistence.ToString();
            text[++column] = credential.LastWriteTime.ToString();
            text[++column] = credential.Description;

            ListViewItem item = new ListViewItem(text);

            switch (credential.Type)
            {
                case CredentialType.Generic:
                    {
                        item.Group = m_genericGroup;
                        break;
                    }
                case CredentialType.DomainPassword:
                    {
                        item.Group = m_domainPasswordGroup;
                        break;
                    }
                case CredentialType.DomainCertificate:
                    {
                        item.Group = m_domainCertificateGroup;
                        break;
                    }
                case CredentialType.DomainVisiblePassword:
                    {
                        item.Group = m_domainVisiblePasswordGroup;
                        break;
                    }
            }

            item.Tag = new Credential(credential);

            m_list.Items.Add(item);

            return item;
        }

        private void ClearList()
        {
            foreach (ListViewItem item in m_list.Items)
            {
                ((IDisposable)item.Tag).Dispose();
            }

            m_list.Items.Clear();
        }

        private readonly ListViewGroup m_genericGroup;
        private readonly ListViewGroup m_domainPasswordGroup;
        private readonly ListViewGroup m_domainCertificateGroup;
        private readonly ListViewGroup m_domainVisiblePasswordGroup;
    }
}