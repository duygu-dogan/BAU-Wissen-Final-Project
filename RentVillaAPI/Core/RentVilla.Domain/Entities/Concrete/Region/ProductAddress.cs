using RentVilla.Domain.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentVilla.Domain.Entities.Concrete.Region
{
  public class ProductAddress: BaseEntity
    {
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public District District { get; set; }
    }
}
