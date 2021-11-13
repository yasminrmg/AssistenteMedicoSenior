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
    public class EnfermidadesController : ControllerBase
    {
        private readonly ApiDbContext _contexto;
        public EnfermidadesController(ApiDbContext contexto)
        {
            _contexto = contexto;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Enfermidade>> Get()
        {
            return _contexto.Enfermidades.AsNoTracking().ToList();
        }

        [HttpGet("{CodEnfermidade}", Name = "VerEnfermidade")]
        public ActionResult<Enfermidade> Get(int CodEnfermidade)
        {
            var enfermidade = _contexto.Enfermidades.AsNoTracking().FirstOrDefault(p => p.Cod_Enfermidade == CodEnfermidade);
            if (enfermidade == null)
                return NotFound("Enfermidade não cadastrada");

            return enfermidade;
        }

        [HttpGet("Deficiencia/{CodDeficiencia}")]
        public ActionResult<IEnumerable<Enfermidade>> GetEnfermidadesDeficiencia(int CodDeficiencia)
        {
            var enfermidades = _contexto.Enfermidades.AsNoTracking().Where(x => x.Cod_Deficiencia == CodDeficiencia).ToList();
            if (enfermidades == null)
                return NotFound("Não existem enfermidades ligadas a este tipo de deficiencia");
            return enfermidades;
        }

        [HttpPost]
        public ActionResult Post([FromBody] Enfermidade enfermidade)
        {
            _contexto.Enfermidades.Add(enfermidade);
            _contexto.SaveChanges();
            return new CreatedAtRouteResult("VerEnfermidade", new {CodEnfermidade = enfermidade.Cod_Enfermidade}, enfermidade);
        }

        [HttpPut("{CodEnfermidade}")]
        public ActionResult Put([FromBody] Enfermidade enfermidade, int CodEnfermidade)
        {
            if(CodEnfermidade != enfermidade.Cod_Enfermidade)
                return BadRequest("Erro ao encontrar enfermidade");
            _contexto.Entry(enfermidade).State = EntityState.Modified;
            _contexto.SaveChanges();
            return Ok("Cadastro de Enfermidade atualizada com sucesso!");
        }

        [HttpDelete("{CodEnfermidade}")]
        public ActionResult<Enfermidade> Delete(int CodEnfermidade)
        {
            var enfermidade = _contexto.Enfermidades.AsNoTracking().FirstOrDefault(c => c.Cod_Enfermidade == CodEnfermidade);
            if(enfermidade == null)
                return NotFound("Evento não localizado");
            _contexto.Enfermidades.Remove(enfermidade);
            _contexto.SaveChanges();
            return enfermidade;
        }
        

    }
}