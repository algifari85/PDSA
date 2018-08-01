using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PDSA.Models;
namespace PDSA.Pages.Admin
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public Unit NewUnit { get; set; }
        public List<Unit> Units { get; set; }
        private readonly PDSAContext _context;
        public IndexModel(PDSAContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            Units = _context.Units.ToList().OrderBy(p => p.UnitName).ToList();
        }

        public ActionResult OnPostNewUnit()
        {
            _context.Units.Add(NewUnit);
            _context.SaveChanges();
            return RedirectToPage("/Admin/Index");
        }
    }
}