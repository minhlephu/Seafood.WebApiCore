using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using SeafoodWpf.COMMON.Configuration;

namespace SeafoodWpf.COMMON.Model;

public partial class User : BasePropertyEvent
{
    [Key]
    private Guid _Id;
    [Key]
    public Guid Id
    {
        get => _Id; set
        {
            _Id = value;
            OnPropertyChanged();
        }
    }

    [Key]
    private string _Username;
    [Key]
    public string Username
    {
        get => _Username; set
        {
            _Username = value;
            OnPropertyChanged();
        }
    }

    [Key]
    private string _PasswordHash;
    [Key]
    public string PasswordHash
    {
        get => _PasswordHash; set
        {
            _PasswordHash = value;
            OnPropertyChanged();
        }
    }

    [Key]
    private int _Salt;
    [Key]
    public int Salt
    {
        get => _Salt; set
        {
            _Salt = value;
            OnPropertyChanged();
        }
    }


    [StringLength(100)]
    public string? DisplayName { get; set; }

    public string? Avarta { get; set; }

    [Column(TypeName = "date")]
    public DateTime? Birthday { get; set; }

    private int? _Sex;
    public int? Sex
    {
        get => _Sex; set
        {
            _Sex = value;
            OnPropertyChanged();
        }
    }

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

    [Key]
    private string _Role;
    [Key]
    public string Role
    {
        get => _Role; set
        {
            _Role = value;
            OnPropertyChanged();
        }
    }

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
