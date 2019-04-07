using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.NetworkInformation;
using MetroFramework.Controls;
using ArcangelDialogs;
using System.Windows.Forms;
using PLM.Modelo;
using System.Data.Entity;
using System.Data;

namespace PLM
{
    public static class GLOBALS
    {
        private static string _ip, _mac, _user, _departamento;

        public static string USUARIO
        {
            get { return _user; }
            set { _user = value; }
        }

        public static string DEPARTAMENTO
        {
            get { return _departamento; }
            set { _departamento = value; }
        }

        public static string IP
        {
            get { return _ip; }
            set { _ip = value; }
        }

        public static string MacAddress
        {
            get { return _mac; }
            set { _mac = value; }
        }

        public static void ObtenerIP()
        {
            IPHostEntry host;
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily.ToString() == "InterNetwork")
                {
                    IP = ip.ToString();
                }
                else
                {
                    IP = "N/D";
                }
            }
        }

        public static void ObtenerMAC()
        {
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if ((nic.NetworkInterfaceType == NetworkInterfaceType.Ethernet || nic.NetworkInterfaceType == NetworkInterfaceType.Wireless80211) && nic.OperationalStatus == OperationalStatus.Up)
                {
                    MacAddress = nic.GetPhysicalAddress().ToString();
                }
                else
                {
                    MacAddress = "N/D";
                }
            }
        }

        public static void Permisos(MetroButton alta, MetroButton actualizar, MetroButton eliminar)
        {
            using (PLMContext db = new PLMContext())
            {
                var datosUsuario = db.Usuarios.Where(x => x.Usser == USUARIO).Select(x => x).ToList().FirstOrDefault();
                if(datosUsuario.Agregar == 0)
                {
                    alta.Enabled = false;
                }
                if (datosUsuario.Modificar == 0)
                {
                    actualizar.Enabled = false;
                }
                if (datosUsuario.Eliminar == 0)
                {
                    eliminar.Enabled = false;
                }
            }
        }

        public static void Permisos(MetroButton alta, MetroButton actualizar, MetroButton eliminar, MetroButton guardar)
        {
            using (PLMContext db = new PLMContext())
            {
                var datosUsuario = db.Usuarios.Where(x => x.Usser == USUARIO).Select(x => x).ToList().FirstOrDefault();
                if (datosUsuario.Agregar == 0)
                {
                    alta.Enabled = false;
                    guardar.Enabled = false;
                }
                if (datosUsuario.Modificar == 0)
                {
                    actualizar.Enabled = false;
                    guardar.Enabled = false;
                }
                if (datosUsuario.Eliminar == 0)
                {
                    eliminar.Enabled = false;
                }
            }
        }

    }
}
