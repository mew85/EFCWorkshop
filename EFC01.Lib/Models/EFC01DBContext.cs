using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EFC01.Lib.Models
{
    public partial class EFC01DBContext : DbContext
    {
        public EFC01DBContext()
        {
        }

        public EFC01DBContext(DbContextOptions<EFC01DBContext> options)
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
                optionsBuilder.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
                //optionsBuilder.EnableSensitiveDataLogging();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Testdaten_EFC01.TestdatenGenerierung_Abteilung(modelBuilder);
            Testdaten_EFC01.TestdatenGenerierung_Funktion(modelBuilder);
            Testdaten_EFC01.TestdatenGenerierung_Niederlassung(modelBuilder);
            Testdaten_EFC01.TestdatenGenerierung_Mitarbeiter(modelBuilder);
        }
    }
}
