using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PetClinic.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Owners",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(maxLength: 256, nullable: false),
                    LastName = table.Column<string>(maxLength: 256, nullable: false),
                    Address = table.Column<string>(maxLength: 256, nullable: false),
                    City = table.Column<string>(maxLength: 256, nullable: false),
                    Telephone = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Specialties",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(maxLength: 256, nullable: false),
                    LastName = table.Column<string>(maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    Type = table.Column<short>(nullable: false),
                    OwnerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pets_Owners_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VetSpecialties",
                columns: table => new
                {
                    VetId = table.Column<int>(nullable: false),
                    SpecialtyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VetSpecialties", x => new { x.VetId, x.SpecialtyId });
                    table.ForeignKey(
                        name: "FK_VetSpecialties_Specialties_SpecialtyId",
                        column: x => x.SpecialtyId,
                        principalTable: "Specialties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VetSpecialties_Vets_VetId",
                        column: x => x.VetId,
                        principalTable: "Vets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Visits",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    Notes = table.Column<string>(maxLength: 256, nullable: false),
                    VetId = table.Column<int>(nullable: false),
                    PetId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Visits_Pets_PetId",
                        column: x => x.PetId,
                        principalTable: "Pets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Visits_Vets_VetId",
                        column: x => x.VetId,
                        principalTable: "Vets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Owners",
                columns: new[] { "Id", "Address", "City", "FirstName", "LastName", "Telephone" },
                values: new object[,]
                {
                    { 1, "901 Messerschmidt Circle", "Katwijk", "Pren", "Handsheart", "696-166-9385" },
                    { 25, "538 Loomis Circle", "Nueva Loja", "Flin", "Witherup", "664-206-1619" },
                    { 26, "62 Parkside Alley", "Herceg-Novi", "Mateo", "Schumacher", "386-444-3002" },
                    { 27, "164 Meadow Valley Street", "Fudian", "Marthe", "Bollen", "665-819-7193" },
                    { 28, "1854 Declaration Street", "Bambakashat", "Seumas", "Indruch", "325-590-1515" },
                    { 29, "0 Farragut Street", "Pameungpeuk", "Kenneth", "Gason", "238-235-9796" },
                    { 30, "4586 Shelley Street", "Ratíškovice", "Kurt", "Bagwell", "512-185-9090" },
                    { 31, "59303 Fallview Road", "Kawakawa", "Alf", "Travis", "655-453-5195" },
                    { 32, "767 Golf Center", "Kaburon", "Stanislas", "Swadlin", "649-852-8037" },
                    { 24, "278 Lake View Trail", "Les Abymes", "Riannon", "Heigold", "628-704-9463" },
                    { 33, "11894 Starling Point", "Gusinoozyorsk", "Kerrill", "Brokenshaw", "395-777-1951" },
                    { 35, "84285 Loeprich Park", "Lasi Dua", "Elmore", "Doley", "761-532-2032" },
                    { 36, "51910 Monterey Drive", "Kommunisticheskiy", "Farly", "Thurley", "195-822-2832" },
                    { 37, "201 Stang Court", "Safotu", "Stephi", "Shellibeer", "201-201-0649" },
                    { 39, "5 Hagan Avenue", "Trzebieszów", "Petey", "Apthorpe", "227-148-6992" },
                    { 40, "19 Declaration Hill", "Sanhui", "Hyacinthe", "Chidler", "873-931-9819" },
                    { 41, "8 Boyd Court", "Ulyanovsk", "Mellicent", "de Nore", "770-120-0778" },
                    { 42, "4626 Northport Avenue", "Irbid", "Karney", "Botton", "106-322-9032" },
                    { 43, "67289 Mesta Hill", "Gaotieling", "Johanna", "Seabrooke", "991-485-2169" },
                    { 34, "1 Bay Drive", "Tamanan", "Holly-anne", "Whitley", "625-587-0047" },
                    { 23, "101 Scoville Avenue", "Hongkou", "Tyrus", "Dumingo", "423-329-2153" },
                    { 38, "6 Superior Terrace", "Dayou", "Mortie", "Gypps", "134-686-0873" },
                    { 21, "28 Sundown Hill", "Smokvica", "Mendy", "Reville", "550-121-5868" },
                    { 22, "2 Waubesa Circle", "Seattle", "Raymond", "Darlison", "253-838-1723" },
                    { 2, "909 Evergreen Trail", "Hatton", "Heinrick", "Vanyatin", "832-116-9214" },
                    { 3, "81 Canary Hill", "Guangfu", "Ivie", "Casterton", "922-605-4531" },
                    { 5, "54695 Farmco Road", "Xinzhuang", "Pru", "Geraudy", "583-126-3845" },
                    { 6, "8541 Haas Park", "Stěžery", "Garry", "Sulley", "737-234-1982" },
                    { 7, "99708 Onsgard Drive", "Tucuran", "Allyn", "McRannell", "448-570-8995" },
                    { 8, "10117 Grasskamp Lane", "Benito Juarez", "Dugald", "Vivyan", "327-144-9061" },
                    { 9, "23 Northfield Crossing", "Araruama", "Christiano", "Volkes", "592-655-7603" },
                    { 10, "3027 Monterey Court", "Samdo", "Horatia", "Tobin", "268-859-3203" },
                    { 4, "784 Everett Circle", "Waingapu", "Gillian", "Bissex", "312-263-8087" },
                    { 12, "1 Clarendon Road", "Beskolen", "Agata", "Sleith", "663-555-7609" },
                    { 20, "98 Melrose Terrace", "Uralo-Kavkaz", "Merola", "Impey", "663-393-2782" },
                    { 11, "7 Heffernan Pass", "Angono", "Vitia", "Copins", "305-416-2369" },
                    { 18, "9287 Schlimgen Lane", "Dalovice", "Maritsa", "Kimber", "515-695-3036" },
                    { 17, "16347 Dapin Drive", "Ruzhany", "Anatola", "Ashdown", "709-337-1856" },
                    { 19, "729 Glendale Court", "San Juan", "Lorilee", "Frensche", "152-194-4906" },
                    { 15, "756 Forest Run Road", "Opatów", "Bonni", "Aspland", "836-500-7512" },
                    { 14, "315 Hansons Circle", "Philadelphia", "Lenora", "Euesden", "610-294-5983" },
                    { 13, "68701 Anderson Crossing", "Kingsport", "Georgeanne", "Conachy", "423-820-4682" },
                    { 16, "48 Cottonwood Trail", "Pragen Selatan", "Gael", "McCuaig", "533-212-7915" }
                });

            migrationBuilder.InsertData(
                table: "Specialties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Radiology" },
                    { 2, "Surgery" },
                    { 3, "Dentistry" }
                });

            migrationBuilder.InsertData(
                table: "Vets",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 17, "Chico", "Aslie" },
                    { 18, "Lauren", "Dibley" },
                    { 21, "Maren", "Degoey" },
                    { 19, "Reginauld", "Gercken" },
                    { 20, "Dayle", "MacGiffin" },
                    { 22, "Em", "D'Angeli" },
                    { 27, "Ritchie", "Girardey" },
                    { 24, "Rubetta", "Syder" },
                    { 25, "Olive", "Laffoley-Lane" },
                    { 26, "Markus", "Lydster" },
                    { 16, "Tallie", "Fanstone" },
                    { 28, "Goldarina", "Greensides" },
                    { 23, "Devlin", "Tompkins" },
                    { 15, "Dougy", "Orteu" },
                    { 3, "Urbain", "Wasson" },
                    { 13, "Beverlie", "Meaking" },
                    { 12, "Petronille", "Montfort" },
                    { 11, "Robin", "Form" },
                    { 10, "Alick", "Ornils" },
                    { 9, "Kali", "Kennet" },
                    { 8, "Viviana", "Storre" },
                    { 7, "Jacquenetta", "Aleksidze" },
                    { 6, "Aristotle", "Blyde" },
                    { 5, "Hildagard", "Lintot" },
                    { 4, "Milton", "Branson" },
                    { 2, "Tadeas", "Rockcliff" },
                    { 1, "Jacintha", "Runham" },
                    { 29, "Jonell", "Earland" },
                    { 14, "Barnett", "Simpole" },
                    { 30, "Chiquita", "Spandley" }
                });

            migrationBuilder.InsertData(
                table: "Pets",
                columns: new[] { "Id", "BirthDate", "Name", "OwnerId", "Type" },
                values: new object[,]
                {
                    { 6, new DateTime(2015, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jeanna", 5, (short)5 },
                    { 7, new DateTime(2013, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Haley", 41, (short)6 },
                    { 20, new DateTime(2015, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Abelard", 40, (short)5 },
                    { 21, new DateTime(2013, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hillyer", 38, (short)1 },
                    { 15, new DateTime(2014, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Clo", 38, (short)2 },
                    { 22, new DateTime(2014, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Roma", 37, (short)4 },
                    { 16, new DateTime(2016, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Franny", 37, (short)1 },
                    { 2, new DateTime(2012, 9, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ulrika", 36, (short)2 },
                    { 5, new DateTime(2004, 10, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Charla", 35, (short)5 },
                    { 18, new DateTime(2004, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Niccolo", 29, (short)1 },
                    { 4, new DateTime(2002, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cloris", 28, (short)3 },
                    { 24, new DateTime(2008, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Celinda", 27, (short)2 },
                    { 17, new DateTime(2006, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kylie", 27, (short)3 },
                    { 19, new DateTime(2007, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Charo", 26, (short)3 },
                    { 3, new DateTime(2018, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Babita", 26, (short)2 },
                    { 8, new DateTime(2011, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lucie", 41, (short)4 },
                    { 25, new DateTime(2017, 11, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Silvia", 22, (short)1 },
                    { 14, new DateTime(2006, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Briant", 5, (short)6 },
                    { 13, new DateTime(2013, 6, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Shelagh", 9, (short)1 },
                    { 1, new DateTime(2001, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Inessa", 10, (short)5 },
                    { 9, new DateTime(2016, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gunner", 24, (short)6 },
                    { 12, new DateTime(2010, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Abbot", 10, (short)3 },
                    { 26, new DateTime(2012, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mattie", 10, (short)4 },
                    { 11, new DateTime(2006, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Adrian", 10, (short)1 },
                    { 30, new DateTime(2017, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Elke", 11, (short)2 },
                    { 29, new DateTime(2010, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nikita", 12, (short)4 },
                    { 23, new DateTime(2018, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Edithe", 14, (short)1 },
                    { 10, new DateTime(2012, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Paten", 18, (short)3 },
                    { 28, new DateTime(2007, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Maryann", 20, (short)1 },
                    { 27, new DateTime(2017, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Katherine", 10, (short)4 }
                });

            migrationBuilder.InsertData(
                table: "VetSpecialties",
                columns: new[] { "VetId", "SpecialtyId" },
                values: new object[,]
                {
                    { 17, 2 },
                    { 18, 3 },
                    { 19, 1 },
                    { 20, 3 },
                    { 21, 1 },
                    { 28, 2 },
                    { 23, 2 },
                    { 24, 3 },
                    { 25, 3 },
                    { 26, 2 },
                    { 27, 1 },
                    { 16, 2 },
                    { 22, 2 },
                    { 15, 1 },
                    { 8, 3 },
                    { 13, 1 },
                    { 12, 1 },
                    { 11, 1 },
                    { 10, 3 },
                    { 9, 2 },
                    { 7, 2 },
                    { 6, 1 },
                    { 5, 3 },
                    { 4, 2 },
                    { 3, 1 },
                    { 2, 3 },
                    { 1, 3 },
                    { 29, 1 },
                    { 14, 1 },
                    { 30, 1 }
                });

            migrationBuilder.InsertData(
                table: "Visits",
                columns: new[] { "Id", "Date", "Notes", "PetId", "VetId" },
                values: new object[,]
                {
                    { 6, new DateTime(2008, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 6, 1 },
                    { 20, new DateTime(2018, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 20, 15 },
                    { 21, new DateTime(2002, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 21, 9 },
                    { 15, new DateTime(2014, 12, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 15, 30 },
                    { 22, new DateTime(2005, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 22, 6 },
                    { 16, new DateTime(2006, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 16, 28 },
                    { 2, new DateTime(2003, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 2, 5 },
                    { 5, new DateTime(2011, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 5, 3 },
                    { 18, new DateTime(2009, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 18, 21 },
                    { 4, new DateTime(2017, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 4, 10 },
                    { 24, new DateTime(2005, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 24, 2 },
                    { 17, new DateTime(2008, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 17, 3 },
                    { 19, new DateTime(2008, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 19, 15 },
                    { 3, new DateTime(2017, 4, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 3, 16 },
                    { 9, new DateTime(2006, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 9, 24 },
                    { 25, new DateTime(2003, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 25, 18 },
                    { 28, new DateTime(2012, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 28, 12 },
                    { 10, new DateTime(2010, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 10, 13 },
                    { 23, new DateTime(2012, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 23, 11 },
                    { 29, new DateTime(2009, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 29, 24 },
                    { 30, new DateTime(2003, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 30, 28 },
                    { 27, new DateTime(2014, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 27, 15 },
                    { 26, new DateTime(2011, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 26, 10 },
                    { 12, new DateTime(2007, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 12, 27 },
                    { 11, new DateTime(2016, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 11, 8 },
                    { 1, new DateTime(2006, 6, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 1, 18 },
                    { 13, new DateTime(2011, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 13, 29 },
                    { 14, new DateTime(2001, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 14, 23 },
                    { 7, new DateTime(2013, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 7, 11 },
                    { 8, new DateTime(2004, 7, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 8, 11 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pets_OwnerId",
                table: "Pets",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_VetSpecialties_SpecialtyId",
                table: "VetSpecialties",
                column: "SpecialtyId");

            migrationBuilder.CreateIndex(
                name: "IX_Visits_PetId",
                table: "Visits",
                column: "PetId");

            migrationBuilder.CreateIndex(
                name: "IX_Visits_VetId",
                table: "Visits",
                column: "VetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VetSpecialties");

            migrationBuilder.DropTable(
                name: "Visits");

            migrationBuilder.DropTable(
                name: "Specialties");

            migrationBuilder.DropTable(
                name: "Pets");

            migrationBuilder.DropTable(
                name: "Vets");

            migrationBuilder.DropTable(
                name: "Owners");
        }
    }
}
