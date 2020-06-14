
using System.Collections;
using System.Collections.Generic;
using Cwiczenia13.DTOs.Requests;
using Cwiczenia13.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cwiczenia13.Services
{
    public interface IOrderDbService
    {
        public IEnumerable GetOrders();
        public IEnumerable GetOrders(string Nazwisko);
        public IActionResult AddOrder(AddOrderRequest request, int klientId);

    }
}
