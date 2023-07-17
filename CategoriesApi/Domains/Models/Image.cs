using System;
using System.Collections.Generic;

namespace Domains.Models;

public partial class Image : AbstractModel
{
    public Guid Id { get; set; }

    public Guid? ProductId { get; set; }

    public Guid? ShopSeefoodId { get; set; }

    public Guid? MoreImgId { get; set; }

    public string? UrlPath { get; set; }

    public string? Base64Str { get; set; }

    public bool IsImageMain { get; set; }
}
