using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ICTWebApp.Data;
using ICTWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using ReflectionIT.Mvc.Paging;

namespace ICTWebApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(string filter,int page = 1, string sortExpression="-CategoryID")
        {
            //var category = await _context.Categories.ToListAsync();
            //var category = await _context.Categories.FromSqlRaw("select * from Categories;").ToListAsync();
            //ViewBag.CategoryCount = await _context.Categories.CountAsync();

            var qry = _context.Categories.AsNoTracking().AsQueryable();
            if (!string.IsNullOrWhiteSpace(filter))
            {
                qry = qry.Where(c => EF.Functions.Like(c.CategoryName, $"%{filter}%"));
            }

            var categoryViewModel = await PagingList.CreateAsync(qry, 3, page, sortExpression, "CategoryID");
            categoryViewModel.RouteValue = new RouteValueDictionary
            {
                {"filter",filter}
            };
            
            return View(categoryViewModel);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }
            //insert
            await _context.AddAsync(category);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id,Category category)
        {
            if (id != category.CategoryID)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return View(category);
            }

            _context.Update(category);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            _context.Remove(category);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
