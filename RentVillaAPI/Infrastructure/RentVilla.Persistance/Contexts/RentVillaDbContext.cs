﻿using Microsoft.EntityFrameworkCore;
using RentVilla.Domain.Entities.Abstract;
using RentVilla.Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentVilla.Persistance.Contexts
{
    public class RentVillaDbContext: DbContext
    {

        public RentVillaDbContext(DbContextOptions options):base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Attributes> Attributes { get; set; }
        public DbSet<AttributeType> AttributeTypes { get; set; }
        public DbSet<ProductAttribute> ProductAttributes { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker.Entries<BaseEntity>();
            foreach (var data in datas)
            {
                var _ = data.State switch
                {
                    EntityState.Added => data.CurrentValues[nameof(BaseEntity.CreatedAt)] = DateTime.UtcNow,
                    EntityState.Modified => data.CurrentValues[nameof(BaseEntity.UpdatedAt)] = DateTime.UtcNow,
                };
            }
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
