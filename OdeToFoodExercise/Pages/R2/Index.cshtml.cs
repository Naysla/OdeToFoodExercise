using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OdeToFoodExercise.Core;
using OdeToFoodExercise.Data;

namespace OdeToFoodExercise.Pages.R2
{
    public class IndexModel : PageModel
    {
        private readonly OdeToFoodExercise.Data.OdeToFoodExerciseDBContext _context;

        public IndexModel(OdeToFoodExercise.Data.OdeToFoodExerciseDBContext context)
        {
            _context = context;
        }

        public IList<Restaurant> Restaurant { get;set; }

        public async Task OnGetAsync()
        {
            Restaurant = await _context.Restaurants.ToListAsync();
        }
    }
}
