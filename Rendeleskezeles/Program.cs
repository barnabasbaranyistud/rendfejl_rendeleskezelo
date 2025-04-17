using System.Windows.Forms;

namespace Rendeleskezelo
{
    internal static class Program
    {
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            LoginForm loginForm = new LoginForm();
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                Application.Exit();
                //Application.Run(new MainForm());
            }
            else
            {
                Application.Exit();
            }
        }
    }
}