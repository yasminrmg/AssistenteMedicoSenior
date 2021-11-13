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
    public class QuestionariosController : ControllerBase
    {
        private readonly ApiDbContext _contexto;
        public QuestionariosController(ApiDbContext contexto)
        {
            _contexto = contexto;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Questionario_Medico>> Get() //lista todas os questionarios
        {
            return _contexto.Questionarios_Medicos
                                .AsNoTracking()
                                .ToList();
        }

        [HttpGet("{CodQuestao}", Name = "VerQuestao")] //questao especifica
        public ActionResult<Questionario_Medico> Get(int CodQuestao)
        {
            var questao = _contexto.Questionarios_Medicos
                                        .AsNoTracking()
                                        .FirstOrDefault(x => x.Cod_Questionario == CodQuestao);

            if (questao == null)
                return NotFound("Questão não encontrada");

            return questao;
        }

        [HttpGet("Pessoa/{codPessoa}")] //questoes de uma pessoa
        public ActionResult<IEnumerable<Questionario_Medico>> GetQuestoesPessoa(int codPessoa)
        {
            var contato = _contexto.Questionarios_Medicos
                                        .AsNoTracking()
                                        .Where(x => x.Cod_Pessoa_Medico == codPessoa || x.Cod_Pessoa_Paciente == codPessoa)
                                        .ToList();

            if (contato.Count == 0)
                return NotFound("Não existem questões cadastradas");

            return contato;
        }

        [HttpPost]
        public ActionResult Post([FromBody] Questionario_Medico questao)
        {
            _contexto.Questionarios_Medicos.Add(questao);
            
            _contexto.SaveChanges();
            return new CreatedAtRouteResult("VerQuestao", new { CodQuestao = questao.Cod_Questionario }, questao);
        }

        [HttpPut("{CodQuestao}")]
        public ActionResult Put([FromBody] Questionario_Medico questao, int CodQuestao)
        {
            if (CodQuestao != questao.Cod_Questionario)
                return BadRequest("Erro ao encontrar questão");
            _contexto.Entry(questao).State = EntityState.Modified;
            _contexto.SaveChanges();
            return Ok("Questão atualizada!");
        }

        [HttpDelete("{CodQuestao}")]
        public ActionResult<Questionario_Medico> Delete(int CodQuestao)
        {
            var questao = _contexto.Questionarios_Medicos
                                        .AsNoTracking()
                                        .FirstOrDefault(p => p.Cod_Questionario == CodQuestao);
            if (questao == null)
                return NotFound("Questão não encontrada");
            _contexto.Questionarios_Medicos.Remove(questao);
            _contexto.SaveChanges();
            return questao;
        }

        [HttpDelete("Pessoa/{codPessoa}")]
        public ActionResult<IEnumerable<Questionario_Medico>> DeleteContatosPessoa(int codPessoa)
        {
            var questoes = _contexto.Questionarios_Medicos
                                        .Where(p => p.Cod_Pessoa_Medico == codPessoa || p.Cod_Pessoa_Paciente == codPessoa)
                                        .ToList();
            if (questoes.Count == 0)
                return NotFound("Não foram questões cadastrados");
            _contexto.Questionarios_Medicos.RemoveRange(questoes);
            _contexto.SaveChanges();
            return questoes;
        }
    }
}