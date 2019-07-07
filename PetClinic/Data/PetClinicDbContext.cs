using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PetClinic.Models;
using System;
using System.Collections.Generic;

namespace PetClinic.Data
{
    public class PetClinicDbContext : DbContext
    {
        public PetClinicDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Owner> Owners { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Specialty> Specialties { get; set; }
        public DbSet<Vet> Vets { get; set; }
        public DbSet<Visit> Visits { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Owner>(b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<string>("FirstName").IsRequired().HasMaxLength(256);
                b.Property<string>("LastName").IsRequired().HasMaxLength(256);
                b.Property<string>("Address").IsRequired().HasMaxLength(256);
                b.Property<string>("City").IsRequired().HasMaxLength(256);
                b.Property<string>("Telephone").IsRequired().HasMaxLength(20);

                b.HasKey("Id");

                b.ToTable("Owners");
            });

            modelBuilder.Entity<Pet>(b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<string>("Name").IsRequired().HasMaxLength(256);
                b.Property<DateTime>("BirthDate").IsRequired();
                b.Property<int>("OwnerId").IsRequired();
                b.Property<PetType>("Type").IsRequired();

                b.HasKey("Id");

                b.HasIndex("OwnerId");

                b.HasOne("PetClinic.Models.Owner", "Owner")
                    .WithMany("Pets")
                    .HasForeignKey("OwnerId")
                    .OnDelete(DeleteBehavior.Cascade);

                b.ToTable("Pets");
            });

            modelBuilder.Entity<Specialty>(b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<string>("Name").IsRequired().HasMaxLength(256);

                b.HasKey("Id");

                b.ToTable("Specialties");
            });

