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


        public bool PromptAgain(System.Windows.Window mainWindow, bool passwordWasInvalid)
        {
            return Prompt(mainWindow, true);
        }


        private bool Prompt(System.Windows.Window mainWindow, bool reprompt)
        {
            using (Kerr.PromptForCredential dialog = new Kerr.PromptForCredential())
            {
                dialog.Title = "Xecrets";
                dialog.Message = "Please sign in to Xecrets to download your list of secrets:";
                dialog.TargetName = "Xecrets";

                dialog.DoNotPersist = false;
                dialog.ShowSaveCheckBox = true;
                dialog.GenericCredentials = true;
                dialog.ExpectConfirmation = true;

                if (reprompt)
                {
                    dialog.IncorrectPassword = true;
                    dialog.AlwaysShowUI = true;
                }

                WindowInteropHelper helper = new WindowInteropHelper(mainWindow);
                System.Windows.Forms.IWin32Window parent = new OldWindow(helper.Handle);

                if (DialogResult.OK == dialog.ShowDialog(parent))
                {
                    if (dialog.SaveChecked)
                    {
                        dialog.ConfirmCredentials();
                    }

                    m_username = dialog.UserName;
                    m_password = dialog.Password.Copy();
                    m_password.MakeReadOnly();

                    return true;
                }
                else
                {
                    return false;
                }
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
