using OdeToFoodExercise.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace OdeToFoodExercise.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
        Restaurant GetById(int id);
    }
    public class InMemoryRestaurantData : IRestaurantData

    {
        readonly List<Restaurant> restaurants;        

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant { Id = 1, Name = "Magic Pizza", Location = "Bogotá", Cuisine = CuisineType.Indian },
                new Restaurant { Id = 2, Name = "La Italiana", Location = "Bogotá", Cuisine = CuisineType.Italian },
                new Restaurant { Id = 3, Name = "Tacos Mex", Location = "Bogotá", Cuisine = CuisineType.Mexican }
            };
        }

        public Restaurant GetById(int id)
        {
            return restaurants.SingleOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restaurant> GetRestaurantsByName( string name=null)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }
    }
}
