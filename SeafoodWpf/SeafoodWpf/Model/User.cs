﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using SeafoodWpf.ViewModel;

namespace SeafoodWpf.Model;

public partial class User : BaseViewModel
{
    [Key]
    public Guid Id { get; set; }

    [StringLength(50)]
    public string Username { get; set; } = null!;

    [StringLength(250)]
    public string PasswordHash { get; set; } = null!;

    public int Salt { get; set; }

    [StringLength(100)]
    public string? DisplayName { get; set; }

    public string? Avarta { get; set; }

    [Column(TypeName = "date")]
    public DateTime? Birthday { get; set; }

    public int? Sex { get; set; }

    private string? _Mobile;
    [StringLength(20)]
    [Unicode(false)]
    public string? Mobile { get => _Mobile; set
        {
            _Mobile = value;
            OnPropertyChanged();
        }
    }

    [StringLength(250)]
    public string? Email { get; set; }

    [StringLength(250)]
    public string? Company { get; set; }

    [StringLength(100)]
    public string Role { get; set; } = null!;

    public bool IsAdminUser { get; set; }

    public bool IsLocked { get; set; }

    public string? Session { get; set; }

    public string? SessionId { get; set; }

    public bool? IsDeleted { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DeletedAt { get; set; }

    [StringLength(100)]
    public string? DeletedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [StringLength(100)]
    public string? CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [StringLength(100)]
    public string? UpdatedBy { get; set; }
}