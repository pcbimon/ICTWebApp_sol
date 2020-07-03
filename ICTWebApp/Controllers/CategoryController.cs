using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ICTWebApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ICTWebApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var category = await _context.Categories.ToListAsync();
            return View(category);
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
