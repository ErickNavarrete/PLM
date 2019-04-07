using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text;

namespace PLM
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MyContext());
        }

        public class MyContext : ApplicationContext
        {
            public MyContext()
            {
                Application.Idle += new EventHandler(Application_Idle);
                string path = Path.GetFullPath("Conexion.ini");
                if (File.Exists(path))
                {
                    Vista.LoginVista view = new Vista.LoginVista();
                    view.Show();
                }
                else
                {                   
                    using (FileStream fs = File.Create(path))
                    {
                        Byte[] info = new UTF8Encoding(true).GetBytes("[Conexion]");
                        fs.Write(info, 0, info.Length);
                        Byte[] infoD = new UTF8Encoding(true).GetBytes("[Dynamic]");
                        fs.Write(infoD, 0, infoD.Length);
                    }
                    Clases.ConfigIni config = new Clases.ConfigIni(path);
                    config.EscribirValores("Conexion", "Host", ".");
                    config.EscribirValores("Conexion", "Bd", "PLM");                    
                    config.EscribirValores("Conexion", "Id", "sa");
                    config.EscribirValores("Conexion", "Password", "12345");
                    config.EscribirValores("Dynamic", "Host", ".");
                    config.EscribirValores("Dynamic", "Bd", "PLM");
                    config.EscribirValores("Dynamic", "Id", "sa");
                    config.EscribirValores("Dynamic", "Password", "12345");
                    Vista.LoginVista view = new Vista.LoginVista();
                    view.Show();
                }
            }

            void Application_Idle(object sender, EventArgs e)
            {
                if (Application.OpenForms.Count == 0)
                {
                    Application.Exit();
                }
            }
        }
    }
}
