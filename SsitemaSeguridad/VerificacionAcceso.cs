using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SsitemaSeguridad
{
    public abstract class VerificacionAcceso
    {
        public void VerificarAcceso(string usuario, string password)
        {
            if (!CapturarCredenciales(usuario, password))
            {
                Console.WriteLine("Credenciales no capturadas correctamente.");
                return;
            }

            if (!ValidarCredenciales())
            {
                Console.WriteLine("Validación fallida.");
                return;
            }

            VerificarNivelAcceso();
            RegistrarIntento();
            NotificarResultado();
        }

        
        public abstract bool CapturarCredenciales(string usuario, string password);
        public abstract bool ValidarCredenciales();
        public abstract void VerificarNivelAcceso();
        public abstract void RegistrarIntento();
        public abstract void NotificarResultado();
    }
}
    

