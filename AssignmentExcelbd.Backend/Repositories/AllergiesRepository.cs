using AssignmentExcelbd.Backend.Data;
using AssignmentExcelbd.Shared;
using Microsoft.EntityFrameworkCore;

namespace AssignmentExcelbd.Backend.Repositories
{
    public class AllergiesRepository : IAllergiesRepository
    {
        private readonly ApplicationDbContext _context;

        public AllergiesRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Allergies>> GetAllergies()
        {
            return await _context.Allergies.ToListAsync();
        }

    }
}
