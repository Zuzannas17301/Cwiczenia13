using System;
using System.Collections.Generic;
using Cwiczenia13.Models;

namespace Cwiczenia13.DTOs.Requests
{
    public class AddOrderRequest
    {
        public DateTime DataPrzyjecia { get; set; }
        public string Uwagi { get; set; }
        public List<Wyrob> Wyroby { get; set; }
    }
}