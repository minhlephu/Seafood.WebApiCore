using System;
using System.Collections.Generic;

namespace Domains.Models;

public partial class FavouriteProd : AbstractModel
{
    public Guid Id { get; set; }

    public Guid? UserId { get; set; }

    public string? IpRequest { get; set; }

    public Guid ProductId { get; set; }

    public Guid? ProdBasketId { get; set; }

    public string? ClassName { get; set; }
}
