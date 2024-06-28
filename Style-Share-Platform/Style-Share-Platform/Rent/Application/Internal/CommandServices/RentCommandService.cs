using Style_Share_Platform.Rent.Domain.Model.Commands;
using Style_Share_Platform.Rent.Domain.Repositories;
using Style_Share_Platform.Rent.Domain.Services;
using Style_Share_Platform.Shared.Domain.Repositories;

namespace Style_Share_Platform.Rent.Application.Internal.CommandServices;

public class RentCommandService (IRentRepository rentRepository ,
    IUnitOfWork unitOfWork) : IRentCommandService
    {


        public async Task<Domain.Model.Aggregates.Rent?> Handle(CreateRentCommand command)
        {
            
                /*
            if (!Enum.TryParse(command.state, out State state))
            {
                throw new ArgumentException($"Invalid state value: {command.state}");
            }
            */
                
            var rent = new Domain.Model.Aggregates.Rent(command.cartId, command.shippingId, command.userId, command.rental_date);
            await rentRepository.AddAsync(rent);
            await unitOfWork.CompleteAsync();
            return rent;
        }
    }
                                                        