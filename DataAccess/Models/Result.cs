﻿using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Result
    {
        public long Id { get; set; }
        public byte[] Date { get; set; } = null!;
        public long CompanyId { get; set; }
        public string Result1 { get; set; } = null!;
        public long OrigPathId { get; set; }
        public long ResPathId { get; set; }

        public virtual Company Company { get; set; } = null!;
        public virtual OriginalPath OrigPath { get; set; } = null!;
        public virtual ResultPath ResPath { get; set; } = null!;
    }
}
