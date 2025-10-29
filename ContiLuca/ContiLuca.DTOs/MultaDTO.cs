namespace Conti.DTOs
{
    public class MultaDTO
    {
        public int ID { get;  set; }
        public string Patente { get;  set; }
        public DateOnly Fecha { get; set; }
        public decimal Monto { get; set; }
        public string Tipo { get; set; }
        public string Estado { get; set; }
    }
}
