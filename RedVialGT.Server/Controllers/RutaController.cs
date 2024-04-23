using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RedVialGT.Server.Models;
using Microsoft.EntityFrameworkCore;
using RedVialGT.Shared;

namespace RedVialGT.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RutaController : ControllerBase
    {
        private readonly DbredVialGuatemalaContext _dbContext;

        public RutaController(DbredVialGuatemalaContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("ListaDestino")]
        public async Task<IActionResult> ListaDestino()
        {
            var responseApi = new ResponseAPI<List<RutaDTO>>();
            var listaRutaDTO = new List<RutaDTO>();

            try
            {
                foreach (var item in await _dbContext.Rutas.Include(d => d.IdDepartamentoDestinoNavigation).ToListAsync())
                {
                    listaRutaDTO.Add(new RutaDTO
                    {
                        IdRuta = item.IdRuta,
                        NombreRuta = item.NombreRuta,
                        IdDepartamentoPartida = item.IdDepartamentoPartida,
                        IdDepartamentoDestino = item.IdDepartamentoDestino,
                        DistanciaDepartamentos = item.DistanciaDepartamentos,
                        Departamento = new DepartamentoDTO
                        {
                            IdDepartamento = item.IdDepartamentoDestinoNavigation.IdDepartamento,
                            NombreDepartamento = item.IdDepartamentoDestinoNavigation.NombreDepartamento
                        }
                    });
                }
                responseApi.EsCorrecto = true;
                responseApi.Valor = listaRutaDTO;
            }
            catch (Exception ex)
            {
                responseApi.EsCorrecto = false;
                responseApi.Mensaje = ex.Message;
            }
            return Ok(responseApi);
        }

        [HttpGet]
        [Route("ListaPatida")]
        public async Task<IActionResult> ListaPartida()
        {
            var responseApi = new ResponseAPI<List<RutaDTO>>();
            var listaRutaDTO = new List<RutaDTO>();

            try
            {
                foreach (var item in await _dbContext.Rutas.Include(d => d.IdDepartamentoPartidaNavigation).ToListAsync())
                {
                    listaRutaDTO.Add(new RutaDTO
                    {
                        IdRuta = item.IdRuta,
                        NombreRuta = item.NombreRuta,
                        IdDepartamentoPartida = item.IdDepartamentoPartida,
                        IdDepartamentoDestino = item.IdDepartamentoDestino,
                        DistanciaDepartamentos = item.DistanciaDepartamentos,
                        Departamento = new DepartamentoDTO
                        {
                            IdDepartamento = item.IdDepartamentoPartidaNavigation.IdDepartamento,
                            NombreDepartamento = item.IdDepartamentoPartidaNavigation.NombreDepartamento
                        }
                    });
                }
                responseApi.EsCorrecto = true;
                responseApi.Valor = listaRutaDTO;
            }
            catch (Exception ex)
            {
                responseApi.EsCorrecto = false;
                responseApi.Mensaje = ex.Message;
            }
            return Ok(responseApi);
        }

        [HttpGet]
        [Route("BuscarRuta/{id}")]
        public async Task<IActionResult> BuscarRuta(int id)
        {
            var responseApi = new ResponseAPI<RutaDTO>();
            var RutaDTO = new RutaDTO();

            try
            {
                var dbRuta = await _dbContext.Rutas.FirstOrDefaultAsync(x => x.IdRuta == id);

                if (dbRuta != null)
                {
                    RutaDTO.IdRuta = dbRuta.IdRuta;
                    RutaDTO.NombreRuta = dbRuta.NombreRuta;
                    RutaDTO.IdDepartamentoPartida = dbRuta.IdDepartamentoPartida;
                    RutaDTO.IdDepartamentoDestino = dbRuta.IdDepartamentoDestino;
                    RutaDTO.DistanciaDepartamentos = dbRuta.DistanciaDepartamentos;

                    responseApi.EsCorrecto = true;
                    responseApi.Valor = RutaDTO;
                }
                else
                {
                    responseApi.EsCorrecto = false;
                    responseApi.Mensaje = "No encontrado";
                }
            }
            catch (Exception ex)
            {
                responseApi.EsCorrecto = false;
                responseApi.Mensaje = ex.Message;
            }
            return Ok(responseApi);
        }

        [HttpPost]
        [Route("GuardarRuta")]
        public async Task<IActionResult> GuardarRuta(RutaDTO ruta)
        {
            var responseApi = new ResponseAPI<int>();

            try
            {
                var dbRuta = new Ruta
                {
                    IdRuta = ruta.IdRuta,
                    NombreRuta = ruta.NombreRuta,
                    IdDepartamentoPartida = ruta.IdDepartamentoPartida,
                    IdDepartamentoDestino = ruta.IdDepartamentoDestino,
                    DistanciaDepartamentos = ruta.DistanciaDepartamentos
                };

                _dbContext.Rutas.Add(dbRuta);
                await _dbContext.SaveChangesAsync();

                if (dbRuta.IdRuta != 0)
                {
                    responseApi.EsCorrecto = true;
                    responseApi.Valor = dbRuta.IdRuta;
                }
                else
                {
                    responseApi.EsCorrecto = false;
                    responseApi.Mensaje = "Error al guardar ruta";
                }
            }
            catch (Exception ex)
            {
                responseApi.EsCorrecto = false;
                responseApi.Mensaje = ex.Message;
            }
            return Ok(responseApi);
        }

        [HttpPut]
        [Route("EditarRuta/{id}")]
        public async Task<IActionResult> EditarRuta(int id, RutaDTO ruta)
        {
            var responseApi = new ResponseAPI<int>();

            try
            {
                var dbRuta = await _dbContext.Rutas.FirstOrDefaultAsync(e => e.IdRuta == id);

                if (dbRuta != null)
                {
                    dbRuta.IdRuta = ruta.IdRuta;
                    dbRuta.NombreRuta = ruta.NombreRuta;
                    dbRuta.IdDepartamentoPartida = ruta.IdDepartamentoPartida;
                    dbRuta.IdDepartamentoDestino = ruta.IdDepartamentoDestino;
                    dbRuta.DistanciaDepartamentos = ruta.DistanciaDepartamentos;

                    _dbContext.Rutas.Update(dbRuta);
                    await _dbContext.SaveChangesAsync();

                    responseApi.EsCorrecto = true;
                    responseApi.Valor = dbRuta.IdRuta;
                }
                else
                {
                    responseApi.EsCorrecto = false;
                    responseApi.Mensaje = "Error al actualizar ruta";
                }
            }
            catch (Exception ex)
            {
                responseApi.EsCorrecto = false;
                responseApi.Mensaje = ex.Message;
            }
            return Ok(responseApi);
        }

        [HttpDelete]
        [Route("EliminarRuta/{id}")]
        public async Task<IActionResult> EliminarRuta(int id)
        {
            var responseApi = new ResponseAPI<int>();

            try
            {
                var dbRuta = await _dbContext.Rutas.FirstOrDefaultAsync(e => e.IdRuta == id);

                if (dbRuta != null)
                {
                    _dbContext.Rutas.Remove(dbRuta);
                    await _dbContext.SaveChangesAsync();

                    responseApi.EsCorrecto = true;
                }
                else
                {
                    responseApi.EsCorrecto = false;
                    responseApi.Mensaje = "Error al eliminar ruta";
                }
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

