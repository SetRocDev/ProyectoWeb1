using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PabloCortes_Proyecto1.Models
{
    public class LavadoVehiculo
    {
        [Key]
        [DisplayName("ID Lavado")]
        [Required(ErrorMessage = "Dato Obligatiorio")]
        public int IdLavado { get; set; }

        [DisplayName("Placa del Vehículo")]
        [Required(ErrorMessage = "Dato Obligatiorio")]
        [StringLength(10, ErrorMessage = "La placa no debe exceder 10 caracteres")]
        public string PlacaVehiculo { get; set; }

        [DisplayName("ID Cliente")]
        [Required(ErrorMessage = "Dato Obligatiorio")]
        [StringLength(20, ErrorMessage = "El ID del cliente no debe exceder 20 caracteres")]
        public string IdCliente { get; set; }

        [DisplayName("ID Empleado")]
        [Required(ErrorMessage = "Dato Obligatiorio")]
        [StringLength(20, ErrorMessage = "El ID del empleado no debe exceder 20 caracteres")]
        public string IdEmpleado { get; set; }

        [DisplayName("Tipo de Lavado")]
        [Required(ErrorMessage = "Dato Obligatiorio")]
        [StringLength(50, ErrorMessage = "El tipo de lavado no debe exceder 50 caracteres")]
        public string TipoLavado { get; set; }

        [DisplayName("Precio")]
        [Required(ErrorMessage = "Dato Obligatiorio")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor que 0")]
        public decimal Precio { get; set; }

        [DisplayName("IVA (13%)")]
        public decimal Iva { get { return Math.Round(Precio * 0.13m, 2); } }

        [DisplayName("Precio Total")]
        public decimal PrecioTotal { get { return Math.Round(Precio + Iva, 2); } }

        [DisplayName("Estado del Lavado")]
        [Required(ErrorMessage = "Dato Obligatiorio")]
        [StringLength(20, ErrorMessage = "El estado no debe exceder 20 caracteres")]
        public string EstadoLavado { get; set; }
    }
}