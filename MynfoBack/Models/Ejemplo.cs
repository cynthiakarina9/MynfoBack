using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MynfoBack.Models
{
    public class Ejemplo
    {
        [Key]
        public int EjemploID { get; set; }

        [Required(ErrorMessage = "You must enter {0}")]
        [StringLength(50, ErrorMessage = "The field {0} can contain maxium {1} and minimum {2} characters", MinimumLength = 1)]
        [Index("Ejemplo_Description_Index", IsUnique = true)]
        public string Description { get; set; }

        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal Price { get; set; }
    }
}