using System.ComponentModel.DataAnnotations.Schema;

namespace Cwiczenia13.Models
{
    public class Zamowienie_WyrobCukierniczy
    {
        [ForeignKey("WyrobCukierniczy")]
        public int IdWyrobuCukierniczego { get; set; }
        
        public virtual WyrobCukierniczy WyrobCukierniczy { get; set; }

        [ForeignKey("Zamowienie")]
        public int IdZamowienia { get; set; }
        
        public virtual Zamowienie Zamowienie { get; set; }
        public int Ilosc { get; set; }
        public string? Uwagi { get; set; }
    }
}