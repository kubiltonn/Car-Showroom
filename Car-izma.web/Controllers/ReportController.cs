using Microsoft.AspNetCore.Mvc;
using Car_izma.data.Models;
using Car_izma.web.Views.ViewModel;
using System.Linq;

namespace Car_izma.web.Controllers
{
    public class ReportController : Controller
    {
        private readonly CarizmaContext _context;
        public ReportController(CarizmaContext context)
        {
            _context = context;
        }

        public IActionResult Sales(string sortOrder)
        {
            var sales = _context.Satislars
                .Select(s => new SalesReportViewModel
                {
                    Id = s.Id,
                    CarInfo = s.Car.Marka + " " + s.Car.Model,
                    MusteriAdSoyad = s.MusteriAdSoyad,
                    UserName = s.User.AdSoyad,
                    SatisTarihi = s.SatisTarihi,
                    SatisFiyati = s.SatisFiyati
                });

            // Sıralama
            switch (sortOrder)
            {
                case "fiyat_azalan":
                    sales = sales.OrderByDescending(x => x.SatisFiyati);
                    break;
                case "fiyat_artan":
                    sales = sales.OrderBy(x => x.SatisFiyati);
                    break;
                case "musteri_az":
                    sales = sales.OrderBy(x => x.MusteriAdSoyad);
                    break;
                case "musteri_za":
                    sales = sales.OrderByDescending(x => x.MusteriAdSoyad);
                    break;
                case "tarih_artan":
                    sales = sales.OrderBy(x => x.SatisTarihi);
                    break;
                case "tarih_azalan":
                    sales = sales.OrderByDescending(x => x.SatisTarihi);
                    break;
                case "araba_az":
                    sales = sales.OrderBy(x => x.CarInfo);
                    break;
                case "araba_za":
                    sales = sales.OrderByDescending(x => x.CarInfo);
                    break;
                default:
                    sales = sales.OrderByDescending(x => x.SatisTarihi); // Varsayılan: yeni satışlar önce
                    break;
            }

            var salesList = sales.ToList();

            ViewBag.TotalSales = salesList.Count;
            ViewBag.TotalRevenue = salesList.Sum(x => x.SatisFiyati);
            ViewBag.CurrentSort = sortOrder;

            return View(salesList);
        }
    }
}