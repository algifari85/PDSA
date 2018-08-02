using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PDSA.Models
{
    public class Problem
    {
        public int ProblemID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Etiologi> Etiologis { get; set; }
        public List<Solution> Solutions{ get; set; }
        public List<Measurement> Measurements { get; set; }
    }

    public class Etiologi
    {
        public int EtiologiID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
    public class Solution
    {
        public int SolutionID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DoStartTime { get; set; }
        public DateTime DoEndTime { get; set; }
    }
    public class Measurement
    {
        public int MeasurementID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DoStartTime { get; set; }
        public DateTime DoEndTime { get; set; }
        // Unit should be a separate class
        public string Unit { get; set; }
        public decimal PretestValue { get; set; }
        public decimal PosttestValue { get; set; }
    }
    public class Evaluation
    {
        public int EvaluationID { get; set; }
        //Utvärdering 0,0 - 10,0
        public decimal EvaluationScore { get; set; }
    }
}
