using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenVanguardia.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Identidad { get; set; }
        public int Edad { get; set; }
        public int IdEstadoCliente { get; set; }
        public EstadoCliente EstadoCliente { get; set; }
        public int Estado { get; set; }

        public sealed class Builder
        {
            private readonly Cliente _cliente;

            public Builder(string nombre, string apellido, int edad, int idEstado,int estado,string identidad)
            {
                _cliente = new Cliente
                {
                   Nombre = nombre,
                   Apellido = apellido,
                   Edad = edad,
                   IdEstadoCliente = idEstado,
                   Estado = estado,
                   Identidad = identidad
                };
            }

            public Builder conEstadoCliente(EstadoCliente estadoCliente)
            {
                _cliente.EstadoCliente = estadoCliente;
                return this;
            }



            public Cliente Constuir()
            {
                return _cliente;
            }
        }
    }
}

