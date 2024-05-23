using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentExcelbd.Shared
{
    public class Allergies_Details
    {
        public int Id { get; set; }
        public int AllergiesId { get; set; }
        public Allergies? Allergies { get; set; }
        public int PatientId { get; set; }
        public PatientInfo? Patient { get; set; }

    }
   
}
