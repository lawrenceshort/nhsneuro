using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nhsneuro.Models
{
    public class SymptomModel
    {
        public int SymptomId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? SnoMedId { get; set; }
    }
}