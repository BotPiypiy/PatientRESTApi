namespace PatientRESTApi.Models.DTOs
{
    /// <summary>
    /// Data Transfer Object for Patient
    /// </summary>
    public class PatientDTO
    {
        public Guid Id { get; set; }
        /// <summary>
        /// State of name pronounciation
        /// </summary>
        public string Use { get; set; }

        /// <summary>
        /// Surname of Patient
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Name of Patient
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Patronymic of patient
        /// </summary>
        public string Patronymic { get; set; }

        /// <summary>
        /// Gender of patient
        /// </summary>
        public string Gender { get; set; }

        /// <summary>
        /// Birthdate of patient
        /// </summary>
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// State of patient
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// Construcor from Patient
        /// </summary>
        /// <param name="patient">Original patient</param>
    }
}
