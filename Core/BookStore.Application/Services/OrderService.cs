using BookStore.Domain.Dto.Order;
using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces.Repositories;
using BookStore.Domain.Interfaces.Services;
using BookStore.Warehouse.Client.Services;
using MapsterMapper;
using Serilog;
using SimpleResults;
//using Warehouse.Client.Interfaces;
//using WhOrder = Warehouse.Client.Dtos.OrderDto;

namespace BookStore.Application.Services
{
    public class OrderService : IOrderService
	{
		private readonly IOrderRepository _repository;
		private readonly IMapper _mapper;
		private readonly ILogger _logger;
		private readonly IWarehouseService _warehouseService;

		public OrderService(IOrderRepository repository, IMapper mapper, ILogger logger,
			IWarehouseService warehouseService)
		{
			_repository = repository;
			_mapper = mapper;
			_logger = logger.ForContext<OrderService>();
			_warehouseService = warehouseService;
		}

		public async Task<Result<OrderDto>> CreateOrderAsync(CreateOrderDto createOrderDto, CancellationToken cancellationToken)
		{
			var order = _mapper.Map<Order>(createOrderDto);
			order = await _repository.CreateAsync(order, cancellationToken);
			_logger.Information("Создан новый заказ с ИД={order.Id}", order.Id);

			var warehouseOrderDto = _mapper.Map<BookStore.Warehouse.Client.Dtos.OrderDto>(order);		
			_warehouseService.ProcessOrder(warehouseOrderDto);

			return _mapper.Map<OrderDto>(order);
		}

		public async Task<Result<OrderDto>> GetOrderByIdAsync(int id, CancellationToken cancellationToken)
		{
			var order = await _repository.GetByIdAsync(id, cancellationToken);

			return _mapper.Map<OrderDto>(order);
		}
	}
}
