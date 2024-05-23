using AssignmentExcelbd.Backend.Data;
using AssignmentExcelbd.Shared;
using Microsoft.EntityFrameworkCore;

namespace AssignmentExcelbd.Backend.Repositories
{
    public class DiseaseRepository : IDiseaseRepository
    {
        private readonly ApplicationDbContext context;

        public DiseaseRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<DiseasesInfo>> GetDiseases()
        {
            return await context.Diseases.ToListAsync();
        }

     
    }
}
