﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Seafood.ARCHITECTURE.Entities.Models;

public partial class Role
{
    [Key]
    public Guid Id { get; set; }

    [StringLength(100)]
    public string RoleName { get; set; } = null!;
}