using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cwiczenia13.Models
{
    public class Zamowienie
    {
        [Key] public int IdZamowienia { get; set; }
        public DateTime DataPrzyjecia { get; set; }
        public DateTime? DataRealizacji { get; set; }
        public string? Uwagi { get; set; }
        
        public int IdKlient { get; set; }
        public virtual Klient Klient { get; set; }
        public int IdPracownik { get; set; }
        public  virtual Pracownik Pracownik { get; set; }
        
        public  ICollection<Zamowienie_WyrobCukierniczy> Zamowienie_WyrobCukierniczy { get; set; }
    }
}