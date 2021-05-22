using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenVanguardia.Models.DTO
{
    public class CategoriaEventoDTO
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int Estado { get; set; }

        public static CategoriaEventoDTO DeModeloADTO(CategoriaEvento categoriaEvento)
        {
            return categoriaEvento != null ? new CategoriaEventoDTO
            {
                Id = categoriaEvento.Id,
                Descripcion = categoriaEvento.Descripcion,
                Estado = categoriaEvento.Estado
            } : null;
        }

        public static IEnumerable<CategoriaEventoDTO> DeModeloADTO(IEnumerable<CategoriaEvento> categoriaEvento)
        {
            if (categoriaEvento == null)
            {
                return new List<CategoriaEventoDTO>();
            }
            List<CategoriaEventoDTO> categoriaEventoData = new List<CategoriaEventoDTO>();

            foreach (var item in categoriaEvento)
            {
                categoriaEventoData.Add(DeModeloADTO(item));
            }

            return categoriaEventoData;
        }


        public static CategoriaEvento DeDTOAModelo(CategoriaEventoDTO categoriaEventoDTO)
        {
            return categoriaEventoDTO != null ? new CategoriaEvento.Builder(categoriaEventoDTO.Descripcion,categoriaEventoDTO.Estado).Constuir() : null;
        }
    }
}
