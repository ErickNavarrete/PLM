using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArcangelDialogs;
using MetroFramework.Controls;
using PLM.Modelo;

namespace PLM.Controlador
{
    class ResurtimientoController
    {
        public Dynamics dbd = new Dynamics();

        public bool GetClientes(MetroComboBox comboBox)
        {
            try
            {
                var clientes = dbd.Inventario2();

                comboBox.Items.Clear();

                foreach (Inventory item in clientes)
                {
                    comboBox.Items.Add(item.Cliente);
                }

                return true;
            }
            catch (Exception ex)
            {
                Dialogs.Show(ex.Message, DialogsType.Error);
                return false;
            }
        }
    }
}
