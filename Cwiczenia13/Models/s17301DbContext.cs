using System;
using Microsoft.EntityFrameworkCore;

namespace Cwiczenia13.Models
{
    public class s17301DbContext : DbContext
    {
        public DbSet<Klient> Klient { get; set; }
        public DbSet<Pracownik> Pracownik { get; set; }
        public DbSet<Zamowienie> Zamowienie { get; set;  }
        public DbSet<WyrobCukierniczy> WyrobCukierniczy { get; set; }
        public DbSet<Zamowienie_WyrobCukierniczy> Zamowienie_WyrobCukierniczy { get; set; }
        
        public s17301DbContext(){}

        public s17301DbContext(DbContextOptions opts) : base(opts)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Klient>((builder) =>
            {
                builder.HasKey(e => e.IdKlient);
                builder.Property(e => e.IdKlient).ValueGeneratedOnAdd();
                builder.Property(e => e.Imie).HasMaxLength(50);
                builder.Property(e => e.Imie).IsRequired();
                builder.Property(e => e.Nazwisko).HasMaxLength(60);
                builder.Property(e => e.Nazwisko).IsRequired();
                builder.HasMany(e => e.Zamowienia)
                    .WithOne(e => e.Klient)
                    .HasForeignKey(e => e.IdKlient)
                    .IsRequired();
                
                builder.HasData(
                    new Klient{IdKlient = 1, Imie = "Agnieszka", Nazwisko = "Poterek"},
                    new Klient{IdKlient = 2, Imie = "Kacper", Nazwisko = "Kali"},
                    new Klient{IdKlient = 3, Imie = "Weronika", Nazwisko = "Smardzik"},
                    new Klient{IdKlient = 4, Imie = "Monika", Nazwisko = "Zajac"},
                    new Klient{IdKlient = 5, Imie = "Katarzyna", Nazwisko = "Malec"}
                );
            });
            
            modelBuilder.Entity<Pracownik>((builder) =>
            {
                builder.HasKey(e => e.IdPracownik);
                builder.Property(e => e.IdPracownik).ValueGeneratedOnAdd();
                builder.Property(e => e.Imie).HasMaxLength(50);
                builder.Property(e => e.Imie).IsRequired();
                builder.Property(e => e.Nazwisko).HasMaxLength(60);
                builder.Property(e => e.Nazwisko).IsRequired();
                builder.HasMany(e => e.Zamowienia)
                    .WithOne(e => e.Pracownik)
                    .HasForeignKey(e => e.IdPracownik)
                    .IsRequired();
                
                builder.HasData(
                    new Pracownik{IdPracownik = 1, Imie = "Wojciech", Nazwisko = "Wojdat"},
                    new Pracownik{IdPracownik = 2, Imie = "Marcin", Nazwisko = "Poniatowski"},
                    new Pracownik{IdPracownik = 3, Imie = "Bartosz", Nazwisko = "Buczek"},
                    new Pracownik{IdPracownik = 4, Imie = "Jakub", Nazwisko = "Malewski"},
                    new Pracownik{IdPracownik = 5, Imie = "Anna", Nazwisko = "Jantar"}
                );
            });

            modelBuilder.Entity<Zamowienie>((builder) =>
            {
                builder.HasKey(e => e.IdZamowienia);
                builder.Property(e => e.IdZamowienia).ValueGeneratedOnAdd();
                builder.Property(e => e.DataPrzyjecia).IsRequired();
                builder.Property(e => e.DataRealizacji).IsRequired();
                builder.Property(e => e.Uwagi).HasMaxLength(300);

                builder.HasMany(e => e.Zamowienie_WyrobCukierniczy)
                        .WithOne(e => e.Zamowienie)
                        .HasForeignKey(e => e.IdZamowienia)
                        .IsRequired();

                builder.HasData(
                    new Zamowienie{IdZamowienia = 1, DataPrzyjecia = DateTime.Parse("25/05/2020"), DataRealizacji = DateTime.Now, Uwagi = "brak", IdKlient = 1, IdPracownik = 1},
                    new Zamowienie{IdZamowienia = 2, DataPrzyjecia = DateTime.Parse("23/05/2020"), DataRealizacji = DateTime.Now, Uwagi = "brak", IdKlient = 2, IdPracownik = 2},
                    new Zamowienie{IdZamowienia = 3, DataPrzyjecia = DateTime.Parse("26/05/2020"), DataRealizacji = DateTime.Parse("28/05/2020"), Uwagi = "sprawnie", IdKlient = 3, IdPracownik = 3},
                    new Zamowienie{IdZamowienia = 4, DataPrzyjecia = DateTime.Parse("30/05/2020"), DataRealizacji = DateTime.Now, Uwagi = "", IdKlient = 4, IdPracownik = 4},
                    new Zamowienie{IdZamowienia = 5, DataPrzyjecia = DateTime.Parse("23/05/2020"), DataRealizacji = DateTime.Now, Uwagi = "", IdKlient = 5, IdPracownik = 5},
                    new Zamowienie{IdZamowienia = 6, DataPrzyjecia = DateTime.Parse("26/05/2020"), DataRealizacji = DateTime.Now, Uwagi = "", IdKlient = 1, IdPracownik = 3},
                    new Zamowienie{IdZamowienia = 7, DataPrzyjecia = DateTime.Parse("10/05/2020"),DataRealizacji = DateTime.Now, Uwagi = "dlugo", IdKlient = 2, IdPracownik = 4}
                );
            });

