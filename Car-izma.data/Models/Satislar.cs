using System;
using System.Collections.Generic;

namespace Car_izma.data.Models;

public partial class Satislar
{
    public int Id { get; set; }

    public int CarId { get; set; }

    public int UserId { get; set; }

    public string MusteriAdSoyad { get; set; } = null!;

    public string? MusteriTelefon { get; set; }

    public DateTime SatisTarihi { get; set; }

    public decimal SatisFiyati { get; set; }

    public virtual Car Car { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
