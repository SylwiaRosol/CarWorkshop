using CarWorkshop.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Infrastructure.Seeders
{
    public class CarWorkshopSeeder
    {
        private readonly CarWorkshopDbContext _dbContext;
        public CarWorkshopSeeder(CarWorkshopDbContext dbContext)
        {

            _dbContext = dbContext;
        }
        public async Task Seed()
        {
            if (await _dbContext.Database.CanConnectAsync())
            {
                if (!_dbContext.CarWorkshop.Any())
                {
                    var autoRepair = new Domain.Entities.CarWorkshop()
                    {

                        Name = "Joe's Auto Repair",
                        Description = "Expert auto repair services for all makes and models.",
                        ContactDetails = new()
                        {
                            PhoneNumber = "555-123-334",
                            Street = "123 Main St",
                            City = "Springfield",
                            PostalCode = "12-405"
                        }
                    };

                    autoRepair.EncodeName();
                    _dbContext.CarWorkshop.Add(autoRepair);
                    await _dbContext.SaveChangesAsync();

                }
            }
        }
    }
}

