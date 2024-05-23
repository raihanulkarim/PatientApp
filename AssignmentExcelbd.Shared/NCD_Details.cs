using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentExcelbd.Shared
{
    public class NCD_Details
    {
        public int Id { get; set; }
        public int NCDId { get; set; }
        public NCD? NCD { get; set; }
        public int PatientId { get; set; }
        public PatientInfo? Patient { get; set; }

    }
}
