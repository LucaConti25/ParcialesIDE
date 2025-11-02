using Conti.Data;
using Conti.DTOs;
using Conti.ModeloDominio;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic; 
using System.Linq; 
using System.Threading.Tasks; 

namespace Conti.Servicios
{
    public class MultaServicios
    {
        public async Task<MultaDTO> AddAsync(MultaDTO multaDTO)
        {
            var multaRepository = new MultaRepository();
            Multa multa = new Multa(0, multaDTO.Patente, multaDTO.Fecha, multaDTO.Monto, multaDTO.Tipo,"Pendiente");
            await multaRepository.AddAsync(multa); 
            
            multaDTO.ID = multa.ID;
            return multaDTO;
        }   

        public async Task<bool> DeleteAsync(int id)
        {
            var multaRepository = new MultaRepository();
            return await multaRepository.DeleteAsync(id);
        }

        public async Task<MultaDTO> GetOneAsync(int id) 
        {
            var multaRepository = new MultaRepository();
            Multa? multa = await multaRepository.GetOneAsync(id);
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

        public async Task<IEnumerable<MultaDTO>> GetAllAsync()
        {
            var multaRepository = new MultaRepository();
            var multas = await multaRepository.GetAllAsync();
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

        public async Task<bool> UpdateAsync(MultaDTO multaDTO)
        {
            var multaRepository = new MultaRepository();
            Multa? multa = await multaRepository.GetOneAsync(multaDTO.ID);
            if (multa == null) return false;

            multa.SetPatente(multaDTO.Patente);
            multa.SetMonto(multaDTO.Monto);
            multa.SetFecha(multaDTO.Fecha);
            multa.SetEstado(multaDTO.Estado);
            multa.SetTipo(multaDTO.Tipo);

            return await multaRepository.UpdateAsync(multa);
        }

        public async Task<IEnumerable<MultaDTO>> GetByEstadoAsync(string estado)
        {
            var multaRepository = new MultaRepository();
            var multas = await multaRepository.GetByEstadoAsync(estado);
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

        public async Task<bool> PagarAsync(int id)
        {
            var multaRepository = new MultaRepository();
            var multa = await multaRepository.GetOneAsync(id);

            if (multa == null)
            {
                throw new KeyNotFoundException($"No se encontró la multa con Id {id}.");
            }
            if (multa.Estado == "Pagada")
            {
                throw new ArgumentException("Esta multa ya fue pagada.");
            }

            multa.SetEstado("Pagada");

            return await multaRepository.UpdateAsync(multa);
        }
    }
}
