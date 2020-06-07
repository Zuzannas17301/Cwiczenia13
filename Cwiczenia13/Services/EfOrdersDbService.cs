
using System;
using System.Collections.Generic;
using System.Linq;
using Cwiczenia13.DTOs.Requests;
using Cwiczenia13.DTOs.Responses;
using Cwiczenia13.Models;
using Microsoft.AspNetCore.Mvc;


namespace Cwiczenia13.Services
{
    public class EfOrdersDbService : IOrderDbService
    {
        private readonly s17301DbContext _context;

        public EfOrdersDbService(s17301DbContext context)
        {
            _context = context;
        }
        
        public List<GetOrdersResponse> GetOrders()
        {
            var result = (from Zamowienie in _context.Zamowienie
                join Zamowienie_WyrobCukierniczy in _context.Zamowienie_WyrobCukierniczy on Zamowienie.IdZamowienia
                    equals Zamowienie_WyrobCukierniczy.IdZamowienia
                        join WyrobCukierniczy in _context.WyrobCukierniczy on Zamowienie_WyrobCukierniczy.IdWyrobuCukierniczego equals WyrobCukierniczy.IdWyrobuCukierniczego
                orderby Zamowienie.IdZamowienia
                select new GetOrdersResponse()
                {
                    IdZamowienie = Zamowienie.IdZamowienia,
                    DataPrzyjecia = Zamowienie.DataPrzyjecia,
                    DataRealizacji = Zamowienie.DataRealizacji,
                    Ilosc = Zamowienie_WyrobCukierniczy.Ilosc,
                    NazwaWyrobuCukierniczego = WyrobCukierniczy.Nazwa,
                    CenaZaSzt = WyrobCukierniczy.CenaZaSzt
                }).ToList();
            
            return result;
        }

        public IEnumerable<GetOrdersResponse> GetOrders(string Nazwisko)
        {
            List<GetOrdersResponse> result = null;
            
            var klient = _context.Klient.Any(e => e.Nazwisko == Nazwisko);

            if (klient)
                {
                    result = (from Zamowienie in _context.Zamowienie
                        join Zamowienie_WyrobCukierniczy in _context.Zamowienie_WyrobCukierniczy on Zamowienie.IdZamowienia
                            equals Zamowienie_WyrobCukierniczy.IdZamowienia
                        join WyrobCukierniczy in _context.WyrobCukierniczy on Zamowienie_WyrobCukierniczy
                                .IdWyrobuCukierniczego
                            equals WyrobCukierniczy.IdWyrobuCukierniczego
                            where Zamowienie.Klient.Nazwisko == Nazwisko
                        orderby Zamowienie.IdZamowienia
                        select new GetOrdersResponse()
                        {
                            IdZamowienie = Zamowienie.IdZamowienia,
                            DataPrzyjecia = Zamowienie.DataPrzyjecia,
                            DataRealizacji = Zamowienie.DataRealizacji,
                            Ilosc = Zamowienie_WyrobCukierniczy.Ilosc,
                            NazwaWyrobuCukierniczego = WyrobCukierniczy.Nazwa,
                            CenaZaSzt = WyrobCukierniczy.CenaZaSzt
                        }).ToList();
                }
            
            return result;
        }

        public IActionResult AddOrder(AddOrderRequest request, int klientId)
        {
           //czy podany klient jest w bazie
           var res = _context.Klient.Any(e => e.IdKlient == klientId);

           if (!res)
           {
               return new BadRequestObjectResult("Nie ma takiego klienta w bazie!");
           }
           else
           {
               //czy podane wyroby cukiernicze sa produkiwane w cukierni
               foreach (Wyrob wyrob in request.Wyroby)
               {
                   var res2 = _context.WyrobCukierniczy.Any(e => e.Nazwa == wyrob.wyrob);
                   if(!res2)
                       return new BadRequestObjectResult("Nie ma takiego wyrobu w bazie!");
               }

               var response = new Zamowienie {DataPrzyjecia = request.DataPrzyjecia, Uwagi = request.Uwagi, IdKlient = klientId, IdPracownik = 1, Zamowienie_WyrobCukierniczy = new List<Zamowienie_WyrobCukierniczy>()};
               foreach (Wyrob wyrob in request.Wyroby)
               {
                   int id = _context.WyrobCukierniczy.FirstOrDefault(e => e.Nazwa == wyrob.wyrob).IdWyrobuCukierniczego;
                   response.Zamowienie_WyrobCukierniczy.Add(new Zamowienie_WyrobCukierniczy{IdWyrobuCukierniczego = id, Uwagi = wyrob.uwagi, Ilosc = wyrob.ilosc});
               }

               _context.Add(response);
               _context.SaveChanges();

               return new OkObjectResult("Pomyślnie dodano nowe zamówienie do bazy");
           }
           
        }
    }
}