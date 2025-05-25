using CW_9_s30081.Model;
using System.ComponentModel.DataAnnotations;

namespace CW_9_s30081.DTOs {
    public class PrescriptionGetDTO {
        public int PerscriptionID { get; set; } 
        public DateTime Date { get; set; }
        public DateTime DueDate { get; set; }
        public int IdPatient { get; set; }
        public int IdDoctor { get; set; }
    }
    public class PrescriptionWithMedicamentsGetDTO {
        public int PerscriptionID { get; set; }
        public DateTime Date { get; set; }
        public DateTime DueDate { get; set; }
        public ICollection<Medicament> Medicaments { get; set; }
    }
}
