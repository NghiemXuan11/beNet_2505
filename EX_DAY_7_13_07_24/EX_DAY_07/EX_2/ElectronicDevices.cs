﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX_2
{
    public class ElectronicDevice : Product
    {
        public string Brand { get; set; }
        public string Model { get; set; }

        public ElectronicDevice(string name, string category, decimal price, int stock, string brand, string model)
            : base(name, category, price, stock)
        {
            Brand = brand;
            Model = model;
        }

        public override decimal CalculateSalePrice()
        {
            return Price * 0.88m;
        }
    }
}
