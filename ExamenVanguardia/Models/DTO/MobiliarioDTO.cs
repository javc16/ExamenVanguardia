using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenVanguardia.Models.DTO
{
    public class MobiliarioDTO
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int CantidadDisponible { get; set; }
        public int Estado { get; set; }
    }
}
