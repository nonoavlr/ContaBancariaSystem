using Microsoft.EntityFrameworkCore.Migrations;

namespace ContaBancaria.Persistency.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bancos",
                columns: table => new
                {
                    BancoID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    CNPJ = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bancos", x => x.BancoID);
                });

            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    EnderecoID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Logradouro = table.Column<string>(nullable: true),
                    Numero = table.Column<int>(nullable: false),
                    Bairro = table.Column<string>(nullable: true),
                    Cidade = table.Column<string>(nullable: true),
                    Estado = table.Column<string>(nullable: true),
                    Pais = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.EnderecoID);
                });

            migrationBuilder.CreateTable(
                name: "Agencias",
                columns: table => new
                {
                    AgenciaID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EnderecoID = table.Column<int>(nullable: false),
                    BancoID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agencias", x => x.AgenciaID);
                    table.ForeignKey(
                        name: "FK_Agencias_Enderecos_AgenciaID",
                        column: x => x.AgenciaID,
                        principalTable: "Enderecos",
                        principalColumn: "EnderecoID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Agencias_Bancos_BancoID",
                        column: x => x.BancoID,
                        principalTable: "Bancos",
                        principalColumn: "BancoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ClientID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    CPF = table.Column<int>(nullable: false),
                    EnderecoID = table.Column<int>(nullable: false),
                    ApiKey = table.Column<string>(nullable: true),
                    ApiSecret = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ClientID);
                    table.ForeignKey(
                        name: "FK_Clients_Enderecos_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Enderecos",
                        principalColumn: "EnderecoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contas",
                columns: table => new
                {
                    ContaID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CodContaCorrente = table.Column<int>(nullable: false),
                    Saldo = table.Column<int>(nullable: false),
                    Depositos = table.Column<int>(nullable: false),
                    Saques = table.Column<int>(nullable: false),
                    AgenciaID = table.Column<int>(nullable: false),
                    ClientID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contas", x => x.ContaID);
                    table.ForeignKey(
                        name: "FK_Contas_Agencias_AgenciaID",
                        column: x => x.AgenciaID,
                        principalTable: "Agencias",
                        principalColumn: "AgenciaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contas_Clients_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Clients",
                        principalColumn: "ClientID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Bancos",
                columns: new[] { "BancoID", "CNPJ", "Name" },
                values: new object[] { 1, "60.746.948/0001-12", "Bradesco" });

            migrationBuilder.InsertData(
                table: "Bancos",
                columns: new[] { "BancoID", "CNPJ", "Name" },
                values: new object[] { 2, "60.701.190/0001", "Itaú" });

            migrationBuilder.InsertData(
                table: "Enderecos",
                columns: new[] { "EnderecoID", "Bairro", "Cidade", "Estado", "Logradouro", "Numero", "Pais" },
                values: new object[] { 1, "Sao Joao", "Belo Horizonte", "Minas Gerais", "Rua Amelia", 126, "Brasil" });

            migrationBuilder.InsertData(
                table: "Enderecos",
                columns: new[] { "EnderecoID", "Bairro", "Cidade", "Estado", "Logradouro", "Numero", "Pais" },
                values: new object[] { 2, "Cuba", "São Paulo", "São Paulo", "Rua Hogwarts", 12598, "Brasil" });

            migrationBuilder.InsertData(
                table: "Enderecos",
                columns: new[] { "EnderecoID", "Bairro", "Cidade", "Estado", "Logradouro", "Numero", "Pais" },
                values: new object[] { 3, "Tucuruvi", "São Paulo", "São Paulo", "Rua Henrique", 10, "Brasil" });

            migrationBuilder.InsertData(
                table: "Enderecos",
                columns: new[] { "EnderecoID", "Bairro", "Cidade", "Estado", "Logradouro", "Numero", "Pais" },
                values: new object[] { 4, "Sao Joao", "Belo Horizonte", "Minas Gerais", "Rua Anastacia", 12598, "Brasil" });

            migrationBuilder.InsertData(
                table: "Agencias",
                columns: new[] { "AgenciaID", "BancoID", "EnderecoID" },
                values: new object[] { 1, 1, 3 });

            migrationBuilder.InsertData(
                table: "Agencias",
                columns: new[] { "AgenciaID", "BancoID", "EnderecoID" },
                values: new object[] { 2, 2, 4 });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "ClientID", "ApiKey", "ApiSecret", "CPF", "EnderecoID", "Name" },
                values: new object[] { 1, "1f06200b-cce4-44c7-9895-e8947a7f8f12", "5028d6b9-87ff-480a-995f-d6e37a376929", 123, 1, "Thais" });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "ClientID", "ApiKey", "ApiSecret", "CPF", "EnderecoID", "Name" },
                values: new object[] { 2, "fcbbeae0-b29e-48dd-ae58-a505170c83c2", "700b6f0b-3887-4887-aae7-7437700e343f", 159, 2, "Nohan" });

            migrationBuilder.InsertData(
                table: "Contas",
                columns: new[] { "ContaID", "AgenciaID", "ClientID", "CodContaCorrente", "Depositos", "Saldo", "Saques" },
                values: new object[] { 1, 2, 1, 0, 0, 0, 0 });

            migrationBuilder.InsertData(
                table: "Contas",
                columns: new[] { "ContaID", "AgenciaID", "ClientID", "CodContaCorrente", "Depositos", "Saldo", "Saques" },
                values: new object[] { 2, 1, 2, 0, 0, 0, 0 });

            migrationBuilder.CreateIndex(
                name: "IX_Agencias_BancoID",
                table: "Agencias",
                column: "BancoID");

            migrationBuilder.CreateIndex(
                name: "IX_Contas_AgenciaID",
                table: "Contas",
                column: "AgenciaID");

            migrationBuilder.CreateIndex(
                name: "IX_Contas_ClientID",
                table: "Contas",
                column: "ClientID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contas");

            migrationBuilder.DropTable(
                name: "Agencias");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Bancos");

            migrationBuilder.DropTable(
                name: "Enderecos");
        }
    }
}
