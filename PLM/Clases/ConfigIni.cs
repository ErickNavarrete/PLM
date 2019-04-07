using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;

namespace PLM.Clases
{
    public class ConfigIni
    {
        public static string path;
        private static string _host;       
        private static string _bd;
        private static string _id;
        private static string _password;
        private static string _hostd;
        private static string _bdd;
        private static string _idd;
        private static string _passwordd;

        public static string Host { get { return _host; } set { _host = value; } }
        public static string Bd { get { return _bd; } set { _bd = value; } }        
        public static string Id { get { return _id; } set { _id = value; } }
        public static string Password { get { return _password; } set { _password = value; } }
        public static string HostDynamic { get { return _hostd; } set { _hostd = value; } }
        public static string BdDynamic { get { return _bdd; } set { _bdd = value; } }
        public static string IdDynamic { get { return _idd; } set { _idd = value; } }
        public static string PasswordDynamic { get { return _passwordd; } set { _passwordd = value; } }

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section,
          string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section,
                 string key, string def, StringBuilder retVal,
            int size, string filePath);

        public ConfigIni(string INIPath)
        {
            try
            {
                path = INIPath;
                Host = LeerValores("Conexion", "Host");
                Bd = LeerValores("Conexion", "Bd");              
                Id = LeerValores("Conexion", "Id");
                Password = LeerValores("Conexion", "Password");
                HostDynamic = LeerValores("Dynamic", "Host");
                BdDynamic = LeerValores("Dynamic", "Bd");
                IdDynamic = LeerValores("Dynamic", "Id");
                PasswordDynamic = LeerValores("Dynamic", "Password");
            }
            catch (Exception ex)
            {
                
            }
        }

        public string LeerValores(string Section, string Key)
        {
            if (Section != string.Empty && Key != string.Empty)
            {
                string valor = string.Empty;
                StringBuilder temp = new StringBuilder(255);
                int i = GetPrivateProfileString(Section, Key, "", temp, 255, path);
                valor = Deserializar(temp.ToString());
                return valor;
            }
            else
            {
                return string.Empty;
            }
        }

        private byte[] Serializar(string valores)
        {
            BinaryFormatter FormateoBinario = new BinaryFormatter();
            MemoryStream MemoriaSecuencial = new MemoryStream();
            FormateoBinario.Serialize(MemoriaSecuencial, valores);
            byte[] arreglo = MemoriaSecuencial.ToArray();
            return arreglo;
        }

        private string ConvertirCadena(byte[] conceptos)
        {
            try
            {
                string cadena = Convert.ToBase64String(conceptos);
                return cadena;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return "Error";
        }

        private string Deserializar(string cadena)
        {
            if (cadena != string.Empty)
            {
                string Conceptos;
                BinaryFormatter FormateoBinario = new BinaryFormatter();
                MemoryStream MemoriaSecuencial2 = new MemoryStream(Convert.FromBase64String(cadena));
                Conceptos = FormateoBinario.Deserialize(MemoriaSecuencial2) as string;
                return Conceptos;
            }
            else
            {
                return string.Empty;
            }
        }
        public void EscribirValores(string Section, string Key, string Value)
        {

            WritePrivateProfileString(Section, Key, ConvertirCadena(Serializar(Value)), path);
        }
    }
}
