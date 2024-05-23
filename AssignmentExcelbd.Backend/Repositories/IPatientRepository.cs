using AssignmentExcelbd.Shared;

namespace AssignmentExcelbd.Backend.Repositories
{
    public interface IPatientRepository
    {
        Task<IEnumerable<PatientInfo>> GetPatients();
        Task<PatientInfo> GetPatientByID(int id);
        Task CreatePatientInfo(PatientInfo patientInfo);
        Task EditPatientInfo(PatientInfo patientInfo);
        Task DeletePatientInfo(PatientInfo patientInfo);
    }
}
