using PatientRESTApi.Models;
using PatientRESTApi.Models.DTOs;

namespace PatientRESTApi.Services.Interfaces
{
    /// <summary>
    /// Interface of service for patients
    /// </summary>
    public interface IPatientService
    {
        /// <summary>
        /// Get all patients
        /// </summary>
        /// <returns>Collection of patients</returns>
        public Task<IEnumerable<PatientDTO>> GetAllAsync();

        /// <summary>
        /// Get patient by id
        /// </summary>
        /// <returns>Patient with same id</returns>
        public Task<PatientDTO> GetByIdAsync(Guid id);

        /// <summary>
        /// Get all patients with same birth date
        /// </summary>
        /// <returns>Collection of patients</returns>
        public Task<IEnumerable<PatientDTO>> GetAllByBirthDateAsync(DateTime birthDate);

        /// <summary>
        /// Add new patient
        /// </summary>
        /// <returns>Task of operation</returns>
        public Task<Patient> CreateAsync(PatientDTO patientDto);

        /// <summary>
        /// Update patient with id
        /// </summary>
        /// <returns>Task of operation</returns>
        public Task<PatientDTO> UpdateAsync(Guid id, PatientDTO patientDto);

        /// <summary>
        /// Delete patient by id
        /// </summary>
        /// <returns>Task of operation</returns>
        public Task DeleteAsync(Guid id);
    }
}
