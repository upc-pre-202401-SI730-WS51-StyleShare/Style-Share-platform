using StyleShare.Platform.API.Rent.Domain.Model.Commands;
using StyleShare.Platform.API.Rent.Domain.Repositories;
using StyleShare.Platform.API.Rent.Domain.Services;
using StyleShare.Platform.API.Shared.Domain.Repositories;
using System.Threading.Tasks;
using StyleShare.Platform.API.Rent.Domain.Model.ValueObjects;

namespace StyleShare.Platform.API.Rent.Application.Internal.CommandServices
{
    public class RentCommandService : IRentCommandService
    {
        private readonly IRentRepository _rentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RentCommandService(IRentRepository rentRepository, IUnitOfWork unitOfWork)
        {
            _rentRepository = rentRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Domain.Model.Aggregates.Rent?> Handle(CreateRentCommand command)
        {
            var cartId = new CartId(command.cartId);
            var shippingId = new ShippingId(command.shippingId);
            var userId = new UserId(command.userId);

            if (!Enum.TryParse(command.state, out State state))
            {
                throw new ArgumentException($"Invalid state value: {command.state}");
            }

            var rental_date = Date.Parse(command.rental_date);

            var rent = new Domain.Model.Aggregates.Rent(cartId, shippingId, userId, state, rental_date);
            await _rentRepository.AddAsync(rent);
            await _unitOfWork.CompleteAsync();
            return rent;
        }
    }
                                                        }
