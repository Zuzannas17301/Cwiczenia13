using System;
using Microsoft.AspNetCore.Mvc;

namespace Cwiczenia13.DTOs.Responses
{
    public class GetOrdersResponse
    {
        public int IdZamowienie { get; set; }
        public DateTime DataPrzyjecia { get; set; }
        public DateTime DataRealizacji { get; set; }
        public int Ilosc { get; set; }
        public string NazwaWyrobuCukierniczego { get; set; }
        public float CenaZaSzt { get; set; }
    }
}