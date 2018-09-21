using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vigneti.Data;
using Vigneti.Models;
using Vigneti.Models.VineyardViewModel;

namespace Vigneti.Controllers
{
    public class HomeController : Controller
    {
        private readonly VineyardContext _context;

        public HomeController(VineyardContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var viewModel = new VineyardsIndexData();
            viewModel.Vineyards = await _context.Vineyards.Include(v => v.VineGrower).Include(v => v.Wine).ToListAsync();
            viewModel.VineGrowers = _context.VineGrowers;
            viewModel.Wines = _context.Wines;
            return View(viewModel);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
