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
    public class DetailsModel : PageModel
    {
        private readonly OdeToFoodExercise.Data.OdeToFoodExerciseDBContext _context;

        public DetailsModel(OdeToFoodExercise.Data.OdeToFoodExerciseDBContext context)
        {
            _context = context;
        }

        public Restaurant Restaurant { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Restaurant = await _context.Restaurants.FirstOrDefaultAsync(m => m.Id == id);

            if (Restaurant == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
