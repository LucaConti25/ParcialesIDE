using Conti.Data;
using Conti.DTOs;
using Conti.ModeloDominio;

namespace Conti.Servicios
{
    public class MultaServicios
    {
        public MultaDTO Add(MultaDTO multaDTO)
        {
            var multaRepository = new MultaRepository();
            Multa multa = new Multa(0, multaDTO.Patente, multaDTO.Fecha, multaDTO.Monto, multaDTO.Tipo, multaDTO.Estado);
            multaRepository.Add(multa); 
            multaDTO.ID = multa.ID;
            return multaDTO;
        }   

        public bool Delete(int id)
        {
            var multaRepository = new MultaRepository();
            return multaRepository.Delete(id);
        }

        public MultaDTO GetOne(int id) 
        {
            var multaRepository = new MultaRepository();
            Multa? multa = multaRepository.GetOne(id);
            if (multa == null)
            {
                return null;
            }
            return new MultaDTO
            {
                ID = multa.ID,
                Patente = multa.Patente,
                Fecha = multa.Fecha,
                Monto = multa.Monto,
                Tipo = multa.Tipo,
                Estado = multa.Estado
            };
        }

        public IEnumerable<MultaDTO> GetAll()
        {
            var multaRepository = new MultaRepository();
            var multas = multaRepository.GetAll();
            return multas.Select(multa => new MultaDTO
            {
                ID = multa.ID,
                Patente = multa.Patente,
                Fecha = multa.Fecha,
                Monto = multa.Monto,
                Tipo = multa.Tipo,
                Estado = multa.Estado
            }).ToList();
        }

        public bool Update(MultaDTO multaDTO)
        {
            var multaRepository = new MultaRepository();
            Multa multa = new Multa(multaDTO.ID, multaDTO.Patente, multaDTO.Fecha, multaDTO.Monto, multaDTO.Tipo, multaDTO.Estado);
            return multaRepository.Update(multa);
        }
    }
}
