using RedVialGT.Shared;


namespace RedVialGT.Client.Services
{
    public interface IRutaService
    {
        Task<List<RutaDTO>> Lista();
        Task<RutaDTO> Buscar(int id);
        Task<int> Guardar(RutaDTO ruta);
        Task<int> Editar(RutaDTO ruta);
        Task<bool> Eliminar(int id);
    }
}
