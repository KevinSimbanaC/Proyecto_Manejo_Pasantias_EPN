using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class Decano : Usuario
    {
        private int idDecano;
        private Boolean activo;

        public int IdDecano { get => idDecano; set => idDecano = value; }
        public bool Activo { get => activo; set => activo = value; }

        public Decano()
        {
        }

        public Decano(int idDecano, bool activo, int idUsuario, string nombreUsuario, string contrasenia, string login, string cedula, string telefono, string correo) :base(idUsuario, nombreUsuario, contrasenia, login, cedula, telefono, correo)
        {
            this.idDecano = idDecano;
            this.activo = activo;
        }

        public override string ToString()
        {
            return this.IdDecano+" "+this.NombreUsuario;
        }
    }
}
