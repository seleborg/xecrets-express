using System;
using System.Windows.Forms;

namespace Kerr.PromptBuilder
{
    class EntryPoint
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new MainWindow());
        }
    }
}
