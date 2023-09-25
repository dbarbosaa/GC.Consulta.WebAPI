using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using GC.Consulta.Domain.Entidade.Util;
using GC.Consulta.Servico;

namespace GC.Consulta.WebApi.Controllers
{
    interface IController<T> where T : Basico, new()
    {
        Task<IActionResult> Salvar(T entidade);
        Task<IActionResult> BuscarPorId(long id);
        Task<IActionResult> Inativar(long id);
        Task<IActionResult> Ativar(long id);
        Task<IActionResult> Paginar(FiltroBase filtro, int pagina, int quantidade);
    }

    [Route("api/[controller]")]
   // [Authorize()]
    [ApiController]
    public abstract class Controller<T> : ControllerBase, IController<T> where T : Basico, new()
    {
        protected readonly IServico<T> service;

        protected Controller(IServico<T> service)
        {
            this.service = service;
        }

        /// <summary>
        /// Cria um novo registro com os dados informados
        /// </summary>
        /// <returns>Registro criado contendo o Id</returns>
        [HttpPost]
        public virtual async Task<IActionResult> Salvar([FromBody] T entidade)
        {
            try
            {
                return Ok(await service.Salvar(entidade));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Faz a inativação (exclusão logica) de um registro de acordo com o id
        /// </summary>
        /// <returns>Status</returns>
        [HttpPut("{id}/Inativar")]
        public virtual async Task<IActionResult> Inativar(long id)
            {
            try
            {
                await service.Inativar(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Faz a ativação  de um registro de acordo com o id
        /// </summary>
        /// <returns>Status</returns>
        [HttpPut("{id}/Ativar")]
        public virtual async Task<IActionResult> Ativar(long id)
        {
            try
            {
                await service.Ativar(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> BuscarPorId(long id)
        {
            try
            {
                return Ok(await service.BuscarPorId(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Paginar/{pagina}/{quantidade}")]
        public async Task<IActionResult> Paginar([FromQuery] FiltroBase filtro, int pagina = 1, int quantidade = 10)
        {
            try
            {
                return Ok(await service.Paginar(filtro, pagina, quantidade));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
