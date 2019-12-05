using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GYM.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompanyContext",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    Email = table.Column<string>(maxLength: 120, nullable: false),
                    City = table.Column<string>(maxLength: 150, nullable: false),
                    District = table.Column<string>(maxLength: 150, nullable: false),
                    State = table.Column<string>(maxLength: 150, nullable: false),
                    PersonalIdentity = table.Column<string>(maxLength: 30, nullable: false),
                    NumberRegister = table.Column<string>(maxLength: 30, nullable: false),
                    Telephone = table.Column<string>(maxLength: 15, nullable: false),
                    Fundation = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyContext", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonContext",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonContext", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProfileRuleContext",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Label = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileRuleContext", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RuleContext",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Label = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RuleContext", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BranchContext",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    Email = table.Column<string>(maxLength: 120, nullable: false),
                    City = table.Column<string>(maxLength: 150, nullable: false),
                    District = table.Column<string>(maxLength: 150, nullable: false),
                    State = table.Column<string>(maxLength: 150, nullable: false),
                    PersonalIdentity = table.Column<string>(maxLength: 30, nullable: false),
                    NumberRegister = table.Column<string>(maxLength: 30, nullable: false),
                    Telephone = table.Column<string>(maxLength: 15, nullable: false),
                    Fundation = table.Column<DateTime>(nullable: false),
                    StatusRegister = table.Column<int>(nullable: false),
                    CompanyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchContext", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BranchContext_CompanyContext_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "CompanyContext",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AddressContext",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Addresses = table.Column<string>(maxLength: 150, nullable: false),
                    District = table.Column<string>(maxLength: 150, nullable: false),
                    Number = table.Column<string>(maxLength: 10, nullable: false),
                    Complement = table.Column<string>(nullable: true),
                    State = table.Column<string>(maxLength: 50, nullable: false),
                    YearLocal = table.Column<string>(nullable: true),
                    PersonId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressContext", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AddressContext_PersonContext_PersonId",
                        column: x => x.PersonId,
                        principalTable: "PersonContext",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientContext",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonalIdentity = table.Column<string>(maxLength: 30, nullable: false),
                    NumberRegister = table.Column<string>(maxLength: 30, nullable: false),
                    Office = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(maxLength: 10, nullable: false),
                    BirthDay = table.Column<DateTime>(nullable: false),
                    StatusAccount = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    PersonId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientContext", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientContext_PersonContext_PersonId",
                        column: x => x.PersonId,
                        principalTable: "PersonContext",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmailContext",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressEmail = table.Column<string>(maxLength: 180, nullable: false),
                    PersonId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailContext", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmailContext_PersonContext_PersonId",
                        column: x => x.PersonId,
                        principalTable: "PersonContext",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeContext",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonalIdentity = table.Column<string>(maxLength: 30, nullable: false),
                    NumberRegister = table.Column<string>(maxLength: 30, nullable: false),
                    Office = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: false),
                    BirthDay = table.Column<DateTime>(nullable: false),
                    Pis = table.Column<string>(nullable: true),
                    NumberWallet = table.Column<string>(nullable: true),
                    DateRegister = table.Column<string>(nullable: true),
                    Salary = table.Column<string>(nullable: true),
                    HoursPerDay = table.Column<string>(nullable: true),
                    NameMother = table.Column<string>(nullable: true),
                    Bonus = table.Column<string>(nullable: true),
                    TypeBonus = table.Column<string>(nullable: true),
                    NameFather = table.Column<string>(nullable: true),
                    Reservist = table.Column<string>(nullable: true),
                    TitleVoter = table.Column<string>(nullable: true),
                    Photo = table.Column<string>(nullable: true),
                    UserLogin = table.Column<string>(maxLength: 30, nullable: false),
                    Password = table.Column<string>(maxLength: 255, nullable: false),
                    Token = table.Column<string>(nullable: true),
                    Expiration = table.Column<DateTime>(nullable: true),
                    LastLogin = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    StatusAccount = table.Column<int>(nullable: false),
                    CompanyId = table.Column<int>(nullable: false),
                    PersonId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeContext", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeContext_CompanyContext_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "CompanyContext",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeContext_PersonContext_PersonId",
                        column: x => x.PersonId,
                        principalTable: "PersonContext",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProviderContext",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonalIdentity = table.Column<string>(maxLength: 30, nullable: false),
                    NumberRegister = table.Column<string>(maxLength: 30, nullable: false),
                    TypeProduct = table.Column<string>(nullable: true),
                    LastVisit = table.Column<DateTime>(nullable: false),
                    FirstVisit = table.Column<DateTime>(nullable: false),
                    StatusRegister = table.Column<int>(nullable: false),
                    PersonId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProviderContext", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProviderContext_PersonContext_PersonId",
                        column: x => x.PersonId,
                        principalTable: "PersonContext",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TelephoneContext",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeTelephone = table.Column<string>(nullable: false),
                    Carrier = table.Column<string>(nullable: true),
                    Number = table.Column<string>(maxLength: 180, nullable: false),
                    State = table.Column<string>(nullable: true),
                    PersonId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TelephoneContext", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TelephoneContext_PersonContext_PersonId",
                        column: x => x.PersonId,
                        principalTable: "PersonContext",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RulesProfilesContext",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(nullable: false),
                    RuleId = table.Column<int>(nullable: false),
                    ProfileRuleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RulesProfilesContext", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RulesProfilesContext_PersonContext_PersonId",
                        column: x => x.PersonId,
                        principalTable: "PersonContext",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RulesProfilesContext_ProfileRuleContext_ProfileRuleId",
                        column: x => x.ProfileRuleId,
                        principalTable: "ProfileRuleContext",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RulesProfilesContext_RuleContext_RuleId",
                        column: x => x.RuleId,
                        principalTable: "RuleContext",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AddressContext_PersonId",
                table: "AddressContext",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_BranchContext_CompanyId",
                table: "BranchContext",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientContext_PersonId",
                table: "ClientContext",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_EmailContext_PersonId",
                table: "EmailContext",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeContext_CompanyId",
                table: "EmployeeContext",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeContext_PersonId",
                table: "EmployeeContext",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_ProviderContext_PersonId",
                table: "ProviderContext",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_RulesProfilesContext_PersonId",
                table: "RulesProfilesContext",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_RulesProfilesContext_ProfileRuleId",
                table: "RulesProfilesContext",
                column: "ProfileRuleId");

            migrationBuilder.CreateIndex(
                name: "IX_RulesProfilesContext_RuleId",
                table: "RulesProfilesContext",
                column: "RuleId");

            migrationBuilder.CreateIndex(
                name: "IX_TelephoneContext_PersonId",
                table: "TelephoneContext",
                column: "PersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AddressContext");

            migrationBuilder.DropTable(
                name: "BranchContext");

            migrationBuilder.DropTable(
                name: "ClientContext");

            migrationBuilder.DropTable(
                name: "EmailContext");

            migrationBuilder.DropTable(
                name: "EmployeeContext");

            migrationBuilder.DropTable(
                name: "ProviderContext");

            migrationBuilder.DropTable(
                name: "RulesProfilesContext");

            migrationBuilder.DropTable(
                name: "TelephoneContext");

            migrationBuilder.DropTable(
                name: "CompanyContext");

            migrationBuilder.DropTable(
                name: "ProfileRuleContext");

            migrationBuilder.DropTable(
                name: "RuleContext");

            migrationBuilder.DropTable(
                name: "PersonContext");
        }
    }
}
