using AssignmentExcelbd.Shared;
using System.ComponentModel.DataAnnotations;

namespace AssignmentExcelbd.Front.Models
{
    public class PatientViewModel
    {
        public int ID { get; set; }
        [Required]
        public string? Name { get; set; }
        public PatientInfo? PatientInfo { get; set; }
        [Required]
        public int? DiseasesId { get; set; }
        public List<DiseasesInfo>? Diseases { get; set; }
        [Required]
        public string? IsEpilepsy { get; set; }

        public List<string>? Epilepsies { get; set; }

        public List<int>? SelectedNCD_Details { get; set; } = new List<int>();
        public List<int>? SelectedAllergies_Details { get; set; } = new List<int>();

        public List<Allergies>? Allergies { get; set; } = new List<Allergies>();
        public List<NCD>? NCDs { get; set; } = new List<NCD>();
    }
}
