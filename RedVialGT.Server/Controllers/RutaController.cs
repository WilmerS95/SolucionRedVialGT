﻿using Microsoft.AspNetCore.Mvc;
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
                var rutas = await _dbContext.Rutas
                   .Include(r => r.IdDepartamentoPartidaNavigation)
                   .Include(r => r.IdDepartamentoDestinoNavigation)
                   .ToListAsync();
                foreach (var item in rutas)
                {
                    listaRutaDTO.Add(new RutaDTO
                    {
                        IdRuta = item.IdRuta,
                        NombreRuta = item.NombreRuta,
                        IdDepartamentoPartida = item.IdDepartamentoPartida,
                        IdDepartamentoDestino = item.IdDepartamentoDestino,
                        DistanciaDepartamentos = item.DistanciaDepartamentos,
                        DepartamentoPartida = new DepartamentoDTO
                        {
                            IdDepartamento = item.IdDepartamentoPartidaNavigation.IdDepartamento,
                            NombreDepartamento = item.IdDepartamentoPartidaNavigation.NombreDepartamento,
                            NombreCabecera = item.IdDepartamentoPartidaNavigation.NombreCabecera,
                            DistanciaCapital = item.IdDepartamentoPartidaNavigation.DistanciaCapital,
                            CantidadPoblacion = item.IdDepartamentoPartidaNavigation.CantidadPoblacion,
                            CantidadMunicipios = item.IdDepartamentoPartidaNavigation.CantidadPoblacion,
                            LugaresTuristicos = item.IdDepartamentoPartidaNavigation.LugaresTuristicos,
                        },
                        DepartamentoDestino = new DepartamentoDTO
                        {
                            IdDepartamento = item.IdDepartamentoDestinoNavigation.IdDepartamento,
                            NombreDepartamento = item.IdDepartamentoDestinoNavigation.NombreDepartamento,
                            NombreCabecera = item.IdDepartamentoDestinoNavigation.NombreCabecera,
                            DistanciaCapital = item.IdDepartamentoDestinoNavigation.DistanciaCapital,
                            CantidadPoblacion = item.IdDepartamentoDestinoNavigation.CantidadPoblacion,
                            CantidadMunicipios = item.IdDepartamentoDestinoNavigation.CantidadPoblacion,
                            LugaresTuristicos = item.IdDepartamentoDestinoNavigation.LugaresTuristicos,
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
            var rutaDTO = new RutaDTO();

            try
            {
                var dbRuta = await _dbContext.Rutas
                    .Include(r => r.IdDepartamentoPartidaNavigation)
                    .FirstOrDefaultAsync(x => x.IdRuta == id);

                if (dbRuta != null)
                {
                    rutaDTO.IdRuta = dbRuta.IdRuta;
                    rutaDTO.NombreRuta = dbRuta.NombreRuta;
                    rutaDTO.IdDepartamentoPartida = dbRuta.IdDepartamentoPartida;
                    rutaDTO.IdDepartamentoDestino = dbRuta.IdDepartamentoDestino;
                    rutaDTO.DistanciaDepartamentos = dbRuta.DistanciaDepartamentos;

                    var departamentoDestino = await _dbContext.Departamentos
                        .FirstOrDefaultAsync(d => d.IdDepartamento == dbRuta.IdDepartamentoDestino);

                    if (departamentoDestino != null)
                    {
                        rutaDTO.DepartamentoDestino = new DepartamentoDTO
                        {
                            IdDepartamento = departamentoDestino.IdDepartamento,
                            NombreDepartamento = departamentoDestino.NombreDepartamento,
                            NombreCabecera = departamentoDestino.NombreCabecera,
                            DistanciaCapital = departamentoDestino.DistanciaCapital,
                            CantidadPoblacion = departamentoDestino.CantidadPoblacion,
                            CantidadMunicipios = departamentoDestino.CantidadMunicipios,
                            LugaresTuristicos = departamentoDestino.LugaresTuristicos,
                        };
                    }

                    responseApi.EsCorrecto = true;
                    responseApi.Valor = rutaDTO;
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
                    //IdRuta = ruta.IdRuta,
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