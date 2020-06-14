
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Cwiczenia13.DTOs.Requests;
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
        
        public IEnumerable GetOrders()
        {
            var result = _context.Zamowienie.Select(e => new
            {
                e.IdZamowienia,
                e.DataPrzyjecia,
                e.DataRealizacji,
                e.Uwagi,
                wyroby = e.Zamowienie_WyrobCukierniczy.Join(_context.WyrobCukierniczy, zw => zw.IdWyrobuCukierniczego,
                    wyr => wyr.IdWyrobuCukierniczego,
                    (zw, wyr) => new
                    {
                        wyr.Nazwa,
                        wyr.CenaZaSzt,
                        wyr.Typ,
                        zw.Ilosc,
                        zw.Uwagi
                    })
            }).ToList();
                
            
            return result;
        }

        public IEnumerable GetOrders(string Nazwisko)
        {
           // List<GetOrdersResponse> result = null;
            
            var klient = _context.Klient.Any(e => e.Nazwisko == Nazwisko);

            if (klient== false)
                throw new Exception("Taki klient nie istnieje w bazie!");
                
                   var result = _context.Zamowienie.Where(e=>e.Klient.Nazwisko.Equals(Nazwisko))
                       .Select(e => new
                   {
                       e.IdZamowienia,
                       e.DataPrzyjecia,
                       e.DataRealizacji,
                       e.Uwagi,
                       wyroby = e.Zamowienie_WyrobCukierniczy.Join(_context.WyrobCukierniczy, zw => zw.IdWyrobuCukierniczego,
                           wyr => wyr.IdWyrobuCukierniczego,
                           (zw, wyr) => new
                           {
                               wyr.Nazwa,
                               wyr.CenaZaSzt,
                               wyr.Typ,
                               zw.Ilosc,
                               zw.Uwagi
                           })
                   }).ToList();
                
            
            return result;
        }

        public IActionResult AddOrder(AddOrderRequest request, int klientId)
        {
           //czy podany klient jest w bazie
           var res = _context.Klient.Any(e => e.IdKlient == klientId);

           if (!res)
           {
              throw new Exception("Taki klient nie istnieje w bazie");
           }
          
               //czy podane wyroby cukiernicze sa produkiwane w cukierni
            foreach (Wyrob wyrob in request.Wyroby)
            { 
                var res2 = _context.WyrobCukierniczy.Any(e => e.Nazwa == wyrob.wyrob); 
                if(!res2) 
                    throw new Exception("Taki wyrób nie jest produkowany przez cukiernię");
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