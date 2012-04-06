using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security;
using System.Text;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Interop;
using Kerr;

namespace XecretsSystray
{
    class WindowsCredentials
    {
        private String m_username;
        private SecureString m_password;
        private Kerr.PromptForCredential m_dialog = new Kerr.PromptForCredential();

        public static WindowsCredentials LoadOrPrompt(System.Windows.Window mainWindow)
        {
            WindowsCredentials cred = new WindowsCredentials();

            if (cred.Prompt(mainWindow, false))
            {
                return cred;
            }
            else
            {
                return null;
            }
        }


        private WindowsCredentials()
        {
            m_dialog.Title = "Xecrets";
            m_dialog.Message = "Please sign in to Xecrets to download your list of secrets:";
            m_dialog.TargetName = "Xecrets";

            m_dialog.DoNotPersist = false;
            m_dialog.ShowSaveCheckBox = true;
            m_dialog.GenericCredentials = true;
            m_dialog.ExpectConfirmation = true;
        }


        public bool PromptAgain(System.Windows.Window mainWindow, bool passwordWasInvalid)
        {
            return Prompt(mainWindow, true);
        }


        private bool Prompt(System.Windows.Window mainWindow, bool reprompt)
        {
            if (reprompt)
            {
                m_dialog.IncorrectPassword = true;
                m_dialog.AlwaysShowUI = true;
            }

            WindowInteropHelper helper = new WindowInteropHelper(mainWindow);
            System.Windows.Forms.IWin32Window parent = new OldWindow(helper.Handle);

            if (DialogResult.OK == m_dialog.ShowDialog(parent))
            {
                m_username = m_dialog.UserName;
                m_password = m_dialog.Password.Copy();
                m_password.MakeReadOnly();

                return true;
            }
            else
            {
                return false;
            }
        }


        public String Username
        {
            get { return m_username; }
        }


        public SecureString Password
        {
            get { return m_password; }
        }


        public void ConfirmThatCredentialsAreValid()
        {
            if (m_dialog.SaveChecked)
            {
                m_dialog.ConfirmCredentials();
            }
        }

        
        private class OldWindow : System.Windows.Forms.IWin32Window
        {
            private readonly System.IntPtr _handle;
            public OldWindow(System.IntPtr handle)
            {
                _handle = handle;
            }
            System.IntPtr System.Windows.Forms.IWin32Window.Handle
            {
                get { return _handle; }
            }
        }
    }
}
