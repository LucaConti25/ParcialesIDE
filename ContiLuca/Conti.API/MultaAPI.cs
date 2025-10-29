using Conti.DTOs;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Net.Http.Json;
namespace Conti.API
{
    public class MultaAPI
    {
        private static HttpClient client  = new HttpClient();

        static MultaAPI()
        {
            client.BaseAddress = new Uri("https://localhost:7272/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static async Task<IEnumerable<MultaDTO>> GetAllAsync()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("multas");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<IEnumerable<MultaDTO>>();
                }
                else
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al obtener lista de usuarioes. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }

            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al obtener lista de multas: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al obtener lista de multas: {ex.Message}", ex);
            }
        }
    }
}
