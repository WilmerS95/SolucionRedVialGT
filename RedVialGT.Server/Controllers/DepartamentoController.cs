using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RedVialGT.Server.Models;
using Microsoft.EntityFrameworkCore;
using RedVialGT.Shared;

namespace RedVialGT.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentoController : ControllerBase
    {
        private readonly DbredVialGuatemalaContext _dbContext;

        public DepartamentoController(DbredVialGuatemalaContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("ListaDepartamento")]
        public async Task<IActionResult> Lista()
        {
            var responseApi = new ResponseAPI<List<DepartamentoDTO>>();
            var listaDepartamentoDTO = new List<DepartamentoDTO>();

            try
            {
                foreach(var item in await _dbContext.Departamentos.ToListAsync())
                {
                    listaDepartamentoDTO.Add(new DepartamentoDTO
                    {
                        IdDepartamento = item.IdDepartamento,
                        NombreDepartamento = item.NombreDepartamento,
                        NombreCabecera = item.NombreCabecera,
                        DistanciaCapital = item.DistanciaCapital,
                        CantidadPoblacion = item.CantidadPoblacion,
                        CantidadMunicipios = item.CantidadMunicipios,
                    });
                }
                responseApi.EsCorrecto = true;
                responseApi.Valor = listaDepartamentoDTO;
            }
            catch (Exception ex)
            {
                responseApi.EsCorrecto = false;
                responseApi.Mensaje = ex.Message;
            }
            return Ok(responseApi);
        }
    }
}
