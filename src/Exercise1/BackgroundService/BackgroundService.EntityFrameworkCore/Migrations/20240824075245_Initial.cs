using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BackgroundService.EntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "identity");

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "identity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    LastUpdatePwd = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "identity",
                table: "Users",
                columns: new[] { "Id", "Email", "LastUpdatePwd", "Status" },
                values: new object[,]
                {
                    { new Guid("1e0c4f2a-83c9-4df6-990f-e4042b1b1ff5"), "test1@gmail.com", new DateTime(2024, 1, 24, 14, 52, 45, 519, DateTimeKind.Local).AddTicks(1848), "Default" },
                    { new Guid("37685deb-c7ca-4190-8736-37cc8f50e703"), "test8@gmail.com", new DateTime(2023, 6, 24, 14, 52, 45, 519, DateTimeKind.Local).AddTicks(1894), "Default" },
                    { new Guid("54514b74-4697-42d0-b721-6d1746503991"), "test7@gmail.com", new DateTime(2023, 7, 24, 14, 52, 45, 519, DateTimeKind.Local).AddTicks(1892), "Default" },
                    { new Guid("5ad5c06a-1e4f-4e4c-b9b8-e7eaa7183ce2"), "test4@gmail.com", new DateTime(2023, 10, 24, 14, 52, 45, 519, DateTimeKind.Local).AddTicks(1876), "Default" },
                    { new Guid("8b034e98-f3d4-4e72-8c96-c4af64a1e6d1"), "test2@gmail.com", new DateTime(2023, 12, 24, 14, 52, 45, 519, DateTimeKind.Local).AddTicks(1871), "Default" },
                    { new Guid("91ac6ccb-f63f-4f37-b8b6-7ccdf344d2d6"), "test5@gmail.com", new DateTime(2023, 9, 24, 14, 52, 45, 519, DateTimeKind.Local).AddTicks(1887), "Default" },
                    { new Guid("963810c9-f315-4c7f-bca5-41767b18d0d6"), "test6@gmail.com", new DateTime(2023, 8, 24, 14, 52, 45, 519, DateTimeKind.Local).AddTicks(1890), "Default" },
                    { new Guid("a363f9d1-210f-42c1-adfc-e21f95d633de"), "test10@gmail.com", new DateTime(2023, 4, 24, 14, 52, 45, 519, DateTimeKind.Local).AddTicks(1898), "Default" },
                    { new Guid("bf30d40c-889f-4061-b903-de738d872f0b"), "test3@gmail.com", new DateTime(2023, 11, 24, 14, 52, 45, 519, DateTimeKind.Local).AddTicks(1874), "Default" },
                    { new Guid("e6778ee3-41f9-496f-9f80-3134c5cdb95b"), "test9@gmail.com", new DateTime(2023, 5, 24, 14, 52, 45, 519, DateTimeKind.Local).AddTicks(1896), "Default" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users",
                schema: "identity");
        }
    }
}
