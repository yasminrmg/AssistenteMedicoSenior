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
    public class ProntuariosController : ControllerBase
    {
        private readonly ApiDbContext _contexto;
        public ProntuariosController(ApiDbContext contexto)
        {
            _contexto = contexto;
        }

        /*[HttpGet] // lista todas as enfermidades de todos os pacientes e as informacoes da tabela paciente _______DESCOMENTAR
        public ActionResult<IEnumerable<Pacientes>> Get()
        {
            return _contexto.Pacientes.Include(x => x.Pessoa)
                                      .Include(x => x.Enfermidades)
                                      //.ThenInclude(x => x.)
                                      //.Include(p.)
                                      .ToList();

            //ver se funciona
        }*/
        /// ____________FIM DESCOMENTAR
        // [HttpGet("{CodEnfermidade}", Name = "VerEnfermidade")] //lista enfermidade de paciente especifico
        // public ActionResult<Enfermidade> Get(int id)
        // {
        //     var enfermidade = _contexto.Pacientes.AsNoTracking().FirstOrDefault(p => p.Cod_Enfermidade == id);
        //     if (enfermidade == null)
        //         return NotFound("Enfermidade não encontrada");

        //     return enfermidade;
        // }
        //_____________DESCOMENTAR
        // [HttpGet("Medico/{CodMedico}")]
        // public ActionResult<IEnumerable<Paciente>> GetProntuariosPacientes(int CodMedico)
        // {
        //     //first or default
        //     var enfermidadesPacientes = _contexto.Pacientes.Include(x => x.Enfermidades_Paciente).Where(m => m.Enfermidades_Paciente.Cod_Medico == CodMedico).ToList();

        //     if (enfermidadesPacientes == null)
        //         return NotFound("Não foram pacientes com enfermidades");
        //     return enfermidadesPacientes;
        // }
        /// ____________FIM DESCOMENTAR
        // [HttpGet("{CodMedico}/Cliente/{CodCliente}")]
        // public ActionResult<IEnumerable<Receituario>> GetRemediosCliente(int CodCliente)
        // {
        //     var consultas = _contexto.Enfermidades_Pacientes.AsNoTracking().Where(x => x.Cod_Paciente == CodCliente || x.Cod_Medico == CodCliente).ToList();
        //     if (consultas == null)
        //         return NotFound("Não foram encontradas receitas cadastradas");
        //     return consultas;
        // }
        /// _____________DESCOMENTAR
        // [HttpGet("Consulta/{CodConsulta}")]
        // public ActionResult<IEnumerable<Receituario>> GetRemediosConsulta(int CodConsulta)
        // {
        //     var consultas = _contexto.Enfermidades_Pacientes.AsNoTracking().Where(x => x.Cod_Consulta == CodConsulta).ToList();
        //     if (consultas == null)
        //         return NotFound("Não foi receitado remédio para essa consulta ");
        //     return consultas;
        // }

        // [HttpPost]
        // public ActionResult Post([FromBody] Receituario receita)
        // {
        //     _contexto.Enfermidades_Pacientes.Add(receita);
        //     _contexto.SaveChanges();
        //     return new CreatedAtRouteResult("VerConsulta", new {id = receita.Cod_Consulta}, receita);
        // }

        // [HttpPut("{id}")]
        // public ActionResult Put([FromBody] Receituario receita, int id)
        // {
        //     if(id != receita.Cod_Consulta)
        //         return BadRequest("Erro ao encontrar Receita Médica");
        //     _contexto.Entry(receita).State = EntityState.Modified;
        //     _contexto.SaveChanges();
        //     return Ok("Receita atualizada com sucesso!");
        // }

        // [HttpDelete("{id}")]
        // public ActionResult<Receituario> Delete(int id)
        // {
        //     var receita = _contexto.Enfermidades_Pacientes.AsNoTracking().FirstOrDefault(c => c.Cod_Receituario == id);
        //     if(receita == null)
        //         return NotFound("Remedio não localizado");
        //     _contexto.Enfermidades_Pacientes.Remove(receita);
        //     _contexto.SaveChanges();
        //     return receita;
        // }
        //________________FIM DESCOMENTAR

    }
}