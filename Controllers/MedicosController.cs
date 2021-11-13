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
    public class MedicosController : ControllerBase
    {
        private readonly ApiDbContext _contexto;
        public MedicosController(ApiDbContext contexto)
        {
            _contexto = contexto;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Medico>> Get() //lista todas os medicos
        {
            return _contexto.Medicos
                            .AsNoTracking()
                            .ToList();
        }

        [HttpGet("{codMedico}", Name = "VerMedico")] //medico especifico
        public ActionResult<Medico> Get(int codMedico)
        {
            var medico = _contexto.Medicos
                                        .AsNoTracking()
                                        .FirstOrDefault(x => x.Cod_Medico == codMedico);

            if (medico == null)
                return NotFound("Cadasto médico não encontrado");

            return medico;
        }

        [HttpPost]
        public ActionResult Post([FromBody] Medico medico)
        {
            _contexto.Medicos.Add(medico);
            
            _contexto.SaveChanges();
            return new CreatedAtRouteResult("VerMedico", new { codMedico = medico.Cod_Medico}, medico);
        }

        [HttpPut("{codMedico}")]
        public ActionResult Put([FromBody] Medico medico, int codMedico)
        {
            if(codMedico != medico.Cod_Medico)
                return BadRequest("Erro ao encontrar Medico");
            _contexto.Entry(medico).State = EntityState.Modified;
            _contexto.SaveChanges();
            return Ok("Cadastro médico atualizado!");
        }

        [HttpDelete("{codMedico}")]
        public ActionResult<Medico> Delete(int codMedico)
        {
            var medico = _contexto.Medicos
                                        .AsNoTracking()
                                        .FirstOrDefault(p => p.Cod_Medico == codMedico);
            if (medico == null)
                return NotFound("Medico não encontrado");
            _contexto.Medicos.Remove(medico);
            _contexto.SaveChanges();
            return medico;
        }
    }
}