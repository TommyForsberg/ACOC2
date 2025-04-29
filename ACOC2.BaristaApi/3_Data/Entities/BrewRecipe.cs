namespace ACOC2.BaristaApi._3_Data.Entities
{
    public class BrewRecipe
    {
        public int Id { get; set; }
        public int BrewTimeSeconds { get; set; }
        public int TemperatureCelsius { get; set; }

        public int CoffeeProductId { get; set; }
        public CoffeeProduct CoffeeProduct { get; set; } = null!;
    }
}
