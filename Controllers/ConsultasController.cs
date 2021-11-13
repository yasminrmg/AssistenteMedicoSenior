using System.Collections.Generic;
using System.Linq;
using AssistenteMedicoSenior.Context;
using AssistenteMedicoSenior.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AssistenteMedicoSenior.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ConsultasController : ControllerBase
    {
        private readonly ApiDbContext _contexto;
        public ConsultasController(ApiDbContext contexto)
        {
            _contexto = contexto;
        }


        [HttpGet] //lista todas as consultas
        public ActionResult<IEnumerable<Consulta>> Get()
        {
            return _contexto.Consultas
                        .AsNoTracking()
                        .ToList();
        }

        [HttpGet("{CodConsulta}", Name = "VerConsulta")]
        public ActionResult<Consulta> GetConsultas(int CodConsulta)
        {
            var consulta = _contexto.Consultas
                                        .AsNoTracking()
                                        .FirstOrDefault(p => p.Cod_Consulta == CodConsulta);
            if (consulta == null)
                return NotFound("Consulta não cadastrada");

            return consulta;
        }


        [HttpGet("Pessoa/{CodPessoa}")]
        public ActionResult<IEnumerable<Consulta>> GetConsultasPessoa(int CodPessoa)
        {
            var consultas = _contexto.Consultas
                                           .AsNoTracking()
                                           .Where(c => c.Cod_Pessoa_Paciente == CodPessoa || c.Cod_Pessoa_Medico == CodPessoa)
                                           .Include(c => c.Medico)
                                           .Include(c => c.Paciente)
                                           .ToList();
            if (consultas == null)
                return NotFound("Não existem consultas cadastradas para a pessoa mencionada");
            return consultas;
        }

        //[HttpGet("Pessoa/{CodPessoa}")] ///lista consultas no intervalo de data
        //public ActionResult<IEnumerable<Consulta>> GetCalendarioCliente(int CodPessoa)
        //{
        //    var consultas = _contexto.Consultas
        //                                   .AsNoTracking()
        //                                   .Where(c => c.Cod_Pessoa_Paciente == CodPessoa || c.Cod_Pessoa_Medico == CodPessoa)
        //                                   .Include(c => c.Medico)
        //                                   .Include(c => c.Paciente)
        //                                   .ToList();
        //    if (consultas == null)
        //        return NotFound("Não existem consultas cadastradas para a pessoa mencionada");
        //    return consultas;
        //}

        [HttpPost]
        public ActionResult Post([FromBody] Consulta consulta)
        {
            _contexto.Consultas.Add(consulta);
            _contexto.SaveChanges();
            return new CreatedAtRouteResult("VerConsulta", new { CodConsulta = consulta.Cod_Consulta }, consulta);
        }

        [HttpPut("{CodConsulta}")]
        public ActionResult Put([FromBody] Consulta consulta, int CodConsulta)
        {
            if (CodConsulta != consulta.Cod_Consulta)
                return BadRequest("Erro ao encontrar consulta marcada");
            _contexto.Entry(consulta).State = EntityState.Modified;
            _contexto.SaveChanges();
            return Ok("Consulta atualizada com sucesso!");
        }

        [HttpDelete("{CodConsulta}")]
        public ActionResult<Consulta> Delete(int CodConsulta)
        {
            var consulta = _contexto.Consultas.AsNoTracking().FirstOrDefault(c => c.Cod_Consulta == CodConsulta);
            if (consulta == null)
                return NotFound("Consulta não localizado");
            _contexto.Consultas.Remove(consulta);
            _contexto.SaveChanges();
            return consulta;
        }


    }
}