using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Seafood.ARCHITECTURE.Entities.Models;

public partial class CheckCodeFirebasis
{
    [Key]
    public Guid Id { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string Mobile { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime TimeSend { get; set; }

    public int NumberOfSend { get; set; }

    [StringLength(6)]
    [Unicode(false)]
    public string? LatestCode { get; set; }

    public string? Description { get; set; }

    public string? Note { get; set; }

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
