using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Seafood.ARCHITECTURE.Entities.Models;

public partial class FavouriteProd
{
    [Key]
    public Guid Id { get; set; }

    public Guid? UserId { get; set; }

    [StringLength(100)]
    public string? IpRequest { get; set; }

    public Guid ProductId { get; set; }

    public Guid? ProdBasketId { get; set; }

    public string? ClassName { get; set; }

    public bool IsDeleted { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DeletedAt { get; set; }

    [StringLength(100)]
    public string? DeletedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [StringLength(100)]
    public string CreatedBy { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [StringLength(100)]
    public string? UpdatedBy { get; set; }
}
