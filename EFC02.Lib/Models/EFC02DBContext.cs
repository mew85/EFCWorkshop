using EFCTest02.Lib.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace EFC02.Lib.Models
{
    public partial class EFC02DBContext : DbContext
    {
        public EFC02DBContext()
        {
        }

        public EFC02DBContext(DbContextOptions<EFC02DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Abteilung> AbteilungListe { get; set; }

        public virtual DbSet<Funktion> FunktionListe { get; set; }

        public virtual DbSet<Mitarbeiter> MitarbeiterListe { get; set; }

        public virtual DbSet<Niederlassung> NiederlassungListe { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
            //=> optionsBuilder.UseSqlServer("data source=SQL-SRV1;initial catalog=EFC01;Integrated Security=true;TrustServerCertificate=Yes;Encrypt=False;");

            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();

            var connectionString = config.GetConnectionString("DBConnectionString");
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectionString);
                //auch beim updaten der DB wird mit dem LogTo() sehr ausführlich geloggtt
                optionsBuilder.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
                //optionsBuilder.EnableSensitiveDataLogging();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            NiederlassungMapping(modelBuilder);
            MitarbeiterMapping(modelBuilder);

            Testdaten_EFC02.TestdatenGenerierung_Abteilung(modelBuilder);
            Testdaten_EFC02.TestdatenGenerierung_Funktion(modelBuilder);
            Testdaten_EFC02.TestdatenGenerierung_Niederlassung2(modelBuilder);
            Testdaten_EFC02.TestdatenGenerierung_Mitarbeiter(modelBuilder);
        }

        #region ModelCustomization
        private  void NiederlassungMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Niederlassung>().ToTable(@"niederlassung", @"dbo");
            modelBuilder.Entity<Niederlassung>().Property(x => x.NiederlassungId).HasColumnName(@"NiederlassungId").HasColumnType(@"int").IsRequired().ValueGeneratedOnAdd().HasPrecision(10, 0);
            modelBuilder.Entity<Niederlassung>().Property(x => x.Niederlassungsbezeichnung).HasColumnName(@"Niederlassungsbezeichnung").HasColumnType(@"nvarchar(50)").IsRequired().ValueGeneratedNever().HasMaxLength(50);
            modelBuilder.Entity<Niederlassung>().Property(x => x.Niederlassungsvorwahl).HasColumnName(@"Niederlassungsvorwahl").HasColumnType(@"nvarchar(50)").ValueGeneratedNever().HasMaxLength(50);
            modelBuilder.Entity<Niederlassung>().Property(x => x.AngelegtAm).HasColumnName(@"AngelegtAm").HasColumnType(@"datetime2").IsRequired().ValueGeneratedOnAdd().HasDefaultValueSql(@"getdate()");
            modelBuilder.Entity<Niederlassung>().Property(x => x.GeaendertAm).HasColumnName(@"GeaendertAm").HasColumnType(@"datetime2").ValueGeneratedNever();
            modelBuilder.Entity<Niederlassung>().Property(x => x.AngelegtVon).HasColumnName(@"AngelegtVon").HasColumnType(@"nvarchar(50)").IsRequired().ValueGeneratedOnAdd().HasMaxLength(50).HasDefaultValueSql(@"suser_sname()");
            modelBuilder.Entity<Niederlassung>().Property(x => x.GeaendertVon).HasColumnName(@"GeaendertVon").HasColumnType(@"nvarchar(50)").ValueGeneratedNever().HasMaxLength(50);
            modelBuilder.Entity<Niederlassung>().Property(x => x.IstAktiv).HasColumnName(@"IstAktiv").HasColumnType(@"bit").IsRequired().ValueGeneratedNever().HasDefaultValueSql(@"1");
            modelBuilder.Entity<Niederlassung>().Property(x => x.IstGeloescht).HasColumnName(@"IstGeloescht").HasColumnType(@"bit").IsRequired().ValueGeneratedNever().HasDefaultValueSql(@"0");
            modelBuilder.Entity<Niederlassung>().HasKey(@"NiederlassungId");
            modelBuilder.Entity<Niederlassung>().HasIndex(@"Niederlassungsbezeichnung").IsUnique(true);
        }

        private void MitarbeiterMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Mitarbeiter>().ToTable(@"mitarbeiter", @"dbo");
            modelBuilder.Entity<Mitarbeiter>()
                .Property(x => x.Geschlecht)
                .HasColumnName(@"Geschlecht")
                .HasMaxLength(1)
                .HasColumnType(@"varchar(1)")
                .IsUnicode(false)
                .IsRequired()
                .HasConversion(x => x.ToString(), x => (eGeschlecht)Enum.Parse(typeof(eGeschlecht), x));
        }
        #endregion
    }
}
