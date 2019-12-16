using OdeToFood.Core;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        readonly List<Restaurant> restaurants;
        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant { Id = 1, Name = "Scott's Pizza", Location = "London", Cuisine=CuisineType.Italian},
                new Restaurant { Id = 2, Name = "Dan's Curries", Location = "Manchester", Cuisine=CuisineType.Indian},
                new Restaurant { Id = 3, Name = "Pedros", Location = "Norwich", Cuisine = CuisineType.Mexican}
            };
        }
        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {
            return from r in restaurants
                  where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                  orderby r.Name
                  select r;
        }
    }
}
