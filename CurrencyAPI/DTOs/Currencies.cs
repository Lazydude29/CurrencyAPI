﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyAPI
{
    public class Currencies
    {
        public DateTime Date { get; set; }
        public IList<Currency> currencies { get; set; }
    }
}
