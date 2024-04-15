﻿using RentVilla.Application.DTOs.ReservationDTOs;

namespace RentVilla.Application.DTOs.ProductDTOs
{
    public class ProductDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public double Deposit { get; set; }
        public List<ProductImageDTO> ProductImages { get; set; }
        public string MapId { get; set; }
        public string Address { get; set; }
        public ProductAddressDTO ProductAddress { get; set; }
        public int ShortestRentPeriod { get; set; }
        public string Properties { get; set; }
        public string Rating { get; set; }
        public CreateReservationDTO Reservation { get; set; }
        public ICollection<ProductAttributeDTO> Attributes { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
