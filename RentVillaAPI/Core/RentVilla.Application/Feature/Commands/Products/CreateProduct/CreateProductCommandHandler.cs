using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RentVilla.Application.Abstraction.Hubs;
using RentVilla.Application.Repositories.AttributeRepo;
using RentVilla.Application.Repositories.ProductRepo;
using RentVilla.Application.Repositories.RegionRepo;
using RentVilla.Domain.Entities.Concrete.Attribute;
using RentVilla.Domain.Entities.Concrete.Region;

namespace RentVilla.Application.Feature.Commands.Products.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>
    {
        private readonly IProductWriteRepository _productWriteRepository;
        private readonly IAttributeReadRepository _attributeReadRepository;
        readonly ILogger<CreateProductCommandHandler> _logger;
        private readonly IProductHubService _hubService;
        private readonly IDistrictReadRepository _districtReadRepository;

        public CreateProductCommandHandler(IProductWriteRepository productWriteRepository, IAttributeReadRepository attributeReadRepository, ILogger<CreateProductCommandHandler> logger, IProductHubService hubService, IDistrictReadRepository districtReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _attributeReadRepository = attributeReadRepository;
            _logger = logger;
            _hubService = hubService;
            _districtReadRepository = districtReadRepository;
        }

        public async Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var attributes  = _attributeReadRepository.AppDbContext.Where(a => request.AttributeIds.Contains(a.Id.ToString())).Include(a => a.AttributeType).ToList();
            List<ProductAttribute> productAttributes = new();
            foreach (var attribute in attributes)
            {
                productAttributes.Add(new()
                {
                    Attributes = attribute
                });
            }
            ProductAddress productAddress = new()
            {
                District = await _districtReadRepository.GetSingleAsync(d => d.Id == Guid.Parse(request.ProductAddress.DistrictId))
            };

            await _productWriteRepository.AddAsync(new()
            {
                Name = request.Name,
                Price = request.Price,
                Deposit = request.Deposit,
                Description = request.Description,
                Address = request.Address,
                MapId = request.MapId,
                Properties = request.Properties,
                ShortestRentPeriod = request.ShortestRentPeriod,
                Attributes = productAttributes,
                ProductAddress = productAddress
            });
            await _productWriteRepository.SaveAsync();
            _logger.LogInformation("Product created successfully");
            await _hubService.ProductAddedMessageAsync($"{request.Name} named product created successfully");
            return new();
        }
    }
}
