using PatientRESTApi.Models.DTOs;
using PatientRESTApi.Models;
using PatientRESTApi.Services.Interfaces;
using PatientRESTApi.Data;
using PatientRESTApi.Mappers;
using Microsoft.EntityFrameworkCore;

namespace PatientRESTApi.Services.Implementations
{
    /// <summary>
    /// Implementation of IPatientService
    /// </summary>
    public class PatientService : IPatientService
    {
        private readonly ApplicationDbContext _dbContext;

        public PatientService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<PatientDTO>> GetAllAsync()
        {
            return await _dbContext.Patients
                .Select(p => PatientMapper.CreatePatientDTO(p))
                .ToListAsync();
        }

        public async Task<PatientDTO> GetByIdAsync(Guid id)
        {
            var patient = await _dbContext.Patients.FindAsync(id);

            return patient == null
                ? null
                : PatientMapper.CreatePatientDTO(patient);
        }

        public async Task<IEnumerable<PatientDTO>> GetAllByBirthDateAsync(DateTime birthDate)
        {
            var patientsDto = await _dbContext.Patients
                .Where(p => p.BirthDate.Date == birthDate.Date)
                .Select(p => PatientMapper.CreatePatientDTO(p))
                .ToListAsync();

            return patientsDto;
        }

        public async Task<Patient> CreateAsync(PatientDTO patientDto)
        {
            var patient = PatientMapper.CreatePatient(patientDto);
            Console.WriteLine(patient is null);
            await _dbContext.Patients.AddAsync(patient);
            await _dbContext.SaveChangesAsync();
            return patient;
        }

        public async Task<PatientDTO> UpdateAsync(Guid id, PatientDTO patientDto)
        {
            var patient = await _dbContext.Patients.FindAsync(id);

            if(patient == null)
            {
                throw new Exception($"Cannot update patient. Not found patient with id: {id}");
            }
            _dbContext.Patients.Update(PatientMapper.UpdatePatient(patient, patientDto));
            await _dbContext.SaveChangesAsync();
            return PatientMapper.CreatePatientDTO(patient);
        }

        public async Task DeleteAsync(Guid id)
        {
            var patient = await _dbContext.Patients.FindAsync(id);

            if(patient == null)
            {
                throw new Exception($"Cannot delete patient. Not found patient with id: {id}");
            }

            _dbContext.Patients.Remove(patient);
            await _dbContext.SaveChangesAsync();
        }
    }
}
