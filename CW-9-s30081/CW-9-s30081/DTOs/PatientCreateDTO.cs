using CW_9_s30081.Model;
using System.ComponentModel.DataAnnotations;

namespace CW_9_s30081.DTOs {
    public class PatientCreateDTO {
        public int IdPatient { get; set; }
        [MaxLength(100)]
        public string FirstName { get; set; }
        [MaxLength(100)]
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
    }
}
