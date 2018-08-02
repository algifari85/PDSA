using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PDSA.Models;

namespace PDSA.Pages.WorkUnit
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        [HiddenInput]
        public int DeleteProcessID { get; set; }
        [BindProperty]
        [HiddenInput]
        public Unit SelectedUnit { get; set; }
        [BindProperty]
        [HiddenInput]
        public int UnitID { get; set; }
        [BindProperty]
        public Process NewProcess { get; set; }
        public List<Process> Processes { get; set; }
        private readonly PDSAContext _context;
        public IndexModel(PDSAContext context)
        {
            _context = context;
        }
        public void OnGet(int UnitID)
        {
            this.UnitID = UnitID;
            this.SelectedUnit = _context.Units.Include(p => p.Processes).Single(p => p.UnitID == UnitID);
        }

        public ActionResult OnPostAddProcess(int UnitID)
        {
            SelectedUnit = _context.Units.Single(p => p.UnitID == UnitID);
            _context.Entry(SelectedUnit).Collection(u => u.Processes).Load();
            SelectedUnit.Processes.Add(NewProcess);
            _context.Update(SelectedUnit);
            _context.SaveChanges();
            return RedirectToPage(new { UnitID = UnitID });
        }
        public ActionResult OnPostDeleteProcess()
        {
            var deleteItem  = _context.Processes.Include(p => p.Problems)
                .Single(p => p.ProcessID == this.DeleteProcessID);
            _context.Processes.Remove(deleteItem);
            _context.SaveChanges();
            return RedirectToPage(new { UnitID = UnitID});
        }
    }
}