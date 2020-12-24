using Microsoft.EntityFrameworkCore;
using OdeToFoodExercise.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace OdeToFoodExercise.Data
{
    public class OdeToFoodExerciseDBContext : DbContext
    {
        public OdeToFoodExerciseDBContext(DbContextOptions<OdeToFoodExerciseDBContext> options)
            :base(options)
        {
                
        }
        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
