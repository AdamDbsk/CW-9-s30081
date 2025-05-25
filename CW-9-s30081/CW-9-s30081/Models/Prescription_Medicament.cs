using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace CW_9_s30081.Model {
    [Table("Prescription_Medicament")]
    [PrimaryKey(nameof(IdMedicament), nameof(IdPrescription))]
    public class Prescription_Medicament {
        public int IdMedicament { get; set; }
        public int IdPrescription { get; set; }
        public int? Dose { get; set; }
        [MaxLength(100)]
        public string Details { get; set; }
        [ForeignKey(nameof(IdMedicament))]
        public virtual Medicament Medicament { get; set; }
        [ForeignKey(nameof(IdPrescription))]
        public virtual Prescription Prescription { get; set; }
    }
}
