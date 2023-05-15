using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using NorthwindEntitiesLib;
using System.Linq;
using Microsoft.AspNetCore.Mvc;


namespace northwindapp
{
    public class SuppliersModel : PageModel
    {
        private Northwind db;
        public SuppliersModel(Northwind injectedContext)
        {
            db = injectedContext;
        }

        [BindProperty]
        public Supplier Supplier { get; set; }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                db.Suppliers.Add(Supplier);
                db.SaveChanges();
                return RedirectToPage("/suppliers");
            }
            return Page();
        }
        public IEnumerable<string> Suppliers { get; set; }
        public void OnGet()
        {
            ViewData["Title"] = "Northwind Web Site - Suppliers";
           Suppliers = db.Suppliers.Select(s => s.CompanyName);
        }
    } 

    }
