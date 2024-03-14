﻿using RentVilla.Application.Repositories.ReservationRepo;
using RentVilla.Domain.Entities.Concrete;
using RentVilla.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentVilla.Persistence.Repositories.ReservationCRepo
{
    public class ReservationReadRepository : ReadRepository<Reservation>, IReservationReadRepository
    {
        public ReservationReadRepository(RentVillaDbContext context) : base(context)
        {
        }
    }
}
