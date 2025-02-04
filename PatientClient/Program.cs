using System.Text;
using System.Text.Json;

using PatientRESTApi.Models;
using PatientRESTApi.Models.DTOs;

namespace PatientClient
{
    public class Program
    {
        private static readonly string[] _families = { "Ivanov", "Sidorov", "Petrov", "Zaycev" };
        private static readonly string[] _names = { "Ivan", "Sidor", "Petr", "Zayac" };
        private static readonly string[] _patronymics = { "Ivanovich", "Sidorovich", "Petrovich", "Zaycovich" };
       
        const int MAX_RETRIES = 100;
        const int RETRY_DELAY = 1;

        public static async Task Main(string[] args)
        {
            const string apiUrl = "http://patientrestapi:8080/api/patient";



            const int numberOfPatients = 100;

            for (int i = 0; i < numberOfPatients; i++)
            {
                var patient = GeneratePatient();

                string json = JsonSerializer.Serialize(patient);

                using (HttpClient client = new HttpClient())
                {
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await CallCreateWithRetries(client, apiUrl, content);

                    if (response is null || response.IsSuccessStatusCode)
                    {
                        Console.WriteLine($"Patient {i + 1} added");
                    }
                    else
                    {
                        Console.WriteLine($"Error with {i + 1} patient: {response.StatusCode}");
                    }
                }
            }
        }

        private static async Task<HttpResponseMessage> CallCreateWithRetries(HttpClient client, string apiUrl, StringContent content, int maxRetries = MAX_RETRIES, int retryDelaySeconds = RETRY_DELAY)
        {
            for (int i = 0; i < maxRetries; i++)
            {
                try
                {
                    HttpResponseMessage response = await client.PostAsync(apiUrl, content);
                    if (response.IsSuccessStatusCode)
                    {
                        return response;
                    }
                }
                catch (HttpRequestException ex)
                {
                    Console.WriteLine(ex.Message + $" Retrying attempt:{i + 1}/{MAX_RETRIES}");
                    await Task.Delay(TimeSpan.FromSeconds(retryDelaySeconds));
                }
            }

            throw new HttpRequestException($"Connection refused after {MAX_RETRIES} attempts. Something is wrong :(");
        }

        private static PatientDTO GeneratePatient()
        {
            Random random = new Random();

            return new PatientDTO
            {
                Use = random.Next(0, 2) == 0 ? "Official" : "Non-officical",
                Surname = _families[random.Next(0, 4)],
                Name = _names[random.Next(0, 4)],
                Patronymic = _patronymics[random.Next(0, 4)],
                Gender = Enum.GetName(typeof(Gender), (Gender)random.Next(0, 4)),
                BirthDate = DateTime.Now.AddDays(-random.Next(0, 365 * 25)),
                Active = random.Next(0, 2) == 0 ? true : false,
            };
        }
    }
}
