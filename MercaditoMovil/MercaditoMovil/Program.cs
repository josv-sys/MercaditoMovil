using System;
using System.Windows.Forms;
using ReaLTaiizor.Manager;

namespace MercaditoMovil.Views.WinForms
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            // Forzar que use SIEMPRE System.Windows.Forms.Application
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);

            // Tema oscuro global
            var skin = MaterialSkinManager.Instance;
            skin.Theme = MaterialSkinManager.Themes.DARK;

            // Abrir Login
            System.Windows.Forms.Application.Run(new FrmLogin());
        }
    }
}


