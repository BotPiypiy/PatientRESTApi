using PatientRESTApi.Models;
using PatientRESTApi.Models.DTOs;
using System.Runtime.Intrinsics.X86;
using System;
using Microsoft.EntityFrameworkCore.Update.Internal;

namespace PatientRESTApi.Mappers
{
    /// <summary>
    /// Convert types of patient data
    /// </summary>
    public static class PatientMapper 
    {
        /// <summary>
        /// Create new
        /// </summary>
        /// <param name="patient"></param>
        /// <returns></returns>
        public static PatientDTO CreatePatientDTO(Patient patient)
        {
            return new PatientDTO
            {
                Id = patient.Id,
                Use = patient.Name.Use,
                Surname = patient.Name.Family,
                Name = patient.Name.Given.Name,
                Patronymic = patient.Name.Given.Patronymic,
                Gender = Enum.GetName(typeof(Gender), patient.Gender),
                BirthDate = patient.BirthDate,
                Active = patient.Active,
            };
        }

        public static Patient CreatePatient(PatientDTO patientDto)
        {
            return new Patient
            {
                Id = Guid.NewGuid(),
                Name = new Name
                {        
                    Use = patientDto.Use,
                    Family = patientDto.Surname,
                    Given = new Given
                    {
                        Name = patientDto.Name,
                        Patronymic = patientDto.Patronymic
                    }
                },
                Gender = patientDto.Gender == "Male" ? Gender.Male
                        : patientDto.Gender == "Female" ? Gender.Female
                        : patientDto.Gender == "Other" ? Gender.Other
                        : Gender.Unknown,
                BirthDate = patientDto.BirthDate,
                Active = patientDto.Active,
            };
        }

        public static Patient UpdatePatient(Patient patient, PatientDTO patientDto)
        {
            patient.Name.Use = patientDto.Use;
            patient.Name.Family = patientDto.Surname;
            patient.Name.Given.Name = patientDto.Name;
            patient.Name.Given.Patronymic = patientDto.Patronymic;
            patient.Gender = patientDto.Gender == "Male" ? Gender.Male
                            : patientDto.Gender == "Female" ? Gender.Female
                            : patientDto.Gender == "Other" ? Gender.Other
                            : Gender.Unknown;
            patient.BirthDate = patientDto.BirthDate;
            patient.Active = patientDto.Active;

            return patient;
        }
    }
}