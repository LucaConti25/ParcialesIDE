using Conti.DTOs;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Net.Http.Json;
namespace Conti.API
{
    public class MultaAPI
    {
        private static HttpClient client = new HttpClient();

        static MultaAPI()
        {
            client.BaseAddress = new Uri("https://localhost:7140/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async static Task<IEnumerable<MultaDTO>> GetAllAsync(string? estado = null)
        {
            string url = "multas";

            if (!string.IsNullOrEmpty(estado) && !estado.ToLower().Equals("todas", StringComparison.OrdinalIgnoreCase))
            {
                url += $"?estado={Uri.EscapeDataString(estado.ToLower())}";
            }

            try
            {
                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<IEnumerable<MultaDTO>>();
                }
                else
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al obtener lista de multas. Status: {response.StatusCode}, Detalle: {errorContent}");
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

        public async static Task<MultaDTO> GetAsync(int id)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"multas/{id}");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<MultaDTO>();
                }
                else
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al obtener multa. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al obtener multa: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al obtener multa: {ex.Message}", ex);
            }
        }

        public async static Task AddAsync(MultaDTO multa)
        {
            try
            {
                HttpResponseMessage response = await client.PostAsJsonAsync("multas", multa);
                if (!response.IsSuccessStatusCode)
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al crear multa. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al crear multa: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al crear multa: {ex.Message}", ex);
            }
        }

        public async static Task UpdateAsync(MultaDTO multa)
        {
            try
            {
                HttpResponseMessage response = await client.PutAsJsonAsync("multas", multa);
                if (!response.IsSuccessStatusCode)
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al actualizar multa. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al actualizar multa: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al actualizar multa: {ex.Message}", ex);
            }
        }

        public async static Task DeleteAsync(int id)
        {
            try
            {
                HttpResponseMessage response = await client.DeleteAsync($"multas/{id}");
                if (!response.IsSuccessStatusCode)
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al eliminar multa. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al eliminar multa: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al eliminar multa: {ex.Message}", ex);
            }
        }

        public static async Task<IEnumerable<MultaDTO>> GetAllByEstadoAsync(string estado)
        {

            string url = "multas";
            if (!string.IsNullOrEmpty(estado) && !estado.ToLower().Equals("todas", StringComparison.OrdinalIgnoreCase))
            {
                url += $"?estado={Uri.EscapeDataString(estado.ToLower())}";
            }

            try
            {
                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<IEnumerable<MultaDTO>>();
                }
                else
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al obtener lista de multas. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }

            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al actualizar multa: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al actualizar multa: {ex.Message}", ex);
            }
        }

        public async static Task PagarAsync(int id)
        {
            try
            {
                HttpResponseMessage response = await client.PutAsync($"multas/{id}/pagar", null);

                if (!response.IsSuccessStatusCode)
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception(errorContent); 
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al pagar multa: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al pagar multa: {ex.Message}", ex);
            }
        }
    }
}
