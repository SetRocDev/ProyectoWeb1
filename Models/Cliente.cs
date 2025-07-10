using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PabloCortes_Proyecto1.Models
{
    public class Cliente
    {
        [Key]
        [DisplayName("Identificación")]
        [Required(ErrorMessage = "Dato Obligatiorio")]
        public string Identificacion { get; set; }
        [DisplayName("Nombre Completo")]
        [Required(ErrorMessage = "Dato Obligatiorio")]
        public string NombreCompleto { get; set; }
        [DisplayName("Provincia")]
        [Required(ErrorMessage = "Dato Obligatiorio")]
        public string Provincia { get; set; }
        [DisplayName("Cantón")]
        [Required(ErrorMessage = "Dato Obligatiorio")]
        public string Canton { get; set; }
        [DisplayName("Distrito")]
        [Required(ErrorMessage = "Dato Obligatiorio")]
        public string Distrito { get; set; }
        [DisplayName("Dirección Exacta")]
        [Required(ErrorMessage = "Dato Obligatiorio")]
        public string DireccionExacta { get; set; }
        [DisplayName("Teléfono")]
        [Required(ErrorMessage = "Dato Obligatiorio")]
        public string Telefono { get; set; }
        [DisplayName("Preferencia de lavado")]
        [Required(ErrorMessage = "Dato Obligatiorio")]
        public string PreferenciaLavado { get; set; }
    }
}
