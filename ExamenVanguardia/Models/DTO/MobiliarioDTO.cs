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
        public string EstadoMobiliario { get; set; }
        public int Estado { get; set; }

        public static MobiliarioDTO DeModeloADTO(Mobiliario mobiliario)
        {
            return mobiliario != null ? new MobiliarioDTO
            {
                Id = mobiliario.Id,
                Descripcion = mobiliario.Descripcion,
                CantidadDisponible = mobiliario.CantidadDisponible,
                EstadoMobiliario = mobiliario.EstadoMobiliario,
                Estado = mobiliario.Estado
            } : null;
        }

        public static IEnumerable<MobiliarioDTO> DeModeloADTO(IEnumerable<Mobiliario> mobiliario)
        {
            if (mobiliario == null)
            {
                return new List<MobiliarioDTO>();
            }
            List<MobiliarioDTO> mobiliarioData = new List<MobiliarioDTO>();

            foreach (var item in mobiliario)
            {
                mobiliarioData.Add(DeModeloADTO(item));
            }

            return mobiliarioData;
        }


        public static Mobiliario DeDTOAModelo(MobiliarioDTO mobiliarioDTO)
        {
            return mobiliarioDTO != null ? new Mobiliario.Builder(mobiliarioDTO.Descripcion,mobiliarioDTO.CantidadDisponible,mobiliarioDTO.EstadoMobiliario, mobiliarioDTO.Estado).Constuir() : null;
        }
    }
}
