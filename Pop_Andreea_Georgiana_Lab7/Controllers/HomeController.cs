﻿using Microsoft.AspNetCore.Mvc;
using Pop_Andreea_Georgiana_Lab2.Models;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Pop_Andreea_Georgiana_Lab2.Data;
using Pop_Andreea_Georgiana_Lab2.Models.LibraryViewModels;

namespace Pop_Andreea_Georgiana_Lab2.Controllers
{
    public class HomeController : Controller
    {
        // private readonly ILogger<HomeController> _logger;

        // public HomeController(ILogger<HomeController> logger)
        // {
        // _logger = logger;
        //}
        private readonly LibraryContext _context;
        public HomeController(LibraryContext context)
        {
            _context = context;
        }

        public async Task<ActionResult> Statistics()
        {
            IQueryable<OrderGroup> data =
            from order in _context.Orders
            group order by order.OrderDate into dateGroup
            select new OrderGroup()
            {
                OrderDate = dateGroup.Key,
                BookCount = dateGroup.Count()
            };
            return View(await data.AsNoTracking().ToListAsync());
        }


        public IActionResult Index()
        {

        return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Chat()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}