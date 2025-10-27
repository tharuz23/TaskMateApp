using System;
using System.Windows.Forms;

namespace TaskMateApp
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // This line decides which form opens first 👇
            Application.Run(new HomePage());
        }
    }
}
