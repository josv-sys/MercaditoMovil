namespace MercaditoMovil.Domain.Entities
{
    public class Producto
    {
        public string ProductCatalogId { get; set; } = "";
        public string Nombre { get; set; } = "";
        public string Unidad { get; set; } = "";
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public bool Activo { get; set; }
        public string Packaging { get; set; } = ""; // ← AGREGADO
    }
   
    }
