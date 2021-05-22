using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenVanguardia.Models
{
    public class EstadoCliente
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int Estado { get; set; }
        public List<Cliente> Clientes { get; set; }

        public sealed class Builder
        {
            private readonly EstadoCliente _estadoCliente;

            public Builder(string descripcion, int estado)
            {
                _estadoCliente = new EstadoCliente
                {
                    Descripcion = descripcion,
                    Estado = estado
                };
            }



            public EstadoCliente Constuir()
            {
                return _estadoCliente;
            }
        }
    }
}
