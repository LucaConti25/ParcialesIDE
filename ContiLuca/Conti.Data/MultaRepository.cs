using System.Diagnostics;
using Conti.ModeloDominio;  
namespace Conti.Data
{
    public class MultaRepository
    {
        private ParcialContext CreateContext()
        {
            return new ParcialContext();
        }

        public void Add(Multa multa)
        {
            using var context = CreateContext();
            context.Multas.Add(multa);
            context.SaveChanges();
        }

        public bool Delete(int id)
        {
            using var context = CreateContext();
            var multa = context.Multas.Find(id);
            if (multa == null)
            {
                return false;
            }
            context.Multas.Remove(multa);
            context.SaveChanges();
            return true;
        }

        public Multa? GetOne(int id)
        {
            using var context = CreateContext();
            return context.Multas.FirstOrDefault(m => m.ID == id);
        }   

        public bool Update(Multa multa)
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
            context.SaveChanges();
            return true;
        }

        public IEnumerable<Multa> GetAll()
        {
            using var context = CreateContext();
            return context.Multas.ToList();
        }

        public IEnumerable<Multa> GetByEstado(string estado)
        {
            using var context = CreateContext();
            return context.Multas.Where(m => m.Estado== estado).ToList();
        }
    }
}
