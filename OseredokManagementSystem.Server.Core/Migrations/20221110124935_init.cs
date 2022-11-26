using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OseredokManagementSystem.Server.Core.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClientPayments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentPerSession = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LastPaymentSum = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LastPaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientPayments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gyms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientCapacity = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gyms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SessionStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RegDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProfileImgPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    GymId = table.Column<int>(type: "int", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Admins_Gyms_GymId",
                        column: x => x.GymId,
                        principalTable: "Gyms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Admins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Coaches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    GymId = table.Column<int>(type: "int", nullable: false),
                    PercentagePerSession = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coaches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Coaches_Gyms_GymId",
                        column: x => x.GymId,
                        principalTable: "Gyms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Coaches_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClientPaymentId = table.Column<int>(type: "int", nullable: false),
                    CoachId = table.Column<int>(type: "int", nullable: false),
                    GymId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clients_ClientPayments_ClientPaymentId",
                        column: x => x.ClientPaymentId,
                        principalTable: "ClientPayments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Clients_Coaches_CoachId",
                        column: x => x.CoachId,
                        principalTable: "Coaches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Clients_Gyms_GymId",
                        column: x => x.GymId,
                        principalTable: "Gyms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Clients_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    CoachId = table.Column<int>(type: "int", nullable: false),
                    GymId = table.Column<int>(type: "int", nullable: false),
                    SessionStatusId = table.Column<int>(type: "int", nullable: false),
                    SessionDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sessions_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sessions_Coaches_CoachId",
                        column: x => x.CoachId,
                        principalTable: "Coaches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sessions_Gyms_GymId",
                        column: x => x.GymId,
                        principalTable: "Gyms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sessions_SessionStatuses_SessionStatusId",
                        column: x => x.SessionStatusId,
                        principalTable: "SessionStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ClientPayments",
                columns: new[] { "Id", "Balance", "LastPaymentDate", "LastPaymentSum", "PaymentPerSession" },
                values: new object[] { 1, 100m, new DateTime(2022, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 100m, 50m });

            migrationBuilder.InsertData(
                table: "Gyms",
                columns: new[] { "Id", "Address", "ClientCapacity" },
                values: new object[] { 1, "someAddress", 5 });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "admin" },
                    { 2, "coach" },
                    { 3, "client" }
                });

            migrationBuilder.InsertData(
                table: "SessionStatuses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 4, "awaiting" },
                    { 5, "accepted" },
                    { 6, "inProcess" },
                    { 7, "completed" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DateOfBirth", "FirstName", "LastName", "MiddleName", "Password", "PhoneNumber", "ProfileImgPath", "RegDate", "RoleId" },
                values: new object[,]
                {
                    { 1, new DateTime(2002, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nazar", "Sachuk", "Igorovych", "loremIpsum123", "0509781078", "some/path", new DateTime(2022, 11, 10, 14, 49, 27, 867, DateTimeKind.Local).AddTicks(2096), 3 },
                    { 2, new DateTime(2002, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nazar2", "Sachuk2", "Igorovych2", "loremIpsum123", "0509781078", "some/path", new DateTime(2022, 11, 10, 14, 49, 27, 867, DateTimeKind.Local).AddTicks(2123), 3 },
                    { 3, new DateTime(2002, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nazar3", "Sachuk3", "Igorovych3", "loremIpsum123", "0509781078", "some/path", new DateTime(2022, 11, 10, 14, 49, 27, 867, DateTimeKind.Local).AddTicks(2126), 3 },
                    { 4, new DateTime(2002, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Max", "Smirnov", "lorem", "loremIpsum123", "0509781078", "some/path", new DateTime(2022, 11, 10, 14, 49, 27, 867, DateTimeKind.Local).AddTicks(2128), 2 },
                    { 5, new DateTime(2002, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Masha", "lorem", "lorem", "loremIpsum123", "0509781078", "some/path", new DateTime(2022, 11, 10, 14, 49, 27, 867, DateTimeKind.Local).AddTicks(2130), 1 },
                    { 6, new DateTime(2002, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pasha", "Mamchyr", "Olexandrovych", "loremIpsum123", "0509781078", "some/path", new DateTime(2022, 11, 10, 14, 49, 27, 867, DateTimeKind.Local).AddTicks(2132), 2 }
                });

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "Id", "GymId", "Salary", "UserId" },
                values: new object[] { 1, 1, 6000m, 5 });

            migrationBuilder.InsertData(
                table: "Coaches",
                columns: new[] { "Id", "GymId", "PercentagePerSession", "UserId" },
                values: new object[] { 1, 1, 10m, 4 });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "ClientPaymentId", "CoachId", "GymId", "UserId" },
                values: new object[] { 1, 1, 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "Sessions",
                columns: new[] { "Id", "ClientId", "CoachId", "GymId", "SessionDate", "SessionStatusId" },
                values: new object[] { 1, 1, 1, 1, new DateTime(2022, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.InsertData(
                table: "Sessions",
                columns: new[] { "Id", "ClientId", "CoachId", "GymId", "SessionDate", "SessionStatusId" },
                values: new object[] { 2, 1, 1, 1, new DateTime(2022, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.InsertData(
                table: "Sessions",
                columns: new[] { "Id", "ClientId", "CoachId", "GymId", "SessionDate", "SessionStatusId" },
                values: new object[] { 3, 1, 1, 1, new DateTime(2022, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.CreateIndex(
                name: "IX_Admins_GymId",
                table: "Admins",
                column: "GymId");

            migrationBuilder.CreateIndex(
                name: "IX_Admins_UserId",
                table: "Admins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_ClientPaymentId",
                table: "Clients",
                column: "ClientPaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_CoachId",
                table: "Clients",
                column: "CoachId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_GymId",
                table: "Clients",
                column: "GymId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_UserId",
                table: "Clients",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Coaches_GymId",
                table: "Coaches",
                column: "GymId");

            migrationBuilder.CreateIndex(
                name: "IX_Coaches_UserId",
                table: "Coaches",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_ClientId",
                table: "Sessions",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_CoachId",
                table: "Sessions",
                column: "CoachId");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_GymId",
                table: "Sessions",
                column: "GymId");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_SessionStatusId",
                table: "Sessions",
                column: "SessionStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Sessions");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "SessionStatuses");

            migrationBuilder.DropTable(
                name: "ClientPayments");

            migrationBuilder.DropTable(
                name: "Coaches");

            migrationBuilder.DropTable(
                name: "Gyms");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}