﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Wba.StovePalace.Data;
using Wba.StovePalace.Models;

namespace Wba.StovePalace.Pages.Fuels
{
    public class DetailsModel : PageModel
    {
        private readonly Wba.StovePalace.Data.StoveContext _context;

        public DetailsModel(Wba.StovePalace.Data.StoveContext context)
        {
            _context = context;
        }

      public Models.Fuel Fuel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Fuel == null)
            {
                return NotFound();
            }

            var fuel = await _context.Fuel.FirstOrDefaultAsync(m => m.Id == id);
            if (fuel == null)
            {
                return NotFound();
            }
            else 
            {
                Fuel = fuel;
            }
            return Page();
        }
    }
}
