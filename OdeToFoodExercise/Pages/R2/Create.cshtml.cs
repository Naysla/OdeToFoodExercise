using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OdeToFoodExercise.Core;
using OdeToFoodExercise.Data;

namespace OdeToFoodExercise.Pages.R2
{
    public class CreateModel : PageModel
    {
        private readonly OdeToFoodExercise.Data.OdeToFoodExerciseDBContext _context;

        public CreateModel(OdeToFoodExercise.Data.OdeToFoodExerciseDBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Restaurant Restaurant { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Restaurants.Add(Restaurant);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}