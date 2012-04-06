using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Security;
using System.Runtime.InteropServices;

namespace Kerr.CredentialSetManager
{
    public partial class EditCredentialDialog : Form
    {
        public EditCredentialDialog()
        {
            InitializeComponent();

            m_password.UseSystemPasswordChar = true;
        }

        protected override void OnLoad(EventArgs args)
        {
            base.OnLoad(args);

            m_targetName.Text = m_credential.TargetName;

            switch (m_credential.Type)
            {
                case CredentialType.Generic:
                {
                    m_typeGeneric.Checked = true;
                    break;
                }
                case CredentialType.DomainPassword:
                {
                    m_typeDomainPassword.Checked = true;
                    break;
                }
                case CredentialType.DomainVisiblePassword:
                {
                    m_typeDomainVisiblePassword.Checked = true;
                    break;
                }
                case CredentialType.DomainCertificate:
                {
                    m_typeDomainCertificate.Checked = true;
                    break;
                }
                default:
                {
                    Debug.Assert(false);
                    break;
                }
            }

            switch (m_credential.Persistence)
            {
                case CredentialPersistence.Session:
                {
                    m_persistenceSession.Checked = true;
                    break;
                }
                case CredentialPersistence.LocalComputer:
                {
                    m_persistenceLocalComputer.Checked = true;
                    break;
                }
                case CredentialPersistence.Enterprise:
                {
                    m_persistenceEnterprise.Checked = true;
                    break;
                }
                default:
                {
                    Debug.Assert(false);
                    break;
                }
            }

            m_userName.Text = m_credential.UserName;

            IntPtr bstr = Marshal.SecureStringToBSTR(m_credential.Password);

            try
            {
                m_password.Text = Marshal.PtrToStringBSTR(bstr);
            }
            finally
            {
                Marshal.FreeBSTR(bstr);
            }

            m_description.Text = m_credential.Description;
        }

        public Credential Credential
        {
            get
            {
                return m_credential;
            }
            set
            {
                m_credential = value;
            }
        }

        private CredentialPersistence GetPersistence()
        {
            CredentialPersistence persistence;

            if (m_persistenceSession.Checked)
            {
                persistence = CredentialPersistence.Session;
            }
            else if (m_persistenceLocalComputer.Checked)
            {
                persistence = CredentialPersistence.LocalComputer;
            }
            else
            {
                Debug.Assert(m_persistenceEnterprise.Checked);
                persistence = CredentialPersistence.Enterprise;
            }

            return persistence;
        }

        private void OkEventHandler(object sender, 
                                    EventArgs args)
        {
            Credential credential = null;

            try
            {
                credential = new Credential(m_credential.TargetName,
                                            m_credential.Type);

                SecureString password = new SecureString();

                foreach (char element in m_password.Text)
                {
                    password.AppendChar(element);
                }

                credential.UserName = m_userName.Text;
                credential.Password = password;
                credential.Persistence = GetPersistence();
                credential.Description = m_description.Text;

                credential.Save();
                m_credential = credential;

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception e)
            {
                if (null != credential)
                {
                    credential.Dispose();
                }

                MessageBox.Show(e.Message,
                                Text,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        Credential m_credential;
    }
}