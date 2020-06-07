using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cwiczenia13.Models
{
    public class Pracownik
    {
        [Key]
        public int IdPracownik { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        
        public ICollection<Zamowienie> Zamowienia { get; set; }
    }
}