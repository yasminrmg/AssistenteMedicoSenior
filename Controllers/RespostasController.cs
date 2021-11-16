using System.Collections.Generic;
using System.Linq;
using AssistenteMedicoSenior.Context;
using AssistenteMedicoSenior.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AssistenteMedicoSenior.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize()]
    public class RespostasController : ControllerBase
    {
        private readonly ApiDbContext _contexto;
        public RespostasController(ApiDbContext contexto)
        {
            _contexto = contexto;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Questionario_Resposta>> Get() //lista todas as respostas existentes de todos os questionarios
        {
            return _contexto.Questionarios_Respostas
                                .AsNoTracking()
                                .ToList();
        }

        [HttpGet("{CodResposta}", Name = "VerResposta")] //resposta especifica
        public ActionResult<Questionario_Resposta> Get(int CodResposta)
        {
            var resposta = _contexto.Questionarios_Respostas
                                        .AsNoTracking()
                                        .FirstOrDefault(x => x.Cod_Resposta == CodResposta);

            if (resposta == null)
                return NotFound("Resposta não encontrada");

            return resposta;
        }

        [HttpGet("Pessoa/{codPessoa}")] //respostas de uma pessoa
        public ActionResult<IEnumerable<Questionario_Medico>> GetQuestoesPessoa(int codPessoa)
        {
            var respostas = _contexto.Questionarios_Medicos
                                        .AsNoTracking()
                                        .Include(q => q.Respostas_Questionarios)
                                        .Where(x => x.Cod_Pessoa_Medico == codPessoa || x.Cod_Pessoa_Paciente == codPessoa)
                                        .ToList();

            if (respostas.Count == 0)
                return NotFound("Não há respostas");

            return respostas;
        }

        [HttpGet("Questionario/{codQuestionario}")] //respostas de um questionario independente da pessoa
        public ActionResult<IEnumerable<Questionario_Medico>> GetQuestoesQuestionario(int codQuestionario)
        {
            var respostas = _contexto.Questionarios_Medicos
                                        .AsNoTracking()
                                        .Include(q => q.Respostas_Questionarios)
                                        .Where(x => x.Cod_Questionario == codQuestionario)
                                        .ToList();

            if (respostas.Count == 0)
                return NotFound("Não há respostas");

            return respostas;
        }


        [HttpPost]
        public ActionResult Post([FromBody] IEnumerable<Questionario_Resposta> respostas)
        {
            _contexto.AddRange(respostas);
            
            _contexto.SaveChanges();
            return Ok("Resposta(s) salva(s)");
        }

        [HttpPut("{CodResposta}")]
        public ActionResult Put([FromBody] Questionario_Resposta resposta, int CodResposta)
        {
            if (CodResposta != resposta.Cod_Resposta)
                return BadRequest("Erro ao encontrar resposta");
            _contexto.Entry(resposta).State = EntityState.Modified;
            _contexto.SaveChanges();
            return Ok("Resposta atualizada!");
        }

        [HttpPut("Pessoa/{CodPessoa}")]
        public ActionResult<IEnumerable<Questionario_Resposta>> Put([FromBody] IEnumerable<Questionario_Resposta> respostas, int CodPessoa)
        {
            var respostasEncontradas = _contexto.Questionarios_Respostas
                            .Where(s => respostas.Any(a => a.Cod_Resposta == s.Cod_Resposta) && s.Cod_Pessoa_Paciente == CodPessoa)
                            .ToList();

            if (respostasEncontradas.Count() != respostas.Count())
                return BadRequest("Respostas ligadas ao usuario não encontradas");

            _contexto.UpdateRange(respostasEncontradas);
            _contexto.SaveChanges();
            return Ok(respostasEncontradas);
        }

        [HttpDelete("{CodResposta}")]
        public ActionResult<Questionario_Resposta> Delete(int CodResposta)
        {
            var resposta = _contexto.Questionarios_Respostas
                                        .AsNoTracking()
                                        .FirstOrDefault(p => p.Cod_Resposta == CodResposta);
            if (resposta == null)
                return NotFound("Resposta não encontrada");
            _contexto.Questionarios_Respostas.Remove(resposta);
            _contexto.SaveChanges();
            return resposta;
        }

        [HttpDelete("Pessoa/{codPessoa}")]
        public ActionResult<IEnumerable<Questionario_Resposta>> DeleteContatosPessoa(int codPessoa)
        {
            var questoes = _contexto.Questionarios_Respostas
                                        .Where(p => p.Cod_Pessoa_Paciente == codPessoa)
                                        .ToList();
            if (questoes.Count == 0)
                return NotFound("Não foram encontradas questões respondidas");
            _contexto.Questionarios_Respostas.RemoveRange(questoes);
            _contexto.SaveChanges();
            return questoes;
        }

        [HttpDelete("Pessoa/{CodPessoa}")]
        public ActionResult<IEnumerable<Questionario_Resposta>> DeleteContatos([FromBody] IEnumerable<Questionario_Resposta> respostas, int CodPessoa)
        {
            var respostasEncontradas = _contexto.Questionarios_Respostas
                                        .Where(s => respostas.Any(a => a.Cod_Resposta == s.Cod_Resposta) && s.Cod_Pessoa_Paciente == CodPessoa)
                                        .ToList();

            var PessoasDiff = respostas.Where(r => r.Cod_Pessoa_Paciente == CodPessoa);
            if (PessoasDiff.Count() != respostas.Count())
                return BadRequest("A pessoa deve ser a mesma das respostas que serão excluidas");
            if (respostasEncontradas.Count() == 0)
                return NotFound("Não foram encontradas questões respondidas");
            _contexto.Questionarios_Respostas.RemoveRange(respostasEncontradas);
            _contexto.SaveChanges();
            return respostasEncontradas;
        }

    }
}