using ACE.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using ACE.Infraestructure.Mapping;

namespace ACE.Infraestructure.Context
{
    public class AppDbContext : IdentityDbContext<Usuario, IdentityRole<Guid>, Guid>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Turma> Turmas { get; set; }
        public DbSet<Matricula> Matriculas { get; set; }
        //public DbSet<Teste> Testes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new AlunoMapping());
            modelBuilder.ApplyConfiguration(new TurmaMapping());
            modelBuilder.ApplyConfiguration(new MatriculaMapping());
            modelBuilder.ApplyConfiguration(new UsuarioMapping());

            SeedIdentity(modelBuilder);

            SeedDadosEscolares(modelBuilder);

        }

        private void SeedIdentity(ModelBuilder builder)
        {

            var adminRoleId = Guid.Parse("C1C3D8A0-E3A2-4B7C-9E5F-8F8D6A4B3C2A");
            var professorRoleId = Guid.Parse("A9B5C4D3-F2E1-4D6C-9B8A-7C6B5A4D3E2F");

            var adminUserId = Guid.Parse("B4B3C2A1-D3E4-4F5B-A6C7-8D9E0A1B2C3D");

            // Roles
            builder.Entity<IdentityRole<Guid>>().HasData(
                new IdentityRole<Guid>
                {
                    Id = adminRoleId,
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole<Guid>
                {
                    Id = professorRoleId,
                    Name = "Professor",
                    NormalizedName = "PROFESSOR"
                }
            );

            // Usuario Admin
            var hasher = new PasswordHasher<Usuario>();

            var adminUser = new Usuario
            {
                Id = adminUserId,
                UserName = "admin@escola.com",
                NormalizedUserName = "ADMIN@ESCOLA.COM",
                Email = "admin@escola.com",
                NormalizedEmail = "ADMIN@ESCOLA.COM",
                EmailConfirmed = true,

               
                SecurityStamp = "E1F5C2F9-93F1-4F5C-A38F-71B2D1F9A3FE",
                ConcurrencyStamp = "C9D4E3F7-12A4-4A2B-A0E1-9287B1C77AF9"
            };

            adminUser.PasswordHash = hasher.HashPassword(adminUser, "abc12345");

            builder.Entity<Usuario>().HasData(adminUser);

            // Vincula Role Admin ao usuário Admin
            builder.Entity<IdentityUserRole<Guid>>().HasData(
                new IdentityUserRole<Guid>
                {
                    UserId = adminUserId,
                    RoleId = adminRoleId
                }
            );

            #region
            //// 1. Definição dos GUIDs para Roles e Usuário Admin
            //// Use GUIDs fixos para que a migração seja idempotente
            //var adminRoleId = Guid.Parse("C1C3D8A0-E3A2-4B7C-9E5F-8F8D6A4B3C2A");
            //var professorRoleId = Guid.Parse("A9B5C4D3-F2E1-4D6C-9B8A-7C6B5A4D3E2F");

            ////Usuario
            //var adminUserId = Guid.Parse("B4B3C2A1-D3E4-4F5B-A6C7-8D9E0A1B2C3D");

            //// 2. Criação das Roles (Admin e Professor)
            //builder.Entity<IdentityRole<Guid>>().HasData(
            //    new IdentityRole<Guid>
            //    {
            //        Id = adminRoleId,
            //        Name = "Admin",
            //        NormalizedName = "ADMIN"
            //    },
            //    new IdentityRole<Guid>
            //    {
            //        Id = professorRoleId,
            //        Name = "Professor",
            //        NormalizedName = "PROFESSOR"
            //    }
            //);

            //// 3. Criação do Usuário Admin (apenas o esqueleto)
            //// OBS: Você precisará de um PasswordHasher para inserir a senha real aqui.
            //// É MUITO MAIS SEGURO e FÁCIL criar o Admin no Program.cs (Seed manual).
            //// Por simplificação (apenas para demonstração do HasData):
            //var hasher = new PasswordHasher<Usuario>();

            //var adminUser = new Usuario
            //{
            //    //Id = adminUserId,
            //    //UserName = "admin@escola.com",
            //    //NormalizedUserName = "ADMIN@ESCOLA.COM",
            //    //Email = "admin@escola.com",
            //    //NormalizedEmail = "ADMIN@ESCOLA.COM",
            //    //// A senha abaixo é "Senha123!". **ATENÇÃO: Mude a senha real!**
            //    //PasswordHash = hasher.HashPassword(null, "Senha123"),
            //    //EmailConfirmed = true,
            //    //SecurityStamp = Guid.NewGuid().ToString("D")

            //    Id = adminUserId,
            //    UserName = "admin@escola.com",
            //    NormalizedUserName = "ADMIN@ESCOLA.COM",
            //    Email = "admin@escola.com",
            //    NormalizedEmail = "ADMIN@ESCOLA.COM",
            //    EmailConfirmed = true,
            //    SecurityStamp = Guid.NewGuid().ToString("D"),
            //    ConcurrencyStamp = Guid.NewGuid().ToString("D")
            //};

            //adminUser.PasswordHash = hasher.HashPassword(adminUser, "Senha123!");

            //builder.Entity<Usuario>().HasData(adminUser);

            //// 4. Atribuição da Role (Admin) ao Usuário
            //builder.Entity<IdentityUserRole<Guid>>().HasData(
            //    new IdentityUserRole<Guid>
            //    {
            //        RoleId = adminRoleId,
            //        UserId = adminUserId
            //    }
            //);
            #endregion
        }

        private void SeedDadosEscolares(ModelBuilder builder)
        {
           
            var al1 = Guid.NewGuid();
            var al2 = Guid.NewGuid();
            var al3 = Guid.NewGuid();

            var t1 = Guid.NewGuid();
            var t2 = Guid.NewGuid();
            var t3 = Guid.NewGuid();

            builder.Entity<Turma>().HasData(
                new Turma { Id = t1, Nome = "1º Ano - Fundamental I" },
                new Turma { Id = t2, Nome = "9º Ano - Fundamental II" },
                new Turma { Id = t3, Nome = "3ª Série - Ensino Médio" }
            );

          
            builder.Entity<Aluno>().HasData(
                new Aluno
                {
                    Id = al1,
                    Nome = "Mara Lima",
                    CPF = "111.111.111-11",
                    CEP = "20040-003",
                    Logradouro = "Av. Rio Branco",
                    Bairro = "Centro",
                    Cidade = "Rio de Janeiro",
                    UF = "RJ",
                    Numero = 100
                },
                new Aluno
                {
                    Id = al2,
                    Nome = "Bruno Dalate",
                    CPF = "222.222.222-22",
                    CEP = "01311-300",
                    Logradouro = "Av. Paulista",
                    Bairro = "Bela Vista",
                    Cidade = "São Paulo",
                    UF = "SP",
                    Numero = 1200
                },
                new Aluno
                {
                    Id = al3,
                    Nome = "Bruna Silva",
                    CPF = "333.333.333-33",
                    CEP = "70040-000",
                    Logradouro = "Praça dos Três Poderes",
                    Bairro = "Zona Cívico-Administrativa",
                    Cidade = "Brasília",
                    UF = "DF",
                    Numero = 10
                }
            );

          
            builder.Entity<Matricula>().HasData(
                new Matricula { Id = 1000, AlunoId = al1, TurmaId = t1, DataMatricula = DateTime.Now.AddDays(-50) },
                new Matricula { Id = 1001, AlunoId = al2, TurmaId = t2, DataMatricula = DateTime.Now.AddDays(-30) },
                new Matricula { Id = 1002, AlunoId = al3, TurmaId = t3, DataMatricula = DateTime.Now.AddDays(-10) }
            );

        }

    }

    //****************************************************************************************************
    //****************************************************************************************************
  
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {

        public AppDbContext CreateDbContext(string[] args)
        {
           
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
     
            const string connectionString = "Data Source=DESKTOP-LQU3KL7\\MSSQLSERVER14;Initial Catalog=dbcadastroescolar;Integrated Security=True;TrustServerCertificate=True";

            optionsBuilder.UseSqlServer(connectionString);

            return new AppDbContext(optionsBuilder.Options);

        }
    
    }

}