            modelBuilder.Entity<Vet>(b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<string>("FirstName").IsRequired().HasMaxLength(256);
                b.Property<string>("LastName").IsRequired().HasMaxLength(256);

                b.HasKey("Id");

                b.ToTable("Vets");
            });

            modelBuilder.Entity<VetSpecialty>(b =>
            {
                b.Property<int>("VetId").IsRequired();
                b.Property<int>("SpecialtyId").IsRequired();

                b.HasOne("PetClinic.Models.Specialty", "Specialty")
                    .WithMany("VetSpecialties")
                    .HasForeignKey("SpecialtyId")
                    .OnDelete(DeleteBehavior.Cascade);

                b.HasOne("PetClinic.Models.Vet", "Vet")
                    .WithMany("Specialties")
                    .HasForeignKey("VetId")
                    .OnDelete(DeleteBehavior.Cascade);

                b.HasKey("VetId", "SpecialtyId");

                b.ToTable("VetSpecialties");
            });

            modelBuilder.Entity<Visit>(b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<DateTime>("Date").IsRequired();
                b.Property<string>("Notes").IsRequired().HasMaxLength(256);
                b.Property<int>("PetId").IsRequired();
                b.Property<int>("VetId").IsRequired();

                b.HasOne("PetClinic.Models.Pet", "Pet")
                    .WithMany("Visits")
                    .HasForeignKey("PetId")
                    .OnDelete(DeleteBehavior.Cascade);

                b.HasOne("PetClinic.Models.Vet", "AssignedVet")
                    .WithMany("Visits")
                    .HasForeignKey("VetId")
                    .OnDelete(DeleteBehavior.Cascade);

                b.HasKey("Id");

                b.HasIndex("PetId");
                b.HasIndex("VetId");

                b.ToTable("Visits");
            });

            #region Data Generation

            modelBuilder.Entity<Owner>().HasData(
                new Owner { Id = 1, FirstName = "Pren", LastName = "Handsheart", Address = "901 Messerschmidt Circle", City = "Katwijk", Telephone = "696-166-9385" },
                new Owner { Id = 2, FirstName = "Heinrick", LastName = "Vanyatin", Address = "909 Evergreen Trail", City = "Hatton", Telephone = "832-116-9214" },
                new Owner { Id = 3, FirstName = "Ivie", LastName = "Casterton", Address = "81 Canary Hill", City = "Guangfu", Telephone = "922-605-4531" },
                new Owner { Id = 4, FirstName = "Gillian", LastName = "Bissex", Address = "784 Everett Circle", City = "Waingapu", Telephone = "312-263-8087" },
                new Owner { Id = 5, FirstName = "Pru", LastName = "Geraudy", Address = "54695 Farmco Road", City = "Xinzhuang", Telephone = "583-126-3845" },
                new Owner { Id = 6, FirstName = "Garry", LastName = "Sulley", Address = "8541 Haas Park", City = "Stěžery", Telephone = "737-234-1982" },
                new Owner { Id = 7, FirstName = "Allyn", LastName = "McRannell", Address = "99708 Onsgard Drive", City = "Tucuran", Telephone = "448-570-8995" },
                new Owner { Id = 8, FirstName = "Dugald", LastName = "Vivyan", Address = "10117 Grasskamp Lane", City = "Benito Juarez", Telephone = "327-144-9061" },
                new Owner { Id = 9, FirstName = "Christiano", LastName = "Volkes", Address = "23 Northfield Crossing", City = "Araruama", Telephone = "592-655-7603" },
                new Owner { Id = 10, FirstName = "Horatia", LastName = "Tobin", Address = "3027 Monterey Court", City = "Samdo", Telephone = "268-859-3203" },
                new Owner { Id = 11, FirstName = "Vitia", LastName = "Copins", Address = "7 Heffernan Pass", City = "Angono", Telephone = "305-416-2369" },
                new Owner { Id = 12, FirstName = "Agata", LastName = "Sleith", Address = "1 Clarendon Road", City = "Beskolen", Telephone = "663-555-7609" },
                new Owner { Id = 13, FirstName = "Georgeanne", LastName = "Conachy", Address = "68701 Anderson Crossing", City = "Kingsport", Telephone = "423-820-4682" },
                new Owner { Id = 14, FirstName = "Lenora", LastName = "Euesden", Address = "315 Hansons Circle", City = "Philadelphia", Telephone = "610-294-5983" },
                new Owner { Id = 15, FirstName = "Bonni", LastName = "Aspland", Address = "756 Forest Run Road", City = "Opatów", Telephone = "836-500-7512" },
                new Owner { Id = 16, FirstName = "Gael", LastName = "McCuaig", Address = "48 Cottonwood Trail", City = "Pragen Selatan", Telephone = "533-212-7915" },
                new Owner { Id = 17, FirstName = "Anatola", LastName = "Ashdown", Address = "16347 Dapin Drive", City = "Ruzhany", Telephone = "709-337-1856" },
                new Owner { Id = 18, FirstName = "Maritsa", LastName = "Kimber", Address = "9287 Schlimgen Lane", City = "Dalovice", Telephone = "515-695-3036" },
                new Owner { Id = 19, FirstName = "Lorilee", LastName = "Frensche", Address = "729 Glendale Court", City = "San Juan", Telephone = "152-194-4906" },
                new Owner { Id = 20, FirstName = "Merola", LastName = "Impey", Address = "98 Melrose Terrace", City = "Uralo-Kavkaz", Telephone = "663-393-2782" },
                new Owner { Id = 21, FirstName = "Mendy", LastName = "Reville", Address = "28 Sundown Hill", City = "Smokvica", Telephone = "550-121-5868" },
                new Owner { Id = 22, FirstName = "Raymond", LastName = "Darlison", Address = "2 Waubesa Circle", City = "Seattle", Telephone = "253-838-1723" },
                new Owner { Id = 23, FirstName = "Tyrus", LastName = "Dumingo", Address = "101 Scoville Avenue", City = "Hongkou", Telephone = "423-329-2153" },
                new Owner { Id = 24, FirstName = "Riannon", LastName = "Heigold", Address = "278 Lake View Trail", City = "Les Abymes", Telephone = "628-704-9463" },
                new Owner { Id = 25, FirstName = "Flin", LastName = "Witherup", Address = "538 Loomis Circle", City = "Nueva Loja", Telephone = "664-206-1619" },
                new Owner { Id = 26, FirstName = "Mateo", LastName = "Schumacher", Address = "62 Parkside Alley", City = "Herceg-Novi", Telephone = "386-444-3002" },
                new Owner { Id = 27, FirstName = "Marthe", LastName = "Bollen", Address = "164 Meadow Valley Street", City = "Fudian", Telephone = "665-819-7193" },
                new Owner { Id = 28, FirstName = "Seumas", LastName = "Indruch", Address = "1854 Declaration Street", City = "Bambakashat", Telephone = "325-590-1515" },
                new Owner { Id = 29, FirstName = "Kenneth", LastName = "Gason", Address = "0 Farragut Street", City = "Pameungpeuk", Telephone = "238-235-9796" },
                new Owner { Id = 30, FirstName = "Kurt", LastName = "Bagwell", Address = "4586 Shelley Street", City = "Ratíškovice", Telephone = "512-185-9090" },
                new Owner { Id = 31, FirstName = "Alf", LastName = "Travis", Address = "59303 Fallview Road", City = "Kawakawa", Telephone = "655-453-5195" },
                new Owner { Id = 32, FirstName = "Stanislas", LastName = "Swadlin", Address = "767 Golf Center", City = "Kaburon", Telephone = "649-852-8037" },
                new Owner { Id = 33, FirstName = "Kerrill", LastName = "Brokenshaw", Address = "11894 Starling Point", City = "Gusinoozyorsk", Telephone = "395-777-1951" },
                new Owner { Id = 34, FirstName = "Holly-anne", LastName = "Whitley", Address = "1 Bay Drive", City = "Tamanan", Telephone = "625-587-0047" },
                new Owner { Id = 35, FirstName = "Elmore", LastName = "Doley", Address = "84285 Loeprich Park", City = "Lasi Dua", Telephone = "761-532-2032" },
                new Owner { Id = 36, FirstName = "Farly", LastName = "Thurley", Address = "51910 Monterey Drive", City = "Kommunisticheskiy", Telephone = "195-822-2832" },
                new Owner { Id = 37, FirstName = "Stephi", LastName = "Shellibeer", Address = "201 Stang Court", City = "Safotu", Telephone = "201-201-0649" },
                new Owner { Id = 38, FirstName = "Mortie", LastName = "Gypps", Address = "6 Superior Terrace", City = "Dayou", Telephone = "134-686-0873" },
                new Owner { Id = 39, FirstName = "Petey", LastName = "Apthorpe", Address = "5 Hagan Avenue", City = "Trzebieszów", Telephone = "227-148-6992" },
                new Owner { Id = 40, FirstName = "Hyacinthe", LastName = "Chidler", Address = "19 Declaration Hill", City = "Sanhui", Telephone = "873-931-9819" },
                new Owner { Id = 41, FirstName = "Mellicent", LastName = "de Nore", Address = "8 Boyd Court", City = "Ulyanovsk", Telephone = "770-120-0778" },
                new Owner { Id = 42, FirstName = "Karney", LastName = "Botton", Address = "4626 Northport Avenue", City = "Irbid", Telephone = "106-322-9032" },
                new Owner { Id = 43, FirstName = "Johanna", LastName = "Seabrooke", Address = "67289 Mesta Hill", City = "Gaotieling", Telephone = "991-485-2169" }
            );

            modelBuilder.Entity<Specialty>().HasData(
                new Specialty { Id = 1, Name = "Radiology" },
                new Specialty { Id = 2, Name = "Surgery" },
                new Specialty { Id = 3, Name = "Dentistry" }
            );

            modelBuilder.Entity<Vet>().HasData(
                new Vet { Id = 1, FirstName = "Jacintha", LastName = "Runham" },
                new Vet { Id = 2, FirstName = "Tadeas", LastName = "Rockcliff" },
                new Vet { Id = 3, FirstName = "Urbain", LastName = "Wasson" },
                new Vet { Id = 4, FirstName = "Milton", LastName = "Branson" },
                new Vet { Id = 5, FirstName = "Hildagard", LastName = "Lintot" },
                new Vet { Id = 6, FirstName = "Aristotle", LastName = "Blyde" },
                new Vet { Id = 7, FirstName = "Jacquenetta", LastName = "Aleksidze" },
                new Vet { Id = 8, FirstName = "Viviana", LastName = "Storre" },
                new Vet { Id = 9, FirstName = "Kali", LastName = "Kennet" },
                new Vet { Id = 10, FirstName = "Alick", LastName = "Ornils" },
                new Vet { Id = 11, FirstName = "Robin", LastName = "Form" },
                new Vet { Id = 12, FirstName = "Petronille", LastName = "Montfort" },
                new Vet { Id = 13, FirstName = "Beverlie", LastName = "Meaking" },
                new Vet { Id = 14, FirstName = "Barnett", LastName = "Simpole" },
                new Vet { Id = 15, FirstName = "Dougy", LastName = "Orteu" },
                new Vet { Id = 16, FirstName = "Tallie", LastName = "Fanstone" },
                new Vet { Id = 17, FirstName = "Chico", LastName = "Aslie" },
                new Vet { Id = 18, FirstName = "Lauren", LastName = "Dibley" },
                new Vet { Id = 19, FirstName = "Reginauld", LastName = "Gercken" },
                new Vet { Id = 20, FirstName = "Dayle", LastName = "MacGiffin" },
                new Vet { Id = 21, FirstName = "Maren", LastName = "Degoey" },
                new Vet { Id = 22, FirstName = "Em", LastName = "D'Angeli" },
                new Vet { Id = 23, FirstName = "Devlin", LastName = "Tompkins" },
                new Vet { Id = 24, FirstName = "Rubetta", LastName = "Syder" },
                new Vet { Id = 25, FirstName = "Olive", LastName = "Laffoley-Lane" },
                new Vet { Id = 26, FirstName = "Markus", LastName = "Lydster" },
                new Vet { Id = 27, FirstName = "Ritchie", LastName = "Girardey" },
                new Vet { Id = 28, FirstName = "Goldarina", LastName = "Greensides" },
                new Vet { Id = 29, FirstName = "Jonell", LastName = "Earland" },
                new Vet { Id = 30, FirstName = "Chiquita", LastName = "Spandley" }
            );

            modelBuilder.Entity<VetSpecialty>().HasData(
                new VetSpecialty { VetId = 1, SpecialtyId = 3 },
                new VetSpecialty { VetId = 2, SpecialtyId = 3 },
                new VetSpecialty { VetId = 3, SpecialtyId = 1 },
                new VetSpecialty { VetId = 4, SpecialtyId = 2 },
                new VetSpecialty { VetId = 5, SpecialtyId = 3 },
                new VetSpecialty { VetId = 6, SpecialtyId = 1 },
                new VetSpecialty { VetId = 7, SpecialtyId = 2 },
                new VetSpecialty { VetId = 8, SpecialtyId = 3 },
                new VetSpecialty { VetId = 9, SpecialtyId = 2 },
                new VetSpecialty { VetId = 10, SpecialtyId = 3 },
                new VetSpecialty { VetId = 11, SpecialtyId = 1 },
                new VetSpecialty { VetId = 12, SpecialtyId = 1 },
                new VetSpecialty { VetId = 13, SpecialtyId = 1 },
                new VetSpecialty { VetId = 14, SpecialtyId = 1 },
                new VetSpecialty { VetId = 15, SpecialtyId = 1 },
                new VetSpecialty { VetId = 16, SpecialtyId = 2 },
                new VetSpecialty { VetId = 17, SpecialtyId = 2 },
                new VetSpecialty { VetId = 18, SpecialtyId = 3 },
                new VetSpecialty { VetId = 19, SpecialtyId = 1 },
                new VetSpecialty { VetId = 20, SpecialtyId = 3 },
                new VetSpecialty { VetId = 21, SpecialtyId = 1 },
                new VetSpecialty { VetId = 22, SpecialtyId = 2 },
                new VetSpecialty { VetId = 23, SpecialtyId = 2 },
                new VetSpecialty { VetId = 24, SpecialtyId = 3 },
                new VetSpecialty { VetId = 25, SpecialtyId = 3 },
                new VetSpecialty { VetId = 26, SpecialtyId = 2 },
                new VetSpecialty { VetId = 27, SpecialtyId = 1 },
                new VetSpecialty { VetId = 28, SpecialtyId = 2 },
                new VetSpecialty { VetId = 29, SpecialtyId = 1 },
                new VetSpecialty { VetId = 30, SpecialtyId = 1 }
            );

            modelBuilder.Entity<Pet>().HasData(
                new Pet { Id = 1, Name = "Inessa", BirthDate = DateTime.Parse("2001/12/02"), Type = PetType.Bird, OwnerId = 10 },
                new Pet { Id = 2, Name = "Ulrika", BirthDate = DateTime.Parse("2012/09/26"), Type = PetType.Dog, OwnerId = 36 },
                new Pet { Id = 3, Name = "Babita", BirthDate = DateTime.Parse("2018/06/30"), Type = PetType.Dog, OwnerId = 26 },
                new Pet { Id = 4, Name = "Cloris", BirthDate = DateTime.Parse("2002/01/02"), Type = PetType.Lizard, OwnerId = 28 },
                new Pet { Id = 5, Name = "Charla", BirthDate = DateTime.Parse("2004/10/23"), Type = PetType.Bird, OwnerId = 35 },
                new Pet { Id = 6, Name = "Jeanna", BirthDate = DateTime.Parse("2015/01/28"), Type = PetType.Bird, OwnerId = 5 },
                new Pet { Id = 7, Name = "Haley", BirthDate = DateTime.Parse("2013/02/01"), Type = PetType.Hamster, OwnerId = 41 },
                new Pet { Id = 8, Name = "Lucie", BirthDate = DateTime.Parse("2011/08/24"), Type = PetType.Snake, OwnerId = 41 },
                new Pet { Id = 9, Name = "Gunner", BirthDate = DateTime.Parse("2016/10/18"), Type = PetType.Hamster, OwnerId = 24 },
                new Pet { Id = 10, Name = "Paten", BirthDate = DateTime.Parse("2012/10/04"), Type = PetType.Lizard, OwnerId = 18 },
                new Pet { Id = 11, Name = "Adrian", BirthDate = DateTime.Parse("2006/04/17"), Type = PetType.Cat, OwnerId = 10 },
                new Pet { Id = 12, Name = "Abbot", BirthDate = DateTime.Parse("2010/05/01"), Type = PetType.Lizard, OwnerId = 10 },
                new Pet { Id = 13, Name = "Shelagh", BirthDate = DateTime.Parse("2013/06/19"), Type = PetType.Cat, OwnerId = 9 },
                new Pet { Id = 14, Name = "Briant", BirthDate = DateTime.Parse("2006/12/21"), Type = PetType.Hamster, OwnerId = 5 },
                new Pet { Id = 15, Name = "Clo", BirthDate = DateTime.Parse("2014/02/13"), Type = PetType.Dog, OwnerId = 38 },
                new Pet { Id = 16, Name = "Franny", BirthDate = DateTime.Parse("2016/01/18"), Type = PetType.Cat, OwnerId = 37 },
                new Pet { Id = 17, Name = "Kylie", BirthDate = DateTime.Parse("2006/05/17"), Type = PetType.Lizard, OwnerId = 27 },
                new Pet { Id = 18, Name = "Niccolo", BirthDate = DateTime.Parse("2004/07/15"), Type = PetType.Cat, OwnerId = 29 },
                new Pet { Id = 19, Name = "Charo", BirthDate = DateTime.Parse("2007/12/20"), Type = PetType.Lizard, OwnerId = 26 },
                new Pet { Id = 20, Name = "Abelard", BirthDate = DateTime.Parse("2015/02/03"), Type = PetType.Bird, OwnerId = 40 },
                new Pet { Id = 21, Name = "Hillyer", BirthDate = DateTime.Parse("2013/08/02"), Type = PetType.Cat, OwnerId = 38 },
                new Pet { Id = 22, Name = "Roma", BirthDate = DateTime.Parse("2014/11/08"), Type = PetType.Snake, OwnerId = 37 },
                new Pet { Id = 23, Name = "Edithe", BirthDate = DateTime.Parse("2018/08/12"), Type = PetType.Cat, OwnerId = 14 },
                new Pet { Id = 24, Name = "Celinda", BirthDate = DateTime.Parse("2008/02/09"), Type = PetType.Dog, OwnerId = 27 },
                new Pet { Id = 25, Name = "Silvia", BirthDate = DateTime.Parse("2017/11/24"), Type = PetType.Cat, OwnerId = 22 },
                new Pet { Id = 26, Name = "Mattie", BirthDate = DateTime.Parse("2012/03/28"), Type = PetType.Snake, OwnerId = 10 },
                new Pet { Id = 27, Name = "Katherine", BirthDate = DateTime.Parse("2017/02/16"), Type = PetType.Snake, OwnerId = 10 },
                new Pet { Id = 28, Name = "Maryann", BirthDate = DateTime.Parse("2007/07/30"), Type = PetType.Cat, OwnerId = 20 },
                new Pet { Id = 29, Name = "Nikita", BirthDate = DateTime.Parse("2010/11/01"), Type = PetType.Snake, OwnerId = 12 },
                new Pet { Id = 30, Name = "Elke", BirthDate = DateTime.Parse("2017/08/12"), Type = PetType.Dog, OwnerId = 11 }
            );

            modelBuilder.Entity<Visit>().HasData(
                new Visit { Id = 1, Date = DateTime.Parse("2006/06/19"), Notes = "", PetId = 1, VetId = 18 },
                new Visit { Id = 2, Date = DateTime.Parse("2003/07/21"), Notes = "", PetId = 2, VetId = 5 },
                new Visit { Id = 3, Date = DateTime.Parse("2017/04/24"), Notes = "", PetId = 3, VetId = 16 },
                new Visit { Id = 4, Date = DateTime.Parse("2017/09/13"), Notes = "", PetId = 4, VetId = 10 },
                new Visit { Id = 5, Date = DateTime.Parse("2011/04/23"), Notes = "", PetId = 5, VetId = 3 },
                new Visit { Id = 6, Date = DateTime.Parse("2008/11/19"), Notes = "", PetId = 6, VetId = 1 },
                new Visit { Id = 7, Date = DateTime.Parse("2013/10/21"), Notes = "", PetId = 7, VetId = 11 },
                new Visit { Id = 8, Date = DateTime.Parse("2004/07/24"), Notes = "", PetId = 8, VetId = 11 },
                new Visit { Id = 9, Date = DateTime.Parse("2006/11/14"), Notes = "", PetId = 9, VetId = 24 },
                new Visit { Id = 10, Date = DateTime.Parse("2010/05/05"), Notes = "", PetId = 10, VetId = 13 },
                new Visit { Id = 11, Date = DateTime.Parse("2016/04/23"), Notes = "", PetId = 11, VetId = 8 },
                new Visit { Id = 12, Date = DateTime.Parse("2007/06/12"), Notes = "", PetId = 12, VetId = 27 },
                new Visit { Id = 13, Date = DateTime.Parse("2011/06/17"), Notes = "", PetId = 13, VetId = 29 },
                new Visit { Id = 14, Date = DateTime.Parse("2001/11/30"), Notes = "", PetId = 14, VetId = 23 },
                new Visit { Id = 15, Date = DateTime.Parse("2014/12/29"), Notes = "", PetId = 15, VetId = 30 },
                new Visit { Id = 16, Date = DateTime.Parse("2006/11/03"), Notes = "", PetId = 16, VetId = 28 },
                new Visit { Id = 17, Date = DateTime.Parse("2008/03/12"), Notes = "", PetId = 17, VetId = 3 },
                new Visit { Id = 18, Date = DateTime.Parse("2009/11/09"), Notes = "", PetId = 18, VetId = 21 },
                new Visit { Id = 19, Date = DateTime.Parse("2008/03/22"), Notes = "", PetId = 19, VetId = 15 },
                new Visit { Id = 20, Date = DateTime.Parse("2018/02/23"), Notes = "", PetId = 20, VetId = 15 },
                new Visit { Id = 21, Date = DateTime.Parse("2002/10/11"), Notes = "", PetId = 21, VetId = 9 },
                new Visit { Id = 22, Date = DateTime.Parse("2005/03/28"), Notes = "", PetId = 22, VetId = 6 },
                new Visit { Id = 23, Date = DateTime.Parse("2012/01/31"), Notes = "", PetId = 23, VetId = 11 },
                new Visit { Id = 24, Date = DateTime.Parse("2005/07/29"), Notes = "", PetId = 24, VetId = 2 },
                new Visit { Id = 25, Date = DateTime.Parse("2003/05/30"), Notes = "", PetId = 25, VetId = 18 },
                new Visit { Id = 26, Date = DateTime.Parse("2011/07/16"), Notes = "", PetId = 26, VetId = 10 },
                new Visit { Id = 27, Date = DateTime.Parse("2014/04/13"), Notes = "", PetId = 27, VetId = 15 },
                new Visit { Id = 28, Date = DateTime.Parse("2012/08/17"), Notes = "", PetId = 28, VetId = 12 },
                new Visit { Id = 29, Date = DateTime.Parse("2009/10/25"), Notes = "", PetId = 29, VetId = 24 },
                new Visit { Id = 30, Date = DateTime.Parse("2003/08/01"), Notes = "", PetId = 30, VetId = 28 }
            );

            #endregion Data Generation
        }
    }
}