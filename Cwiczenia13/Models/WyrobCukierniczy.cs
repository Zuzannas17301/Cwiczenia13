using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cwiczenia13.Models
{
    public class WyrobCukierniczy
    {
        [Key] 
        public int IdWyrobuCukierniczego { get; set; }
        public string Nazwa { get; set; }
        public float CenaZaSzt { get; set; }
        public string Typ { get; set; }
        
        public ICollection<Zamowienie_WyrobCukierniczy> Zamowienie_WyrobCukierniczy { get; set; }
    }
}