            modelBuilder.Entity<WyrobCukierniczy>((builder) =>
            {
                builder.HasKey(e => e.IdWyrobuCukierniczego);
                builder.Property(e => e.IdWyrobuCukierniczego).ValueGeneratedOnAdd();
                builder.Property(e => e.Nazwa).IsRequired();
                builder.Property(e => e.Nazwa).HasMaxLength(200);
                builder.Property(e => e.CenaZaSzt).IsRequired();
                builder.Property(e => e.Typ).HasMaxLength(40);
                builder.Property(e => e.Typ).IsRequired();

                builder.HasMany(e => e.Zamowienie_WyrobCukierniczy)
                    .WithOne(e => e.WyrobCukierniczy)
                    .HasForeignKey(e => e.IdWyrobuCukierniczego)
                    .IsRequired();
                
                builder.HasData(
                    new WyrobCukierniczy{IdWyrobuCukierniczego = 1, Nazwa = "Beza Pavlova", CenaZaSzt = 60, Typ = "ciasto"},
                    new WyrobCukierniczy{IdWyrobuCukierniczego = 2, Nazwa = "Karpatka", CenaZaSzt = 20, Typ = "ciasto"},
                    new WyrobCukierniczy{IdWyrobuCukierniczego = 3, Nazwa = "Szarlotka", CenaZaSzt = 15, Typ = "ciasto"},
                    new WyrobCukierniczy{IdWyrobuCukierniczego = 4, Nazwa = "Pączek", CenaZaSzt = 1.50f, Typ = "deser" },
                    new WyrobCukierniczy{IdWyrobuCukierniczego = 5, Nazwa = "Karmelowiec", CenaZaSzt = 35, Typ = "ciasto"}
                );
            });

            modelBuilder.Entity<Zamowienie_WyrobCukierniczy>((builder) =>
            {
                builder.HasKey(e => new {e.IdWyrobuCukierniczego, e.IdZamowienia});
                builder.Property(e => e.Ilosc).IsRequired();
                builder.Property(e => e.Uwagi).HasMaxLength(300);
                
                builder.HasData(
                    new Zamowienie_WyrobCukierniczy{IdWyrobuCukierniczego = 1, IdZamowienia = 1, Ilosc = 1, Uwagi = "przechowywac w chlodzie"},
                    new Zamowienie_WyrobCukierniczy{IdWyrobuCukierniczego = 2, IdZamowienia = 2, Ilosc = 2, Uwagi = ""},
                    new Zamowienie_WyrobCukierniczy{IdWyrobuCukierniczego = 3, IdZamowienia = 3, Ilosc = 1, Uwagi = ""},
                    new Zamowienie_WyrobCukierniczy{IdWyrobuCukierniczego = 4, IdZamowienia = 4, Ilosc = 5, Uwagi = ""},
                    new Zamowienie_WyrobCukierniczy{IdWyrobuCukierniczego = 5, IdZamowienia = 5, Ilosc = 2, Uwagi = ""},
                    new Zamowienie_WyrobCukierniczy{IdWyrobuCukierniczego = 1, IdZamowienia = 6, Ilosc = 3, Uwagi = ""},
                    new Zamowienie_WyrobCukierniczy{IdWyrobuCukierniczego = 4, IdZamowienia = 7, Ilosc = 10, Uwagi = "tlusty czwartek"}
                );
            });

        }

    }
}