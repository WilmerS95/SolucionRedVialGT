using RedVialGT.Shared;


namespace RedVialGT.Client.Services
{
    public interface IRutaService
    {
        Task<List<RutaDTO>> ListaDestino();
        Task<List<RutaDTO>> ListaPartida();
        Task<RutaDTO> Buscar(int id);
        Task<int> Guardar(RutaDTO ruta);
        Task<int> Editar(RutaDTO ruta);
        Task<bool> Eliminar(int id);
    }
}
