﻿using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class ReviewDTO: EntityBase
    {
        public int? Id { get; set; }
        public int? ProductId { get; set; }
        public int? CustomerId { get; set; }
        public int? Rating { get; set; }
        public string? Comment { get; set; }
    }
}
