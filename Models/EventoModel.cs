namespace EmilyChiribogaSemana6Backend.Models
{
    public class EventoModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public DateTime Fecha { get; set; }
        public string Lugar { get; set; } = string.Empty;
        public string? Descripcion { get; set; }
        public decimal Precio { get; set; }
        public ICollection<FacturaModel> Facturas { get; set; } = new List<FacturaModel>();
    }
}
