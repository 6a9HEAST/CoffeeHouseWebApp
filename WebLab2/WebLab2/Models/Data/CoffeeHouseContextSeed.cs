namespace WebLab2.Models
{
    public static class CoffeeHouseContextSeed
    {
        public static async Task SeedAsync(CoffeeHouseContext context)
        {
            try
            {
                context.Database.EnsureCreated();
                if (context.Products.Any()) 
                    return;
                var products = new Product[]
                {
                    new Product{Name = "Капучино", Price = 100,Type="Кофе",ImageAdress="https://bogatyr.club/uploads/posts/2023-03/1678182068_bogatyr-club-p-kofe-kapuchino-foni-krasivo-57.png"},
                    new Product{Name = "Эспрессо", Price = 80,Type="Кофе",ImageAdress="https://pixy.org/src2/582/5825313.jpg"},
                };
                foreach (var p in products)
                {
                    context.Products.Add(p);
                }
                await context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}
