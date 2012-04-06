using System;
using System.Windows.Forms;

namespace Kerr.CredentialSetManager
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new MainWindow());
        }
    }
}