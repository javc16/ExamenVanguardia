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
        public string EstadoMobiliario { get; set; }
        public int Estado { get; set; }
        public List<ReservaDetalle> ReservaDetalle { get; set; }

        public sealed class Builder
        {
            private readonly Mobiliario _mobiliario;

            public Builder(string descripcion, int cantidadDisponible, string estadoMobiliario,int estado)
            {
                _mobiliario = new Mobiliario
                {
                    Descripcion = descripcion,
                    CantidadDisponible = cantidadDisponible,
                    EstadoMobiliario = estadoMobiliario,
                    Estado = estado
                };
            }



            public Mobiliario Constuir()
            {
                return _mobiliario;
            }
        }
    }
}
