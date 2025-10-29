using static System.Runtime.InteropServices.JavaScript.JSType;
namespace Conti.ModeloDominio
{
    public class Multa
    {
        public int ID { get; private set; } 
        public string Patente { get; private set; }
        public DateOnly Fecha { get; private set; }
        public decimal Monto { get; private set; }  
        public string Tipo { get; private set; }
        public string Estado { get; private set; }

        public Multa(int id, string patente, DateOnly fecha, decimal monto, string tipo, string estado)
        {
            SetPatente(patente);
            SetFecha(fecha);
            SetMonto(monto);
            SetTipo(tipo);
            SetEstado(estado);
            SetId(id);
        }


        public void SetId(int id)
        {
            ID = id; 
        }
        public void SetPatente(string patente)
        {
            if (string.IsNullOrWhiteSpace(patente))
            {
                throw new ArgumentException("La patente es obligatoria");
            }
            Patente = patente;
        }
        public void SetFecha(DateOnly fecha)
        {
            Fecha = fecha;
        }

        public void SetMonto(decimal monto)
        {
            Monto = monto;
        }

        public void SetTipo(string tipo)
        {
            if (string.IsNullOrWhiteSpace(tipo))
            {
                throw new ArgumentException("El tipo es obligatorio");
            }
            Tipo = tipo;
        }

        public void SetEstado(string estado)
        {
            Estado = estado;
        }
    }


}

