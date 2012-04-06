using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Security;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;

namespace Kerr.PromptBuilder
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();

            m_password.UseSystemPasswordChar = true;
        }

        private void FocusEventHandler(object sender, 
                                       EventArgs args)
        {
            Control control = sender as Control;
            Debug.Assert(null != control);

            m_help.Text = control.Tag.ToString();
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

        private void TestEventHandler(object sender, 
                                      EventArgs args)
        {
            try
            {
                using (Kerr.PromptForCredential prompt = new Kerr.PromptForCredential())
                {
                    prompt.TargetName = m_targetName.Text;
                    prompt.UserName = m_userName.Text;

                    prompt.Password = new SecureString();

                    foreach (char element in m_password.Text)
                    {
                        prompt.Password.AppendChar(element);
                    }

                    prompt.Title = m_title.Text;
                    prompt.Message = m_message.Text;

                    if (0 != m_banner.Text.Length)
                    {
                        prompt.Banner = new Bitmap(m_banner.Text);
                    }

                    int errorCode = 0;

                    if (int.TryParse(m_errorCode.Text,
                                    out errorCode))
                    {
                        prompt.ErrorCode = errorCode;
                    }

                    prompt.SaveChecked = m_saveChecked.Checked;

                    prompt.AlwaysShowUI = m_alwaysShowUI.Checked;
                    prompt.CompleteUserName = m_completeUserName.Checked;
                    prompt.DoNotPersist = m_doNotPersist.Checked;
                    prompt.ExcludeCertificates = m_excludeCertificates.Checked;
                    prompt.ExpectConfirmation = m_expectConfirmation.Checked;
                    prompt.GenericCredentials = m_genericCredentials.Checked;
                    prompt.IncorrectPassword = m_incorrectPassword.Checked;
                    prompt.Persist = m_persist.Checked;
                    prompt.RequestAdministrator = m_requestAdministrator.Checked;
                    prompt.RequireCertificate = m_requireCertificate.Checked;
                    prompt.RequireSmartCard = m_requireSmartCard.Checked;
                    prompt.ShowSaveCheckBox = m_showSaveCheckBox.Checked;
                    prompt.UserNameReadOnly = m_userNameReadOnly.Checked;
                    prompt.ValidateUserName = m_validateUserName.Checked;

                    if (DialogResult.OK == prompt.ShowDialog(this))
                    {
                        m_saveChecked.Checked = prompt.SaveChecked;
                        m_userName.Text = prompt.UserName;

                        IntPtr passwordBstr = Marshal.SecureStringToBSTR(prompt.Password);

                        try
                        {
                            m_password.Text = Marshal.PtrToStringBSTR(passwordBstr);
                        }
                        finally
                        {
                            if (IntPtr.Zero != passwordBstr)
                            {
                                Marshal.FreeBSTR(passwordBstr);
                            }
                        }

                        if (prompt.ExpectConfirmation && prompt.SaveChecked)
                        {
                            prompt.ConfirmCredentials();
                        }
                    }
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

        private void HidePasswordEventHandler(object sender, 
                                              EventArgs args)
        {
            m_password.UseSystemPasswordChar = !m_password.UseSystemPasswordChar;
        }

        private void AlwaysShowUICheckedChangedEventHandler(object sender, EventArgs args)
        {
            if (m_alwaysShowUI.Checked)
            {
                m_genericCredentials.Checked = true;
            }
        }

        private void DoNotPersistCheckedChangedEventHandler(object sender, EventArgs args)
        {
            if (m_doNotPersist.Checked)
            {
                m_expectConfirmation.Checked = false;
                m_persist.Checked = false;
            }
            else
            {
                m_showSaveCheckBox.Checked = false;
            }
        }

        private void ExcludeCertificatesCheckedChangedEventHandler(object sender, EventArgs args)
        {
            if (m_excludeCertificates.Checked)
            {
                m_requireCertificate.Checked = false;
                m_requireSmartCard.Checked = false;
            }
        }

        private void ExpectConfirmationCheckedChangedEventHandler(object sender, EventArgs args)
        {
            if (m_expectConfirmation.Checked)
            {
                m_doNotPersist.Checked = false;
            }
        }

        private void GenericCredentialsCheckedChangedEventHandler(object sender, EventArgs args)
        {
            if (!m_genericCredentials.Checked)
            {
                m_alwaysShowUI.Checked = false;
            }
        }

        private void IncorrectPasswordCheckedChangedEventHandler(object sender, EventArgs args)
        {

        }

        private void PersistCheckedChangedEventHandler(object sender, EventArgs args)
        {
            if (m_persist.Checked)
            {
                m_doNotPersist.Checked = false;
            }
        }

        private void RequestAdministratorCheckedChangedEventHandler(object sender, EventArgs args)
        {

        }

        private void RequireCertificateCheckedChangedEventHandler(object sender, EventArgs args)
        {
            if (m_requireCertificate.Checked)
            {
                m_requireSmartCard.Checked = false;
                m_excludeCertificates.Checked = false;
            }
        }

        private void RequireSmartCardCheckedChangedEventHandler(object sender, EventArgs args)
        {
            if (m_requireSmartCard.Checked)
            {
                m_requireCertificate.Checked = false;
                m_excludeCertificates.Checked = false;
            }
        }

        private void ServerCredentialCheckedChangedEventHandler(object sender, EventArgs args)
        {

        }

        private void ShowSaveCheckBoxCheckedChangedEventHandler(object sender, EventArgs args)
        {
            if (m_showSaveCheckBox.Checked)
            {
                m_doNotPersist.Checked = true;
            }
        }

        private void TargetNameChangedEventHandler(object sender, 
                                                   EventArgs args)
        {
            if (0 == m_targetName.Text.Length)
            {
                m_doNotPersist.Checked = true;
            }
        }

        private void BannerBrowseEventHandler(object sender, 
                                              EventArgs args)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "Bitmap image (*.bmp)|*.bmp|All files (*.*)|*.*";

                if (DialogResult.OK == dialog.ShowDialog(this))
                {
                    m_banner.Text = dialog.FileName;
                }
            }
        }

        private void CopyCppCodeEventHandler(object sender,
                                             EventArgs args)
        {
            CopyCode(true);
        }

        private void CopyCSharpCodeEventHandler(object sender,
                                                EventArgs args)
        {
            CopyCode(false);
        }

        private void CopyCode(bool cpp)
        {
            StringBuilder text = new StringBuilder();

            string tab = null;

            if (cpp)
            {
                text.AppendLine("Kerr::PromptForCredential prompt;");
                tab = string.Empty;
            }
            else
            {
                text.AppendLine("using (Kerr.PromptForCredential prompt = new Kerr.PromptForCredential())");
                text.AppendLine("{");
                tab = "    ";
            }

            if (0 != m_targetName.Text.Length)
            {
                text.AppendFormat("{2}prompt.TargetName = \"{0}\";{1}",
                                  m_targetName.Text,
                                  Environment.NewLine,
                                  tab);
            }

            if (0 != m_userName.Text.Length)
            {
                text.AppendFormat("{2}prompt.UserName = \"{0}\";{1}",
                                  m_userName.Text,
                                  Environment.NewLine,
                                  tab);
            }

            if (0 != m_title.Text.Length)
            {
                text.AppendFormat("{2}prompt.Title = \"{0}\";{1}",
                                  m_title.Text,
                                  Environment.NewLine,
                                  tab);
            }

            if (0 != m_message.Text.Length)
            {
                text.AppendFormat("{2}prompt.Message = \"{0}\";{1}",
                                  m_message.Text,
                                  Environment.NewLine,
                                  tab);
            }

            if (0 != m_banner.Text.Length)
            {
                if (cpp)
                {
                    text.AppendFormat("{2}prompt.Banner = gcnew Drawing::Bitmap(\"{0}\");{1}",
                                      m_banner.Text.Replace("\\", "\\\\"),
                                      Environment.NewLine,
                                      tab);
                }
                else
                {
                    text.AppendFormat("{2}prompt.Banner = new System.Drawing.Bitmap(\"{0}\");{1}",
                                      m_banner.Text.Replace("\\", "\\\\"),
                                      Environment.NewLine,
                                      tab);
                }
            }

            int errorCode = 0;

            if (int.TryParse(m_errorCode.Text,
                             out errorCode))
            {
                text.AppendFormat("{2}prompt.ErrorCode = {0};{1}",
                                  errorCode,
                                  Environment.NewLine,
                                  tab);
            }

            if (m_showSaveCheckBox.Checked)
            {
                text.AppendFormat("{2}prompt.SaveChecked = {0};{1}",
                                  m_saveChecked.Checked ? "true" : "false",
                                  Environment.NewLine,
                                  tab);
            }

            text.AppendLine();

            if (m_alwaysShowUI.Checked) text.AppendFormat("{0}prompt.AlwaysShowUI = true;{1}", tab, Environment.NewLine);
            if (m_completeUserName.Checked) text.AppendFormat("{0}prompt.CompleteUserName = true;{1}", tab, Environment.NewLine);
            if (m_doNotPersist.Checked) text.AppendFormat("{0}prompt.DoNotPersist = true;{1}", tab, Environment.NewLine);
            if (m_excludeCertificates.Checked) text.AppendFormat("{0}prompt.ExcludeCertificates = true;{1}", tab, Environment.NewLine);
            if (m_expectConfirmation.Checked) text.AppendFormat("{0}prompt.ExpectConfirmation = true;{1}", tab, Environment.NewLine);
            if (m_genericCredentials.Checked) text.AppendFormat("{0}prompt.GenericCredentials = true;{1}", tab, Environment.NewLine);
            if (m_incorrectPassword.Checked) text.AppendFormat("{0}prompt.IncorrectPassword = true;{1}", tab, Environment.NewLine);
            if (m_persist.Checked) text.AppendFormat("{0}prompt.Persist = true;{1}", tab, Environment.NewLine);
            if (m_requestAdministrator.Checked) text.AppendFormat("{0}prompt.RequestAdministrator = true;{1}", tab, Environment.NewLine);
            if (m_requireCertificate.Checked) text.AppendFormat("{0}prompt.RequireCertificate = true;{1}", tab, Environment.NewLine);
            if (m_requireSmartCard.Checked) text.AppendFormat("{0}prompt.RequireSmartCard = true;{1}", tab, Environment.NewLine);
            if (m_showSaveCheckBox.Checked) text.AppendFormat("{0}prompt.ShowSaveCheckBox = true;{1}", tab, Environment.NewLine);
            if (m_userNameReadOnly.Checked) text.AppendFormat("{0}prompt.UserNameReadOnly = true;{1}", tab, Environment.NewLine);
            if (m_validateUserName.Checked) text.AppendFormat("{0}prompt.ValidateUserName = true;{1}", tab, Environment.NewLine);

            text.AppendLine();

            if (cpp)
            {
                text.AppendFormat("{0}if (Windows::Forms::DialogResult::OK == prompt.ShowDialog(/* owner */)){1}", tab, Environment.NewLine);
            }
            else
            {
                text.AppendFormat("{0}if (System.Windows.Forms.DialogResult.OK == prompt.ShowDialog(/* owner */)){1}", tab, Environment.NewLine);
            }

            text.AppendFormat("{0}{{{1}", tab, Environment.NewLine);
            text.AppendFormat("{0}    {1}", tab, Environment.NewLine);
            text.AppendFormat("{0}}}{1}", tab, Environment.NewLine);

            if (!cpp)
            {
                text.AppendLine("}");
            }

            Clipboard.SetDataObject(text.ToString(),
                                    true);
        }
    }
}