using TermProject2025.Forms;
using TermProject2025.Data;

namespace TermProject2025
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var context = new MyPassDbContext())
            {
                context.Database.EnsureCreated();
            }

            ApplicationConfiguration.Initialize();
            Application.Run(new LoginForm());
        }
    }
}