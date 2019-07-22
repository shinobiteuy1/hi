using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
namespace AdminPanel.Data
{
    public class CreateScheme : Migration
    {
        protected override void Up (MigrationBuilder migrate){
            migrate.CreateTable(
                name:"AspNetRoles",
                columns : table => new{
                    Id = table.Column<string>(nullable:false),
                    ConcurrencyStamp = table.Column<string>(nullable:true),
                    Name = table.Column<string>(maxLength:256,nullable:true),
                    NormalizedName = table.Column<string>(maxLength:256,nullable:true)
                },
                constraints:table =>
                {
                    table.PrimaryKey("PK_Asp.NetRole",x=>x.Id);
                }
            );
            migrate.CreateTable(
                name:"AspNetUserTokens",
                columns:table=>new{
                    UserId = table.Column<string>(nullable:false),
                    LoginProvider = table.Column<string>(nullable:false),
                    Name = table.Column<string>(nullable:false),
                    Value = table.Column<string>(nullable:true),
                    Moo = table.Column<string>(nullable:true)
                }
            );
            migrate.CreateTable(
                name :"AspNetUsers",
                columns:table=>new{
                    Id = table.Column<string>(nullable:false),
                    AccessFailedCount = table.Column<int>(nullable:false),
                    ConcurrencyStamp = table.Column<string>(nullable:true),
                    Email = table.Column<string>(maxLength:256,nullable:true),
                    EmailConfirmed = table.Column<bool>(nullable:false),
                    LockoutEnabled = table.Column<bool>(nullable:false),
                    Lockoutend = table.Column<DateTimeOffset>(nullable:false),
                    NormalizedEmail = table.Column<string>(maxLength:256,nullable:true),
                    PasswordHash = table.Column<string>(nullable:true),
                    PhoneNumber = table.Column<String>(nullable:true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable:true),
                    SecurityStamp = table.Column<string>(nullable:true),
                    TwoFactorEnabled = table.Column<bool>(nullable:false),
                    Username = table.Column<string>(maxLength:256,nullable:true),
                    moonow = table.Column<string>(maxLength:256,nullable:true)
                },
                constraints : table=>
                {
                    table.PrimaryKey("PK_AspNetUsers",x=>x.Id);
                }
            );
            migrate.CreateTable(
                name:"AspNetRoleClaims",
                columns:table=>new{
                    Id = table.Column<int>(nullable:false).Annotation("SqlServer:ValueGeneratopnStrategy",SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable:true),
                    claimValue = table.Column<string>(nullable:true),
                    RoleId = table.Column<String>(nullable:false)
                },
                constraints:table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims",x=>x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRole_RoleId",
                        column:x=>x.RoleId,
                        principalTable : "AspNetRoles",
                        principalColumn: "id",
                        onDelete:ReferentialAction.Cascade
                    );
                }
            );
            migrate.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                }
            );
            migrate.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                }
            );
            migrate.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
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
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                }
            );
            migrate.CreateIndex(
                name:"RoleNameIndex",
                table:"AspNetRoles",
                column:"NormalizedName"
            );
            migrate.CreateIndex(
                name:"IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column:"RoleId"
            );
            migrate.CreateIndex(
                name:"IX_AspNetUserClaims_UserId",
                table:"AspNetUserClaims",
                column:"UserId"
            );
            migrate.CreateIndex(
                name:"IX_AspNetUserLogins_UserId",
                table:"AspNetUserLogins",
                column : "UserId"
            );
            migrate.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrate.CreateIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles",
                column: "UserId");

            migrate.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrate.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);
            migrate.CreateIndex(
                name:"moonow1",
                table:"AspNetUsers",
                column: "moonow"
            );

        }
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
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}