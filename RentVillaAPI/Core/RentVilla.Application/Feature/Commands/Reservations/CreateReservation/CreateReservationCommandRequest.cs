﻿using MediatR;
using RentVilla.Application.DTOs.ReservationDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentVilla.Application.Feature.Commands.Reservations.CreateReservation
{
    public class CreateReservationCommandRequest: IRequest<CreateReservationCommandResponse>
    {
        public CreateReservationDTO createReservation { get; set; }
    }
}
