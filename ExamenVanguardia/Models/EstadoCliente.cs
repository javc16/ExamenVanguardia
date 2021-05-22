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
        public List<Cliente> Clientes { get; set; }
    }
}
