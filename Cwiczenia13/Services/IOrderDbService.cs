
using System.Collections;
using System.Collections.Generic;
using Cwiczenia13.DTOs.Requests;
using Cwiczenia13.DTOs.Responses;
using Cwiczenia13.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cwiczenia13.Services
{
    public interface IOrderDbService
    {
        public List<GetOrdersResponse> GetOrders();
        public IEnumerable<GetOrdersResponse> GetOrders(string Nazwisko);
        public IActionResult AddOrder(AddOrderRequest request, int klientId);

    }
}
