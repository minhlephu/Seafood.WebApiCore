using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Seafood.ARCHITECTURE.Entities.Models;

public partial class User
{
    [Key]
    public Guid Id { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string Username { get; set; } = null!;

    [StringLength(250)]
    [Unicode(false)]
    public string PasswordHash { get; set; } = null!;

    [StringLength(20)]
    [Unicode(false)]
    public string Salt { get; set; } = null!;

    [StringLength(100)]
    public string? DisplayName { get; set; }

    public string? Avarta { get; set; }

    [Column(TypeName = "date")]
    public DateTime? Birthday { get; set; }

    public int? Sex { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string Mobile { get; set; } = null!;

    [StringLength(250)]
    public string? Email { get; set; }

    [StringLength(250)]
    public string? Company { get; set; }

    [StringLength(100)]
    public string? Role { get; set; }

    public bool? IsAdminUser { get; set; }

    public bool? IsLocked { get; set; }

    public string? Session { get; set; }

    public string? SessionId { get; set; }

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
