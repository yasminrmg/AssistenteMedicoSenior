using Microsoft.EntityFrameworkCore;
using AssistenteMedicoSenior.Models;

namespace AssistenteMedicoSenior.Context
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {}
        //configurar a startup amanha
        public DbSet<Consulta> Consultas { get; set; }
        public DbSet<Contato> Contatos { get; set; }
        public DbSet<Deficiencia> Deficiencias { get; set; }
        public DbSet<Dispositivo> Dispositivos { get; set; }
        public DbSet<Enfermidade_Paciente> Enfermidades_Pacientes { get; set; }
        public DbSet<Enfermidade> Enfermidades { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Paciente_Relacionamento> Paciente_Relacionamentos { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Pessoa_Tipo> Pessoa_Tipos { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Questionario_Medico> Questionarios_Medicos { get; set; }
        public DbSet<Questionario_Resposta> Questionarios_Respostas { get; set; }
        public DbSet<Receituario> Receituarios { get; set; }
        public DbSet<Relatorio_Diario> Relatorios_Diarios { get; set; }
    }
}