using CW_9_s30081.Model;
using System.ComponentModel.DataAnnotations;

namespace CW_9_s30081.DTOs {
    public class PrescriptionCreateDTO {
        public PatientCreateDTO Patient { get; set; }
        public ICollection<MedicamentPutDTO> Medicaments { get; set; }

        [Required]
        public DateTime Date { get; set; }
        [Required]
        public DateTime DueDate { get; set; }
    }
}
