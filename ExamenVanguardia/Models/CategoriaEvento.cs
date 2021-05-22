using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenVanguardia.Models
{
    public class CategoriaEvento
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int Estado { get; set; }
        public List<Reserva> Reservas { get; set; }

        public sealed class Builder
        {
            private readonly CategoriaEvento _categoriaEvento;

            public Builder(string descripcion,int estado)
            {
                _categoriaEvento = new CategoriaEvento
                {
                    Descripcion = descripcion,
                    Estado = estado
                };
            }

        

            public CategoriaEvento Constuir()
            {
                return _categoriaEvento;
            }
        }
    }
}
