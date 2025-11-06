namespace ContosoPizza.Data;

public static class ContosoPizzaContextSeed
    {
        public static async Task SeedAsync(ContosoPizzaContext context)
        {
            if (!context.Pizzas.Any())
            {
                var pizzas = new List<Models.Pizza>
                    {
                        new Models.Pizza { Name = "Margherita", IsGlutenFree = false },
                        new Models.Pizza { Name = "Pepperoni", IsGlutenFree = false },
                        new Models.Pizza { Name = "Four Cheese", IsGlutenFree = true },
                        new Models.Pizza { Name = "Neapolitan", IsGlutenFree = false },
                        new Models.Pizza { Name = "Vegetarian", IsGlutenFree = true }
                    };

                context.Pizzas.AddRange(pizzas);
                await context.SaveChangesAsync();
            }
        }
    }
