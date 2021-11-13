using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AssistenteMedicoSenior.Migrations
{
    public partial class GeraBanco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Deficiencias",
                columns: table => new
                {
                    Cod_Deficiencia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome_Deficiencia = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deficiencias", x => x.Cod_Deficiencia);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Pessoa_Tipos",
                columns: table => new
                {
                    Cod_Pessoa_Tipo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome_Tipo = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Tipo_ativo = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoa_Tipos", x => x.Cod_Pessoa_Tipo);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Enfermidades",
                columns: table => new
                {
                    Cod_Enfermidade = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Nome_Cientifico = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descricao = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Possui_Tratamento = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Cod_Deficiencia = table.Column<int>(type: "int", nullable: false),
                    DeficienciaCod_Deficiencia = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enfermidades", x => x.Cod_Enfermidade);
                    table.ForeignKey(
                        name: "FK_Enfermidades_Deficiencias_DeficienciaCod_Deficiencia",
                        column: x => x.DeficienciaCod_Deficiencia,
                        principalTable: "Deficiencias",
                        principalColumn: "Cod_Deficiencia",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Pessoas",
                columns: table => new
                {
                    Cod_Pessoa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cpf = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Rg = table.Column<string>(type: "varchar(12)", maxLength: 12, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Data_Nascimento = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Sexo = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Raca_Cor = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Nacionalidade = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cep = table.Column<string>(type: "varchar(9)", maxLength: 9, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Endereco = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Num_Endereco = table.Column<int>(type: "int", nullable: false),
                    Complemento = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Municipio = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Uf = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Usuario = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Senha = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cod_Pessoa_Tipo = table.Column<int>(type: "int", nullable: false),
                    Pessoa_TipoCod_Pessoa_Tipo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoas", x => x.Cod_Pessoa);
                    table.ForeignKey(
                        name: "FK_Pessoas_Pessoa_Tipos_Pessoa_TipoCod_Pessoa_Tipo",
                        column: x => x.Pessoa_TipoCod_Pessoa_Tipo,
                        principalTable: "Pessoa_Tipos",
                        principalColumn: "Cod_Pessoa_Tipo",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Contatos",
                columns: table => new
                {
                    Cod_Contato = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Telefone = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Emergencia = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Ativo = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Cod_Pessoa = table.Column<int>(type: "int", nullable: false),
                    PessoaCod_Pessoa = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contatos", x => x.Cod_Contato);
                    table.ForeignKey(
                        name: "FK_Contatos_Pessoas_PessoaCod_Pessoa",
                        column: x => x.PessoaCod_Pessoa,
                        principalTable: "Pessoas",
                        principalColumn: "Cod_Pessoa",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Dispositivos",
                columns: table => new
                {
                    Cod_Dispositivo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Apelido_Dispositivo = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cod_Dispositivo_Smartphone = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Ativo = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Cod_Pessoa = table.Column<int>(type: "int", nullable: false),
                    PessoaCod_Pessoa = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dispositivos", x => x.Cod_Dispositivo);
                    table.ForeignKey(
                        name: "FK_Dispositivos_Pessoas_PessoaCod_Pessoa",
                        column: x => x.PessoaCod_Pessoa,
                        principalTable: "Pessoas",
                        principalColumn: "Cod_Pessoa",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Medicos",
                columns: table => new
                {
                    Cod_Medico = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Especialidade = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Crm = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Crm_Secundario = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cod_Pessoa = table.Column<int>(type: "int", nullable: false),
                    PessoaCod_Pessoa = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicos", x => x.Cod_Medico);
                    table.ForeignKey(
                        name: "FK_Medicos_Pessoas_PessoaCod_Pessoa",
                        column: x => x.PessoaCod_Pessoa,
                        principalTable: "Pessoas",
                        principalColumn: "Cod_Pessoa",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    Cod_Paciente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Altura = table.Column<float>(type: "float", nullable: false),
                    Peso = table.Column<float>(type: "float", nullable: false),
                    Cod_Pessoa = table.Column<int>(type: "int", nullable: false),
                    PessoaCod_Pessoa = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.Cod_Paciente);
                    table.ForeignKey(
                        name: "FK_Pacientes_Pessoas_PessoaCod_Pessoa",
                        column: x => x.PessoaCod_Pessoa,
                        principalTable: "Pessoas",
                        principalColumn: "Cod_Pessoa",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Questionarios_Medicos",
                columns: table => new
                {
                    Cod_Questionario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Dispositivo = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Questao = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Ativa = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Cod_Pessoa_Medico = table.Column<int>(type: "int", nullable: false),
                    Cod_Pessoa_Paciente = table.Column<int>(type: "int", nullable: true),
                    Cod_Enfermidade = table.Column<int>(type: "int", nullable: true),
                    EnfermidadeCod_Enfermidade = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questionarios_Medicos", x => x.Cod_Questionario);
                    table.ForeignKey(
                        name: "FK_Questionarios_Medicos_Enfermidades_EnfermidadeCod_Enfermidade",
                        column: x => x.EnfermidadeCod_Enfermidade,
                        principalTable: "Enfermidades",
                        principalColumn: "Cod_Enfermidade",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Questionarios_Medicos_Pessoas_Cod_Pessoa_Medico",
                        column: x => x.Cod_Pessoa_Medico,
                        principalTable: "Pessoas",
                        principalColumn: "Cod_Pessoa",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Questionarios_Medicos_Pessoas_Cod_Pessoa_Paciente",
                        column: x => x.Cod_Pessoa_Paciente,
                        principalTable: "Pessoas",
                        principalColumn: "Cod_Pessoa",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Consultas",
                columns: table => new
                {
                    Cod_Consulta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Data = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Data_Registro = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Confirmado = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Realizada = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Relatorio = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Resumo_Saude = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Criador = table.Column<int>(type: "int", nullable: false),
                    Lembrete = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Cod_Pessoa_Paciente = table.Column<int>(type: "int", nullable: false),
                    Cod_Pessoa_Medico = table.Column<int>(type: "int", nullable: false),
                    PacienteCod_Paciente = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultas", x => x.Cod_Consulta);
                    table.ForeignKey(
                        name: "FK_Consultas_Pacientes_PacienteCod_Paciente",
                        column: x => x.PacienteCod_Paciente,
                        principalTable: "Pacientes",
                        principalColumn: "Cod_Paciente",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Consultas_Pessoas_Cod_Pessoa_Medico",
                        column: x => x.Cod_Pessoa_Medico,
                        principalTable: "Pessoas",
                        principalColumn: "Cod_Pessoa",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Consultas_Pessoas_Cod_Pessoa_Paciente",
                        column: x => x.Cod_Pessoa_Paciente,
                        principalTable: "Pessoas",
                        principalColumn: "Cod_Pessoa",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Enfermidades_Pacientes",
                columns: table => new
                {
                    Cod_Enfermidade_Paciente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Ativa = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    InformacoesAdicionais = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Data = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Cod_Pessoa_Paciente = table.Column<int>(type: "int", nullable: false),
                    Cod_Pessoa_Medico = table.Column<int>(type: "int", nullable: false),
                    Cod_Enfermidade = table.Column<int>(type: "int", nullable: false),
                    EnfermidadeCod_Enfermidade = table.Column<int>(type: "int", nullable: true),
                    PacienteCod_Paciente = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enfermidades_Pacientes", x => x.Cod_Enfermidade_Paciente);
                    table.ForeignKey(
                        name: "FK_Enfermidades_Pacientes_Enfermidades_EnfermidadeCod_Enfermida~",
                        column: x => x.EnfermidadeCod_Enfermidade,
                        principalTable: "Enfermidades",
                        principalColumn: "Cod_Enfermidade",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Enfermidades_Pacientes_Pacientes_PacienteCod_Paciente",
                        column: x => x.PacienteCod_Paciente,
                        principalTable: "Pacientes",
                        principalColumn: "Cod_Paciente",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Enfermidades_Pacientes_Pessoas_Cod_Pessoa_Medico",
                        column: x => x.Cod_Pessoa_Medico,
                        principalTable: "Pessoas",
                        principalColumn: "Cod_Pessoa",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enfermidades_Pacientes_Pessoas_Cod_Pessoa_Paciente",
                        column: x => x.Cod_Pessoa_Paciente,
                        principalTable: "Pessoas",
                        principalColumn: "Cod_Pessoa",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Paciente_Relacionamentos",
                columns: table => new
                {
                    Codigo_Relacionamento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Ativo = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Cod_Pessoa_Paciente = table.Column<int>(type: "int", nullable: false),
                    Cod_Pessoa_Medico = table.Column<int>(type: "int", nullable: false),
                    PacienteCod_Paciente = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paciente_Relacionamentos", x => x.Codigo_Relacionamento);
                    table.ForeignKey(
                        name: "FK_Paciente_Relacionamentos_Pacientes_PacienteCod_Paciente",
                        column: x => x.PacienteCod_Paciente,
                        principalTable: "Pacientes",
                        principalColumn: "Cod_Paciente",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Paciente_Relacionamentos_Pessoas_Cod_Pessoa_Medico",
                        column: x => x.Cod_Pessoa_Medico,
                        principalTable: "Pessoas",
                        principalColumn: "Cod_Pessoa",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Paciente_Relacionamentos_Pessoas_Cod_Pessoa_Paciente",
                        column: x => x.Cod_Pessoa_Paciente,
                        principalTable: "Pessoas",
                        principalColumn: "Cod_Pessoa",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Relatorios_Diarios",
                columns: table => new
                {
                    Cod_Diario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Data_Diario = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Sintomas = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cod_Questionario = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Questionario_MedicoCod_Questionario = table.Column<int>(type: "int", nullable: true),
                    Cod_Pessoa = table.Column<int>(type: "int", nullable: false),
                    PacienteCod_Pessoa = table.Column<int>(type: "int", nullable: true),
                    PacienteCod_Paciente = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relatorios_Diarios", x => x.Cod_Diario);
                    table.ForeignKey(
                        name: "FK_Relatorios_Diarios_Pacientes_PacienteCod_Paciente",
                        column: x => x.PacienteCod_Paciente,
                        principalTable: "Pacientes",
                        principalColumn: "Cod_Paciente",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Relatorios_Diarios_Pessoas_PacienteCod_Pessoa",
                        column: x => x.PacienteCod_Pessoa,
                        principalTable: "Pessoas",
                        principalColumn: "Cod_Pessoa",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Relatorios_Diarios_Questionarios_Medicos_Questionario_Medico~",
                        column: x => x.Questionario_MedicoCod_Questionario,
                        principalTable: "Questionarios_Medicos",
                        principalColumn: "Cod_Questionario",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Receituarios",
                columns: table => new
                {
                    Cod_Receituario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Medicamento = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Dosagem = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Intervalo_Horas = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Inicio = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Fim = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Lembrete = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Cod_Consulta = table.Column<int>(type: "int", nullable: false),
                    ConsultaCod_Consulta = table.Column<int>(type: "int", nullable: true),
                    Cod_Enfermidade = table.Column<int>(type: "int", nullable: false),
                    EnfermidadeCod_Enfermidade = table.Column<int>(type: "int", nullable: true),
                    Cod_Pessoa_Paciente = table.Column<int>(type: "int", nullable: false),
                    Cod_Pessoa_Medico = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receituarios", x => x.Cod_Receituario);
                    table.ForeignKey(
                        name: "FK_Receituarios_Consultas_ConsultaCod_Consulta",
                        column: x => x.ConsultaCod_Consulta,
                        principalTable: "Consultas",
                        principalColumn: "Cod_Consulta",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Receituarios_Enfermidades_EnfermidadeCod_Enfermidade",
                        column: x => x.EnfermidadeCod_Enfermidade,
                        principalTable: "Enfermidades",
                        principalColumn: "Cod_Enfermidade",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Receituarios_Pessoas_Cod_Pessoa_Medico",
                        column: x => x.Cod_Pessoa_Medico,
                        principalTable: "Pessoas",
                        principalColumn: "Cod_Pessoa",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Receituarios_Pessoas_Cod_Pessoa_Paciente",
                        column: x => x.Cod_Pessoa_Paciente,
                        principalTable: "Pessoas",
                        principalColumn: "Cod_Pessoa",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Questionarios_Respostas",
                columns: table => new
                {
                    Cod_Resposta = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Resposta = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cod_Pessoa_Paciente = table.Column<int>(type: "int", nullable: false),
                    Cod_Pessoa_Medico = table.Column<int>(type: "int", nullable: false),
                    Cod_Dispositivo = table.Column<int>(type: "int", nullable: false),
                    DispositivoCod_Dispositivo = table.Column<int>(type: "int", nullable: true),
                    Cod_Questionario = table.Column<int>(type: "int", nullable: false),
                    Questionario_MedicoCod_Questionario = table.Column<int>(type: "int", nullable: true),
                    Cod_Diario = table.Column<int>(type: "int", nullable: false),
                    Relatorio_DiarioCod_Diario = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questionarios_Respostas", x => x.Cod_Resposta);
                    table.ForeignKey(
                        name: "FK_Questionarios_Respostas_Dispositivos_DispositivoCod_Disposit~",
                        column: x => x.DispositivoCod_Dispositivo,
                        principalTable: "Dispositivos",
                        principalColumn: "Cod_Dispositivo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Questionarios_Respostas_Pessoas_Cod_Pessoa_Medico",
                        column: x => x.Cod_Pessoa_Medico,
                        principalTable: "Pessoas",
                        principalColumn: "Cod_Pessoa",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Questionarios_Respostas_Pessoas_Cod_Pessoa_Paciente",
                        column: x => x.Cod_Pessoa_Paciente,
                        principalTable: "Pessoas",
                        principalColumn: "Cod_Pessoa",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Questionarios_Respostas_Questionarios_Medicos_Questionario_M~",
                        column: x => x.Questionario_MedicoCod_Questionario,
                        principalTable: "Questionarios_Medicos",
                        principalColumn: "Cod_Questionario",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Questionarios_Respostas_Relatorios_Diarios_Relatorio_DiarioC~",
                        column: x => x.Relatorio_DiarioCod_Diario,
                        principalTable: "Relatorios_Diarios",
                        principalColumn: "Cod_Diario",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Consultas_Cod_Pessoa_Medico",
                table: "Consultas",
                column: "Cod_Pessoa_Medico");

            migrationBuilder.CreateIndex(
                name: "IX_Consultas_Cod_Pessoa_Paciente",
                table: "Consultas",
                column: "Cod_Pessoa_Paciente");

            migrationBuilder.CreateIndex(
                name: "IX_Consultas_PacienteCod_Paciente",
                table: "Consultas",
                column: "PacienteCod_Paciente");

            migrationBuilder.CreateIndex(
                name: "IX_Contatos_PessoaCod_Pessoa",
                table: "Contatos",
                column: "PessoaCod_Pessoa");

            migrationBuilder.CreateIndex(
                name: "IX_Dispositivos_PessoaCod_Pessoa",
                table: "Dispositivos",
                column: "PessoaCod_Pessoa");

            migrationBuilder.CreateIndex(
                name: "IX_Enfermidades_DeficienciaCod_Deficiencia",
                table: "Enfermidades",
                column: "DeficienciaCod_Deficiencia");

            migrationBuilder.CreateIndex(
                name: "IX_Enfermidades_Pacientes_Cod_Pessoa_Medico",
                table: "Enfermidades_Pacientes",
                column: "Cod_Pessoa_Medico");

            migrationBuilder.CreateIndex(
                name: "IX_Enfermidades_Pacientes_Cod_Pessoa_Paciente",
                table: "Enfermidades_Pacientes",
                column: "Cod_Pessoa_Paciente");

            migrationBuilder.CreateIndex(
                name: "IX_Enfermidades_Pacientes_EnfermidadeCod_Enfermidade",
                table: "Enfermidades_Pacientes",
                column: "EnfermidadeCod_Enfermidade");

            migrationBuilder.CreateIndex(
                name: "IX_Enfermidades_Pacientes_PacienteCod_Paciente",
                table: "Enfermidades_Pacientes",
                column: "PacienteCod_Paciente");

            migrationBuilder.CreateIndex(
                name: "IX_Medicos_PessoaCod_Pessoa",
                table: "Medicos",
                column: "PessoaCod_Pessoa");

            migrationBuilder.CreateIndex(
                name: "IX_Paciente_Relacionamentos_Cod_Pessoa_Medico",
                table: "Paciente_Relacionamentos",
                column: "Cod_Pessoa_Medico");

            migrationBuilder.CreateIndex(
                name: "IX_Paciente_Relacionamentos_Cod_Pessoa_Paciente",
                table: "Paciente_Relacionamentos",
                column: "Cod_Pessoa_Paciente");

            migrationBuilder.CreateIndex(
                name: "IX_Paciente_Relacionamentos_PacienteCod_Paciente",
                table: "Paciente_Relacionamentos",
                column: "PacienteCod_Paciente");

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_PessoaCod_Pessoa",
                table: "Pacientes",
                column: "PessoaCod_Pessoa");

            migrationBuilder.CreateIndex(
                name: "IX_Pessoas_Pessoa_TipoCod_Pessoa_Tipo",
                table: "Pessoas",
                column: "Pessoa_TipoCod_Pessoa_Tipo");

            migrationBuilder.CreateIndex(
                name: "IX_Questionarios_Medicos_Cod_Pessoa_Medico",
                table: "Questionarios_Medicos",
                column: "Cod_Pessoa_Medico");

            migrationBuilder.CreateIndex(
                name: "IX_Questionarios_Medicos_Cod_Pessoa_Paciente",
                table: "Questionarios_Medicos",
                column: "Cod_Pessoa_Paciente");

            migrationBuilder.CreateIndex(
                name: "IX_Questionarios_Medicos_EnfermidadeCod_Enfermidade",
                table: "Questionarios_Medicos",
                column: "EnfermidadeCod_Enfermidade");

            migrationBuilder.CreateIndex(
                name: "IX_Questionarios_Respostas_Cod_Pessoa_Medico",
                table: "Questionarios_Respostas",
                column: "Cod_Pessoa_Medico");

            migrationBuilder.CreateIndex(
                name: "IX_Questionarios_Respostas_Cod_Pessoa_Paciente",
                table: "Questionarios_Respostas",
                column: "Cod_Pessoa_Paciente");

            migrationBuilder.CreateIndex(
                name: "IX_Questionarios_Respostas_DispositivoCod_Dispositivo",
                table: "Questionarios_Respostas",
                column: "DispositivoCod_Dispositivo");

            migrationBuilder.CreateIndex(
                name: "IX_Questionarios_Respostas_Questionario_MedicoCod_Questionario",
                table: "Questionarios_Respostas",
                column: "Questionario_MedicoCod_Questionario");

            migrationBuilder.CreateIndex(
                name: "IX_Questionarios_Respostas_Relatorio_DiarioCod_Diario",
                table: "Questionarios_Respostas",
                column: "Relatorio_DiarioCod_Diario");

            migrationBuilder.CreateIndex(
                name: "IX_Receituarios_Cod_Pessoa_Medico",
                table: "Receituarios",
                column: "Cod_Pessoa_Medico");

            migrationBuilder.CreateIndex(
                name: "IX_Receituarios_Cod_Pessoa_Paciente",
                table: "Receituarios",
                column: "Cod_Pessoa_Paciente");

            migrationBuilder.CreateIndex(
                name: "IX_Receituarios_ConsultaCod_Consulta",
                table: "Receituarios",
                column: "ConsultaCod_Consulta");

            migrationBuilder.CreateIndex(
                name: "IX_Receituarios_EnfermidadeCod_Enfermidade",
                table: "Receituarios",
                column: "EnfermidadeCod_Enfermidade");

            migrationBuilder.CreateIndex(
                name: "IX_Relatorios_Diarios_PacienteCod_Paciente",
                table: "Relatorios_Diarios",
                column: "PacienteCod_Paciente");

            migrationBuilder.CreateIndex(
                name: "IX_Relatorios_Diarios_PacienteCod_Pessoa",
                table: "Relatorios_Diarios",
                column: "PacienteCod_Pessoa");

            migrationBuilder.CreateIndex(
                name: "IX_Relatorios_Diarios_Questionario_MedicoCod_Questionario",
                table: "Relatorios_Diarios",
                column: "Questionario_MedicoCod_Questionario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contatos");

            migrationBuilder.DropTable(
                name: "Enfermidades_Pacientes");

            migrationBuilder.DropTable(
                name: "Medicos");

            migrationBuilder.DropTable(
                name: "Paciente_Relacionamentos");

            migrationBuilder.DropTable(
                name: "Questionarios_Respostas");

            migrationBuilder.DropTable(
                name: "Receituarios");

            migrationBuilder.DropTable(
                name: "Dispositivos");

            migrationBuilder.DropTable(
                name: "Relatorios_Diarios");

            migrationBuilder.DropTable(
                name: "Consultas");

            migrationBuilder.DropTable(
                name: "Questionarios_Medicos");

            migrationBuilder.DropTable(
                name: "Pacientes");

            migrationBuilder.DropTable(
                name: "Enfermidades");

            migrationBuilder.DropTable(
                name: "Pessoas");

            migrationBuilder.DropTable(
                name: "Deficiencias");

            migrationBuilder.DropTable(
                name: "Pessoa_Tipos");
        }
    }
}
