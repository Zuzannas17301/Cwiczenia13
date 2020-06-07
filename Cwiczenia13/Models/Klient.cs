using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cwiczenia13.Models
{
    public class Klient
    {
        [Key]
        public int IdKlient { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        
        public ICollection<Zamowienie> Zamowienia { get; set; }
    }
}