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
    public class CarController : Controller
    {
        private readonly CarizmaContext _context;

        public CarController(CarizmaContext context)
        {
            _context = context;
        }


        public IActionResult Cars()
        {

            var carList = _context.Cars
    .Include(c => c.Showroom)
    .ToList();
            return View(carList);
        }
        public IActionResult Review(int id)
        {
            var car = _context.Cars
    .Include(c => c.Showroom)
    .Include(c => c.CarImages)
    .FirstOrDefault(c => c.CarId == id);


            if (car == null)
                return NotFound();

            return View(car);
        }
        [HttpPost]
        public IActionResult Review(int id, Car car)
        {
            _context.Update(car);
            _context.SaveChanges();

            return RedirectToAction("Cars");

        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Showrooms = new SelectList(_context.Showrooms, "ShowroomId", "ShowroomAd");
            return View();

        }
        [HttpPost]
        public IActionResult Create(Car car, string imageUrl)
        {
            car.CarEklenmeTarihi = DateTime.Now;
            _context.Add(car);
            _context.SaveChanges();

            if (!string.IsNullOrEmpty(imageUrl))
            {
                var carImage = new CarImage
                {
                    CarId = car.CarId,
                    ImagePath = imageUrl
                };
                _context.CarImages.Add(carImage);
                _context.SaveChanges();
            }

            return RedirectToAction("Cars");
        }

        public IActionResult Edit(int id)
        {
            ViewBag.Showrooms = new SelectList(_context.Showrooms, "ShowroomId", "ShowroomAd");

            var update = _context.Cars
                .Include(c => c.CarImages)
                .FirstOrDefault(c => c.CarId == id);
            ViewBag.ImageUrl = update?.CarImages.FirstOrDefault()?.ImagePath ?? "";

            return View(update);
        }
        [HttpPost]
        public IActionResult Edit(int id, Car car, string imageUrl)
        {
            var existingCar = _context.Cars
                .Include(c => c.CarImages)
                .FirstOrDefault(c => c.CarId == id);

            if (existingCar == null)
                return NotFound();

          
            var carImage = existingCar.CarImages.FirstOrDefault();
            if (carImage != null)
            {
                carImage.ImagePath = imageUrl;
            }
            else if (!string.IsNullOrEmpty(imageUrl))
            {
                _context.CarImages.Add(new CarImage { CarId = id, ImagePath = imageUrl });
            }

            _context.SaveChanges();
            return RedirectToAction("Cars");
        }
        public IActionResult Delete(int id)
        {
            ViewBag.Showrooms = new SelectList(_context.Showrooms, "ShowroomId", "ShowroomAd");

            var delete = _context.Cars
                .Include(c => c.CarImages)
                .FirstOrDefault(c => c.CarId == id);
            ViewBag.ImageUrl = delete?.CarImages.FirstOrDefault()?.ImagePath ?? "";

            return View(delete);
        }
        [HttpPost]
        public IActionResult Delete(int id, Car cars)
        {
            var car = _context.Cars
                .Include(c => c.CarImages)
                .FirstOrDefault(c => c.CarId == id);

            if (car == null)
                return NotFound();

            if (car.CarImages != null && car.CarImages.Any())
                _context.CarImages.RemoveRange(car.CarImages);

            _context.Cars.Remove(car);
            _context.SaveChanges();

            return RedirectToAction("Cars");
        }
    }
}

