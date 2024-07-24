using Microsoft.EntityFrameworkCore;
using AutoShop.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace AutoShop.Infrastructure
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<CarListing> CarListings { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<EngineType> EngineTypes { get; set; }
        public DbSet<FuelType> FuelTypes { get; set; }
        public DbSet<TransmissionType> TransmissionTypes { get; set; }
        public DbSet<BodyType> BodyTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Model>()
                .HasOne(m => m.Brand)
                .WithMany(b => b.Models)
                .HasForeignKey(m => m.BrandId);

            modelBuilder.Entity<CarListing>()
                .HasOne(c => c.Model)
                .WithMany(m => m.CarListings)
                .HasForeignKey(c => c.ModelId);

            modelBuilder.Entity<CarListing>()
                .HasOne(c => c.EngineType)
                .WithMany(b => b.CarListings)
                .HasForeignKey(c => c.EngineTypeId);

            modelBuilder.Entity<CarListing>()
                .HasOne(c => c.TransmissionType)
                .WithMany(b => b.CarListings)
                .HasForeignKey(c => c.TransmissionTypeId);

            modelBuilder.Entity<CarListing>()
                .HasOne(c => c.FuelType)
                .WithMany(b => b.CarListings)
                .HasForeignKey(c => c.FuelTypeId);

            modelBuilder.Entity<CarListing>()
                .HasOne(c => c.BodyType)
                .WithMany(b => b.CarListings)
                .HasForeignKey(c => c.BodyTypeId);

            modelBuilder.Entity<CarListing>(entity =>
            {
                entity.HasIndex(c => c.VIN).IsUnique();
            });

            modelBuilder.Entity<IdentityUser>(entity =>
            {
                entity.HasIndex(u => u.Email).IsUnique();
                entity.HasIndex(u => u.NormalizedEmail).IsUnique();
                entity.HasIndex(u => u.PhoneNumber).IsUnique();
            });

            modelBuilder.Entity<Brand>().HasData(
                new Brand { BrandId = 1, Name = "Audi" },
                new Brand { BrandId = 2, Name = "BMW" },
                new Brand { BrandId = 3, Name = "Citroen" },
                new Brand { BrandId = 4, Name = "Fiat" },
                new Brand { BrandId = 5, Name = "Hyundai" },
                new Brand { BrandId = 6, Name = "Opel" },
                new Brand { BrandId = 7, Name = "Porsche" },
                new Brand { BrandId = 8, Name = "Renault" },
                new Brand { BrandId = 9, Name = "Tesla" }
            );

            modelBuilder.Entity<Model>().HasData(
                new Model { ModelId = 1, Name = "A1", BrandId = 1 },
                new Model { ModelId = 2, Name = "A2", BrandId = 1 },
                new Model { ModelId = 3, Name = "A3", BrandId = 1 },
                new Model { ModelId = 4, Name = "A4", BrandId = 1 },
                new Model { ModelId = 5, Name = "A5", BrandId = 1 },
                new Model { ModelId = 6, Name = "A6", BrandId = 1 },
                new Model { ModelId = 7, Name = "A7", BrandId = 1 },
                new Model { ModelId = 8, Name = "A8", BrandId = 1 },

                new Model { ModelId = 9, Name = "M2", BrandId = 2 },
                new Model { ModelId = 10, Name = "M3", BrandId = 2 },
                new Model { ModelId = 11, Name = "M4", BrandId = 2 },
                new Model { ModelId = 12, Name = "M5", BrandId = 2 },
                new Model { ModelId = 13, Name = "M6", BrandId = 2 },
                new Model { ModelId = 14, Name = "X1", BrandId = 2 },
                new Model { ModelId = 15, Name = "X2", BrandId = 2 },
                new Model { ModelId = 16, Name = "X3", BrandId = 2 },

                new Model { ModelId = 17, Name = "Ami", BrandId = 3 },
                new Model { ModelId = 18, Name = "Berlingo", BrandId = 3 },
                new Model { ModelId = 19, Name = "C1", BrandId = 3 },
                new Model { ModelId = 20, Name = "C2", BrandId = 3 },
                new Model { ModelId = 21, Name = "C3", BrandId = 3 },
                new Model { ModelId = 22, Name = "C4 Grand Picasso", BrandId = 3 },
                new Model { ModelId = 23, Name = "C5", BrandId = 3 },
                new Model { ModelId = 24, Name = "C6", BrandId = 3 },

                new Model { ModelId = 25, Name = "Albea", BrandId = 4 },
                new Model { ModelId = 26, Name = "Bravo", BrandId = 4 },
                new Model { ModelId = 27, Name = "Croma", BrandId = 4 },
                new Model { ModelId = 28, Name = "Dublo", BrandId = 4 },
                new Model { ModelId = 29, Name = "EVO", BrandId = 4 },
                new Model { ModelId = 30, Name = "Freemont", BrandId = 4 },
                new Model { ModelId = 31, Name = "Idea", BrandId = 4 },
                new Model { ModelId = 32, Name = "Punto", BrandId = 4 },

                new Model { ModelId = 33, Name = "Atos", BrandId = 5 },
                new Model { ModelId = 34, Name = "Bayon", BrandId = 5 },
                new Model { ModelId = 35, Name = "Coupe", BrandId = 5 },
                new Model { ModelId = 36, Name = "Elantra", BrandId = 5 },
                new Model { ModelId = 37, Name = "Genesis", BrandId = 5 },
                new Model { ModelId = 38, Name = "Kona", BrandId = 5 },
                new Model { ModelId = 39, Name = "Matrix", BrandId = 5 },
                new Model { ModelId = 40, Name = "Santa Fe", BrandId = 5 },

                new Model { ModelId = 41, Name = "Adam", BrandId = 6 },
                new Model { ModelId = 42, Name = "Astra", BrandId = 6 },
                new Model { ModelId = 43, Name = "Corsa", BrandId = 6 },
                new Model { ModelId = 44, Name = "Frontera", BrandId = 6 },
                new Model { ModelId = 45, Name = "Insignia", BrandId = 6 },
                new Model { ModelId = 46, Name = "Kadett", BrandId = 6 },
                new Model { ModelId = 47, Name = "Karl", BrandId = 6 },
                new Model { ModelId = 48, Name = "Monterey", BrandId = 6 },

                new Model { ModelId = 49, Name = "911", BrandId = 7 },
                new Model { ModelId = 50, Name = "Cayenne", BrandId = 7 },
                new Model { ModelId = 51, Name = "Cayman", BrandId = 7 },
                new Model { ModelId = 52, Name = "Macan", BrandId = 7 },
                new Model { ModelId = 53, Name = "Panamera", BrandId = 7 },
                new Model { ModelId = 54, Name = "Targa", BrandId = 7 },
                new Model { ModelId = 55, Name = "Boxster", BrandId = 7 },
                new Model { ModelId = 56, Name = "944", BrandId = 7 },

                new Model { ModelId = 57, Name = "Austral", BrandId = 8 },
                new Model { ModelId = 58, Name = "Clio", BrandId = 8 },
                new Model { ModelId = 59, Name = "Express", BrandId = 8 },
                new Model { ModelId = 60, Name = "Fluence", BrandId = 8 },
                new Model { ModelId = 61, Name = "Kadjar", BrandId = 8 },
                new Model { ModelId = 62, Name = "Megane", BrandId = 8 },
                new Model { ModelId = 63, Name = "Nevada", BrandId = 8 },
                new Model { ModelId = 64, Name = "Twingo", BrandId = 8 },

                new Model { ModelId = 65, Name = "Model S", BrandId = 9 },
                new Model { ModelId = 66, Name = "Model 3", BrandId = 9 },
                new Model { ModelId = 67, Name = "Model Y", BrandId = 9 },
                new Model { ModelId = 68, Name = "Model X", BrandId = 9 }
            );

            modelBuilder.Entity<EngineType>().HasData(
                new EngineType { EngineTypeId = 1, Type = "Euro 1" },
                new EngineType { EngineTypeId = 2, Type = "Euro 2" },
                new EngineType { EngineTypeId = 3, Type = "Euro 3" },
                new EngineType { EngineTypeId = 4, Type = "Euro 4" },
                new EngineType { EngineTypeId = 5, Type = "Euro 5" },
                new EngineType { EngineTypeId = 6, Type = "Euro 6" }
            );

            modelBuilder.Entity<TransmissionType>().HasData(
                new TransmissionType { TransmissionTypeId = 1, Type = "Manual" },
                new TransmissionType { TransmissionTypeId = 2, Type = "Automatic" }
            );

            modelBuilder.Entity<FuelType>().HasData(
                new FuelType { FuelTypeId = 1, Type = "Diesel" },
                new FuelType { FuelTypeId = 2, Type = "Petrol" },
                new FuelType { FuelTypeId = 3, Type = "Electicity" },
                new FuelType { FuelTypeId = 4, Type = "Hybrid" },
                new FuelType { FuelTypeId = 5, Type = "Natural gas" }
            );

            modelBuilder.Entity<BodyType>().HasData(
                new BodyType { BodyTypeId = 1, Type = "Sedan" },
                new BodyType { BodyTypeId = 2, Type = "Hatchback" },
                new BodyType { BodyTypeId = 3, Type = "SUV" },
                new BodyType { BodyTypeId = 4, Type = "Coupe" },
                new BodyType { BodyTypeId = 5, Type = "Pickup" },
                new BodyType { BodyTypeId = 6, Type = "Convertible" },
                new BodyType { BodyTypeId = 7, Type = "MiniVan" }
            );

            modelBuilder.Entity<CarListing>().HasData(
                new CarListing
                {
                    CarId = 1,
                    UserId = "1",
                    BrandName = "1",
                    ModelId = 1,
                    Year = 2011,
                    Color = CarColor.Red,
                    EngineTypeId = 5,
                    TransmissionTypeId = 1,
                    FuelTypeId = 2,
                    BodyTypeId = 2,
                    Mileage = 212110,
                    Price = 6200,
                    NumberOfDoors = CarDoors.Three,
                    NumberOfSeats = 4,
                    VIN = "1934830127",
                    Description = "Vozilo u odlicnom stanju. Uvoz Svajcarska. U top stanju, bez dinara ulaganja. Zamenjen pogonski lanac komplet sa lancem uljne pumpe. Zamenjen pk kais, spaner i roler pk kaisa, nove svecice, prednji diskovi i plocice novi, zadnji u odlicnom stanju, zamenjeno ulje i 4 filtera. Gume zimske nove. Klima napunjena. Zadnji parking senzori, navigacija azurirana za 2023 godinu,tempomat. Na vozilu sve ispravno i u odlicnom stanju. Cena dogovor....saljem na viber slike od kupovine iz CH i broj sasije. Odlican za pocetnike",
                    ImageUrl = "/images/car/Audi A1.jpg",
                    Status = CarStatus.Active
                },

                new CarListing
                {
                    CarId = 2,
                    UserId = "2",
                    BrandName = "1",
                    ModelId = 2,
                    Year = 2003,
                    Color = CarColor.Black,
                    EngineTypeId = 3,
                    TransmissionTypeId = 1,
                    FuelTypeId = 1,
                    BodyTypeId = 2,
                    Mileage = 172000,
                    Price = 3150,
                    NumberOfDoors = CarDoors.Five,
                    NumberOfSeats = 4,
                    VIN = "1934830128",
                    Description = "Automobil je u odličnom stanju. Mehanički potpuno ispravan, kao i limarijski. Vozilo za svaku preporuku i vredi pogledati. Za više informacija o vozilu, kao i gledanje istog, pozovite na ispod navedene brojeve. Dozvoljena je svaka vrsta provere po želji kupca. Srećna kupovina!",
                    ImageUrl = "/images/car/Audi A2.jpg",
                    Status = CarStatus.Active
                },

                new CarListing
                {
                    CarId = 3,
                    UserId = "3",
                    BrandName = "1",
                    ModelId = 3,
                    Year = 2015,
                    Color = CarColor.Gray,
                    EngineTypeId = 6,
                    TransmissionTypeId = 1,
                    FuelTypeId = 2,
                    BodyTypeId = 2,
                    Mileage = 101000,
                    Price = 11200,
                    NumberOfDoors = CarDoors.Five,
                    NumberOfSeats = 5,
                    VIN = "1934830129",
                    Description = "Auto je kao NOV !!! Od prvog dana servisiran u ovlascenom servisu. Ovako ocuvan auto je jako tesko naci. Dozvoljen svaki vid provere kod vaseg majstora ili ovlascenom servisu. Srecna kupovina !!!",
                    ImageUrl = "/images/car/Audi A3.jpg",
                    Status = CarStatus.Active
                },

                new CarListing
                {
                    CarId = 4,
                    UserId = "4",
                    BrandName = "1",
                    ModelId = 4,
                    Year = 2020,
                    Color = CarColor.White,
                    EngineTypeId = 6,
                    TransmissionTypeId = 2,
                    FuelTypeId = 1,
                    BodyTypeId = 1,
                    Mileage = 149000,
                    Price = 28250,
                    NumberOfDoors = CarDoors.Five,
                    NumberOfSeats = 5,
                    VIN = "1934830130",
                    Description = "Orginalna kilometraza, servisna knjiga, i kompletna servisna istorija od prvog dana, sto se moze proveriti u ovlascenom audi servisu !!!!!!!!! Auto je iz uvoza, prodaje se na ime kupca... Kupac ne placa prenos vozila... Placena carina, pdv i amss... Dobijeno pismeno uverenje o ispravnosti vozila, od agencije za bezbednost saobracaja... Stanje novo, dosta dodatne opreme... Vozilo ispitano, mehanicki pregledano, tehnicki ispravno, bez ikakvih dodatnih ulaganja, pregledano...",
                    ImageUrl = "/images/car/Audi A4.jpg",
                    Status = CarStatus.Active
                },

                new CarListing
                {
                    CarId = 5,
                    UserId = "5",
                    BrandName = "1",
                    ModelId = 5,
                    Year = 2021,
                    Color = CarColor.Blue,
                    EngineTypeId = 6,
                    TransmissionTypeId = 2,
                    FuelTypeId = 4,
                    BodyTypeId = 2,
                    Mileage = 24000,
                    Price = 38800,
                    NumberOfDoors = CarDoors.Five,
                    NumberOfSeats = 5,
                    VIN = "1934830131",
                    Description = "Auto je kupljen u Audijevom salonu u Švedskoj za koji je moguć svaki vid provere kod majstora kao i carvertical koji ćemo mi platiti u slučaju da nešto nije tačno što piše u oglasu. Automobil proizveden u aprilu 2021 godine, dok je prva registracija 23.06.2021 godine. Pri kupovini automobil ide direktno na kupca gde od troškova ima samo registraciju koja je izuzetno niska zbog hybridnog motora.",
                    ImageUrl = "/images/car/Audi A5.jpg",
                    Status = CarStatus.Active
                },

                new CarListing
                {
                    CarId = 6,
                    UserId = "6",
                    BrandName = "1",
                    ModelId = 6,
                    Year = 2015,
                    Color = CarColor.Red,
                    EngineTypeId = 6,
                    TransmissionTypeId = 2,
                    FuelTypeId = 1,
                    BodyTypeId = 1,
                    Mileage = 208000,
                    Price = 22900,
                    NumberOfDoors = CarDoors.Five,
                    NumberOfSeats = 5,
                    VIN = "1934830132",
                    Description = "Auto u ekstra stanju. Servisiran alnaser, alternator i kompresor klime. Zamenjeni zadnji amortizeri, potkovica i zadnji selen blokovi. Sva četiri diska nova. Enterijer očuvan i nista nije pocepano. Zimske mišelin gume na alu felnama. Gratis još jedan set letnjih guma na alu felnama. Auto skroz pouzdan i siguran. Bez ulaganja. Prodaje se zato sto sam kupio drugi automobil.",
                    ImageUrl = "/images/car/Audi A6.jpg",
                    Status = CarStatus.Active
                },

                new CarListing
                {
                    CarId = 7,
                    UserId = "7",
                    BrandName = "1",
                    ModelId = 7,
                    Year = 2017,
                    Color = CarColor.Green,
                    EngineTypeId = 6,
                    TransmissionTypeId = 2,
                    FuelTypeId = 4,
                    BodyTypeId = 2,
                    Mileage = 138000,
                    Price = 60000,
                    NumberOfDoors = CarDoors.Five,
                    NumberOfSeats = 5,
                    VIN = "1934830133",
                    Description = "Kupljen nov u Nemačkoj, garancija na pređenu kilometražu i sve ostalo. Čipovan je na 400 ks.",
                    ImageUrl = "/images/car/Audi A7.jpg",
                    Status = CarStatus.Active
                },

                new CarListing
                {
                    CarId = 8,
                    UserId = "8",
                    BrandName = "1",
                    ModelId = 8,
                    Year = 2019,
                    Color = CarColor.Gray,
                    EngineTypeId = 6,
                    TransmissionTypeId = 2,
                    FuelTypeId = 1,
                    BodyTypeId = 1,
                    Mileage = 95000,
                    Price = 65000,
                    NumberOfDoors = CarDoors.Five,
                    NumberOfSeats = 5,
                    VIN = "1934830134",
                    Description = "Besprekorno održavan automobil",
                    ImageUrl = "/images/car/Audi A8.jpg",
                    Status = CarStatus.Active
                },

                new CarListing
                {
                    CarId = 9,
                    UserId = "9",
                    BrandName = "2",
                    ModelId = 9,
                    Year = 2019,
                    Color = CarColor.Blue,
                    EngineTypeId = 6,
                    TransmissionTypeId = 2,
                    FuelTypeId = 2,
                    BodyTypeId = 1,
                    Mileage = 31000,
                    Price = 55000,
                    NumberOfDoors = CarDoors.Three,
                    NumberOfSeats = 4,
                    VIN = "2563075495",
                    Description = "Nove Hankook gume",
                    ImageUrl = "/images/car/BMW M2.jpg",
                    Status = CarStatus.Active
                },

                new CarListing
                {
                    CarId = 10,
                    UserId = "10",
                    BrandName = "2",
                    ModelId = 10,
                    Year = 2009,
                    Color = CarColor.Blue,
                    EngineTypeId = 4,
                    TransmissionTypeId = 2,
                    FuelTypeId = 2,
                    BodyTypeId = 1,
                    Mileage = 117441,
                    Price = 45000,
                    NumberOfDoors = CarDoors.Five,
                    NumberOfSeats = 5,
                    VIN = "2563075496",
                    Description = "Automobil je u TOP stanju u svakom smislu.",
                    ImageUrl = "/images/car/BMW M3.jpg",
                    Status = CarStatus.Active
                },

                new CarListing
                {
                    CarId = 11,
                    UserId = "5",
                    BrandName = "2",
                    ModelId = 11,
                    Year = 2022,
                    Color = CarColor.Green,
                    EngineTypeId = 6,
                    TransmissionTypeId = 2,
                    FuelTypeId = 2,
                    BodyTypeId = 4,
                    Mileage = 35535,
                    Price = 98990,
                    NumberOfDoors = CarDoors.Three,
                    NumberOfSeats = 4,
                    VIN = "2563075497",
                    Description = "Vozilo je u perfektnom stanju, kupljeno kao novo u Srbiji u Delta Motorsu. Redovno održavano u ovlašćenom BMW servisu. Datum prve registracije: 10.08.2022. Automobil ima produženu fabričku garanciju do 09.08.2026 ili 200.000 km. Poseduje paket besplatnog održavanja (Service inclusive) do 09.08.2026 ili do 120.000 km.",
                    ImageUrl = "/images/car/BMW M4.jpg",
                    Status = CarStatus.Active
                },

                new CarListing
                {
                    CarId = 12,
                    UserId = "4",
                    BrandName = "2",
                    ModelId = 12,
                    Year = 2018,
                    Color = CarColor.Red,
                    EngineTypeId = 6,
                    TransmissionTypeId = 2,
                    FuelTypeId = 2,
                    BodyTypeId = 1,
                    Mileage = 58000,
                    Price = 72000,
                    NumberOfDoors = CarDoors.Five,
                    NumberOfSeats = 5,
                    VIN = "2563075498",
                    Description = "Vozilo u perfektnom stanju. Mogucnost svake vrste provere u servisu.",
                    ImageUrl = "/images/car/BMW M5.jpg",
                    Status = CarStatus.Active
                },

                new CarListing
                {
                    CarId = 13,
                    UserId = "3",
                    BrandName = "2",
                    ModelId = 13,
                    Year = 2006,
                    Color = CarColor.Blue,
                    EngineTypeId = 4,
                    TransmissionTypeId = 2,
                    FuelTypeId = 4,
                    BodyTypeId = 6,
                    Mileage = 124000,
                    Price = 22600,
                    NumberOfDoors = CarDoors.Three,
                    NumberOfSeats = 4,
                    VIN = "2563075499",
                    Description = "Poslednji model M Bmw-a sa atnosverskim motorom. Redak i cenjen model u Cabrio verziji.",
                    ImageUrl = "/images/car/BMW M6.jpg",
                    Status = CarStatus.Active
                },

                new CarListing
                {
                    CarId = 14,
                    UserId = "2",
                    BrandName = "2",
                    ModelId = 14,
                    Year = 2011,
                    Color = CarColor.Gray,
                    EngineTypeId = 5,
                    TransmissionTypeId = 1,
                    FuelTypeId = 1,
                    BodyTypeId = 3,
                    Mileage = 189000,
                    Price = 6700,
                    NumberOfDoors = CarDoors.Five,
                    NumberOfSeats = 5,
                    VIN = "2563075500",
                    Description = "Motor je u kvaru !!!",
                    ImageUrl = "/images/car/BMW X1.jpg",
                    Status = CarStatus.Active
                },

                new CarListing
                {
                    CarId = 15,
                    UserId = "1",
                    BrandName = "2",
                    ModelId = 15,
                    Year = 2018,
                    Color = CarColor.Yellow,
                    EngineTypeId = 6,
                    TransmissionTypeId = 2,
                    FuelTypeId = 1,
                    BodyTypeId = 3,
                    Mileage = 151000,
                    Price = 26990,
                    NumberOfDoors = CarDoors.Five,
                    NumberOfSeats = 5,
                    VIN = "2563075501",
                    Description = "Odličan, spreman za zimu sa XD pogonom. Svi servisi redovno rađeni u BMW-u.",
                    ImageUrl = "/images/car/BMW X2.jpg",
                    Status = CarStatus.Active
                },

                new CarListing
                {
                    CarId = 16,
                    UserId = "6",
                    BrandName = "2",
                    ModelId = 16,
                    Year = 2021,
                    Color = CarColor.Black,
                    EngineTypeId = 6,
                    TransmissionTypeId = 2,
                    FuelTypeId = 2,
                    BodyTypeId = 3,
                    Mileage = 74442,
                    Price = 51990,
                    NumberOfDoors = CarDoors.Five,
                    NumberOfSeats = 5,
                    VIN = "2563075502",
                    Description = "Vozilo je u besprekornom stanju. Datum prve registracije: 15.04.2021. Mogućnost kupovine vozila preko kredita, finansijskog ili operativnog lizinga. Delta Automoto daje garanciju na motor.",
                    ImageUrl = "/images/car/BMW X3.jpg",
                    Status = CarStatus.Active
                },

                new CarListing
                {
                    CarId = 17,
                    UserId = "7",
                    BrandName = "3",
                    ModelId = 17,
                    Year = 2022,
                    Color = CarColor.Gray,
                    EngineTypeId = 6,
                    TransmissionTypeId = 2,
                    FuelTypeId = 3,
                    BodyTypeId = 2,
                    Mileage = 58,
                    Price = 8950,
                    NumberOfDoors = CarDoors.Three,
                    NumberOfSeats = 2,
                    VIN = "3984532196",
                    Description = "Panorama krov. Tonirana stakla. Automobil je nov..za vise info pozvati.",
                    ImageUrl = "/images/car/Citroen Ami.jpg",
                    Status = CarStatus.Active
                },

                new CarListing
                {
                    CarId = 18,
                    UserId = "8",
                    BrandName = "3",
                    ModelId = 18,
                    Year = 2016,
                    Color = CarColor.Blue,
                    EngineTypeId = 6,
                    TransmissionTypeId = 1,
                    FuelTypeId = 1,
                    BodyTypeId = 7,
                    Mileage = 170000,
                    Price = 7499,
                    NumberOfDoors = CarDoors.Five,
                    NumberOfSeats = 5,
                    VIN = "3984532197",
                    Description = "Uvezen iz Nemacke 2022. Registrovan godinu dana do Decembra 2024. Redovno odrzavan. Dva seta guma. Bez ulaganja.",
                    ImageUrl = "/images/car/Citroen Berlingo.jpg",
                    Status = CarStatus.Active
                },

                new CarListing
                {
                    CarId = 19,
                    UserId = "9",
                    BrandName = "3",
                    ModelId = 19,
                    Year = 2010,
                    Color = CarColor.Gray,
                    EngineTypeId = 4,
                    TransmissionTypeId = 1,
                    FuelTypeId = 2,
                    BodyTypeId = 2,
                    Mileage = 214521,
                    Price = 2750,
                    NumberOfDoors = CarDoors.Three,
                    NumberOfSeats = 4,
                    VIN = "3984532198",
                    Description = "Gradski zvrk sa motorom Toyote. Odlicno stanje kako limarijski tako i mehanicki. Zamenjen lonac auspuha koji je u garanciji 2 godine. Auto bez ulaganja za grad izmisljen. Razlog prodaje sin iznenadno dobio posao u inostranstvu pa bi bio visak.",
                    ImageUrl = "/images/car/Citroen C1.jpg",
                    Status = CarStatus.Active
                },

                new CarListing
                {
                    CarId = 20,
                    UserId = "10",
                    BrandName = "3",
                    ModelId = 20,
                    Year = 2004,
                    Color = CarColor.Red,
                    EngineTypeId = 3,
                    TransmissionTypeId = 1,
                    FuelTypeId = 2,
                    BodyTypeId = 2,
                    Mileage = 145000,
                    Price = 2100,
                    NumberOfDoors = CarDoors.Three,
                    NumberOfSeats = 4,
                    VIN = "3984532199",
                    Description = "PRAVA KILOMETRAZA! Digitalna klima!",
                    ImageUrl = "/images/car/Citroen C2.jpg",
                    Status = CarStatus.Active
                },

                new CarListing
                {
                    CarId = 21,
                    UserId = "1",
                    BrandName = "3",
                    ModelId = 21,
                    Year = 2018,
                    Color = CarColor.Red,
                    EngineTypeId = 6,
                    TransmissionTypeId = 1,
                    FuelTypeId = 2,
                    BodyTypeId = 2,
                    Mileage = 68240,
                    Price = 10990,
                    NumberOfDoors = CarDoors.Five,
                    NumberOfSeats = 5,
                    VIN = "3984532200",
                    Description = "Vozilo je iz uvoza. Poseduje kompletnu servisnu istoriju (istorija je dostupna na uvid prilikom posete izložbenom salonu.",
                    ImageUrl = "/images/car/Citroen C3.jpg",
                    Status = CarStatus.Active
                },

                new CarListing
                {
                    CarId = 22,
                    UserId = "2",
                    BrandName = "3",
                    ModelId = 22,
                    Year = 2016,
                    Color = CarColor.Gray,
                    EngineTypeId = 6,
                    TransmissionTypeId = 1,
                    FuelTypeId = 1,
                    BodyTypeId = 2,
                    Mileage = 141382,
                    Price = 8950,
                    NumberOfDoors = CarDoors.Five,
                    NumberOfSeats = 5,
                    VIN = "3984532201",
                    Description = "Za svaki kupljeni auto kod nas mozete da uradite veliki servis u nasem servisu za koji dobijate GARANCIJU.",
                    ImageUrl = "/images/car/Citroen C4.jpg",
                    Status = CarStatus.Active
                },

                new CarListing
                {
                    CarId = 23,
                    UserId = "3",
                    BrandName = "3",
                    ModelId = 23,
                    Year = 2008,
                    Color = CarColor.Gray,
                    EngineTypeId = 4,
                    TransmissionTypeId = 1,
                    FuelTypeId = 1,
                    BodyTypeId = 1,
                    Mileage = 186344,
                    Price = 4450,
                    NumberOfDoors = CarDoors.Five,
                    NumberOfSeats = 5,
                    VIN = "3984532202",
                    Description = "Auto u ekstra stanju redovno odrzavano, potpuno ispravno. Kupcu ostaje samo tehnicki i registracija.",
                    ImageUrl = "/images/car/Citroen C5.jpg",
                    Status = CarStatus.Active
                },

                new CarListing
                {
                    CarId = 24,
                    UserId = "4",
                    BrandName = "3",
                    ModelId = 24,
                    Year = 2008,
                    Color = CarColor.Gray,
                    EngineTypeId = 4,
                    TransmissionTypeId = 2,
                    FuelTypeId = 1,
                    BodyTypeId = 1,
                    Mileage = 220000,
                    Price = 5999,
                    NumberOfDoors = CarDoors.Five,
                    NumberOfSeats = 5,
                    VIN = "3984532203",
                    Description = "Visoka klasa vozila. Digitalna tabla. Praćenje trake. Redovno servisiran i održavan. Motor mu tiho radi i nema dima. Menjač šalta savršeno i ne lupa ni vruć a ni hladan. Cena smešna za keš - fixno.",
                    ImageUrl = "/images/car/Citroen C6.jpg",
                    Status = CarStatus.Active
                },

                new CarListing
                {
                    CarId = 25,
                    UserId = "5",
                    BrandName = "4",
                    ModelId = 25,
                    Year = 2005,
                    Color = CarColor.Other,
                    EngineTypeId = 3,
                    TransmissionTypeId = 1,
                    FuelTypeId = 2,
                    BodyTypeId = 1,
                    Mileage = 97000,
                    Price = 1600,
                    NumberOfDoors = CarDoors.Five,
                    NumberOfSeats = 5,
                    VIN = "4396710321",
                    Description = "Prvi i jedini vlasnik do sada.2009-te godine je ugradjen autogas uredjaj (pre neki dan je uradjen reatest a boca treba da se menja tek za 7-8 godina-pošto je zamenjena pre par godina. Do sada su zamenjeni akumulator i auspuh više puta i redovno ulje, filteri, antifriz kablovi i svećice.Zatim su menjani alternator, set kvačila, zupčasti kajiš,kočioni diskovi, nosači motora, diferencijal i kompjuter koji nije sasvim otkazao-čuvam ga i sada za „ne daj bože“ pošto se zameni za 2 minuta a samo je pokazao izvesnu nestabilnost u radu dok se motor ne zagreje. Auto je u solidnom stanju za svoje godine, ispravan, upravo registrovan (registracija važi do 03.01.2025 god.) vrlo malo prešao (uvek je bio drugi sigurni auto).Ima nekoliko manjih oštećenja-ulubljenja od nesmotrenih vozača na parkingu (bilo je i ranije pa mi je pre 7-8 god. autolimar sve to sredio prefarbao ali džaba-opet isto…).",
                    ImageUrl = "/images/car/Fiat Albea.jpg",
                    Status = CarStatus.Active
                },

                new CarListing
                {
                    CarId = 26,
                    UserId = "6",
                    BrandName = "4",
                    ModelId = 26,
                    Year = 2007,
                    Color = CarColor.Red,
                    EngineTypeId = 4,
                    TransmissionTypeId = 1,
                    FuelTypeId = 1,
                    BodyTypeId = 2,
                    Mileage = 221000,
                    Price = 3800,
                    NumberOfDoors = CarDoors.Five,
                    NumberOfSeats = 5,
                    VIN = "4396710322",
                    Description = "Auto je kupljen u avgustu 2023. godine. Krenuo sam da ga sredjujem za licnu upotrebu, razlog prodaje je poslovna prilika koja se otvorila u medjuvremenu. Registrovan je do kraja aprila 2024. Mozete doci da pogledate auto svakim danom do 9 ujutru ili posle 4 popodne, kontakt na broj telefona.",
                    ImageUrl = "/images/car/Fiat Bravo.jpg",
                    Status = CarStatus.Active
                },

                new CarListing
                {
                    CarId = 27,
                    UserId = "7",
                    BrandName = "4",
                    ModelId = 27,
                    Year = 2008,
                    Color = CarColor.Gray,
                    EngineTypeId = 4,
                    TransmissionTypeId = 1,
                    FuelTypeId = 1,
                    BodyTypeId = 1,
                    Mileage = 189000,
                    Price = 3490,
                    NumberOfDoors = CarDoors.Five,
                    NumberOfSeats = 5,
                    VIN = "4396710323",
                    Description = "VOZILO IZ UVOZA,OCARINJENO I URADJEN AMSS. MEHANICKI BEZ GRESKE, ENTERIJER KAO NOV. DOZVOLJENE SVE VRSTE PREGLEDA.LEPSI UZIVO NEGO NA SLIKAMA.",
                    ImageUrl = "/images/car/Fiat Croma.jpg",
                    Status = CarStatus.Active
                },

                new CarListing
                {
                    CarId = 28,
                    UserId = "8",
                    BrandName = "4",
                    ModelId = 28,
                    Year = 2013,
                    Color = CarColor.White,
                    EngineTypeId = 5,
                    TransmissionTypeId = 1,
                    FuelTypeId = 1,
                    BodyTypeId = 7,
                    Mileage = 161000,
                    Price = 6999,
                    NumberOfDoors = CarDoors.Five,
                    NumberOfSeats = 5,
                    VIN = "4396710324",
                    Description = "Uradjen veliki servis. Utegnut u voznji. Mogucnost svake vrste provere.",
                    ImageUrl = "/images/car/Fiat Dublo.jpg",
                    Status = CarStatus.Active
                },

                new CarListing
                {
                    CarId = 29,
                    UserId = "9",
                    BrandName = "4",
                    ModelId = 29,
                    Year = 2010,
                    Color = CarColor.White,
                    EngineTypeId = 4,
                    TransmissionTypeId = 1,
                    FuelTypeId = 1,
                    BodyTypeId = 2,
                    Mileage = 186000,
                    Price = 3599,
                    NumberOfDoors = CarDoors.Three,
                    NumberOfSeats = 5,
                    VIN = "4396710325",
                    Description = "Auto je u odlicnom stanju. Na ime kupca.",
                    ImageUrl = "/images/car/Fiat Evo.jpg",
                    Status = CarStatus.Active
                },

                new CarListing
                {
                    CarId = 30,
                    UserId = "10",
                    BrandName = "4",
                    ModelId = 30,
                    Year = 2011,
                    Color = CarColor.Black,
                    EngineTypeId = 5,
                    TransmissionTypeId = 1,
                    FuelTypeId = 1,
                    BodyTypeId = 3,
                    Mileage = 241318,
                    Price = 8700,
                    NumberOfDoors = CarDoors.Five,
                    NumberOfSeats = 7,
                    VIN = "4396710326",
                    Description = "Vozilo iz uvoza, kupljeno od prvog vlasnika. Redovno održavano u ovlašćenom servisu FIAT ( original servisna knjižica i elektronska servisna istorija dostupna na uvid ).",
                    ImageUrl = "/images/car/Fiat Freemont.jpg",
                    Status = CarStatus.Active
                },

                new CarListing
                {
                    CarId = 31,
                    UserId = "1",
                    BrandName = "4",
                    ModelId = 31,
                    Year = 2006,
                    Color = CarColor.Blue,
                    EngineTypeId = 4,
                    TransmissionTypeId = 1,
                    FuelTypeId = 1,
                    BodyTypeId = 2,
                    Mileage = 199000,
                    Price = 2350,
                    NumberOfDoors = CarDoors.Five,
                    NumberOfSeats = 5,
                    VIN = "4396710327",
                    Description = "Auto u odličnom stanju. Za vise informacija pozovi.",
                    ImageUrl = "/images/car/Fiat Idea.jpg",
                    Status = CarStatus.Active
                },

                new CarListing
                {
                    CarId = 32,
                    UserId = "2",
                    BrandName = "4",
                    ModelId = 32,
                    Year = 2004,
                    Color = CarColor.Blue,
                    EngineTypeId = 4,
                    TransmissionTypeId = 1,
                    FuelTypeId = 2,
                    BodyTypeId = 2,
                    Mileage = 94822,
                    Price = 2280,
                    NumberOfDoors = CarDoors.Five,
                    NumberOfSeats = 5,
                    VIN = "4396710328",
                    Description = "MALI POTROŠAČ JEFTIN ZA ODRZÀVANJE. BEZ DINARA DODATNIH ULAGANJA. CENA SKORO FIXNA FIXNA.",
                    ImageUrl = "/images/car/Fiat Punto.jpg",
                    Status = CarStatus.Active
                },

                new CarListing
                {
                    CarId = 33,
                    UserId = "3",
                    BrandName = "5",
                    ModelId = 33,
                    Year = 2002,
                    Color = CarColor.Yellow,
                    EngineTypeId = 4,
                    TransmissionTypeId = 1,
                    FuelTypeId = 2,
                    BodyTypeId = 2,
                    Mileage = 144148,
                    Price = 1300,
                    NumberOfDoors = CarDoors.Five,
                    NumberOfSeats = 5,
                    VIN = "5912482390",
                    Description = "Auto se prodaje jer nam vise nije potreban. Baka više ne želi da vozi.",
                    ImageUrl = "/images/car/Hyundai Atos.jpg",
                    Status = CarStatus.Active
                },

                new CarListing
                {
                    CarId = 34,
                    UserId = "4",
                    BrandName = "5",
                    ModelId = 34,
                    Year = 2023,
                    Color = CarColor.Green,
                    EngineTypeId = 6,
                    TransmissionTypeId = 1,
                    FuelTypeId = 2,
                    BodyTypeId = 2,
                    Mileage = 7,
                    Price = 18390,
                    NumberOfDoors = CarDoors.Five,
                    NumberOfSeats = 5,
                    VIN = "5912482391",
                    Description = "Garancija na vozilo 5+2 godine, bez ograničenja pređene kilometraže. Mogućnost kupovine pod povoljnim uslovima na kredit ili lizing.",
                    ImageUrl = "/images/car/Hyundai Bayon.jpg",
                    Status = CarStatus.Active
                },

                new CarListing
                {
                    CarId = 35,
                    UserId = "5",
                    BrandName = "5",
                    ModelId = 35,
                    Year = 2004,
                    Color = CarColor.Blue,
                    EngineTypeId = 3,
                    TransmissionTypeId = 1,
                    FuelTypeId = 2,
                    BodyTypeId = 4,
                    Mileage = 142000,
                    Price = 3350,
                    NumberOfDoors = CarDoors.Three,
                    NumberOfSeats = 4,
                    VIN = "5912482392",
                    Description = "Stanje odlicno. Uradjen veliki servis na 135.000 km. Urađeno kvačilo na 135.000 km. Gume nove sve cetri, motor i menjac savrseni, za dodatne informacije pozovite.",
                    ImageUrl = "/images/car/Hyundai Coupe.jpg",
                    Status = CarStatus.Active
                },

                new CarListing
                {
                    CarId = 36,
                    UserId = "6",
                    BrandName = "5",
                    ModelId = 36,
                    Year = 2017,
                    Color = CarColor.Gray,
                    EngineTypeId = 6,
                    TransmissionTypeId = 1,
                    FuelTypeId = 1,
                    BodyTypeId = 1,
                    Mileage = 61000,
                    Price = 13500,
                    NumberOfDoors = CarDoors.Five,
                    NumberOfSeats = 5,
                    VIN = "5912482393",
                    Description = "Vozilo je kupljeno novo u Srbiji, redovno servisirano u ovlascenom Hyundai servisu i nakon isteka garancije u ovlašćenom servisu.",
                    ImageUrl = "/images/car/Hyundai Elantra.jpg",
                    Status = CarStatus.Active
                },

                new CarListing
                {
                    CarId = 37,
                    UserId = "7",
                    BrandName = "5",
                    ModelId = 37,
                    Year = 2011,
                    Color = CarColor.Gray,
                    EngineTypeId = 5,
                    TransmissionTypeId = 2,
                    FuelTypeId = 2,
                    BodyTypeId = 4,
                    Mileage = 37000,
                    Price = 19500,
                    NumberOfDoors = CarDoors.Three,
                    NumberOfSeats = 4,
                    VIN = "5912482394",
                    Description = "Automobil je u perfektnom stanju, bez oštećenja i mehaničkih kvarova. Prvi sam vlasnik automobila kupljenog i odrzavanog u Hyundai Srbija u Beogradu. Motor je u besprekornom stanju. Posedujem kompletnu servisnu dokumentaciju.",
                    ImageUrl = "/images/car/Hyundai Genesis.jpg",
                    Status = CarStatus.Active
                },

                new CarListing
                {
                    CarId = 38,
                    UserId = "8",
                    BrandName = "5",
                    ModelId = 38,
                    Year = 2022,
                    Color = CarColor.White,
                    EngineTypeId = 6,
                    TransmissionTypeId = 2,
                    FuelTypeId = 2,
                    BodyTypeId = 3,
                    Mileage = 14200,
                    Price = 20990,
                    NumberOfDoors = CarDoors.Five,
                    NumberOfSeats = 5,
                    VIN = "5912482395",
                    Description = "U besprekornom stanju. Fabricka garancija. Dva originalna kljuca-kartice. Registrovan do Septembra 2024. godine.",
                    ImageUrl = "/images/car/Hyundai Kona.jpg",
                    Status = CarStatus.Active
                },

                new CarListing
                {
                    CarId = 39,
                    UserId = "9",
                    BrandName = "5",
                    ModelId = 39,
                    Year = 2005,
                    Color = CarColor.Blue,
                    EngineTypeId = 4,
                    TransmissionTypeId = 1,
                    FuelTypeId = 1,
                    BodyTypeId = 7,
                    Mileage = 236000,
                    Price = 1799,
                    NumberOfDoors = CarDoors.Five,
                    NumberOfSeats = 5,
                    VIN = "5912482396",
                    Description = "U dobrom stanju. Menjac i motor dobri, limariski nema ulaganja. Gume dobre. Električni podizaci stakala. Gume dobre.",
                    ImageUrl = "/images/car/Hyundai Matrix.jpg",
                    Status = CarStatus.Active
                },

                new CarListing
                {
                    CarId = 40,
                    UserId = "10",
                    BrandName = "5",
                    ModelId = 40,
                    Year = 2017,
                    Color = CarColor.Other,
                    EngineTypeId = 6,
                    TransmissionTypeId = 2,
                    FuelTypeId = 1,
                    BodyTypeId = 3,
                    Mileage = 163000,
                    Price = 19900,
                    NumberOfDoors = CarDoors.Five,
                    NumberOfSeats = 5,
                    VIN = "5912482397",
                    Description = "Kupljen nov u Srbiji; održavan od prvog dana do danas u ovlašćenom Hyundai servisu. Na automobilu se nalaze nove Continental All Season gume kupljene u maju 2023.",
                    ImageUrl = "/images/car/Hyundai Santa Fe.jpg",
                    Status = CarStatus.Active
                },

                new CarListing
                {
                    CarId = 41,
                    UserId = "9",
                    BrandName = "6",
                    ModelId = 41,
                    Year = 2019,
                    Color = CarColor.Green,
                    EngineTypeId = 6,
                    TransmissionTypeId = 1,
                    FuelTypeId = 2,
                    BodyTypeId = 2,
                    Mileage = 190000,
                    Price = 8850,
                    NumberOfDoors = CarDoors.Three,
                    NumberOfSeats = 4,
                    VIN = "5104529476",
                    Description = "Auto je u perfektnom stanju. Placena carina, ide na ime kupca, potrebna samo registracija.",
                    ImageUrl = "/images/car/Opel Adam.jpg",
                    Status = CarStatus.Active
                },

                new CarListing
                {
                    CarId = 42,
                    UserId = "8",
                    BrandName = "6",
                    ModelId = 42,
                    Year = 2011,
                    Color = CarColor.Blue,
                    EngineTypeId = 5,
                    TransmissionTypeId = 1,
                    FuelTypeId = 1,
                    BodyTypeId = 2,
                    Mileage = 175044,
                    Price = 5790,
                    NumberOfDoors = CarDoors.Five,
                    NumberOfSeats = 5,
                    VIN = "5104529477",
                    Description = "Kupljena i uvezena od prvog vlasnika sa kompletnom servisnom istorijom od prvog dana + 2 originalna ključa. Automobil je bez ikakvog oštećenja na karoseriji i enterijeru. Mehanički je u perfektnom stanju kako motor tako i menjač, u vožnji utegnut nema stranih zvukova, kvačilo mekano. Izvršen kompletan pregled automobila u 90 tačaka. Svako dugme na automobilu radi, klima odlično hladi. Na automobilu su odlične Letnje gume. Proizvedena 12.2010, a prvi put registrovana 2011 godine. Plaćene sve dažbine, uradjen je i pregled AMSS.",
                    ImageUrl = "/images/car/Opel Astra.jpg",
                    Status = CarStatus.Active
                },

                new CarListing
                {
                    CarId = 43,
                    UserId = "7",
                    BrandName = "6",
                    ModelId = 43,
                    Year = 2014,
                    Color = CarColor.White,
                    EngineTypeId = 5,
                    TransmissionTypeId = 1,
                    FuelTypeId = 2,
                    BodyTypeId = 2,
                    Mileage = 121800,
                    Price = 4850,
                    NumberOfDoors = CarDoors.Five,
                    NumberOfSeats = 5,
                    VIN = "5104529478",
                    Description = "Vozilo u odlicnom stanju. Uvoz iz Švajcarske. Motor, menjac i trap u odlicnom stanju. Limarijski bez ulaganja. Unutrasnjost vozila izuzetno ocuvana. Na vozilu se nalaze zimski pneumatici. Vozilo poseduje originalnu servisnu knjizicu iz uvoza.",
                    ImageUrl = "/images/car/Opel Corsa.jpg",
                    Status = CarStatus.Active
                },

                new CarListing
                {
                    CarId = 44,
                    UserId = "6",
                    BrandName = "6",
                    ModelId = 44,
                    Year = 2003,
                    Color = CarColor.White,
                    EngineTypeId = 3,
                    TransmissionTypeId = 1,
                    FuelTypeId = 1,
                    BodyTypeId = 3,
                    Mileage = 257000,
                    Price = 3450,
                    NumberOfDoors = CarDoors.Five,
                    NumberOfSeats = 5,
                    VIN = "5104529479",
                    Description = "limarijski zdrava. Motor odlican. Menjac odlican, pogon 4x4 odlican. Trapovi odlicni. Gume letnje. Diskovi, plocice, paknovi - sve novo stavljeno, odrzavan auto. Od enterijera, vozacevo sediste leva strana malo pohabana.",
                    ImageUrl = "/images/car/Opel Frontera.jpg",
                    Status = CarStatus.Active
                },

                new CarListing
                {
                    CarId = 45,
                    UserId = "5",
                    BrandName = "6",
                    ModelId = 45,
                    Year = 2018,
                    Color = CarColor.Blue,
                    EngineTypeId = 6,
                    TransmissionTypeId = 2,
                    FuelTypeId = 1,
                    BodyTypeId = 1,
                    Mileage = 192825,
                    Price = 13890,
                    NumberOfDoors = CarDoors.Five,
                    NumberOfSeats = 5,
                    VIN = "5104529480",
                    Description = "U besprkornom stanju u svim segmentima. Izuzetno mali potrosac 6.7/100km GRAD!",
                    ImageUrl = "/images/car/Opel Insignia.jpg",
                    Status = CarStatus.Active
                },

                new CarListing
                {
                    CarId = 46,
                    UserId = "4",
                    BrandName = "6",
                    ModelId = 46,
                    Year = 1987,
                    Color = CarColor.Gray,
                    EngineTypeId = 3,
                    TransmissionTypeId = 1,
                    FuelTypeId = 2,
                    BodyTypeId = 1,
                    Mileage = 162365,
                    Price = 400,
                    NumberOfDoors = CarDoors.Three,
                    NumberOfSeats = 3,
                    VIN = "5104529481",
                    Description = "Auto je u dobrom stanju, motor perfektan, enterijer u dobrom stanju, razlog prodaje posedujem dva automobila. Registrovan do 22.01.2024. Auto poseduje klimu koju nisam koristio.",
                    ImageUrl = "/images/car/Opel Kadett.jpg",
                    Status = CarStatus.Active
                },

                new CarListing
                {
                    CarId = 47,
                    UserId = "3",
                    BrandName = "6",
                    ModelId = 47,
                    Year = 2016,
                    Color = CarColor.Red,
                    EngineTypeId = 6,
                    TransmissionTypeId = 1,
                    FuelTypeId = 5,
                    BodyTypeId = 2,
                    Mileage = 187230,
                    Price = 6500,
                    NumberOfDoors = CarDoors.Five,
                    NumberOfSeats = 4,
                    VIN = "5104529482",
                    Description = "PERFEKTNO STANJE MOTORA I MENJAČA... FABRIČKI PLIN - ATESTIRAN...",
                    ImageUrl = "/images/car/Opel Karl.jpg",
                    Status = CarStatus.Active
                },

                new CarListing
                {
                    CarId = 48,
                    UserId = "2",
                    BrandName = "6",
                    ModelId = 48,
                    Year = 1995,
                    Color = CarColor.Other,
                    EngineTypeId = 2,
                    TransmissionTypeId = 1,
                    FuelTypeId = 1,
                    BodyTypeId = 3,
                    Mileage = 265756,
                    Price = 4000,
                    NumberOfDoors = CarDoors.Five,
                    NumberOfSeats = 5,
                    VIN = "5104529483",
                    Description = "Dzip u dobrom stanju.",
                    ImageUrl = "/images/car/Opel Monterey.jpg",
                    Status = CarStatus.Active
                },

                new CarListing
                {
                    CarId = 49,
                    UserId = "1",
                    BrandName = "7",
                    ModelId = 49,
                    Year = 2016,
                    Color = CarColor.Red,
                    EngineTypeId = 6,
                    TransmissionTypeId = 2,
                    FuelTypeId = 2,
                    BodyTypeId = 4,
                    Mileage = 70000,
                    Price = 99999,
                    NumberOfDoors = CarDoors.Three,
                    NumberOfSeats = 4,
                    VIN = "6923104572",
                    Description = "Automobil u PERFEKTNOM stanju. Kupljen nov u Srbiji, prvi vlasnik. Redovno i isključivo održavan u ovlašćenom servisu, poseduje kompletnu dokumentaciju.",
                    ImageUrl = "/images/car/Porsche 911.jpg",
                    Status = CarStatus.Active
                },

                new CarListing
                {
                    CarId = 50,
                    UserId = "9",
                    BrandName = "7",
                    ModelId = 50,
                    Year = 2009,
                    Color = CarColor.White,
                    EngineTypeId = 4,
                    TransmissionTypeId = 2,
                    FuelTypeId = 1,
                    BodyTypeId = 3,
                    Mileage = 190000,
                    Price = 14500,
                    NumberOfDoors = CarDoors.Five,
                    NumberOfSeats = 5,
                    VIN = "6923104573",
                    Description = "Prvi vlasnik, garantovano prava kilometraza (moguca svaka provera), posedujem racune kad je kupljeno vozilo 2009 godine, najjaci paket opreme, panorama… sve 4 gume 2023 godiste kao i felne plus zimski set, dva kljuca, redovno odrzavan, VOZILO JE BUKVALNO KAO NOVO BEZ DINARA ULAGANJA, GARANTUJEM DA JE NAJLEPSI PRIMERAK, garaziran od prvog dana! Navedena cena je fiksna i iskljucivo za kes!",
                    ImageUrl = "/images/car/Porsche Cayenne.jpg",
                    Status = CarStatus.Active
                },

                new CarListing
                {
                    CarId = 51,
                    UserId = "8",
                    BrandName = "7",
                    ModelId = 51,
                    Year = 2007,
                    Color = CarColor.Red,
                    EngineTypeId = 4,
                    TransmissionTypeId = 1,
                    FuelTypeId = 2,
                    BodyTypeId = 4,
                    Mileage = 178500,
                    Price = 27500,
                    NumberOfDoors = CarDoors.Three,
                    NumberOfSeats = 2,
                    VIN = "6923104574",
                    Description = "Urađen mali servis. Zamenjen separator ulja. Zamenjeni svi diskovi i pločice. Nove svećice. Set kvačila. Prednje levo rame. Prednje desno rame. Nove opruge. Novi amortizeri na haubi. Unutrašnja rasveta sa LED sijalicama. LED svetla za maglu i pozicija. Nove patosnice. Nove lajsne na pragovima. Dva ključa. Dva seta alu felni sa gumama (letnje 17\" / zimske 18\")",
                    ImageUrl = "/images/car/Porsche Cayman.jpg",
                    Status = CarStatus.Active
                },

                new CarListing
                {
                    CarId = 52,
                    UserId = "7",
                    BrandName = "7",
                    ModelId = 52,
                    Year = 2015,
                    Color = CarColor.Blue,
                    EngineTypeId = 6,
                    TransmissionTypeId = 2,
                    FuelTypeId = 1,
                    BodyTypeId = 3,
                    Mileage = 119899,
                    Price = 34990,
                    NumberOfDoors = CarDoors.Five,
                    NumberOfSeats = 5,
                    VIN = "6923104575",
                    Description = "Vozilo u odličnom stanju, kupljeno kao novo u Srbiji i redovno održavano u ovlašćenom servisu. Datum prve registracije: 29.04.2015.",
                    ImageUrl = "/images/car/Porsche Macan.jpg",
                    Status = CarStatus.Active
                },

                new CarListing
                {
                    CarId = 53,
                    UserId = "6",
                    BrandName = "7",
                    ModelId = 53,
                    Year = 2018,
                    Color = CarColor.Other,
                    EngineTypeId = 6,
                    TransmissionTypeId = 2,
                    FuelTypeId = 2,
                    BodyTypeId = 2,
                    Mileage = 123000,
                    Price = 81500,
                    NumberOfDoors = CarDoors.Five,
                    NumberOfSeats = 4,
                    VIN = "6923104576",
                    Description = "Prvi vlasnik. Svaki servis urađen u ovlašćenom servisu. Servisna knjiga. Visok nivo opreme: panorama, privlačenje vrata, key lets go, ambijentalna rasveta, grejanje i hlađenje sedišta, display na zadnjoj klupi, full matrix far....... Možete proveriti vozilo sa svojim majstorom ili zakazati pregled u ovlašćenom servisu. Vozilo je apsolutno ispravno bez ulaganja bilo koje vrste.",
                    ImageUrl = "/images/car/Porsche Panamera.jpg",
                    Status = CarStatus.Active
                },

                new CarListing
                {
                    CarId = 54,
                    UserId = "5",
                    BrandName = "7",
                    ModelId = 54,
                    Year = 2021,
                    Color = CarColor.Blue,
                    EngineTypeId = 6,
                    TransmissionTypeId = 2,
                    FuelTypeId = 2,
                    BodyTypeId = 6,
                    Mileage = 12000,
                    Price = 156200,
                    NumberOfDoors = CarDoors.Three,
                    NumberOfSeats = 4,
                    VIN = "6923104577",
                    Description = "Vozilo je u fabričkoj garanciji. Na stanju i odmah dostupno.",
                    ImageUrl = "/images/car/Porsche Targa.jpg",
                    Status = CarStatus.Active
                },

                new CarListing
                {
                    CarId = 55,
                    UserId = "4",
                    BrandName = "7",
                    ModelId = 55,
                    Year = 2007,
                    Color = CarColor.Gray,
                    EngineTypeId = 4,
                    TransmissionTypeId = 1,
                    FuelTypeId = 2,
                    BodyTypeId = 6,
                    Mileage = 82000,
                    Price = 35000,
                    NumberOfDoors = CarDoors.Three,
                    NumberOfSeats = 2,
                    VIN = "6923104578",
                    Description = "Uvoz iz Nemacke! Vozilo iz uvoza, kupljeno od prvog vlasnika. Redovno održavano u ovlašćenom servisu (original servisna knjižica ili elektronska servisna istorija dostupna na uvid ). Vozilo je pregledano od strane kompanije SGS-a ili Dekre i nema nikakvih nedostataka ili dodatnih troškova nakon kupovine, osim registracije čije troškove snosi kupac.",
                    ImageUrl = "/images/car/Porsche Boxster.jpg",
                    Status = CarStatus.Active
                },

                new CarListing
                {
                    CarId = 56,
                    UserId = "3",
                    BrandName = "7",
                    ModelId = 56,
                    Year = 1987,
                    Color = CarColor.Red,
                    EngineTypeId = 1,
                    TransmissionTypeId = 1,
                    FuelTypeId = 1,
                    BodyTypeId = 4,
                    Mileage = 150000,
                    Price = 13500,
                    NumberOfDoors = CarDoors.Three,
                    NumberOfSeats = 4,
                    VIN = "6923104579",
                    Description = "U odličnom stanju zadnjih 10 godina se ne vozi garažiran. Cena nije fiksna. S motor 190 ks nova tabla klima. Električna sedišta sa grejačima, multimedija, alarm, daljensko zaključavanje.",
                    ImageUrl = "/images/car/Porsche 944.jpg",
                    Status = CarStatus.Active
                },

                new CarListing
                {
                    CarId = 57,
                    UserId = "2",
                    BrandName = "8",
                    ModelId = 57,
                    Year = 2023,
                    Color = CarColor.Gray,
                    EngineTypeId = 6,
                    TransmissionTypeId = 1,
                    FuelTypeId = 2,
                    BodyTypeId = 3,
                    Mileage = 400,
                    Price = 32000,
                    NumberOfDoors = CarDoors.Five,
                    NumberOfSeats = 5,
                    VIN = "7230518392",
                    Description = "Polovno vozilo kupljeno u salonu Jevtović Auto pre dva meseca.",
                    ImageUrl = "/images/car/Renault Austral.jpg",
                    Status = CarStatus.Active
                },

                new CarListing
                {
                    CarId = 58,
                    UserId = "1",
                    BrandName = "8",
                    ModelId = 58,
                    Year = 2020,
                    Color = CarColor.White,
                    EngineTypeId = 6,
                    TransmissionTypeId = 1,
                    FuelTypeId = 2,
                    BodyTypeId = 2,
                    Mileage = 15135,
                    Price = 11950,
                    NumberOfDoors = CarDoors.Five,
                    NumberOfSeats = 5,
                    VIN = "7230518393",
                    Description = "Auto kupljen nov u Srbiji, bez udesa i kvarova. Ima servisnu knjižicu, ECC sertifikat. Ima funciju povezivosti na Android Auto i Apple CarPlay, ESM sistem. Mali servis uradjen.",
                    ImageUrl = "/images/car/Renault Clio.jpg",
                    Status = CarStatus.Active
                },

                new CarListing
                {
                    CarId = 59,
                    UserId = "3",
                    BrandName = "8",
                    ModelId = 59,
                    Year = 1991,
                    EngineTypeId = 2,
                    Color = CarColor.Other,
                    TransmissionTypeId = 1,
                    FuelTypeId = 1,
                    BodyTypeId = 7,
                    Mileage = 250000,
                    Price = 400,
                    NumberOfDoors = CarDoors.Three,
                    NumberOfSeats = 5,
                    VIN = "7230518394",
                    Description = "Nema klimu. Nije oštećen.",
                    ImageUrl = "/images/car/Renault Express.jpg",
                    Status = CarStatus.Active
                },

                new CarListing
                {
                    CarId = 60,
                    UserId = "4",
                    BrandName = "8",
                    ModelId = 60,
                    Year = 2014,
                    Color = CarColor.Gray,
                    EngineTypeId = 5,
                    TransmissionTypeId = 1,
                    FuelTypeId = 2,
                    BodyTypeId = 1,
                    Mileage = 296763,
                    Price = 6100,
                    NumberOfDoors = CarDoors.Five,
                    NumberOfSeats = 5,
                    VIN = "7230518395",
                    Description = "Redovno održavan, korišćen uglavnom za duga putovanja. Postoje sitna oštećenja na limariji od gradske vožnje, ništa ekstremno. Mehanički je auto ispravan, atest nije produžen, dokunentacija je skroz uredna ali nisam imao slobodnog vremena pa se to odlagalo. Nepušački auto, dva seta guma. Letnje 16 inča, gume zrele za zamenu, zimske su dobre i na čeličnim su felnama. Nije lupan auto. Ne troši ulje, motor je perfektan. Registracija ističe kraj četvrtog meseca.",
                    ImageUrl = "/images/car/Renault Fluence.jpg",
                    Status = CarStatus.Active
                },

                new CarListing
                {
                    CarId = 61,
                    UserId = "5",
                    BrandName = "8",
                    ModelId = 61,
                    Year = 2018,
                    Color = CarColor.Gray,
                    EngineTypeId = 6,
                    TransmissionTypeId = 2,
                    FuelTypeId = 2,
                    BodyTypeId = 3,
                    Mileage = 96532,
                    Price = 20000,
                    NumberOfDoors = CarDoors.Five,
                    NumberOfSeats = 5,
                    VIN = "7230518396",
                    Description = "Održavan isključivo u ovlašćenom Renault servisu, servisna knjiga plus elektronski listing održavanja.",
                    ImageUrl = "/images/car/Renault Kadjar.jpg",
                    Status = CarStatus.Active
                },

                new CarListing
                {
                    CarId = 62,
                    UserId = "6",
                    BrandName = "8",
                    ModelId = 62,
                    Year = 2019,
                    Color = CarColor.Gray,
                    EngineTypeId = 6,
                    TransmissionTypeId = 1,
                    FuelTypeId = 2,
                    BodyTypeId = 2,
                    Mileage = 58504,
                    Price = 11990,
                    NumberOfDoors = CarDoors.Five,
                    NumberOfSeats = 5,
                    VIN = "7230518397",
                    Description = "VOZILO KUPLJENO NOVO U SRBIJI. ODRŽAVANO U OVLAŠĆENOM SERVISU.",
                    ImageUrl = "/images/car/Renault Megane.jpg",
                    Status = CarStatus.Active
                },

                new CarListing
                {
                    CarId = 63,
                    UserId = "7",
                    BrandName = "8",
                    ModelId = 63,
                    Year = 2011,
                    Color = CarColor.Green,
                    EngineTypeId = 4,
                    TransmissionTypeId = 1,
                    FuelTypeId = 2,
                    BodyTypeId = 2,
                    Mileage = 171400,
                    Price = 3790,
                    NumberOfDoors = CarDoors.Five,
                    NumberOfSeats = 5,
                    VIN = "7230518398",
                    Description = "Vozilo je u dobrom stanju, nema limarskih oštećenja. Urađen veliki servis i redovan servis u aprilu 2023 godine, kvačilo je promenjeno u novembru 2023 godine.",
                    ImageUrl = "/images/car/Renault Modus.jpg",
                    Status = CarStatus.Active
                },

                new CarListing
                {
                    CarId = 64,
                    UserId = "8",
                    BrandName = "8",
                    ModelId = 64,
                    Year = 2016,
                    Color = CarColor.Orange,
                    EngineTypeId = 6,
                    TransmissionTypeId = 1,
                    FuelTypeId = 2,
                    BodyTypeId = 2,
                    Mileage = 180000,
                    Price = 6999,
                    NumberOfDoors = CarDoors.Five,
                    NumberOfSeats = 4,
                    VIN = "7230518399",
                    Description = "Automobil u perfektnom stanju,bez ostecenja na unutrasnjost i spoljasnost vozila. Mehanicki u potpunosti ispravan i ne zahteva nikakva ulaganja. Četiri odlicne zimske gume.",
                    ImageUrl = "/images/car/Renault Twingo.jpg",
                    Status = CarStatus.Active
                },

                new CarListing
                {
                    CarId = 65,
                    UserId = "9",
                    BrandName = "9",
                    ModelId = 65,
                    Year = 2014,
                    Color = CarColor.Black,
                    EngineTypeId = 6,
                    TransmissionTypeId = 2,
                    FuelTypeId = 3,
                    BodyTypeId = 1,
                    Mileage = 179000,
                    Price = 25999,
                    NumberOfDoors = CarDoors.Five,
                    NumberOfSeats = 5,
                    VIN = "8103644572",
                    Description = "Auto je kupljeno u Tesla Norge, auto je bio na detaljnoj proveri pre prodaje, sto posedujem dokumentaciju. Domet baterije je oko 400km. Automobil je u savrsenom stanju, slike pri kupovini.",
                    ImageUrl = "/images/car/Tesla Model S.jpg",
                    Status = CarStatus.Active
                },

                new CarListing
                {
                    CarId = 66,
                    UserId = "10",
                    BrandName = "9",
                    ModelId = 66,
                    Year = 2021,
                    Color = CarColor.Blue,
                    EngineTypeId = 6,
                    TransmissionTypeId = 2,
                    FuelTypeId = 3,
                    BodyTypeId = 2,
                    Mileage = 74000,
                    Price = 39900,
                    NumberOfDoors = CarDoors.Five,
                    NumberOfSeats = 5,
                    VIN = "8103644573",
                    Description = "Простран и веома безбедан, са високим фокусом на безбедност, модел 3 је практично без дугмади, где се већина функција аутомобила контролише са централно постављеног екрана од 15 инча. Пуноправна самовозећа седишта чине аутомобил подељен на самовозећи уз помоћ 8 камера, дванаест сензора и 1 радара. Има јединствен домет од 620 км (ВЛПТ), убрзање од 0-100 за 4,4 секунде и максималну брзину од 233 км/х, тако да може да иде брзо.",
                    ImageUrl = "/images/car/Tesla Model 3.jpg",
                    Status = CarStatus.Active
                },

                new CarListing
                {
                    CarId = 67,
                    UserId = "1",
                    BrandName = "9",
                    ModelId = 67,
                    Year = 2022,
                    Color = CarColor.Red,
                    EngineTypeId = 6,
                    TransmissionTypeId = 2,
                    FuelTypeId = 3,
                    BodyTypeId = 3,
                    Mileage = 11841,
                    Price = 53000,
                    NumberOfDoors = CarDoors.Five,
                    NumberOfSeats = 5,
                    VIN = "8103644574",
                    Description = "Nov auto, kupljen od prvog vlasnika u Nemačkoj. Svaka vrsta provere od strane kupca je moguća.",
                    ImageUrl = "/images/car/Tesla Model Y.jpg",
                    Status = CarStatus.Active
                },

                new CarListing
                {
                    CarId = 68,
                    UserId = "2",
                    BrandName = "9",
                    ModelId = 68,
                    Year = 2019,
                    Color = CarColor.Blue,
                    EngineTypeId = 6,
                    TransmissionTypeId = 2,
                    FuelTypeId = 3,
                    BodyTypeId = 3,
                    Mileage = 63000,
                    Price = 60000,
                    NumberOfDoors = CarDoors.Five,
                    NumberOfSeats = 6,
                    VIN = "8103644575",
                    Description = "SNAGA 525 KS. RANGE (DOMET BATERIJE) 405 KM.",
                    ImageUrl = "/images/car/Tesla Model X.jpg",
                    Status = CarStatus.Active
                }
            );
        }
    }
}
