using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentExcelbd.Shared
{
    public class PatientInfo
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? DiseasesId { get; set; }
        public DiseasesInfo? Diseases { get; set; }
        public string? IsEpilepsy { get; set; }

        public ICollection<NCD_Details>? NCD_Details { get; set; }
        public ICollection<Allergies_Details>? Allergies_Details { get; set; }
    }
}
