﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentVilla.Application.Feature.Commands.ProductImages.DeleteProductImages
{
    public class DeleteProductImagesRequest : IRequest<DeleteProductImagesResponse>
    {
        public string pathOrContainerName { get; set; }
        public string fileName { get; set; }
    }
}
