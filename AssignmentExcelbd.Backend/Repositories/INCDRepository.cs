using AssignmentExcelbd.Shared;

namespace AssignmentExcelbd.Backend.Repositories
{
    public interface INCDRepository
    {
        Task<IEnumerable<NCD>> GetNCDs();
    }
}
