using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PabloCortes_Proyecto1.Models
{
    public class Empleado
    {
        [Key]
        [DisplayName("Cedula")]
        [Required(ErrorMessage = "Dato Obligatiorio")]
        [StringLength(20, ErrorMessage = "La cédula no debe exceder 20 caracteres")]
        public string Cedula { get; set; }

        [DisplayName("Fecha de Nacimiento")]
        [Required(ErrorMessage = "Dato Obligatiorio")]
        public DateTime FechaNacimiento { get; set; }

        [DisplayName("Fecha de Ingreso")]
        [Required(ErrorMessage = "Dato Obligatiorio")]
        public DateTime FechaIngreso { get; set; }

        [DisplayName("Salario por Día")]
        [Required(ErrorMessage = "Dato Obligatiorio")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El salario debe ser mayor que 0")]
        public decimal SalarioPorDia { get; set; }

        [DisplayName("Días de Vacaciones Acumulados")]
        [Required(ErrorMessage = "Dato Obligatiorio")]
        [Range(0, int.MaxValue, ErrorMessage = "Los días deben ser un número positivo")]
        public int DiasVacacionesAcumulados { get; set; }

        [DisplayName("Fecha de Retiro")]
        public DateTime? FechaRetiro { get; set; }

        [DisplayName("Monto de Liquidación")]
        public decimal? MontoLiquidacion { get; set; }
    }
}
