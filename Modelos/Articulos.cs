using System.ComponentModel.DataAnnotations;

namespace ArticulosAPI.Modelos
{
    public class Articulos
    {
        [Key]
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Marca { get; set; }
        public int Cantidad { get; set; }       
    }
}
