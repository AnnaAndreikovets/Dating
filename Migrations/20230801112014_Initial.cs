using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatingSite.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Blanks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    SecondName = table.Column<string>(type: "TEXT", nullable: false),
                    Age = table.Column<byte>(type: "INTEGER", nullable: false),
                    Photo = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Sex = table.Column<string>(type: "TEXT", nullable: false),
                    PreferSex = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blanks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Chats",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Interactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interactions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Interesteds",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interesteds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    BlankId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Chat",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    BlankId = table.Column<Guid>(type: "TEXT", nullable: false),
                    AnketId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ChatsId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chat_Chats_ChatsId",
                        column: x => x.ChatsId,
                        principalTable: "Chats",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Anket",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    See = table.Column<bool>(type: "INTEGER", nullable: false),
                    Like = table.Column<bool>(type: "INTEGER", nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    InteractionId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anket", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Anket_Interactions_InteractionId",
                        column: x => x.InteractionId,
                        principalTable: "Interactions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InterestedUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    InterestedId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterestedUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InterestedUsers_Interesteds_InterestedId",
                        column: x => x.InterestedId,
                        principalTable: "Interesteds",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Message",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Text = table.Column<string>(type: "TEXT", nullable: false),
                    Time = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Reading = table.Column<bool>(type: "INTEGER", nullable: false),
                    ChatId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Message_Chat_ChatId",
                        column: x => x.ChatId,
                        principalTable: "Chat",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Anket_InteractionId",
                table: "Anket",
                column: "InteractionId");

            migrationBuilder.CreateIndex(
                name: "IX_Chat_ChatsId",
                table: "Chat",
                column: "ChatsId");

            migrationBuilder.CreateIndex(
                name: "IX_InterestedUsers_InterestedId",
                table: "InterestedUsers",
                column: "InterestedId");

            migrationBuilder.CreateIndex(
                name: "IX_Message_ChatId",
                table: "Message",
                column: "ChatId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Anket");

            migrationBuilder.DropTable(
                name: "Blanks");

            migrationBuilder.DropTable(
                name: "InterestedUsers");

            migrationBuilder.DropTable(
                name: "Message");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Interactions");

            migrationBuilder.DropTable(
                name: "Interesteds");

            migrationBuilder.DropTable(
                name: "Chat");

            migrationBuilder.DropTable(
                name: "Chats");
        }
    }
}
