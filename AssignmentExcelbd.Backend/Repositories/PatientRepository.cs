using AssignmentExcelbd.Backend.Data;
using AssignmentExcelbd.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace AssignmentExcelbd.Backend.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly ApplicationDbContext _context;

        public PatientRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        //create
        public async Task CreatePatientInfo(PatientInfo patientInfo)
        {
            if (patientInfo == null)
            {
                throw new ArgumentNullException(nameof(patientInfo));
            }

            _context.Add(patientInfo);
            await _context.SaveChangesAsync();
        }


        //delete
        
        public async Task DeletePatientInfo(PatientInfo patientInfo)
        {
            if (patientInfo == null)
            {
                throw new ArgumentNullException(nameof(patientInfo));
            }

            _context.Remove(patientInfo);
            await _context.SaveChangesAsync();
        }

        
        //edit
        public async Task EditPatientInfo(PatientInfo patientInfo)
        {
            if (patientInfo == null)
            {
                throw new ArgumentNullException(nameof(patientInfo));
            }

            _context.Update(patientInfo);
            await _context.SaveChangesAsync();
        }

        
        //get by id
        public async Task<PatientInfo> GetPatientByID(int id)
        {
            return await _context.PatientInfos
                .Include(r=> r.Diseases)
                .Include(p => p.NCD_Details)
                    .ThenInclude(nd => nd.NCD)
                .Include(p => p.Allergies_Details)
                    .ThenInclude(ad => ad.Allergies)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        //get all patients
        public async Task<IEnumerable<PatientInfo>> GetPatients()
        {
            return await _context.PatientInfos
                .Include(r=> r.Diseases)
                .Include(p => p.NCD_Details)
                    .ThenInclude(nd => nd.NCD)
                .Include(p => p.Allergies_Details)
                    .ThenInclude(ad => ad.Allergies)
                .ToListAsync();
        }
    }
}
