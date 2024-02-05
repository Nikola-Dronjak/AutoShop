using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AutoShop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddTablesToDbAndSeedThem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BodyTypes",
                columns: table => new
                {
                    BodyTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BodyTypes", x => x.BodyTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    BrandId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.BrandId);
                });

            migrationBuilder.CreateTable(
                name: "EngineTypes",
                columns: table => new
                {
                    EngineTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EngineTypes", x => x.EngineTypeId);
                });

            migrationBuilder.CreateTable(
                name: "FuelTypes",
                columns: table => new
                {
                    FuelTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuelTypes", x => x.FuelTypeId);
                });

            migrationBuilder.CreateTable(
                name: "TransmissionTypes",
                columns: table => new
                {
                    TransmissionTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransmissionTypes", x => x.TransmissionTypeId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Models",
                columns: table => new
                {
                    ModelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrandId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Models", x => x.ModelId);
                    table.ForeignKey(
                        name: "FK_Models_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "BrandId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarListings",
                columns: table => new
                {
                    CarId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrandName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModelId = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Color = table.Column<int>(type: "int", nullable: false),
                    EngineTypeId = table.Column<int>(type: "int", nullable: false),
                    TransmissionTypeId = table.Column<int>(type: "int", nullable: false),
                    FuelTypeId = table.Column<int>(type: "int", nullable: false),
                    BodyTypeId = table.Column<int>(type: "int", nullable: false),
                    Mileage = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    NumberOfDoors = table.Column<int>(type: "int", nullable: false),
                    NumberOfSeats = table.Column<int>(type: "int", nullable: false),
                    VIN = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarListings", x => x.CarId);
                    table.ForeignKey(
                        name: "FK_CarListings_BodyTypes_BodyTypeId",
                        column: x => x.BodyTypeId,
                        principalTable: "BodyTypes",
                        principalColumn: "BodyTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarListings_EngineTypes_EngineTypeId",
                        column: x => x.EngineTypeId,
                        principalTable: "EngineTypes",
                        principalColumn: "EngineTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarListings_FuelTypes_FuelTypeId",
                        column: x => x.FuelTypeId,
                        principalTable: "FuelTypes",
                        principalColumn: "FuelTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarListings_Models_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Models",
                        principalColumn: "ModelId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarListings_TransmissionTypes_TransmissionTypeId",
                        column: x => x.TransmissionTypeId,
                        principalTable: "TransmissionTypes",
                        principalColumn: "TransmissionTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "BodyTypes",
                columns: new[] { "BodyTypeId", "Type" },
                values: new object[,]
                {
                    { 1, "Sedan" },
                    { 2, "Hatchback" },
                    { 3, "SUV" },
                    { 4, "Coupe" },
                    { 5, "Pickup" },
                    { 6, "Convertible" },
                    { 7, "MiniVan" }
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "BrandId", "Name" },
                values: new object[,]
                {
                    { 1, "Audi" },
                    { 2, "BMW" },
                    { 3, "Citroen" },
                    { 4, "Fiat" },
                    { 5, "Hyundai" },
                    { 6, "Opel" },
                    { 7, "Porsche" },
                    { 8, "Renault" },
                    { 9, "Tesla" }
                });

            migrationBuilder.InsertData(
                table: "EngineTypes",
                columns: new[] { "EngineTypeId", "Type" },
                values: new object[,]
                {
                    { 1, "Euro 1" },
                    { 2, "Euro 2" },
                    { 3, "Euro 3" },
                    { 4, "Euro 4" },
                    { 5, "Euro 5" },
                    { 6, "Euro 6" }
                });

            migrationBuilder.InsertData(
                table: "FuelTypes",
                columns: new[] { "FuelTypeId", "Type" },
                values: new object[,]
                {
                    { 1, "Diesel" },
                    { 2, "Petrol" },
                    { 3, "Electicity" },
                    { 4, "Hybrid" },
                    { 5, "Natural gas" }
                });

            migrationBuilder.InsertData(
                table: "TransmissionTypes",
                columns: new[] { "TransmissionTypeId", "Type" },
                values: new object[,]
                {
                    { 1, "Manual" },
                    { 2, "Automatic" }
                });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "ModelId", "BrandId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "A1" },
                    { 2, 1, "A2" },
                    { 3, 1, "A3" },
                    { 4, 1, "A4" },
                    { 5, 1, "A5" },
                    { 6, 1, "A6" },
                    { 7, 1, "A7" },
                    { 8, 1, "A8" },
                    { 9, 2, "M2" },
                    { 10, 2, "M3" },
                    { 11, 2, "M4" },
                    { 12, 2, "M5" },
                    { 13, 2, "M6" },
                    { 14, 2, "X1" },
                    { 15, 2, "X2" },
                    { 16, 2, "X3" },
                    { 17, 3, "Ami" },
                    { 18, 3, "Berlingo" },
                    { 19, 3, "C1" },
                    { 20, 3, "C2" },
                    { 21, 3, "C3" },
                    { 22, 3, "C4 Grand Picasso" },
                    { 23, 3, "C5" },
                    { 24, 3, "C6" },
                    { 25, 4, "Albea" },
                    { 26, 4, "Bravo" },
                    { 27, 4, "Croma" },
                    { 28, 4, "Dublo" },
                    { 29, 4, "EVO" },
                    { 30, 4, "Freemont" },
                    { 31, 4, "Idea" },
                    { 32, 4, "Punto" },
                    { 33, 5, "Atos" },
                    { 34, 5, "Bayon" },
                    { 35, 5, "Coupe" },
                    { 36, 5, "Elantra" },
                    { 37, 5, "Genesis" },
                    { 38, 5, "Kona" },
                    { 39, 5, "Matrix" },
                    { 40, 5, "Santa Fe" },
                    { 41, 6, "Adam" },
                    { 42, 6, "Astra" },
                    { 43, 6, "Corsa" },
                    { 44, 6, "Frontera" },
                    { 45, 6, "Insignia" },
                    { 46, 6, "Kadett" },
                    { 47, 6, "Karl" },
                    { 48, 6, "Monterey" },
                    { 49, 7, "911" },
                    { 50, 7, "Cayenne" },
                    { 51, 7, "Cayman" },
                    { 52, 7, "Macan" },
                    { 53, 7, "Panamera" },
                    { 54, 7, "Targa" },
                    { 55, 7, "Boxster" },
                    { 56, 7, "944" },
                    { 57, 8, "Austral" },
                    { 58, 8, "Clio" },
                    { 59, 8, "Express" },
                    { 60, 8, "Fluence" },
                    { 61, 8, "Kadjar" },
                    { 62, 8, "Megane" },
                    { 63, 8, "Nevada" },
                    { 64, 8, "Twingo" },
                    { 65, 9, "Model S" },
                    { 66, 9, "Model 3" },
                    { 67, 9, "Model Y" },
                    { 68, 9, "Model X" }
                });

            migrationBuilder.InsertData(
                table: "CarListings",
                columns: new[] { "CarId", "BodyTypeId", "BrandName", "Color", "Description", "EngineTypeId", "FuelTypeId", "ImageUrl", "Mileage", "ModelId", "NumberOfDoors", "NumberOfSeats", "Price", "Status", "TransmissionTypeId", "UserId", "VIN", "Year" },
                values: new object[,]
                {
                    { 1, 2, "1", 0, "Vozilo u odlicnom stanju. Uvoz Svajcarska. U top stanju, bez dinara ulaganja. Zamenjen pogonski lanac komplet sa lancem uljne pumpe. Zamenjen pk kais, spaner i roler pk kaisa, nove svecice, prednji diskovi i plocice novi, zadnji u odlicnom stanju, zamenjeno ulje i 4 filtera. Gume zimske nove. Klima napunjena. Zadnji parking senzori, navigacija azurirana za 2023 godinu,tempomat. Na vozilu sve ispravno i u odlicnom stanju. Cena dogovor....saljem na viber slike od kupovine iz CH i broj sasije. Odlican za pocetnike", 5, 2, "/images/car/Audi A1.jpg", 212110, 1, 0, 4, 6200, 0, 1, "1", "1934830127", 2011 },
                    { 2, 2, "1", 5, "Automobil je u odličnom stanju. Mehanički potpuno ispravan, kao i limarijski. Vozilo za svaku preporuku i vredi pogledati. Za više informacija o vozilu, kao i gledanje istog, pozovite na ispod navedene brojeve. Dozvoljena je svaka vrsta provere po želji kupca. Srećna kupovina!", 3, 1, "/images/car/Audi A2.jpg", 172000, 2, 1, 4, 3150, 0, 1, "2", "1934830128", 2003 },
                    { 3, 2, "1", 6, "Auto je kao NOV !!! Od prvog dana servisiran u ovlascenom servisu. Ovako ocuvan auto je jako tesko naci. Dozvoljen svaki vid provere kod vaseg majstora ili ovlascenom servisu. Srecna kupovina !!!", 6, 2, "/images/car/Audi A3.jpg", 101000, 3, 1, 5, 11200, 0, 1, "3", "1934830129", 2015 },
                    { 4, 1, "1", 7, "Orginalna kilometraza, servisna knjiga, i kompletna servisna istorija od prvog dana, sto se moze proveriti u ovlascenom audi servisu !!!!!!!!! Auto je iz uvoza, prodaje se na ime kupca... Kupac ne placa prenos vozila... Placena carina, pdv i amss... Dobijeno pismeno uverenje o ispravnosti vozila, od agencije za bezbednost saobracaja... Stanje novo, dosta dodatne opreme... Vozilo ispitano, mehanicki pregledano, tehnicki ispravno, bez ikakvih dodatnih ulaganja, pregledano...", 6, 1, "/images/car/Audi A4.jpg", 149000, 4, 1, 5, 28250, 0, 2, "4", "1934830130", 2020 },
                    { 5, 2, "1", 4, "Auto je kupljen u Audijevom salonu u Švedskoj za koji je moguć svaki vid provere kod majstora kao i carvertical koji ćemo mi platiti u slučaju da nešto nije tačno što piše u oglasu. Automobil proizveden u aprilu 2021 godine, dok je prva registracija 23.06.2021 godine. Pri kupovini automobil ide direktno na kupca gde od troškova ima samo registraciju koja je izuzetno niska zbog hybridnog motora.", 6, 4, "/images/car/Audi A5.jpg", 24000, 5, 1, 5, 38800, 0, 2, "5", "1934830131", 2021 },
                    { 6, 1, "1", 0, "Auto u ekstra stanju. Servisiran alnaser, alternator i kompresor klime. Zamenjeni zadnji amortizeri, potkovica i zadnji selen blokovi. Sva četiri diska nova. Enterijer očuvan i nista nije pocepano. Zimske mišelin gume na alu felnama. Gratis još jedan set letnjih guma na alu felnama. Auto skroz pouzdan i siguran. Bez ulaganja. Prodaje se zato sto sam kupio drugi automobil.", 6, 1, "/images/car/Audi A6.jpg", 208000, 6, 1, 5, 22900, 0, 2, "6", "1934830132", 2015 },
                    { 7, 2, "1", 3, "Kupljen nov u Nemačkoj, garancija na pređenu kilometražu i sve ostalo. Čipovan je na 400 ks.", 6, 4, "/images/car/Audi A7.jpg", 138000, 7, 1, 5, 60000, 0, 2, "7", "1934830133", 2017 },
                    { 8, 1, "1", 6, "Besprekorno održavan automobil", 6, 1, "/images/car/Audi A8.jpg", 95000, 8, 1, 5, 65000, 0, 2, "8", "1934830134", 2019 },
                    { 9, 1, "2", 4, "Nove Hankook gume", 6, 2, "/images/car/BMW M2.jpg", 31000, 9, 0, 4, 55000, 0, 2, "9", "2563075495", 2019 },
                    { 10, 1, "2", 4, "Automobil je u TOP stanju u svakom smislu.", 4, 2, "/images/car/BMW M3.jpg", 117441, 10, 1, 5, 45000, 0, 2, "10", "2563075496", 2009 },
                    { 11, 4, "2", 3, "Vozilo je u perfektnom stanju, kupljeno kao novo u Srbiji u Delta Motorsu. Redovno održavano u ovlašćenom BMW servisu. Datum prve registracije: 10.08.2022. Automobil ima produženu fabričku garanciju do 09.08.2026 ili 200.000 km. Poseduje paket besplatnog održavanja (Service inclusive) do 09.08.2026 ili do 120.000 km.", 6, 2, "/images/car/BMW M4.jpg", 35535, 11, 0, 4, 98990, 0, 2, "5", "2563075497", 2022 },
                    { 12, 1, "2", 0, "Vozilo u perfektnom stanju. Mogucnost svake vrste provere u servisu.", 6, 2, "/images/car/BMW M5.jpg", 58000, 12, 1, 5, 72000, 0, 2, "4", "2563075498", 2018 },
                    { 13, 6, "2", 4, "Poslednji model M Bmw-a sa atnosverskim motorom. Redak i cenjen model u Cabrio verziji.", 4, 4, "/images/car/BMW M6.jpg", 124000, 13, 0, 4, 22600, 0, 2, "3", "2563075499", 2006 },
                    { 14, 3, "2", 6, "Motor je u kvaru !!!", 5, 1, "/images/car/BMW X1.jpg", 189000, 14, 1, 5, 6700, 0, 1, "2", "2563075500", 2011 },
                    { 15, 3, "2", 2, "Odličan, spreman za zimu sa XD pogonom. Svi servisi redovno rađeni u BMW-u.", 6, 1, "/images/car/BMW X2.jpg", 151000, 15, 1, 5, 26990, 0, 2, "1", "2563075501", 2018 },
                    { 16, 3, "2", 5, "Vozilo je u besprekornom stanju. Datum prve registracije: 15.04.2021. Mogućnost kupovine vozila preko kredita, finansijskog ili operativnog lizinga. Delta Automoto daje garanciju na motor.", 6, 2, "/images/car/BMW X3.jpg", 74442, 16, 1, 5, 51990, 0, 2, "6", "2563075502", 2021 },
                    { 17, 2, "3", 6, "Panorama krov. Tonirana stakla. Automobil je nov..za vise info pozvati.", 6, 3, "/images/car/Citroen Ami.jpg", 58, 17, 0, 2, 8950, 0, 2, "7", "3984532196", 2022 },
                    { 18, 7, "3", 4, "Uvezen iz Nemacke 2022. Registrovan godinu dana do Decembra 2024. Redovno odrzavan. Dva seta guma. Bez ulaganja.", 6, 1, "/images/car/Citroen Berlingo.jpg", 170000, 18, 1, 5, 7499, 0, 1, "8", "3984532197", 2016 },
                    { 19, 2, "3", 6, "Gradski zvrk sa motorom Toyote. Odlicno stanje kako limarijski tako i mehanicki. Zamenjen lonac auspuha koji je u garanciji 2 godine. Auto bez ulaganja za grad izmisljen. Razlog prodaje sin iznenadno dobio posao u inostranstvu pa bi bio visak.", 4, 2, "/images/car/Citroen C1.jpg", 214521, 19, 0, 4, 2750, 0, 1, "9", "3984532198", 2010 },
                    { 20, 2, "3", 0, "PRAVA KILOMETRAZA! Digitalna klima!", 3, 2, "/images/car/Citroen C2.jpg", 145000, 20, 0, 4, 2100, 0, 1, "10", "3984532199", 2004 },
                    { 21, 2, "3", 0, "Vozilo je iz uvoza. Poseduje kompletnu servisnu istoriju (istorija je dostupna na uvid prilikom posete izložbenom salonu.", 6, 2, "/images/car/Citroen C3.jpg", 68240, 21, 1, 5, 10990, 0, 1, "1", "3984532200", 2018 },
                    { 22, 2, "3", 6, "Za svaki kupljeni auto kod nas mozete da uradite veliki servis u nasem servisu za koji dobijate GARANCIJU.", 6, 1, "/images/car/Citroen C4.jpg", 141382, 22, 1, 5, 8950, 0, 1, "2", "3984532201", 2016 },
                    { 23, 1, "3", 6, "Auto u ekstra stanju redovno odrzavano, potpuno ispravno. Kupcu ostaje samo tehnicki i registracija.", 4, 1, "/images/car/Citroen C5.jpg", 186344, 23, 1, 5, 4450, 0, 1, "3", "3984532202", 2008 },
                    { 24, 1, "3", 6, "Visoka klasa vozila. Digitalna tabla. Praćenje trake. Redovno servisiran i održavan. Motor mu tiho radi i nema dima. Menjač šalta savršeno i ne lupa ni vruć a ni hladan. Cena smešna za keš - fixno.", 4, 1, "/images/car/Citroen C6.jpg", 220000, 24, 1, 5, 5999, 0, 2, "4", "3984532203", 2008 },
                    { 25, 1, "4", 8, "Prvi i jedini vlasnik do sada.2009-te godine je ugradjen autogas uredjaj (pre neki dan je uradjen reatest a boca treba da se menja tek za 7-8 godina-pošto je zamenjena pre par godina. Do sada su zamenjeni akumulator i auspuh više puta i redovno ulje, filteri, antifriz kablovi i svećice.Zatim su menjani alternator, set kvačila, zupčasti kajiš,kočioni diskovi, nosači motora, diferencijal i kompjuter koji nije sasvim otkazao-čuvam ga i sada za „ne daj bože“ pošto se zameni za 2 minuta a samo je pokazao izvesnu nestabilnost u radu dok se motor ne zagreje. Auto je u solidnom stanju za svoje godine, ispravan, upravo registrovan (registracija važi do 03.01.2025 god.) vrlo malo prešao (uvek je bio drugi sigurni auto).Ima nekoliko manjih oštećenja-ulubljenja od nesmotrenih vozača na parkingu (bilo je i ranije pa mi je pre 7-8 god. autolimar sve to sredio prefarbao ali džaba-opet isto…).", 3, 2, "/images/car/Fiat Albea.jpg", 97000, 25, 1, 5, 1600, 0, 1, "5", "4396710321", 2005 },
                    { 26, 2, "4", 0, "Auto je kupljen u avgustu 2023. godine. Krenuo sam da ga sredjujem za licnu upotrebu, razlog prodaje je poslovna prilika koja se otvorila u medjuvremenu. Registrovan je do kraja aprila 2024. Mozete doci da pogledate auto svakim danom do 9 ujutru ili posle 4 popodne, kontakt na broj telefona.", 4, 1, "/images/car/Fiat Bravo.jpg", 221000, 26, 1, 5, 3800, 0, 1, "6", "4396710322", 2007 },
                    { 27, 1, "4", 6, "VOZILO IZ UVOZA,OCARINJENO I URADJEN AMSS. MEHANICKI BEZ GRESKE, ENTERIJER KAO NOV. DOZVOLJENE SVE VRSTE PREGLEDA.LEPSI UZIVO NEGO NA SLIKAMA.", 4, 1, "/images/car/Fiat Croma.jpg", 189000, 27, 1, 5, 3490, 0, 1, "7", "4396710323", 2008 },
                    { 28, 7, "4", 7, "Uradjen veliki servis. Utegnut u voznji. Mogucnost svake vrste provere.", 5, 1, "/images/car/Fiat Dublo.jpg", 161000, 28, 1, 5, 6999, 0, 1, "8", "4396710324", 2013 },
                    { 29, 2, "4", 7, "Auto je u odlicnom stanju. Na ime kupca.", 4, 1, "/images/car/Fiat Evo.jpg", 186000, 29, 0, 5, 3599, 0, 1, "9", "4396710325", 2010 },
                    { 30, 3, "4", 5, "Vozilo iz uvoza, kupljeno od prvog vlasnika. Redovno održavano u ovlašćenom servisu FIAT ( original servisna knjižica i elektronska servisna istorija dostupna na uvid ).", 5, 1, "/images/car/Fiat Freemont.jpg", 241318, 30, 1, 7, 8700, 0, 1, "10", "4396710326", 2011 },
                    { 31, 2, "4", 4, "Auto u odličnom stanju. Za vise informacija pozovi.", 4, 1, "/images/car/Fiat Idea.jpg", 199000, 31, 1, 5, 2350, 0, 1, "1", "4396710327", 2006 },
                    { 32, 2, "4", 4, "MALI POTROŠAČ JEFTIN ZA ODRZÀVANJE. BEZ DINARA DODATNIH ULAGANJA. CENA SKORO FIXNA FIXNA.", 4, 2, "/images/car/Fiat Punto.jpg", 94822, 32, 1, 5, 2280, 0, 1, "2", "4396710328", 2004 },
                    { 33, 2, "5", 2, "Auto se prodaje jer nam vise nije potreban. Baka više ne želi da vozi.", 4, 2, "/images/car/Hyundai Atos.jpg", 144148, 33, 1, 5, 1300, 0, 1, "3", "5912482390", 2002 },
                    { 34, 2, "5", 3, "Garancija na vozilo 5+2 godine, bez ograničenja pređene kilometraže. Mogućnost kupovine pod povoljnim uslovima na kredit ili lizing.", 6, 2, "/images/car/Hyundai Bayon.jpg", 7, 34, 1, 5, 18390, 0, 1, "4", "5912482391", 2023 },
                    { 35, 4, "5", 4, "Stanje odlicno. Uradjen veliki servis na 135.000 km. Urađeno kvačilo na 135.000 km. Gume nove sve cetri, motor i menjac savrseni, za dodatne informacije pozovite.", 3, 2, "/images/car/Hyundai Coupe.jpg", 142000, 35, 0, 4, 3350, 0, 1, "5", "5912482392", 2004 },
                    { 36, 1, "5", 6, "Vozilo je kupljeno novo u Srbiji, redovno servisirano u ovlascenom Hyundai servisu i nakon isteka garancije u ovlašćenom servisu.", 6, 1, "/images/car/Hyundai Elantra.jpg", 61000, 36, 1, 5, 13500, 0, 1, "6", "5912482393", 2017 },
                    { 37, 4, "5", 6, "Automobil je u perfektnom stanju, bez oštećenja i mehaničkih kvarova. Prvi sam vlasnik automobila kupljenog i odrzavanog u Hyundai Srbija u Beogradu. Motor je u besprekornom stanju. Posedujem kompletnu servisnu dokumentaciju.", 5, 2, "/images/car/Hyundai Genesis.jpg", 37000, 37, 0, 4, 19500, 0, 2, "7", "5912482394", 2011 },
                    { 38, 3, "5", 7, "U besprekornom stanju. Fabricka garancija. Dva originalna kljuca-kartice. Registrovan do Septembra 2024. godine.", 6, 2, "/images/car/Hyundai Kona.jpg", 14200, 38, 1, 5, 20990, 0, 2, "8", "5912482395", 2022 },
                    { 39, 7, "5", 4, "U dobrom stanju. Menjac i motor dobri, limariski nema ulaganja. Gume dobre. Električni podizaci stakala. Gume dobre.", 4, 1, "/images/car/Hyundai Matrix.jpg", 236000, 39, 1, 5, 1799, 0, 1, "9", "5912482396", 2005 },
                    { 40, 3, "5", 8, "Kupljen nov u Srbiji; održavan od prvog dana do danas u ovlašćenom Hyundai servisu. Na automobilu se nalaze nove Continental All Season gume kupljene u maju 2023.", 6, 1, "/images/car/Hyundai Santa Fe.jpg", 163000, 40, 1, 5, 19900, 0, 2, "10", "5912482397", 2017 },
                    { 41, 2, "6", 3, "Auto je u perfektnom stanju. Placena carina, ide na ime kupca, potrebna samo registracija.", 6, 2, "/images/car/Opel Adam.jpg", 190000, 41, 0, 4, 8850, 0, 1, "9", "5104529476", 2019 },
                    { 42, 2, "6", 4, "Kupljena i uvezena od prvog vlasnika sa kompletnom servisnom istorijom od prvog dana + 2 originalna ključa. Automobil je bez ikakvog oštećenja na karoseriji i enterijeru. Mehanički je u perfektnom stanju kako motor tako i menjač, u vožnji utegnut nema stranih zvukova, kvačilo mekano. Izvršen kompletan pregled automobila u 90 tačaka. Svako dugme na automobilu radi, klima odlično hladi. Na automobilu su odlične Letnje gume. Proizvedena 12.2010, a prvi put registrovana 2011 godine. Plaćene sve dažbine, uradjen je i pregled AMSS.", 5, 1, "/images/car/Opel Astra.jpg", 175044, 42, 1, 5, 5790, 0, 1, "8", "5104529477", 2011 },
                    { 43, 2, "6", 7, "Vozilo u odlicnom stanju. Uvoz iz Švajcarske. Motor, menjac i trap u odlicnom stanju. Limarijski bez ulaganja. Unutrasnjost vozila izuzetno ocuvana. Na vozilu se nalaze zimski pneumatici. Vozilo poseduje originalnu servisnu knjizicu iz uvoza.", 5, 2, "/images/car/Opel Corsa.jpg", 121800, 43, 1, 5, 4850, 0, 1, "7", "5104529478", 2014 },
                    { 44, 3, "6", 7, "limarijski zdrava. Motor odlican. Menjac odlican, pogon 4x4 odlican. Trapovi odlicni. Gume letnje. Diskovi, plocice, paknovi - sve novo stavljeno, odrzavan auto. Od enterijera, vozacevo sediste leva strana malo pohabana.", 3, 1, "/images/car/Opel Frontera.jpg", 257000, 44, 1, 5, 3450, 0, 1, "6", "5104529479", 2003 },
                    { 45, 1, "6", 4, "U besprkornom stanju u svim segmentima. Izuzetno mali potrosac 6.7/100km GRAD!", 6, 1, "/images/car/Opel Insignia.jpg", 192825, 45, 1, 5, 13890, 0, 2, "5", "5104529480", 2018 },
                    { 46, 1, "6", 6, "Auto je u dobrom stanju, motor perfektan, enterijer u dobrom stanju, razlog prodaje posedujem dva automobila. Registrovan do 22.01.2024. Auto poseduje klimu koju nisam koristio.", 3, 2, "/images/car/Opel Kadett.jpg", 162365, 46, 0, 3, 400, 0, 1, "4", "5104529481", 1987 },
                    { 47, 2, "6", 0, "PERFEKTNO STANJE MOTORA I MENJAČA... FABRIČKI PLIN - ATESTIRAN...", 6, 5, "/images/car/Opel Karl.jpg", 187230, 47, 1, 4, 6500, 0, 1, "3", "5104529482", 2016 },
                    { 48, 3, "6", 8, "Dzip u dobrom stanju.", 2, 1, "/images/car/Opel Monterey.jpg", 265756, 48, 1, 5, 4000, 0, 1, "2", "5104529483", 1995 },
                    { 49, 4, "7", 0, "Automobil u PERFEKTNOM stanju. Kupljen nov u Srbiji, prvi vlasnik. Redovno i isključivo održavan u ovlašćenom servisu, poseduje kompletnu dokumentaciju.", 6, 2, "/images/car/Porsche 911.jpg", 70000, 49, 0, 4, 99999, 0, 2, "1", "6923104572", 2016 },
                    { 50, 3, "7", 7, "Prvi vlasnik, garantovano prava kilometraza (moguca svaka provera), posedujem racune kad je kupljeno vozilo 2009 godine, najjaci paket opreme, panorama… sve 4 gume 2023 godiste kao i felne plus zimski set, dva kljuca, redovno odrzavan, VOZILO JE BUKVALNO KAO NOVO BEZ DINARA ULAGANJA, GARANTUJEM DA JE NAJLEPSI PRIMERAK, garaziran od prvog dana! Navedena cena je fiksna i iskljucivo za kes!", 4, 1, "/images/car/Porsche Cayenne.jpg", 190000, 50, 1, 5, 14500, 0, 2, "9", "6923104573", 2009 },
                    { 51, 4, "7", 0, "Urađen mali servis. Zamenjen separator ulja. Zamenjeni svi diskovi i pločice. Nove svećice. Set kvačila. Prednje levo rame. Prednje desno rame. Nove opruge. Novi amortizeri na haubi. Unutrašnja rasveta sa LED sijalicama. LED svetla za maglu i pozicija. Nove patosnice. Nove lajsne na pragovima. Dva ključa. Dva seta alu felni sa gumama (letnje 17\" / zimske 18\")", 4, 2, "/images/car/Porsche Cayman.jpg", 178500, 51, 0, 2, 27500, 0, 1, "8", "6923104574", 2007 },
                    { 52, 3, "7", 4, "Vozilo u odličnom stanju, kupljeno kao novo u Srbiji i redovno održavano u ovlašćenom servisu. Datum prve registracije: 29.04.2015.", 6, 1, "/images/car/Porsche Macan.jpg", 119899, 52, 1, 5, 34990, 0, 2, "7", "6923104575", 2015 },
                    { 53, 2, "7", 8, "Prvi vlasnik. Svaki servis urađen u ovlašćenom servisu. Servisna knjiga. Visok nivo opreme: panorama, privlačenje vrata, key lets go, ambijentalna rasveta, grejanje i hlađenje sedišta, display na zadnjoj klupi, full matrix far....... Možete proveriti vozilo sa svojim majstorom ili zakazati pregled u ovlašćenom servisu. Vozilo je apsolutno ispravno bez ulaganja bilo koje vrste.", 6, 2, "/images/car/Porsche Panamera.jpg", 123000, 53, 1, 4, 81500, 0, 2, "6", "6923104576", 2018 },
                    { 54, 6, "7", 4, "Vozilo je u fabričkoj garanciji. Na stanju i odmah dostupno.", 6, 2, "/images/car/Porsche Targa.jpg", 12000, 54, 0, 4, 156200, 0, 2, "5", "6923104577", 2021 },
                    { 55, 6, "7", 6, "Uvoz iz Nemacke! Vozilo iz uvoza, kupljeno od prvog vlasnika. Redovno održavano u ovlašćenom servisu (original servisna knjižica ili elektronska servisna istorija dostupna na uvid ). Vozilo je pregledano od strane kompanije SGS-a ili Dekre i nema nikakvih nedostataka ili dodatnih troškova nakon kupovine, osim registracije čije troškove snosi kupac.", 4, 2, "/images/car/Porsche Boxster.jpg", 82000, 55, 0, 2, 35000, 0, 1, "4", "6923104578", 2007 },
                    { 56, 4, "7", 0, "U odličnom stanju zadnjih 10 godina se ne vozi garažiran. Cena nije fiksna. S motor 190 ks nova tabla klima. Električna sedišta sa grejačima, multimedija, alarm, daljensko zaključavanje.", 1, 1, "/images/car/Porsche 944.jpg", 150000, 56, 0, 4, 13500, 0, 1, "3", "6923104579", 1987 },
                    { 57, 3, "8", 6, "Polovno vozilo kupljeno u salonu Jevtović Auto pre dva meseca.", 6, 2, "/images/car/Renault Austral.jpg", 400, 57, 1, 5, 32000, 0, 1, "2", "7230518392", 2023 },
                    { 58, 2, "8", 7, "Auto kupljen nov u Srbiji, bez udesa i kvarova. Ima servisnu knjižicu, ECC sertifikat. Ima funciju povezivosti na Android Auto i Apple CarPlay, ESM sistem. Mali servis uradjen.", 6, 2, "/images/car/Renault Clio.jpg", 15135, 58, 1, 5, 11950, 0, 1, "1", "7230518393", 2020 },
                    { 59, 7, "8", 8, "Nema klimu. Nije oštećen.", 2, 1, "/images/car/Renault Express.jpg", 250000, 59, 0, 5, 400, 0, 1, "3", "7230518394", 1991 },
                    { 60, 1, "8", 6, "Redovno održavan, korišćen uglavnom za duga putovanja. Postoje sitna oštećenja na limariji od gradske vožnje, ništa ekstremno. Mehanički je auto ispravan, atest nije produžen, dokunentacija je skroz uredna ali nisam imao slobodnog vremena pa se to odlagalo. Nepušački auto, dva seta guma. Letnje 16 inča, gume zrele za zamenu, zimske su dobre i na čeličnim su felnama. Nije lupan auto. Ne troši ulje, motor je perfektan. Registracija ističe kraj četvrtog meseca.", 5, 2, "/images/car/Renault Fluence.jpg", 296763, 60, 1, 5, 6100, 0, 1, "4", "7230518395", 2014 },
                    { 61, 3, "8", 6, "Održavan isključivo u ovlašćenom Renault servisu, servisna knjiga plus elektronski listing održavanja.", 6, 2, "/images/car/Renault Kadjar.jpg", 96532, 61, 1, 5, 20000, 0, 2, "5", "7230518396", 2018 },
                    { 62, 2, "8", 6, "VOZILO KUPLJENO NOVO U SRBIJI. ODRŽAVANO U OVLAŠĆENOM SERVISU.", 6, 2, "/images/car/Renault Megane.jpg", 58504, 62, 1, 5, 11990, 0, 1, "6", "7230518397", 2019 },
                    { 63, 2, "8", 3, "Vozilo je u dobrom stanju, nema limarskih oštećenja. Urađen veliki servis i redovan servis u aprilu 2023 godine, kvačilo je promenjeno u novembru 2023 godine.", 4, 2, "/images/car/Renault Modus.jpg", 171400, 63, 1, 5, 3790, 0, 1, "7", "7230518398", 2011 },
                    { 64, 2, "8", 1, "Automobil u perfektnom stanju,bez ostecenja na unutrasnjost i spoljasnost vozila. Mehanicki u potpunosti ispravan i ne zahteva nikakva ulaganja. Četiri odlicne zimske gume.", 6, 2, "/images/car/Renault Twingo.jpg", 180000, 64, 1, 4, 6999, 0, 1, "8", "7230518399", 2016 },
                    { 65, 1, "9", 5, "Auto je kupljeno u Tesla Norge, auto je bio na detaljnoj proveri pre prodaje, sto posedujem dokumentaciju. Domet baterije je oko 400km. Automobil je u savrsenom stanju, slike pri kupovini.", 6, 3, "/images/car/Tesla Model S.jpg", 179000, 65, 1, 5, 25999, 0, 2, "9", "8103644572", 2014 },
                    { 66, 2, "9", 4, "Простран и веома безбедан, са високим фокусом на безбедност, модел 3 је практично без дугмади, где се већина функција аутомобила контролише са централно постављеног екрана од 15 инча. Пуноправна самовозећа седишта чине аутомобил подељен на самовозећи уз помоћ 8 камера, дванаест сензора и 1 радара. Има јединствен домет од 620 км (ВЛПТ), убрзање од 0-100 за 4,4 секунде и максималну брзину од 233 км/х, тако да може да иде брзо.", 6, 3, "/images/car/Tesla Model 3.jpg", 74000, 66, 1, 5, 39900, 0, 2, "10", "8103644573", 2021 },
                    { 67, 3, "9", 0, "Nov auto, kupljen od prvog vlasnika u Nemačkoj. Svaka vrsta provere od strane kupca je moguća.", 6, 3, "/images/car/Tesla Model Y.jpg", 11841, 67, 1, 5, 53000, 0, 2, "1", "8103644574", 2022 },
                    { 68, 3, "9", 4, "SNAGA 525 KS. RANGE (DOMET BATERIJE) 405 KM.", 6, 3, "/images/car/Tesla Model X.jpg", 63000, 68, 1, 6, 60000, 0, 2, "2", "8103644575", 2019 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail",
                unique: true,
                filter: "[NormalizedEmail] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Email",
                table: "AspNetUsers",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_PhoneNumber",
                table: "AspNetUsers",
                column: "PhoneNumber",
                unique: true,
                filter: "[PhoneNumber] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CarListings_BodyTypeId",
                table: "CarListings",
                column: "BodyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CarListings_EngineTypeId",
                table: "CarListings",
                column: "EngineTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CarListings_FuelTypeId",
                table: "CarListings",
                column: "FuelTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CarListings_ModelId",
                table: "CarListings",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_CarListings_TransmissionTypeId",
                table: "CarListings",
                column: "TransmissionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CarListings_VIN",
                table: "CarListings",
                column: "VIN",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Models_BrandId",
                table: "Models",
                column: "BrandId");
        }

        /// <inheritdoc />
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
                name: "CarListings");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "BodyTypes");

            migrationBuilder.DropTable(
                name: "EngineTypes");

            migrationBuilder.DropTable(
                name: "FuelTypes");

            migrationBuilder.DropTable(
                name: "Models");

            migrationBuilder.DropTable(
                name: "TransmissionTypes");

            migrationBuilder.DropTable(
                name: "Brands");
        }
    }
}
