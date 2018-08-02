using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PDSA.Models;

namespace PDSA.Pages.WorkUnit.WorkProcess
{
    public class EditModel : PageModel
    {
        private readonly PDSAContext _context;

        [BindProperty]
        public Problem Problem { get; set; }
        public EditModel(PDSAContext context)
        {
            _context = context;
        }
        public void OnGet(int UnitID, int ProcessID, int ProblemID)
        {
            Problem = _context.Problems.Single(p => p.ProblemID == ProblemID);
        }
    }
}