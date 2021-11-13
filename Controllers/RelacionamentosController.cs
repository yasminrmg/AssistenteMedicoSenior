using System.Collections.Generic;
using System.Linq;
using AssistenteMedicoSenior.Context;
using AssistenteMedicoSenior.Models;
//using AssistenteMedicoSenior.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace AssistenteMedicoSenior.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize()]
    public class RelacionamentosController : ControllerBase
    {
        private readonly ApiDbContext _contexto;
        public RelacionamentosController(ApiDbContext contexto)
        {
            _contexto = contexto;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Paciente_Relacionamento>> Get() //lista todas os relacionamentos
        {
            return _contexto.Paciente_Relacionamentos
                            .AsNoTracking()
                            .Include(x => x.Paciente)
                            .Include(x => x.Medico)
                            .ToList();
        }

        [HttpGet("{CodRelacionamento}", Name = "VerRelacionamento")] //relacionamento especifico
        public ActionResult<IEnumerable<Paciente_Relacionamento>> GetRelacionamento(int CodRelacionamento, int CodPessoa)
        {
            //var pessoa = _contexto.Pessoas.AsNoTracking().FirstOrDefault(p => p.Cod_Pessoa == CodPessoa);
            var relacionamento = _contexto.Paciente_Relacionamentos
                                        .AsNoTracking()
                                        .Include(x => x.Paciente)
                                        .Include(x => x.Medico)
                                        .Where(x => x.Ativo == true && x.Codigo_Relacionamento == CodRelacionamento)
                                        .ToList();

            if (relacionamento == null)
                return NotFound("Relacionamento não encontrado");

            return relacionamento;
        }
        [HttpGet("Pessoa/{CodPessoa}")] //relacionamentos de uma pessoa
        public ActionResult<IEnumerable<Paciente_Relacionamento>> GetRelacionamentosPessoa(int CodPessoa)
        {
            //var pessoa = _contexto.Pessoas.AsNoTracking().FirstOrDefault(p => p.Cod_Pessoa == CodPessoa);
            var relacionamento = _contexto.Paciente_Relacionamentos
                                        .AsNoTracking()
                                        .Include(x => x.Paciente)
                                        .Include(x => x.Medico)
                                        .Where(x => x.Ativo == true && (x.Cod_Pessoa_Medico == CodPessoa || x.Cod_Pessoa_Paciente == CodPessoa))
                                        .ToList();

            if (relacionamento == null)
                return NotFound("Relacionamento não encontrado");

            return relacionamento;
        }

        [HttpPost]
        public ActionResult Post([FromBody] Paciente_Relacionamento paciente_Relacionamento)
        {
            _contexto.Paciente_Relacionamentos
                            .Add(paciente_Relacionamento);
            
            _contexto.SaveChanges();
            return new CreatedAtRouteResult("VerRelacionamento", new { CodRelacionamento = paciente_Relacionamento.Codigo_Relacionamento}, paciente_Relacionamento);
        }

        [HttpPut("{CodRelacionamento}")]
        public ActionResult Put([FromBody] Paciente_Relacionamento paciente_Relacionamento, int CodRelacionamento)
        {
            if(CodRelacionamento != paciente_Relacionamento.Codigo_Relacionamento)
                return BadRequest("Erro ao encontrar Relacionamento");
            _contexto.Entry(paciente_Relacionamento).State = EntityState.Modified;
            _contexto.SaveChanges();
            return Ok("Relacionamento atualizado!");
        }

        [HttpDelete("{CodRelacionamento}")]
        public ActionResult<Paciente_Relacionamento> Delete(int CodRelacionamento)
        {
            var paciente_Relacionamento = _contexto.Paciente_Relacionamentos
                                                        .AsNoTracking()
                                                        .FirstOrDefault(p => p.Codigo_Relacionamento == CodRelacionamento);
            if(paciente_Relacionamento == null)
                return NotFound("Relacionamento não encontrado");
            _contexto.Paciente_Relacionamentos.Remove(paciente_Relacionamento);
            _contexto.SaveChanges();
            return paciente_Relacionamento;
        }
    }
}