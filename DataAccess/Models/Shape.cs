﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DataAccess.Models
{
    public partial class Shape
    {
        public Shape()
        {
            Counterfeits = new ObservableCollection<Counterfeit>();
        }

        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public string Formula { get; set; } = null!;

        public virtual ObservableCollection<Counterfeit> Counterfeits { get; set; }
    }
}
