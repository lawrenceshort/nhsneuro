using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nhsneuro.Models
{
    public class ConditionModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int? SnowMedID { get; set; }
        public bool? IsRare { get; set; }
        public IEnumerable<string> Symptoms { get; set; }
    }
}