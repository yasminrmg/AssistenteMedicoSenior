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
    public class ContatosController : ControllerBase
    {
        private readonly ApiDbContext _contexto;
        public ContatosController(ApiDbContext contexto)
        {
            _contexto = contexto;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Contato>> Get() //lista todas os contatos
        {
            return _contexto.Contatos
                            .AsNoTracking()
                            .ToList();
        }

        [HttpGet("{codContato}", Name = "VerContato")] //contato especifico
        public ActionResult<Contato> Get(int codContato)
        {
            var contato = _contexto.Contatos
                                        .AsNoTracking()
                                        .FirstOrDefault(x => x.Ativo == true && x.Cod_Contato == codContato);

            if (contato == null)
                return NotFound("Telefone não encontrado");

            return contato;
        }
        [HttpGet("Pessoa/{codPessoa}")] //contatos de uma pessoa
        public ActionResult<IEnumerable<Contato>> GetRelacionamentosPessoa(int codPessoa)
        {
            var contato = _contexto.Contatos
                                        .AsNoTracking()
                                        .Where(x => x.Ativo == true && x.Cod_Pessoa == codPessoa)
                                        .ToList();

            if (contato.Count == 0)
                return NotFound("Cadastro não possui contatos");

            return contato;
        }

        [HttpPost]
        public ActionResult Post([FromBody] Contato contato)
        {
            _contexto.Contatos
                            .Add(contato);
            
            _contexto.SaveChanges();
            return new CreatedAtRouteResult("VerContato", new { codContato = contato.Cod_Contato}, contato);
        }

        [HttpPut("{codContato}")]
        public ActionResult Put([FromBody] Contato contato, int codContato)
        {
            if(codContato != contato.Cod_Contato)
                return BadRequest("Erro ao encontrar Contato");
            _contexto.Entry(contato).State = EntityState.Modified;
            _contexto.SaveChanges();
            return Ok("Contato atualizado!");
        }

        [HttpDelete("{codContato}")]
        public ActionResult<Contato> Delete(int codContato)
        {
            var contato = _contexto.Contatos
                                        .AsNoTracking()
                                        .FirstOrDefault(p => p.Cod_Contato == codContato);
            if (contato == null)
                return NotFound("Contato não encontrado");
            _contexto.Contatos.Remove(contato);
            _contexto.SaveChanges();
            return contato;
        }

        [HttpDelete("Pessoa/{codPessoa}")]
        public ActionResult<IEnumerable<Contato>> DeleteContatosPessoa(int codPessoa)
        {
            var contatos = _contexto.Contatos
                                        .Where(p => p.Cod_Pessoa == codPessoa)
                                        .ToList();
            if (contatos.Count == 0)
                return NotFound("Não existem contatos cadastrados");
            _contexto.Contatos.RemoveRange(contatos);
            _contexto.SaveChanges();
            return contatos;
        }
    }
}