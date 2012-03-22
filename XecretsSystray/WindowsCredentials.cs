using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Forms;
using Kerr;

namespace XecretsSystray
{
    class WindowsCredentials
    {
        public void LoadOrPrompt(System.Windows.Window mainWindow)
        {
            Prompt(mainWindow);
        }

        private void Prompt(System.Windows.Window mainWindow)
        {
            using (Kerr.PromptForCredential dialog = new Kerr.PromptForCredential())
            {
                dialog.Title = "Title";
                dialog.Message = "Message";
                //dialog.Banner = Images.Banner;
                dialog.UserName = "initial user name";

                dialog.DoNotPersist = true;
                dialog.ShowSaveCheckBox = true;

                WindowInteropHelper helper = new WindowInteropHelper(mainWindow);
                System.Windows.Forms.IWin32Window parent = new OldWindow(helper.Handle);

                if (DialogResult.OK == dialog.ShowDialog(parent))
                {
                    // Use credentials wisely...
                }
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
