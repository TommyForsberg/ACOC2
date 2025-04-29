using Microsoft.EntityFrameworkCore;

namespace ACOC2.BaristaApi._3_Data.Entities
{
    public class CoffeeProduct
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        [Precision(18, 2)]
        public decimal Price { get; set; }

        public BrewRecipe? BrewRecipe { get; set; }
    }
}
