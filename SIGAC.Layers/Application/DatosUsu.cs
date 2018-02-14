using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGAC.Layers.Application
{
    public class DatosUsu
    {
        public string UsuarioName { get; private set; }
        public string IpUsuario { get; private set; }
        public DateTime Fecha { get; private set; }
        public string MachineName { get; private set; }

        public DatosUsu()
        {
            UsuarioName = "Usuario de Prueba";
            IpUsuario = MachineInformation.LocalIpAddress();
            MachineName = $"MAC: {MachineInformation.GetMacAddress()}";
            Fecha = DateTime.Now;
        }
    }
}
