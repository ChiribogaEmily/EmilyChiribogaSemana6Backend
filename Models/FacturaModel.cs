namespace EmilyChiribogaSemana6Backend.Models
{
    public class FacturaModel
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public string Descripcion { get; set; } = string.Empty;
        public decimal Total { get; set; }
        public int EventoId { get; set; }
        public EventoModel? Evento { get; set; }
    }
}
