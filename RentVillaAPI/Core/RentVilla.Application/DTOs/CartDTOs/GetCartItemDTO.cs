﻿using RentVilla.Application.DTOs.ProductDTOs;
using RentVilla.Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentVilla.Application.DTOs.CartDTOs
{
    public class GetCartItemDTO
    {
        public string CartItemId { get; set; }
        public ProductDTO Product { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int AdultNumber { get; set; }
        public int ChildrenNumber { get; set; }
        public string Note { get; set; }
        public double Price { get; set; }
        public double TotalCost { get; set; }

    }
}
