using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PDSA.Models;

namespace PDSA.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public int UnitID { get; set; }
        public List<Unit> Units { get; set; }
        private readonly PDSAContext _context;
        public IndexModel(PDSAContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            Units = _context.Units.ToList();
            
        }
    }
}
