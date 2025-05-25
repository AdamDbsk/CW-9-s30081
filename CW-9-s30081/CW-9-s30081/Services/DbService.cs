using CW_9_s30081.Data;
using CW_9_s30081.DTOs;
using CW_9_s30081.Exceptions;
using CW_9_s30081.Model;
using Microsoft.EntityFrameworkCore;

namespace CW_9_s30081.Services {
    public interface IDBService {
        public Task<PrescriptionGetDTO> CreateNewPrescription(PrescriptionCreateDTO perscriptionData);
        public Task<PatientGetDTO> GetPatientDetailsByIdAsync(int id);
    }
    public class DbService(AppDbContext data) : IDBService {
        public async Task<PrescriptionGetDTO> CreateNewPrescription(PrescriptionCreateDTO prescriptionData) {


            using var transaction = await data.Database.BeginTransactionAsync();

            int? patientID = await data.Patients
                .Where(x => x.IdPatient == prescriptionData.Patient.IdPatient)
                .Select(x => (int?)x.IdPatient)
                .FirstOrDefaultAsync();

            int idPrescription = await data.Prescriptions.MaxAsync(x=>x.IdPrescription)+1;

            if (patientID == null) {
                patientID = prescriptionData.Patient.IdPatient;
                Patient patient = new Patient {
                    IdPatient = prescriptionData.Patient.IdPatient,
                    FirstName = prescriptionData.Patient.FirstName,
                    LastName = prescriptionData.Patient.LastName,
                    Birthdate = prescriptionData.Patient.Birthdate,
                    Prescriptions = new List<Prescription>()
                };
                
                await data.Patients.AddAsync(patient);
                
            }

            if(prescriptionData.Medicaments.Count>10)
                throw new NotFoundException($"Prescription can reference at most 10 medicaments");
            if(prescriptionData.DueDate<prescriptionData.Date)
                throw new NotFoundException($"Due date cant be before date");

            Prescription prescription = new Prescription {
                Date = prescriptionData.Date,
                DueDate = prescriptionData.DueDate,
                IdDoctor = 1,
                IdPatient = patientID.Value,
            };
            await data.Prescriptions.AddAsync(prescription);
            await data.SaveChangesAsync();


            List<Prescription_Medicament> pml = new List<Prescription_Medicament>();
            foreach (var med in prescriptionData.Medicaments) {
                if (!await data.Medicaments.AnyAsync(x => x.IdMedicament == med.IdMedicament)) {
                    await transaction.RollbackAsync();
                    throw new NotFoundException($"Medication with id {med.IdMedicament} doesn't exist");
                }
                pml.Add(new Prescription_Medicament {
                    IdPrescription = idPrescription,
                    IdMedicament = med.IdMedicament,
                    Details = "",
                    Dose = med.Dose
                });
            }
            await data.Prescription_Medicaments.AddRangeAsync(pml);

            await data.SaveChangesAsync();
            await transaction.CommitAsync();
            return new PrescriptionGetDTO {
                PerscriptionID = idPrescription,
                Date = prescriptionData.Date,
                DueDate = prescriptionData.DueDate,
                IdPatient = patientID.Value,
            };
            
        }

        public async Task<PatientGetDTO> GetPatientDetailsByIdAsync(int id) {
            var result = await data.Patients
                .Where(x => x.IdPatient == id)
                .Select(x => new PatientGetDTO {
                    IdPatient = x.IdPatient,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Birthdate = x.Birthdate,
                    Prescriptions = x.Prescriptions.Select(y => new PrescriptionWithMedicamentsGetDTO {
                        Date = y.Date,
                        DueDate = y.DueDate,
                        PerscriptionID = y.IdPrescription,
                        Medicaments = y.Prescription_Medicaments.Join(data.Medicaments, pm => pm.IdMedicament, m => m.IdMedicament,
                        (pm, m) => new Medicament {
                            IdMedicament = m.IdMedicament,
                            Name = m.Name,
                            Description = m.Description,
                            Type = m.Type
                        }).ToList()
                    }).ToList()
                }).FirstOrDefaultAsync();
             return result;
        }
    }
}
