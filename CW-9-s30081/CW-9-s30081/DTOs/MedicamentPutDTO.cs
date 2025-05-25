using CW_9_s30081.Model;
using System.ComponentModel.DataAnnotations;

namespace CW_9_s30081.DTOs {
    public class MedicamentPutDTO {
        public int IdMedicament { get; set; }
        public int Dose { get; set; }
        [MaxLength(100)]
        public string Description { get; set; }
    }
    public class MedicamentGetDto {
        public int IdMedicament { get; set; }
        public string Name { get; set; }
        public int Dose { get; set; }
        public string Description { get; set; }
    }
}
