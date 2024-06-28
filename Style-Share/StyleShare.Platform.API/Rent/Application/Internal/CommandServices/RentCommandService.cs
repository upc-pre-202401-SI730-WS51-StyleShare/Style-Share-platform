using System.Runtime.InteropServices.JavaScript;
using StyleShare.Platform.API.Rent.Domain.Model.Commands;
using StyleShare.Platform.API.Rent.Domain.Repositories;
using StyleShare.Platform.API.Rent.Domain.Services;
using StyleShare.Platform.API.Shared.Domain.Repositories;
using System.Threading.Tasks;
using StyleShare.Platform.API.Rent.Domain.Model.ValueObjects;

namespace StyleShare.Platform.API.Rent.Application.Internal.CommandServices;

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
                                                        