﻿using RentVilla.Domain.Entities.Concrete.Region;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentVilla.Application.Feature.Queries.StateImages.GetStateImages
{
    public class GetStateImagesQueryResponse
    {
        public List<StateImageFile> imageFiles { get; set; }
    }
}
