using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAcquisitionSystemModbusProtocol.DataAccess.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Devices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Unit",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    UnitType = table.Column<int>(type: "INTEGER", nullable: false),
                    ManufacturerName = table.Column<string>(type: "TEXT", nullable: false),
                    Code = table.Column<string>(type: "TEXT", nullable: false),
                    AreaName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ModbusMasters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModbusMasters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModbusMasters_Devices_Id",
                        column: x => x.Id,
                        principalTable: "Devices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RedModbus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ModbusMasterId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RedModbus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RedModbus_ModbusMasters_ModbusMasterId",
                        column: x => x.ModbusMasterId,
                        principalTable: "ModbusMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ModbusSlaves",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    RedModbusId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModbusSlaves", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModbusSlaves_Devices_Id",
                        column: x => x.Id,
                        principalTable: "Devices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModbusSlaves_RedModbus_RedModbusId",
                        column: x => x.RedModbusId,
                        principalTable: "RedModbus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Variables",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    VariableType = table.Column<int>(type: "INTEGER", nullable: false),
                    Code = table.Column<string>(type: "TEXT", nullable: false),
                    SamplingPeriod = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModbusProtocolDirection = table.Column<string>(type: "TEXT", nullable: true),
                    UnitId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ModbusSlaveId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Variables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Variables_ModbusSlaves_ModbusSlaveId",
                        column: x => x.ModbusSlaveId,
                        principalTable: "ModbusSlaves",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Variables_Unit_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Unit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnalogicVaruables",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnalogicVaruables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnalogicVaruables_Variables_Id",
                        column: x => x.Id,
                        principalTable: "Variables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DigitalVariables",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DigitalVariables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DigitalVariables_Variables_Id",
                        column: x => x.Id,
                        principalTable: "Variables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sample",
                columns: table => new
                {
                    VariableId = table.Column<Guid>(type: "TEXT", nullable: false),
                    SampleDateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Id = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sample", x => new { x.VariableId, x.SampleDateTime });
                    table.ForeignKey(
                        name: "FK_Sample_Variables_VariableId",
                        column: x => x.VariableId,
                        principalTable: "Variables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ModbusSlaves_RedModbusId",
                table: "ModbusSlaves",
                column: "RedModbusId");

            migrationBuilder.CreateIndex(
                name: "IX_RedModbus_ModbusMasterId",
                table: "RedModbus",
                column: "ModbusMasterId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Variables_ModbusSlaveId",
                table: "Variables",
                column: "ModbusSlaveId");

            migrationBuilder.CreateIndex(
                name: "IX_Variables_UnitId",
                table: "Variables",
                column: "UnitId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnalogicVaruables");

            migrationBuilder.DropTable(
                name: "DigitalVariables");

            migrationBuilder.DropTable(
                name: "Sample");

            migrationBuilder.DropTable(
                name: "Variables");

            migrationBuilder.DropTable(
                name: "ModbusSlaves");

            migrationBuilder.DropTable(
                name: "Unit");

            migrationBuilder.DropTable(
                name: "RedModbus");

            migrationBuilder.DropTable(
                name: "ModbusMasters");

            migrationBuilder.DropTable(
                name: "Devices");
        }
    }
}
