using ACOC2.BaristaApi._3_Data;
using ACOC2.BaristaApi._3_Data.Entities;
using Grpc.Core;
using Microsoft.EntityFrameworkCore;

namespace ACOC2.BaristaApi._2_Domain
{
    public class BaristaGrpcService : BaristaService.BaristaServiceBase
    {
        private readonly BaristaDbContext _db;

        public BaristaGrpcService(BaristaDbContext db)
        {
            _db = db;
        }

        public override async Task<ListCoffeesResponse> ListCoffees(ListCoffeesRequest request, ServerCallContext context)
        {
            var coffees = await _db.CoffeeProducts
                .Select(c => new CoffeeDto
                {
                    Id = c.Id,
                    Name = c.Name,
                 //   BrewTimeSeconds = c.BrewTimeSeconds
                })
                .ToListAsync();

            return new ListCoffeesResponse { Coffees = { coffees } };
        }

        public override async Task<CoffeeDto> GetCoffeeById(GetCoffeeByIdRequest request, ServerCallContext context)
        {
            var coffee = await _db.CoffeeProducts.FindAsync(request.Id);

            if (coffee == null)
                throw new Exception();

            return new CoffeeDto
            {
                Id = coffee.Id,
                Name = coffee.Name,
               // BrewTimeSeconds = coffee.BrewTimeSeconds
            };
        }

        public override async Task<CoffeeDto> CreateCoffee(CreateCoffeeRequest request, ServerCallContext context)
        {
            var coffee = new CoffeeProduct
            {
                Name = request.Name,
               // BrewTimeSeconds = request.BrewTimeSeconds
            };

            _db.CoffeeProducts.Add(coffee);
            await _db.SaveChangesAsync();

            return new CoffeeDto
            {
                Id = coffee.Id,
                Name = coffee.Name,
             //   BrewTimeSeconds = coffee.BrewTimeSeconds
            };
        }
    }

}
