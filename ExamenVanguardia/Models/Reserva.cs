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
        public int Estado { get; set; }
        public sealed class Builder
        {
            private readonly Reserva _reserva;

            public Builder(string descripcion, DateTime fechaInicial, DateTime fechaFinal, int idCategoriaEvento, int idCliente,int estado)
            {
                _reserva = new Reserva
                {
                    Descripcion = descripcion,
                    FechaInicial = fechaInicial,
                    FechaFinal = fechaFinal,
                    IdCategoriaEvento = idCategoriaEvento,
                    IdCliente = idCliente,
                    Estado = estado
                };
            }

            public Builder conCategoriaEvento(CategoriaEvento categoriaEvento)
            {
                _reserva.CategoriaEvento = categoriaEvento;
                return this;
            }

            public Builder conCliente(Cliente cliente)
            {
                _reserva.Cliente = cliente;
                return this;
            }



            public Reserva Constuir()
            {
                return _reserva;
            }
        }

    }
}

