using System;
using System.Collections.Generic;

namespace Car_izma.data.Models;

public partial class User
{
    public int UserId { get; set; }

    public string AdSoyad { get; set; } = null!;

    public string UserEmail { get; set; } = null!;

    public string UserSifre { get; set; } = null!;

    public string? UserTelefon { get; set; }

    public string? UserRol { get; set; }

    public int? ShowroomId { get; set; }

    public virtual ICollection<Satislar> Satislars { get; set; } = new List<Satislar>();

    public virtual Showroom? Showroom { get; set; }
}
