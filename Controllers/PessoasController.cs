using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using AssistenteMedicoSenior.Context;
using AssistenteMedicoSenior.Models;
using Microsoft.AspNetCore.Authorization;
//using AssistenteMedicoSenior.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;

namespace AssistenteMedicoSenior.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PessoasController : ControllerBase
    {
        private readonly ApiDbContext _contexto;
        public PessoasController(ApiDbContext contexto)
        {
            _contexto = contexto;
        }

        [HttpGet]
        [Authorize()]
        public ActionResult<IEnumerable<Pessoa>> Get() //lista todas as pessoas
        {
            return _contexto.Pessoas
                            .AsNoTracking()
                            .ToList();
        }

        [HttpGet("{CodPessoa}", Name = "VerCadastro")] //exibe cadastro da pessoa
        [Authorize()]
        public ActionResult<Pessoa> GetPessoas(int CodPessoa)
        {
            var pessoa = _contexto.Pessoas
                                .AsNoTracking()
                                .FirstOrDefault(p => p.Cod_Pessoa == CodPessoa);
            if (pessoa == null)
                return NotFound("Usuario não encontrado");

            return pessoa;
        }

        [HttpGet("/login/{cpf}/{senha}", Name = "ValidaCadastro")] //Valida login
        [AllowAnonymous]
        public ActionResult GetLogin(string cpf, string senha)
        {
            var usuario = _contexto.Pessoas.FirstOrDefault(p => p.Cpf == cpf && p.Senha == senha);

            if (usuario == null)
                return Unauthorized("CPF e/ou Senha não inválidos!");
            else
                usuario.token = gerarToken(usuario);

            return Ok(usuario);
        }

        private string gerarToken(Pessoa pessoa)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Sid, pessoa.Cod_Pessoa.ToString()),
                new Claim(ClaimTypes.Name, pessoa.Nome)
            };

            //recebe uma instancia da classe SymmetricSecurityKey 
            //armazenando a chave de criptografia usada na criação do token
            var key = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes("290ffbfb1b25e479476c5soi65681hjgtj9d9bfe"));

            //recebe um objeto do tipo SigninCredentials contendo a chave de 
            //criptografia e o algoritmo de segurança empregados na geração 
            // de assinaturas digitais para tokens
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken
            (
                 claims: claims,
                 expires: DateTime.Now.AddMinutes(60),
                 signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        //[HttpGet("{codPessoaMedico}/Pacientes")] // lista pacientes do medico ___________ nao é necessario pois ja existe no relacionamentosController ___________
        //public ActionResult<IEnumerable<Paciente_Relacionamento>> GetPacientes(int codPessoaMedico)
        //{
        //    //var pessoa = _contexto.Pessoas.AsNoTracking().Include(x => x.RelacionamentosMedico).Where(p => p.Cod_Pessoa == codPessoaMedico).ToList();
        //    var pessoa = _contexto.Paciente_Relacionamentos.AsNoTracking().Where(m => m.Cod_Pessoa_Medico == codPessoaMedico && m.Ativo == true).ToList();
        //    if (pessoa == null)
        //        return NotFound("Voce não possui pacientes cadastrados");
        //    return pessoa;
        //}

        [HttpGet("{codPessoaMedico}/Pacientes/{codPessoaPaciente}")] //lista paciente especifico do medico
        [Authorize()]

        public ActionResult<IEnumerable<Paciente>> GetPaciente(int codPessoaMedico, int codPessoaPaciente) //retorno informacao do paciente
        {
            //return _contexto.Pessoas.AsNoTracking().FirstOrDefault(p => p.Cod_Pessoa == codPaciente);
            return _contexto.Pacientes
                            .AsNoTracking()
                            .Include(p => p.Pessoa)
                            .Include(p => p.Enfermidades)
                            .Where(x => x.Cod_Pessoa == codPessoaPaciente).ToList();
        }

        [HttpPost]
        [Authorize()]

        public ActionResult Post([FromBody] Pessoa pessoa)
        {
            _contexto.Pessoas.Add(pessoa);
            
            _contexto.SaveChanges();
            return new CreatedAtRouteResult("VerCadastro", new { CodPessoa = pessoa.Cod_Pessoa}, pessoa);
        }

        [HttpPut("{id}")]
        [Authorize()]

        public ActionResult Put([FromBody] Pessoa pessoa, int id)
        {
            if(id != pessoa.Cod_Pessoa)
                return BadRequest("Erro ao encontrar cadastro");
            _contexto.Entry(pessoa).State = EntityState.Modified;
            _contexto.SaveChanges();
            return Ok("Cadastro atualizado com sucesso!");
        }

        [HttpDelete("{id}")]
        [Authorize()]

        public ActionResult<Pessoa> Delete(int id)
        {
            var pessoa = _contexto.Pessoas
                                .AsNoTracking()
                                .FirstOrDefault(p => p.Cod_Pessoa == id);
            if(pessoa == null)
                return NotFound("Esse cadastro não foi localizado");
            _contexto.Pessoas.Remove(pessoa);
            _contexto.SaveChanges();
            return pessoa;
        }
    }
}