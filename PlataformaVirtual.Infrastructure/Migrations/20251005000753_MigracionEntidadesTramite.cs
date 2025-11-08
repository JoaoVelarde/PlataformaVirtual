using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlataformaVirtual.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MigracionEntidadesTramite : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "tramite");

            migrationBuilder.CreateTable(
                name: "persona",
                schema: "tramite",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    id_tipo_documento = table.Column<int>(type: "integer", nullable: false),
                    NroDocumento_TipoDocumentoId = table.Column<int>(type: "integer", nullable: false),
                    nro_documento = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    nombres = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    primer_apellido = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    segundo_apellido = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    direccion = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    correo = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    celular = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    UsuarioCreaId = table.Column<Guid>(type: "uuid", nullable: false),
                    FechaCrea = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UsuarioModificaId = table.Column<Guid>(type: "uuid", nullable: true),
                    FechaModifica = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UsuarioEliminaId = table.Column<Guid>(type: "uuid", nullable: true),
                    FechaElimina = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    EstadoId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_persona", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "procedimiento",
                schema: "tramite",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    nombre = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    UsuarioCreaId = table.Column<Guid>(type: "uuid", nullable: false),
                    FechaCrea = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UsuarioModificaId = table.Column<Guid>(type: "uuid", nullable: true),
                    FechaModifica = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UsuarioEliminaId = table.Column<Guid>(type: "uuid", nullable: true),
                    FechaElimina = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    EstadoId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_procedimiento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "operador",
                schema: "tramite",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    foto_operador = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    persona_id = table.Column<Guid>(type: "uuid", nullable: false),
                    correo = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    UsuarioCreaId = table.Column<Guid>(type: "uuid", nullable: false),
                    FechaCrea = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UsuarioModificaId = table.Column<Guid>(type: "uuid", nullable: true),
                    FechaModifica = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UsuarioEliminaId = table.Column<Guid>(type: "uuid", nullable: true),
                    FechaElimina = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    EstadoId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_operador", x => x.Id);
                    table.ForeignKey(
                        name: "FK_operador_persona_persona_id",
                        column: x => x.persona_id,
                        principalSchema: "tramite",
                        principalTable: "persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "expediente",
                schema: "tramite",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    nro_expediente = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    procedimiento_id = table.Column<Guid>(type: "uuid", nullable: false),
                    UsuarioCreaId = table.Column<Guid>(type: "uuid", nullable: false),
                    FechaCrea = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UsuarioModificaId = table.Column<Guid>(type: "uuid", nullable: true),
                    FechaModifica = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UsuarioEliminaId = table.Column<Guid>(type: "uuid", nullable: true),
                    FechaElimina = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    EstadoId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_expediente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_expediente_procedimiento_procedimiento_id",
                        column: x => x.procedimiento_id,
                        principalSchema: "tramite",
                        principalTable: "procedimiento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "operador_credencial",
                schema: "tramite",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    numero_credencial = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    operador_id = table.Column<Guid>(type: "uuid", nullable: false),
                    expediente_id = table.Column<Guid>(type: "uuid", nullable: false),
                    fecha_vencimiento = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UsuarioCreaId = table.Column<Guid>(type: "uuid", nullable: false),
                    FechaCrea = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UsuarioModificaId = table.Column<Guid>(type: "uuid", nullable: true),
                    FechaModifica = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UsuarioEliminaId = table.Column<Guid>(type: "uuid", nullable: true),
                    FechaElimina = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    EstadoId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_operador_credencial", x => x.Id);
                    table.ForeignKey(
                        name: "FK_operador_credencial_expediente_expediente_id",
                        column: x => x.expediente_id,
                        principalSchema: "tramite",
                        principalTable: "expediente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_operador_credencial_operador_operador_id",
                        column: x => x.operador_id,
                        principalSchema: "tramite",
                        principalTable: "operador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "operador_entidad",
                schema: "tramite",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    expediente_id = table.Column<Guid>(type: "uuid", nullable: false),
                    operador_id = table.Column<Guid>(type: "uuid", nullable: false),
                    UsuarioCreaId = table.Column<Guid>(type: "uuid", nullable: false),
                    FechaCrea = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UsuarioModificaId = table.Column<Guid>(type: "uuid", nullable: true),
                    FechaModifica = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UsuarioEliminaId = table.Column<Guid>(type: "uuid", nullable: true),
                    FechaElimina = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    EstadoId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_operador_entidad", x => x.Id);
                    table.ForeignKey(
                        name: "FK_operador_entidad_expediente_expediente_id",
                        column: x => x.expediente_id,
                        principalSchema: "tramite",
                        principalTable: "expediente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_operador_entidad_operador_operador_id",
                        column: x => x.operador_id,
                        principalSchema: "tramite",
                        principalTable: "operador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_expediente_nro_expediente",
                schema: "tramite",
                table: "expediente",
                column: "nro_expediente",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_expediente_procedimiento_id",
                schema: "tramite",
                table: "expediente",
                column: "procedimiento_id");

            migrationBuilder.CreateIndex(
                name: "IX_operador_persona_id",
                schema: "tramite",
                table: "operador",
                column: "persona_id");

            migrationBuilder.CreateIndex(
                name: "IX_operador_credencial_expediente_id",
                schema: "tramite",
                table: "operador_credencial",
                column: "expediente_id");

            migrationBuilder.CreateIndex(
                name: "IX_operador_credencial_operador_id",
                schema: "tramite",
                table: "operador_credencial",
                column: "operador_id");

            migrationBuilder.CreateIndex(
                name: "IX_operador_entidad_expediente_id",
                schema: "tramite",
                table: "operador_entidad",
                column: "expediente_id");

            migrationBuilder.CreateIndex(
                name: "IX_operador_entidad_operador_id",
                schema: "tramite",
                table: "operador_entidad",
                column: "operador_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "operador_credencial",
                schema: "tramite");

            migrationBuilder.DropTable(
                name: "operador_entidad",
                schema: "tramite");

            migrationBuilder.DropTable(
                name: "expediente",
                schema: "tramite");

            migrationBuilder.DropTable(
                name: "operador",
                schema: "tramite");

            migrationBuilder.DropTable(
                name: "procedimiento",
                schema: "tramite");

            migrationBuilder.DropTable(
                name: "persona",
                schema: "tramite");
        }
    }
}
