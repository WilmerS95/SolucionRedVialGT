using RedVialGT.Shared;
using System.Net.Http.Json;

namespace RedVialGT.Client.Services
{
    public class RutaService : IRutaService
    {
        private readonly HttpClient _http;

        public RutaService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<RutaDTO>> ListaRuta()
        {
            var result = await _http.GetFromJsonAsync<ResponseAPI<List<RutaDTO>>>("api/Ruta/ListaRuta");

            if (result!.EsCorrecto)
                return result.Valor!;
            else
                throw new Exception(result.Mensaje);
        }

        //public async Task<List<RutaDTO>> ListaPartida()
        //{
        //    var result = await _http.GetFromJsonAsync<ResponseAPI<List<RutaDTO>>>("api/Ruta/ListaPartida");

        //    if (result!.EsCorrecto)
        //        return result.Valor!;
        //    else
        //        throw new Exception(result.Mensaje);
        //}
        public async Task<RutaDTO> Buscar(int id)
        {
            var result = await _http.GetFromJsonAsync<ResponseAPI<RutaDTO>>($"api/Ruta/BuscarRuta/{id}");

            if (result!.EsCorrecto)
                return result.Valor!;
            else
                throw new Exception(result.Mensaje);
        }
        public async Task<int> Guardar(RutaDTO ruta)
        {
            var result = await _http.PostAsJsonAsync("api/Ruta/GuardarRuta",ruta);
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<int>>();

            if (response!.EsCorrecto)
                return response.Valor!;
            else
                throw new Exception(response.Mensaje);
        }

        public async Task<int> Editar(RutaDTO ruta)
        {
            var result = await _http.PutAsJsonAsync($"api/Ruta/EditarRuta/{ruta.IdRuta}", ruta);
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<int>>();

            if (response!.EsCorrecto)
                return response.Valor!;
            else
                throw new Exception(response.Mensaje);
        }

        public async Task<bool> Eliminar(int id)
        {
            var result = await _http.DeleteAsync($"api/Ruta/EditarRuta/{id}");
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<int>>();

            if (response!.EsCorrecto)
                return response.EsCorrecto!;
            else
                throw new Exception(response.Mensaje);
        }
    }
}
