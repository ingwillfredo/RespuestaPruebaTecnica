﻿using System;
using System.Collections.Generic;

namespace ApiBackPruebaTec.Entities.Models;

public partial class Task
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public string? Status { get; set; }

    public DateTime? CreatedAt { get; set; }
}
