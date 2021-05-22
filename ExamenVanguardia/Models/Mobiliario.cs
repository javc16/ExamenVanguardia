using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenVanguardia.Models
{
    public class Mobiliario
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int CantidadDisponible { get; set; }
        public int Estado { get; set; }
        public List<ReservaDetalle> ReservaDetalle { get; set; }
    }
}
