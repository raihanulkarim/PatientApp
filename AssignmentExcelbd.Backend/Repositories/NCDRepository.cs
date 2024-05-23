using AssignmentExcelbd.Backend.Data;
using AssignmentExcelbd.Shared;
using Microsoft.EntityFrameworkCore;

namespace AssignmentExcelbd.Backend.Repositories
{
    public class NCDRepository : INCDRepository
    {
        private readonly ApplicationDbContext context;

        public NCDRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<NCD>> GetNCDs()
        {
            return await context.NCDs.ToListAsync();
        }
    }
}
