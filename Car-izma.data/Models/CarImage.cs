using System;
using System.Collections.Generic;

namespace Car_izma.data.Models;

public partial class CarImage
{
    public int ImageId { get; set; }

    public int CarId { get; set; }

    public string ImagePath { get; set; } = null!;

    public virtual Car Car { get; set; } = null!;
}
