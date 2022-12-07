using RestaurantStoreHub.Entities;

namespace RestaurantStoreHub
{
    public class RestaurantSeeder
    {
        private readonly RestaurantDbContext _dbContext;

        public RestaurantSeeder(RestaurantDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public RestaurantDbContext Get_dbContext()
        {
            return _dbContext;
        }

        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Restaurants.Any())
                {
                    var restaurants = GetRestaurants();
                    _dbContext.Restaurants.AddRange(restaurants);
                    _dbContext.SaveChanges();
                }
            }
        }
        private IEnumerable<Restaurant> GetRestaurants()
        {
            var restaurants = new List<Restaurant>()
            {
                new Restaurant()
                {
                    Name = "KFC",
                    Category = "Fast Food",
                    Description = "KFC is an American fast food restaurant chain headquartered in Louisville, Kentucky, that specializes in fried chicken.",
                    ContactEmail = "contact@kfc.com",
                    HasDelivery = true,
                    Dishes = new List<Dish>()
                    {
                        new Dish()
                        {
                            Name = "Grander",
                            Price = 26.99M,
                        },

                        new Dish()
                        {
                            Name = "Mega Pocket Big Box",
                            Price = 38.99M,
                        },

                        new Dish()
                        {
                            Name = "Kubełek 30 Strips",
                            Price = 81.99M,
                        },

                        new Dish()
                        {
                            Name = "Kubełek frytek",
                            Price = 12.99M,
                        },
                    },
                    Address = new Address()
                    {
                        City = "Gdańsk",
                        Street = "aleja Jana Pawła II 19",
                        PostalCode = "80-462"
                    }
                },
                new Restaurant()
                {
                    Name = "NOI pizza i wino",
                    Category = "Pizza",
                    Description = "NOI in Italian means WE, and WE love pizza and good wine. Our love has created a place to which we want to invite you. Our menu also includes dishes such as: soups, salads, pastas and burgers.",
                    ContactEmail = "noipizza.biuro@gmail.com",
                    HasDelivery = true,
                    Dishes = new List<Dish>()
                    {
                        new Dish()
                        {
                            Name = "Pizza Margherita",
                            Price = 24.00M,
                        },

                        new Dish()
                        {
                            Name = "Pizza Quattro Formaggi",
                            Price = 36.00M,
                        },

                        new Dish()
                        {
                            Name = "Pizza Tartufo",
                            Price = 33.00M,
                        },

                        new Dish()
                        {
                            Name = "Pizza Cipolla Caramellata",
                            Price = 37.00M,
                        },
                    },
                    Address = new Address()
                    {
                        City = "Gdansk",
                        Street = "ul. Obrońców Wybrzeża 3C/U13-14",
                        PostalCode = "80-398"
                    }
                }
            };
            return restaurants;
        }
    }
}

