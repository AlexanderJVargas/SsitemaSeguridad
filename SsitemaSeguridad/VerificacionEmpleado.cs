using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SsitemaSeguridad
{
    using System;

    namespace SistemaDeSeguridad
    {
        public class VerificacionEmpleado : VerificacionAcceso
        {
            private string usuarioEmpleado;
            private string passwordEmpleado;

            public override bool CapturarCredenciales(string usuario, string password)
            {
                usuarioEmpleado = usuario;
                passwordEmpleado = password;
                Console.WriteLine("Capturando credenciales del empleado...");
                return true;
            }

            public override bool ValidarCredenciales()
            {
                Console.WriteLine("Validando credenciales del empleado...");
                return usuarioEmpleado == "empleado1" && passwordEmpleado == "ClaveSegura";
            }

            public override void VerificarNivelAcceso()
            {
                Console.WriteLine("Verificando nivel de acceso del empleado...");
            }

            public override void RegistrarIntento()
            {
                Console.WriteLine("Registrando intento de acceso del empleado...");
            }

            public override void NotificarResultado()
            {
                Console.WriteLine("Acceso autorizado al empleado.");
            }
        }
    }

}
