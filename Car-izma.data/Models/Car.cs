using System;
using System.Collections.Generic;

namespace Car_izma.data.Models;

public partial class Car
{
    public int CarId { get; set; }

    public int? ShowroomId { get; set; }

    public string? Marka { get; set; }

    public string? Model { get; set; }

    public int? Yil { get; set; }

    public string? Renk { get; set; }

    public string? Plaka { get; set; }

    public string? SaseNo { get; set; }

    public string? MotorNo { get; set; }

    public string? YakıtTipi { get; set; }

    public string? VitesTipi { get; set; }

    public string? KasaTipi { get; set; }

    public int? Km { get; set; }

    public decimal? Fiyat { get; set; }

    public string? CarAciklama { get; set; }

    public DateTime? CarEklenmeTarihi { get; set; }

    public virtual ICollection<CarImage> CarImages { get; set; } = new List<CarImage>();

    public virtual ICollection<Satislar> Satislars { get; set; } = new List<Satislar>();

    public virtual Showroom? Showroom { get; set; }
}
