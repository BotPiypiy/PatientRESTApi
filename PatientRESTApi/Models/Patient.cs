using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PatientRESTApi.Models
{
    /// <summary>
    /// Model of patient
    /// </summary>
    public class Patient
    {
        /// <summary>
        /// ID
        /// </summary>
        [Key]
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        /// <summary>
        /// Name structure of patient
        /// </summary>
        [JsonPropertyName("name")]
        public Name Name { get; set; }

        /// <summary>
        /// Gender of patient
        /// </summary>
        [JsonPropertyName("gender")]
        public Gender Gender { get; set; }

        /// <summary>
        /// Birth date of patient
        /// </summary>
        [JsonPropertyName("birthDate")]
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// Status of patient
        /// </summary>
        [JsonPropertyName("active")]
        public bool Active { get; set; }
    }

    /// <summary>
    /// Model of name
    /// </summary>
    public class Name
    {
        /// <summary>
        /// State of name pronounciation
        /// </summary>
        [JsonPropertyName("use")]
        public string Use { get; set; }

        /// <summary>
        /// Surname of patient
        /// </summary>
        [JsonPropertyName("family")]
        public string Family { get; set; }

        /// <summary>
        /// Name and patronymic of patient
        /// </summary>
        [JsonPropertyName("given")]
        public Given Given { get; set; }
    }

    public class Given
    {
        /// <summary>
        /// Name of patient
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Patronymic of patient
        /// </summary>
        [JsonPropertyName("patronymic")]
        public string Patronymic { get; set; }
    }

    /// <summary>
    /// Gender type
    /// </summary>
    public enum Gender
    {
        /// <summary>
        /// Male
        /// </summary>
        Male,
        /// <summary>
        /// Female
        /// </summary>
        Female,
        /// <summary>
        /// Other non-existen genders
        /// </summary>
        Other,
        /// <summary>
        /// Unknown gender(hermaphrodite)
        /// </summary>
        Unknown
    }
}
