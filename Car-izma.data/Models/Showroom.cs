using System;
using System.Collections.Generic;

namespace Car_izma.data.Models;

public partial class Showroom
{
    public int ShowroomId { get; set; }

    public string? ShowroomAd { get; set; }

    public string? ShowroomAdres { get; set; }

    public string? ShowroomTel { get; set; }

    public string? ShowroomMail { get; set; }

    public string? ShowroomAciklama { get; set; }

    public virtual ICollection<Car> Cars { get; set; } = new List<Car>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
