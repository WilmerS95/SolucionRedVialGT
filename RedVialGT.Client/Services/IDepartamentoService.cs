using RedVialGT.Shared;

namespace RedVialGT.Client.Services
{
    public interface IDepartamentoService
    {
        Task<List<DepartamentoDTO>> ListaDepartamento();
    }
}
