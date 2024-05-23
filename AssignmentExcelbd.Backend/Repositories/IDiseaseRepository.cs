using AssignmentExcelbd.Shared;

namespace AssignmentExcelbd.Backend.Repositories
{
    public interface IDiseaseRepository
    {
        Task <IEnumerable<DiseasesInfo>> GetDiseases();

    }
}
