using System.Diagnostics;
using Conti.ModeloDominio;
using System.Collections.Generic;
using System.Linq; 
using System.Threading.Tasks; 
using Microsoft.EntityFrameworkCore;
namespace Conti.Data
{
    public class MultaRepository
    {
        private ParcialContext CreateContext()
        {
            return new ParcialContext();
        }

        public async Task AddAsync(Multa multa)
        {
            await using var context = CreateContext();
            context.Multas.Add(multa);
            await context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            await using var context = CreateContext();
            var multa = await context.Multas.FindAsync(id);
            if (multa == null)
            {
                return false;
            }
            context.Multas.Remove(multa);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<Multa?> GetOneAsync(int id)
        {
            await using var context = CreateContext();
            return await context.Multas.FirstOrDefaultAsync(m => m.ID == id);
        }   

        public async Task<bool> UpdateAsync(Multa multa)
        {
            using var context = CreateContext();
            var existingMulta = context.Multas.Find(multa.ID);
            if (existingMulta == null)
            {
                return false;
            }
            existingMulta.SetPatente(multa.Patente);
            existingMulta.SetMonto(multa.Monto);
            existingMulta.SetFecha(multa.Fecha);
            existingMulta.SetEstado(multa.Estado);
            existingMulta.SetTipo(multa.Tipo);
            await context.SaveChangesAsync();
            return true;
        }

        public async  Task<IEnumerable<Multa>> GetAllAsync()
        {
            await using var context = CreateContext();
            return await context.Multas.ToListAsync();
        }

        public async Task<IEnumerable<Multa>> GetByEstadoAsync(string estado)
        {
            await using var context = CreateContext();
            return await context.Multas.Where(m => m.Estado== estado).ToListAsync();
        }
    }
}
