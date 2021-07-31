﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTL_Nhom8.Dto
{
    public class CartItem
    {
        public ProductDto productDto { get; set; }
        public int quantity { get; set; }
        public CartItem()
        {
            this.quantity = 0;
        }
        public double getAmount()
        {
            return this.productDto.Price * this.quantity;
        }

    }
}