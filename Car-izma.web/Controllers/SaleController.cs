using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Car_izma.data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Car_izma.web.Controllers
{
    public class SaleController : Controller
    {
        private readonly CarizmaContext _context;

        public SaleController(CarizmaContext context)

        {
            _context = context;
        }

        public IActionResult Sales()
        {
            var carList = _context.Satislars
    .Include(u => u.User).Include(s => s.Car)
    .ToList();
            return View(carList);
        }



        [HttpGet]
            public IActionResult Create()
            {
            ViewBag.Cars = _context.Cars
.Select(c => new { c.CarId, c.Model, c.Fiyat })
.ToList();
            ViewBag.Users = new SelectList(_context.Users.ToList(), "UserId", "AdSoyad");
                return View();
            }

        [HttpPost]
        public IActionResult Create(Satislar satislar)
        {
            satislar.SatisTarihi = DateTime.Now;
            _context.Add(satislar);
            _context.SaveChanges();

           

            return RedirectToAction("Sales");
        }

        public IActionResult Delete(int id)
        {
            ViewBag.Users = new SelectList(_context.Users.ToList(), "UserId", "AdSoyad");
            ViewBag.Cars = new SelectList(_context.Cars.ToList(), "CarId", "Marka" , "Model");

            var delete = _context.Satislars.Find(id);
            return View(delete);
        }

        [HttpPost]
        public IActionResult Delete(int id, Satislar satislar)
        {
            var deleteSatis = _context.Satislars.Find(id);
            if (deleteSatis != null)
            {
                _context.Satislars.Remove(deleteSatis);
                _context.SaveChanges();
            }

            return RedirectToAction("Sales");

        }

    }
    }


