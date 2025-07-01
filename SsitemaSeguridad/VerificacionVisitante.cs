using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SsitemaSeguridad
{
    public class VerificacionVisitante : VerificacionAcceso
    {
        private string usuarioVisitante;
        private string passwordVisitante;

        public override bool CapturarCredenciales(string usuario, string password)
        {
            usuarioVisitante = usuario;
            passwordVisitante = password;
            Console.WriteLine("Capturando credenciales del visitante...");
            return true;
        }

        public override bool ValidarCredenciales()
        {
            Console.WriteLine("Validando credenciales del visitante...");
            return usuarioVisitante == "visitante1" && passwordVisitante == "ClaveTemporal";
        }

        public override void VerificarNivelAcceso()
        {
            Console.WriteLine("Verificando nivel de acceso del visitante...");
        }

        public override void RegistrarIntento()
        {
            Console.WriteLine("Registrando intento de acceso del visitante...");
        }

        public override void NotificarResultado()
        {
            Console.WriteLine("Acceso temporal autorizado para el visitante.");
        }
    }
}

