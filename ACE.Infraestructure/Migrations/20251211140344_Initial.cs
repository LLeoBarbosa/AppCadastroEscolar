using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ACE.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBALUNOS",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NOME = table.Column<string>(type: "varchar(50)", nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CEP = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: true),
                    LOGRADOURO = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    BAIRRO = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CIDADE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UF = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    NUMERO = table.Column<int>(type: "int", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBALUNOS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TBTURMAS",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NOME = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBTURMAS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TBUSUARIOS",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBUSUARIOS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TBMATRICULAS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DATAMATRICULA = table.Column<string>(type: "varchar(50)", nullable: false),
                    ALUNO_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TURMA_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ID", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TBMATRICULAS_TBALUNOS_ALUNO_ID",
                        column: x => x.ALUNO_ID,
                        principalTable: "TBALUNOS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TBMATRICULAS_TBTURMAS_TURMA_ID",
                        column: x => x.TURMA_ID,
                        principalTable: "TBTURMAS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_TBUSUARIOS_UserId",
                        column: x => x.UserId,
                        principalTable: "TBUSUARIOS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_TBUSUARIOS_UserId",
                        column: x => x.UserId,
                        principalTable: "TBUSUARIOS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_TBUSUARIOS_UserId",
                        column: x => x.UserId,
                        principalTable: "TBUSUARIOS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_TBUSUARIOS_UserId",
                        column: x => x.UserId,
                        principalTable: "TBUSUARIOS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("a9b5c4d3-f2e1-4d6c-9b8a-7c6b5a4d3e2f"), null, "Professor", "PROFESSOR" },
                    { new Guid("c1c3d8a0-e3a2-4b7c-9e5f-8f8d6a4b3c2a"), null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "TBALUNOS",
                columns: new[] { "ID", "BAIRRO", "CEP", "CPF", "CIDADE", "LOGRADOURO", "NOME", "NUMERO", "UF" },
                values: new object[,]
                {
                    { new Guid("2bd55200-9dca-4483-a347-f96e45afa5f1"), "Bela Vista", "01311-300", "222.222.222-22", "São Paulo", "Av. Paulista", "Bruno Dalate", 1200, "SP" },
                    { new Guid("47061db8-4b3d-4578-8030-98f60a436aed"), "Zona Cívico-Administrativa", "70040-000", "333.333.333-33", "Brasília", "Praça dos Três Poderes", "Bruna Silva", 10, "DF" },
                    { new Guid("c08c23bb-b84a-4f6b-ae42-40222a0376dc"), "Centro", "20040-003", "111.111.111-11", "Rio de Janeiro", "Av. Rio Branco", "Mara Lima", 100, "RJ" }
                });

            migrationBuilder.InsertData(
                table: "TBTURMAS",
                columns: new[] { "ID", "NOME" },
                values: new object[,]
                {
                    { new Guid("33213a40-3e09-488f-a7b4-19d222877d99"), "9º Ano - Fundamental II" },
                    { new Guid("4eaed25b-cff0-4a34-9397-70720abb0276"), "1º Ano - Fundamental I" },
                    { new Guid("6ddfbd03-445a-4904-bb84-0d0d5879d834"), "3ª Série - Ensino Médio" }
                });

            migrationBuilder.InsertData(
                table: "TBUSUARIOS",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("b4b3c2a1-d3e4-4f5b-a6c7-8d9e0a1b2c3d"), 0, "C9D4E3F7-12A4-4A2B-A0E1-9287B1C77AF9", "admin@escola.com", true, false, null, "ADMIN@ESCOLA.COM", "ADMIN@ESCOLA.COM", "AQAAAAIAAYagAAAAECUh8XIIWrBuS9LIy8GrpRCwVCy+YH9GfFsrPlLoMF3a/FAZPEbNXaR8nlBpoZaFnQ==", null, false, "E1F5C2F9-93F1-4F5C-A38F-71B2D1F9A3FE", false, "admin@escola.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("c1c3d8a0-e3a2-4b7c-9e5f-8f8d6a4b3c2a"), new Guid("b4b3c2a1-d3e4-4f5b-a6c7-8d9e0a1b2c3d") });

            migrationBuilder.InsertData(
                table: "TBMATRICULAS",
                columns: new[] { "ID", "ALUNO_ID", "DATAMATRICULA", "TURMA_ID" },
                values: new object[,]
                {
                    { 1000, new Guid("c08c23bb-b84a-4f6b-ae42-40222a0376dc"), "2025-10-22 11:03:43.9516136", new Guid("4eaed25b-cff0-4a34-9397-70720abb0276") },
                    { 1001, new Guid("2bd55200-9dca-4483-a347-f96e45afa5f1"), "2025-11-11 11:03:43.9516157", new Guid("33213a40-3e09-488f-a7b4-19d222877d99") },
                    { 1002, new Guid("47061db8-4b3d-4578-8030-98f60a436aed"), "2025-12-01 11:03:43.9516159", new Guid("6ddfbd03-445a-4904-bb84-0d0d5879d834") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_TBALUNOS_CPF",
                table: "TBALUNOS",
                column: "CPF",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TBMATRICULAS_ALUNO_ID",
                table: "TBMATRICULAS",
                column: "ALUNO_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TBMATRICULAS_TURMA_ID",
                table: "TBMATRICULAS",
                column: "TURMA_ID");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "TBUSUARIOS",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "TBUSUARIOS",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "TBMATRICULAS");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "TBUSUARIOS");

            migrationBuilder.DropTable(
                name: "TBALUNOS");

            migrationBuilder.DropTable(
                name: "TBTURMAS");
        }
    }
}
