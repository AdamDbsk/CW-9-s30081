using CW_9_s30081.Model;
using System.ComponentModel.DataAnnotations;

namespace CW_9_s30081.DTOs {
    public class PatientGetDTO {
        public int IdPatient { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
        public ICollection<PrescriptionWithMedicamentsGetDTO> Prescriptions { get; set; }
    }
}
