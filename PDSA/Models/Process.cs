using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PDSA.Models
{
    public class Process
    {
        public int ProcessID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Unit ProcessUnit { get; set; }
        public List<Problem> Problems { get; set; }

    }
    public class Unit
    {
        public int UnitID { get; set; }
        public string UnitName { get; set; }
        public List<Process> Processes { get; set; }
    }
}
