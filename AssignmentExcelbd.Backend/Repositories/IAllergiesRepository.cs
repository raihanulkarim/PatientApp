using AssignmentExcelbd.Shared;

namespace AssignmentExcelbd.Backend.Repositories
{
    public interface IAllergiesRepository
    {
        Task<IEnumerable<Allergies>> GetAllergies();
    }
}
