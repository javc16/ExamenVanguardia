using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenVanguardia.Models
{
    public class Reserva
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaInicial { get; set; }
        public DateTime FechaFinal { get; set; }
        public int IdCategoriaEvento { get; set; }
        public CategoriaEvento CategoriaEvento { get; set; }
        public int IdCliente { get; set; }
        public Cliente Cliente { get; set; }
        public List<ReservaDetalle> Detalle { get; set; }

    }
}
//•	Id
//•	Descripcion.
//•	IdCategoriaEvento. (Requerido)
//•	IdCliente. (Requerido)
//•	Fecha y hora Inicial. (Solo se puede reservar en horario libre) mayor que ambos y menor que ambos
//•	Fecha y hora Final.
//•	Lista Mobiliario.
