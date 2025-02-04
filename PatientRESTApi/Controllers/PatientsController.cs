using Microsoft.AspNetCore.Mvc;
using PatientRESTApi.Mappers;
using PatientRESTApi.Models;
using PatientRESTApi.Models.DTOs;
using PatientRESTApi.Services.Interfaces;

namespace PatientRESTApi.Controllers
{
    /// <summary>
    /// Controler for model Patient
    /// </summary>
    [ApiController]
    [Route("api/patient")]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientService _patientService;

        /// <summary>
        /// Constructor using by default (Not a default constructor)
        /// </summary>
        /// <param name="patientService">Service for patient stuff</param>
        public PatientsController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        /// <summary>
        /// Get all patients
        /// </summary>
        /// <returns>Task with list of patients</returns>
        [HttpGet]
        public async Task<IEnumerable<PatientDTO>> GetAll()
        {
            return await _patientService.GetAllAsync();
        }

        /// <summary>
        /// Get patient by ID
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>Task with founded patient</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<PatientDTO>> GetById(Guid id)
        {
            var patientDto = await _patientService.GetByIdAsync(id);

            if (patientDto == null)
            {
                return NotFound();
            }

            return Ok(patientDto);
        }

        /// <summary>
        /// Get patient by a birthDate
        /// </summary>
        /// <param name="birthDate"></param>
        /// <returns></returns>
        [HttpGet("birthdate/{birthDate}")]
        public async Task<ActionResult<IEnumerable<Patient>>> GetAllByBirthDate(DateTime birthDate)
        {
            var patientsDto = await _patientService.GetAllByBirthDateAsync(birthDate);

            if (!patientsDto.Any())
            {
                return NotFound();
            }

            return Ok(patientsDto);
        }

        /// <summary>
        /// Add patient
        /// </summary>
        /// <param name="patient">Patient to add</param>
        /// <returns>Task with new patient</returns>
        [HttpPost]
        public async Task<ActionResult<PatientDTO>> Create(PatientDTO patientDto)
        {
            var patient = await _patientService.CreateAsync(patientDto);
            return Ok(patient);
        }

        /// <summary>
        /// Update patient
        /// </summary>
        /// <param name="id">ID</param>
        /// <param name="patient">New patient data</param>
        /// <returns>Task with actrion result</returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<PatientDTO>> Update(Guid id, PatientDTO patientDto)
        {
            PatientDTO patientDtoResult = null;
            try
            {
               patientDtoResult = await _patientService.UpdateAsync(id, patientDto);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

            if(patientDtoResult is null)
            {
                return NotFound();
            }

            return Ok(patientDtoResult);
        }

        /// <summary>
        /// Delete patient
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>Task with actrion result</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _patientService.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

            return Ok();
        }
    }
}
