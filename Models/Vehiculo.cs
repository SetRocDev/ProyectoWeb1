using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PabloCortes_Proyecto1.Models
{
    public class Vehiculo
    {
        [Key]
        [DisplayName("Placa")]
        [Required(ErrorMessage = "Dato Obligatiorio")]
        public string Placa { get; set; }

        [DisplayName("Marca")]
        [Required(ErrorMessage = "Dato Obligatiorio")]
        public string Marca { get; set; }
        [DisplayName("Modelo")]
        [Required(ErrorMessage = "Dato Obligatiorio")]
        public string Modelo { get; set; }
        [DisplayName("Traccion")]
        [Required(ErrorMessage = "Dato Obligatiorio")]
        public string Traccion { get; set; }
        [DisplayName("Color")]
        [Required(ErrorMessage = "Dato Obligatiorio")]
        public string Color { get; set; }
        [DisplayName("Ultima fecha de atencion")]
        [Required(ErrorMessage = "Dato Obligatiorio")]
        public DateTime UltimaFechaAtencion { get; set; }
        [DisplayName("Tratamiento nano ceramico")]
        [Required(ErrorMessage = "Dato Obligatiorio")]
        public bool TratamientoNanoCeramico { get; set; }
    }
}
