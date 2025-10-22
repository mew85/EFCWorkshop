using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
            => optionsBuilder.UseSqlServer("data source=FEBRUAR;initial catalog=EFC01;Integrated Security=true;TrustServerCertificate=Yes;Encrypt=False;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { }
    }
}
