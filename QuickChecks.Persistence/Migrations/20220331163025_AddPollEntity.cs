using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using QuickChecks.Kernel.Entities.Enum;

#nullable disable

namespace QuickChecks.Persistence.Migrations
{
    public partial class AddPollEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:poll_status", "pending,in_progress,completed,aborted")
                .Annotation("Npgsql:Enum:question_type", "single,multiple");

            migrationBuilder.CreateTable(
                name: "poll_entity",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    status = table.Column<PollStatus>(type: "poll_status", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    started_date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    completed_date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    poll_template_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_poll_entity", x => x.id);
                    table.ForeignKey(
                        name: "fk_poll_entity_poll_templates_poll_template_id",
                        column: x => x.poll_template_id,
                        principalTable: "poll_templates",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "category_entity",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    poll_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_category_entity", x => x.id);
                    table.ForeignKey(
                        name: "fk_category_entity_poll_entity_poll_id",
                        column: x => x.poll_id,
                        principalTable: "poll_entity",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "question_entity",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    order_index = table.Column<int>(type: "integer", nullable: false),
                    is_required = table.Column<bool>(type: "boolean", nullable: false),
                    content = table.Column<string>(type: "text", nullable: true),
                    type = table.Column<QuestionType>(type: "question_type", nullable: false),
                    category_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_question_entity", x => x.id);
                    table.ForeignKey(
                        name: "fk_question_entity_category_entity_category_id",
                        column: x => x.category_id,
                        principalTable: "category_entity",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "question_option_entity",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    order_index = table.Column<int>(type: "integer", nullable: false),
                    content = table.Column<string>(type: "text", nullable: true),
                    score = table.Column<int>(type: "integer", nullable: false),
                    question_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_question_option_entity", x => x.id);
                    table.ForeignKey(
                        name: "fk_question_option_entity_question_entity_question_id",
                        column: x => x.question_id,
                        principalTable: "question_entity",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_category_entity_poll_id",
                table: "category_entity",
                column: "poll_id");

            migrationBuilder.CreateIndex(
                name: "ix_poll_entity_poll_template_id",
                table: "poll_entity",
                column: "poll_template_id");

            migrationBuilder.CreateIndex(
                name: "ix_question_entity_category_id",
                table: "question_entity",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "ix_question_option_entity_question_id",
                table: "question_option_entity",
                column: "question_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "question_option_entity");

            migrationBuilder.DropTable(
                name: "question_entity");

            migrationBuilder.DropTable(
                name: "category_entity");

            migrationBuilder.DropTable(
                name: "poll_entity");

            migrationBuilder.AlterDatabase()
                .OldAnnotation("Npgsql:Enum:poll_status", "pending,in_progress,completed,aborted")
                .OldAnnotation("Npgsql:Enum:question_type", "single,multiple");
        }
    }
}
