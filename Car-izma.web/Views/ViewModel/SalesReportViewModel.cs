using System;
namespace Car_izma.web.Views.ViewModel
{
    
        public class SalesReportViewModel
        {
            public int Id { get; set; }
            public string CarInfo { get; set; } = string.Empty;
            public string MusteriAdSoyad { get; set; } = string.Empty;
            public string UserName { get; set; } = string.Empty;
            public DateTime SatisTarihi { get; set; }
            public decimal SatisFiyati { get; set; }
        }

        
    }



