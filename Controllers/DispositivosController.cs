using System.Collections.Generic;
using System.Linq;
using AssistenteMedicoSenior.Context;
using AssistenteMedicoSenior.Models;
//using AssistenteMedicoSenior.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AssistenteMedicoSenior.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DispositivosController : ControllerBase
    {
        private readonly ApiDbContext _contexto;
        public DispositivosController(ApiDbContext contexto)
        {
            _contexto = contexto;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Dispositivo>> Get() //lista todas os dispositivos
        {
            return _contexto.Dispositivos
                            .AsNoTracking()
                            .ToList();
        }

        [HttpGet("{CodDispositivo}", Name = "VerDispositivos")] //dispositivo especifico
        public ActionResult<Dispositivo> Get(int CodDispositivo)
        {
            var dispositivo = _contexto.Dispositivos
                                        .AsNoTracking()
                                        .FirstOrDefault(x => x.Ativo == true && x.Cod_Dispositivo == CodDispositivo);

            if (dispositivo == null)
                return NotFound("Dispositivo não encontrado");

            return dispositivo;
        }
        [HttpGet("Pessoa/{CodPessoa}")] // todos os dispositivos de uma pessoa
        public ActionResult<IEnumerable<Dispositivo>> GetDispositivosPessoa(int CodPessoa)
        {
            var relacionamento = _contexto.Dispositivos
                                        .AsNoTracking()
                                        .Where(x => x.Ativo == true && x.Cod_Pessoa == CodPessoa)
                                        .ToList();

            if (relacionamento.Count == 0)
                return NotFound("Não existem dispositivos cadastrados");

            return relacionamento;
        }

        [HttpPost]
        public ActionResult Post([FromBody] Dispositivo dispositivo)
        {
            _contexto.Dispositivos.Add(dispositivo);
            _contexto.SaveChanges();
            return new CreatedAtRouteResult("VerDispositivos", new { CodDispositivo = dispositivo.Cod_Dispositivo}, dispositivo);
        }

        [HttpPut("{CodDispositivo}")]
        public ActionResult Put([FromBody] Dispositivo dispositivo, int CodDispositivo)
        {
            if(CodDispositivo != dispositivo.Cod_Dispositivo)
                return BadRequest("Erro ao encontrar Dispositivo");

            _contexto.Entry(dispositivo).State = EntityState.Modified;
            _contexto.SaveChanges();
            return Ok("Dispositivo alterado");
        }

        [HttpDelete("{CodDispositivo}")]
        public ActionResult<Dispositivo> Delete(int CodDispositivo)
        {
            var dispositivo = _contexto.Dispositivos
                                            .AsNoTracking()
                                            .FirstOrDefault(p => p.Cod_Dispositivo == CodDispositivo);
            if(dispositivo == null)
                return NotFound("Dispositivo não encontrado");
            _contexto.Dispositivos.Remove(dispositivo);
            _contexto.SaveChanges();
            return dispositivo;
        }
    }
}