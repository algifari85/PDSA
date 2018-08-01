using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PDSA.Models;
using Microsoft.EntityFrameworkCore;
namespace PDSA.Pages.WorkUnit.WorkProcess
{
    public class IndexModel : PageModel
    {
        public Process Process { get; set; }
        [BindProperty]
        [HiddenInput]
        public int SelectedProcess { get; set; }
        [BindProperty]
        [HiddenInput]
        public int UnitID { get; set; }
        [BindProperty]
        public Problem NewProblem { get; set; }
        private readonly PDSAContext _context;

        public IndexModel(PDSAContext context)
        {
            _context = context;
        }
        public void OnGet(int ProcessID, int UnitID)
        {
            this.UnitID = UnitID;
            SelectedProcess = ProcessID;
            Process = _context.Processes.Include(p => p.Problems).Single(p => p.ProcessID == ProcessID);
        }
        
        public ActionResult OnPostNewProblem(int SelectedProcess)
        {
            var ProcessUpdate = _context.Processes.Include(p => p.Problems).Single(p => p.ProcessID == SelectedProcess);
            ProcessUpdate.Problems.Add(NewProblem);
            _context.Processes.Update(ProcessUpdate);
            _context.SaveChanges();

            return RedirectToPage(new { ProcessID = ProcessUpdate.ProcessID,UnitID = UnitID });
        }
    }
}