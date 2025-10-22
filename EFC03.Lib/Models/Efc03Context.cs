using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace EFC03.Lib.Models;

public partial class Efc03Context : DbContext
{
    public Efc03Context()
    {
    }

    public Efc03Context(DbContextOptions<Efc03Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Abteilung> AbteilungsListe { get; set; }

    public virtual DbSet<Funktion> FunktionsListe { get; set; }

    public virtual DbSet<Mitarbeiter> MitarbeiterListe { get; set; }

    public virtual DbSet<Niederlassung> NiederlassungListe { get; set; }

    public virtual DbSet<Projekt> ProjektListe { get; set; }

    public virtual DbSet<Projektergebnis> Projektergebnis { get; set; }

    public virtual DbSet<Projektmitarbeiter> ProjektmitarbeiterListe { get; set; }

    public virtual DbSet<Projektstatus> ProjektstatusListe { get; set; }

    public virtual DbSet<Projekttyp> ProjekttypListe { get; set; }

    //public virtual DbSet<VMitarbeiterListeMitFunktionen> VMitarbeiterListeMitFunktionens { get; set; }

    // ------------------------------------------------------------------------------------------------------- >>>
    [DbFunction("udfBerechneAlter", "dbo")]
    public static int Alter(DateOnly? geburtsdatum)
        => throw new InvalidOperationException($"{nameof(Alter)} hat zu einem Fehler geführt");

    [DbFunction("udfBestimmeAnrede", "dbo")]
    public static string Anrede(string geschlecht)
        => throw new InvalidOperationException($"{nameof(Alter)} hat zu einem Fehler geführt");

    public virtual DbSet<AbteilungEmails> vAbteilungEMailListe { get; set; } //Name einer vorhandenen View

    public virtual DbSet<Projektentwicklung> udfProjektentwicklung { get; set; } //Name einer vorhandenen Tabellenwertfunktion

    public virtual DbSet<AbteilungEmails> uspAbteilungEMailListe { get; set; } //Name einer vorhandenen Stored-Procedure
    // <<< -------------------------------------------------------------------------------------------------------
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();

        var connectionString = config.GetConnectionString("DBConnectionString");
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(connectionString);
            //auch beim updaten der DB wird mit dem LogTo() sehr ausführlich geloggtt
            //optionsBuilder.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
            //optionsBuilder.EnableSensitiveDataLogging();
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Abteilung>(entity =>
        {
            entity.ToTable("abteilung");

            entity.HasIndex(e => e.Abteilungsbezeichnung, "IX_abteilung_abteilungsbezeichnung")
                .IsUnique()
                .HasFilter("([abteilungsbezeichnung] IS NOT NULL)");

            entity.Property(e => e.AbteilungId).HasColumnName("abteilungId");
            entity.Property(e => e.Abteilungsbezeichnung)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("abteilungsbezeichnung");
        });

        modelBuilder.Entity<Funktion>(entity =>
        {
            entity.ToTable("funktion");

            entity.Property(e => e.FunktionId).HasColumnName("funktionId");
            entity.Property(e => e.Funktionsbezeichnung)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("funktionsbezeichnung");
        });

        modelBuilder.Entity<Mitarbeiter>(entity =>
        {
            entity.ToTable("mitarbeiter");

            entity.HasIndex(e => e.AbteilungId, "IX_mitarbeiter_abteilungId");

            entity.HasIndex(e => e.FunktionId, "IX_mitarbeiter_funktionId");

            entity.HasIndex(e => e.NiederlassungId, "IX_mitarbeiter_niederlassungId");

            entity.Property(e => e.MitarbeiterId).HasColumnName("mitarbeiterId");
            entity.Property(e => e.AbteilungId)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("abteilungId");
            entity.Property(e => e.DatumAustritt)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("datum_austritt");
            entity.Property(e => e.DatumEintritt)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("datum_eintritt");
            entity.Property(e => e.Durchwahl)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("durchwahl");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("email");
            entity.Property(e => e.Extern)
                .HasDefaultValue(false)
                .HasColumnName("extern");
            entity.Property(e => e.FunktionId)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("funktionId");
            entity.Property(e => e.Geburtsdatum).HasColumnName("geburtsdatum");
            entity.Property(e => e.Geschlecht)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("geschlecht");
            entity.Property(e => e.Nachname)
                .HasMaxLength(50)
                .HasColumnName("nachname");
            entity.Property(e => e.NiederlassungId)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("niederlassungId");
            entity.Property(e => e.Prsnr)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("prsnr");
            entity.Property(e => e.Vorname)
                .HasMaxLength(50)
                .HasColumnName("vorname");

            entity.HasOne(d => d.Abteilung).WithMany(p => p.MitarbeiterListe).HasForeignKey(d => d.AbteilungId);

            entity.HasOne(d => d.Funktion).WithMany(p => p.MitarbeiterListe).HasForeignKey(d => d.FunktionId);

            entity.HasOne(d => d.Niederlassung).WithMany(p => p.MitarbeiterListe).HasForeignKey(d => d.NiederlassungId);
        });

        modelBuilder.Entity<Niederlassung>(entity =>
        {
            entity.ToTable("niederlassung");

            entity.HasIndex(e => e.Niederlassungsbezeichnung, "IX_niederlassung_niederlassungsbezeichnung").IsUnique();

            entity.Property(e => e.NiederlassungId).HasColumnName("niederlassungId");
            entity.Property(e => e.Niederlassungsbezeichnung)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("niederlassungsbezeichnung");
            entity.Property(e => e.Niederlassungsvorwahl)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("niederlassungsvorwahl");
        });

        modelBuilder.Entity<Projekt>(entity =>
        {
            entity.ToTable("projekt");

            entity.HasIndex(e => e.Projektbezeichnung, "IX_projekt_projektbezeichnung").IsUnique();

            entity.HasIndex(e => e.ProjektstatusId, "IX_projekt_projektstatusId");

            entity.HasIndex(e => e.ProjekttypId, "IX_projekt_projekttypId");

            entity.Property(e => e.ProjektId).HasColumnName("projektId");
            entity.Property(e => e.Fakturierbar)
                .HasDefaultValue(false)
                .HasColumnName("fakturierbar");
            entity.Property(e => e.Projektbezeichnung)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("projektbezeichnung");
            entity.Property(e => e.Projektende)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("projektende");
            entity.Property(e => e.Projektstart)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("projektstart");
            entity.Property(e => e.ProjektstatusId)
                .HasDefaultValue(1)
                .HasColumnName("projektstatusId");
            entity.Property(e => e.ProjekttypId)
                .HasDefaultValue(1)
                .HasColumnName("projekttypId");

            entity.HasOne(d => d.Projektstatus).WithMany(p => p.ProjektListe).HasForeignKey(d => d.ProjektstatusId);

            entity.HasOne(d => d.Projekttyp).WithMany(p => p.ProjektListe).HasForeignKey(d => d.ProjekttypId);
        });

        modelBuilder.Entity<Projektergebnis>(entity =>
        {
            entity.HasKey(e => e.ProjektergebnisId);

            entity.ToTable("projektergebnis");

            entity.HasIndex(e => e.ProjektId, "IX_projektergebnis_projektId").IsUnique();

            entity.Property(e => e.ProjektergebnisId).HasColumnName("projektergebnisId");
            entity.Property(e => e.Mehrwertsteuersatz)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("mehrwertsteuersatz");
            entity.Property(e => e.Nettopreis)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("decimal(20, 2)")
                .HasColumnName("nettopreis");
            entity.Property(e => e.ProjektId).HasColumnName("projektId");
            entity.Property(e => e.Rechnungstellung)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("rechnungstellung");
            entity.Property(e => e.Zahlungseingang)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("zahlungseingang");

            entity.HasOne(d => d.Projekt).WithOne(p => p.Projektergebnis).HasForeignKey<Projektergebnis>(d => d.ProjektId);
        });

        modelBuilder.Entity<Projektmitarbeiter>(entity =>
        {
            entity.ToTable("projektmitarbeiter");

            entity.HasIndex(e => e.FunktionId, "IX_projektmitarbeiter_funktionId");

            entity.HasIndex(e => e.MitarbeiterId, "IX_projektmitarbeiter_mitarbeiterId");

            entity.HasIndex(e => e.ProjektId, "IX_projektmitarbeiter_projektId");

            entity.Property(e => e.ProjektmitarbeiterId).HasColumnName("projektmitarbeiterId");
            entity.Property(e => e.Beginn)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("beginn");
            entity.Property(e => e.Ende)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("ende");
            entity.Property(e => e.Fakturierbarestunden)
                .HasDefaultValueSql("('0')")
                .HasColumnName("fakturierbarestunden");
            entity.Property(e => e.FunktionId)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("funktionId");
            entity.Property(e => e.MitarbeiterId).HasColumnName("mitarbeiterId");
            entity.Property(e => e.Nichtfakturierbarestunden)
                .HasDefaultValueSql("('0')")
                .HasColumnName("nichtfakturierbarestunden");
            entity.Property(e => e.ProjektId).HasColumnName("projektId");
            entity.Property(e => e.Stundensatz)
                .HasColumnType("money")
                .HasColumnName("stundensatz");

            entity.HasOne(d => d.Funktion).WithMany(p => p.ProjektmitarbeiterListe).HasForeignKey(d => d.FunktionId);

            entity.HasOne(d => d.Mitarbeiter).WithMany(p => p.ProjektmitarbeiterListe).HasForeignKey(d => d.MitarbeiterId);

            entity.HasOne(d => d.Projekt).WithMany(p => p.Projektmitarbeiters).HasForeignKey(d => d.ProjektId);
        });

        modelBuilder.Entity<Projektstatus>(entity =>
        {
            entity.ToTable("projektstatus");

            entity.Property(e => e.ProjektstatusId).HasColumnName("projektstatusId");
            entity.Property(e => e.Projektstatus1)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("projektstatus");
        });

        modelBuilder.Entity<Projekttyp>(entity =>
        {
            entity.ToTable("projekttyp");

            entity.Property(e => e.ProjekttypId).HasColumnName("projekttypId");
            entity.Property(e => e.Projekttyp1)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("projekttyp");
        });

        modelBuilder.Entity<VMitarbeiterListeMitFunktionen>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vMitarbeiterListeMitFunktionen");

            entity.Property(e => e.Abteilung)
                .HasMaxLength(45)
                .IsUnicode(false);
            entity.Property(e => e.Anrede)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Funktion)
                .HasMaxLength(45)
                .IsUnicode(false);
            entity.Property(e => e.MitarbeiterId).HasColumnName("mitarbeiterId");
            entity.Property(e => e.Name).HasMaxLength(102);
            entity.Property(e => e.Niederlassung)
                .HasMaxLength(45)
                .IsUnicode(false);
            entity.Property(e => e.Telefon).HasMaxLength(96);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
