using System.Collections.Generic;
using System.Linq;
using AssistenteMedicoSenior.Context;
using AssistenteMedicoSenior.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace AssistenteMedicoSenior.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize()]
    public class RemediosController : ControllerBase
    {
        private readonly ApiDbContext _contexto;
        public RemediosController(ApiDbContext contexto)
        {
            _contexto = contexto;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Receituario>> Get()
        {
            return _contexto.Receituarios
                                .AsNoTracking()
                                .ToList();
        }

        [HttpGet("{CodReceitaRemedio}", Name = "VerRemedios")]
        public ActionResult<Receituario> Get(int CodReceitaRemedio)
        {
            var receita = _contexto.Receituarios
                                        .AsNoTracking()
                                        .FirstOrDefault(p => p.Cod_Receituario == CodReceitaRemedio);
            if (receita == null)
                return NotFound("Receita não encontrada");
            
            return receita;
        }
        [HttpGet("Pessoa/{CodPessoa}")]
        public ActionResult<IEnumerable<Receituario>> GetRemediosPessoa(int CodPessoa)
        {
            var receitas = _contexto.Receituarios
                                        .AsNoTracking()
                                        .Where(x => x.Cod_Pessoa_Medico == CodPessoa || x.Cod_Pessoa_Paciente == CodPessoa)
                                        .ToList();
            return receitas;
        }
        [HttpGet("Consulta/{CodConsulta}")]
        public ActionResult<IEnumerable<Receituario>> GetReceitasConsulta(int CodConsulta)
        {
            var receitas = _contexto.Receituarios
                                        .AsNoTracking()
                                        .Where(x => x.Cod_Consulta == CodConsulta)
                                        .ToList();
            //if(receitas.Count == 0)
            //    return NotFound("Não foi receitado remédio para essa consulta.");

            return receitas;
        }

        [HttpPost]
        public ActionResult Post([FromBody] Receituario receita)
        {
            _contexto.Receituarios.Add(receita);
            _contexto.SaveChanges();
            return new CreatedAtRouteResult("VerRemedios", new { CodReceitaRemedio = receita.Cod_Receituario }, receita);
        }

        [HttpPut("{CodReceitaRemedio}")]
        public ActionResult Put([FromBody] Receituario receita, int CodReceitaRemedio)
        {
            if (CodReceitaRemedio != receita.Cod_Receituario)
                return BadRequest("Erro ao encontrar Receita Médica");
            _contexto.Entry(receita).State = EntityState.Modified;
            _contexto.SaveChanges();
            return Ok("Receita atualizada com sucesso!");
        }

        [HttpDelete("{CodReceitaRemedio}")]
        public ActionResult<Receituario> Delete(int CodReceitaRemedio)
        {
            var receita = _contexto.Receituarios    
                                        .AsNoTracking()
                                        .FirstOrDefault(c => c.Cod_Receituario == CodReceitaRemedio);
            if(receita == null)
                return NotFound("Remedio não localizado");
            _contexto.Receituarios.Remove(receita);
            _contexto.SaveChanges();
            return receita;
        }
        

    }
}