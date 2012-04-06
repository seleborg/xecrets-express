using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Security;

namespace Kerr.CredentialSetManager
{
    public partial class AddCredentialDialog : Form
    {
        public AddCredentialDialog()
        {
            InitializeComponent();

            m_password.UseSystemPasswordChar = true;

            Disposed += new EventHandler(DisposedEventHandler);
        }

        void DisposedEventHandler(object sender, 
                                  EventArgs args)
        {
            if (null != m_credential)
            {
                m_credential.Dispose();
            }
        }

        public Credential Credential
        {
            get
            {
                return m_credential;
            }
        }

        private CredentialType GetCredentialType()
        {
            CredentialType type;

            if (m_typeGeneric.Checked)
            {
                type = CredentialType.Generic;
            }
            else if (m_typeDomainPassword.Checked)
            {
                type = CredentialType.DomainPassword;
            }
            else if (m_typeDomainVisiblePassword.Checked)
            {
                type = CredentialType.DomainVisiblePassword;
            }
            else
            {
                Debug.Assert(m_typeDomainCertificate.Checked);
                type = CredentialType.DomainCertificate;
            }

            return type;
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

        private void AddEventHandler(object sender, 
                                     EventArgs args)
        {
            try
            {
                if (Credential.Exists(m_targetName.Text,
                                      GetCredentialType()))
                {
                    throw new Exception("Credentials with the given target name and type already exist.");
                }

                SecureString password = new SecureString();

                foreach (char element in m_password.Text)
                {
                    password.AppendChar(element);
                }

                m_credential = new Credential(m_targetName.Text,
                                              GetCredentialType(),
                                              m_userName.Text,
                                              password,
                                              GetPersistence(),
                                              m_description.Text);

                m_credential.Save();

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception e)
            {
                if (null != m_credential)
                {
                    m_credential.Dispose();
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