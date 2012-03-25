using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Forms;
using Kerr;

namespace XecretsSystray
{
    class WindowsCredentials
    {
        private String m_username;
        private SecureString m_password = new SecureString();

        public static WindowsCredentials LoadOrPrompt(System.Windows.Window mainWindow)
        {
            WindowsCredentials cred = new WindowsCredentials();

            if (cred.Prompt(mainWindow))
            {
                return cred;
            }
            else
            {
                return null;
            }
        }


        private bool Prompt(System.Windows.Window mainWindow)
        {
            using (Kerr.PromptForCredential dialog = new Kerr.PromptForCredential())
            {
                dialog.Title = "Xecrets";
                dialog.Message = "Please sign in to Xecrets to download your list of secrets:";
                //dialog.Banner = Images.Banner;
                dialog.UserName = "me@mail.com";

                dialog.DoNotPersist = true;
                dialog.ShowSaveCheckBox = true;

                WindowInteropHelper helper = new WindowInteropHelper(mainWindow);
                System.Windows.Forms.IWin32Window parent = new OldWindow(helper.Handle);

                if (DialogResult.OK == dialog.ShowDialog(parent))
                {
                    m_username = dialog.UserName;
                    m_password = dialog.Password;
                    m_password.MakeReadOnly();

                    String peek = SecureStringToString(m_password);
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


        public String Password
        {
            get { return SecureStringToString(m_password); }
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


        public static String SecureStringToString(SecureString value)
        {
            IntPtr bstr = Marshal.SecureStringToBSTR(value);

            try
            {
                return Marshal.PtrToStringBSTR(bstr);
            }
            finally
            {
                Marshal.FreeBSTR(bstr);
            }
        }
    }
}
