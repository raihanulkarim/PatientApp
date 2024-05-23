using AssignmentExcelbd.Backend.Repositories;
using AssignmentExcelbd.Shared;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace AssignmentExcelbd.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientRepository _patientRepository;

        public PatientsController(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        #region fetchpatients

        [HttpGet]
        //api/patients
        public async Task<ActionResult<PatientInfo>> GetPatients()
        {
            try
            {
                var patients = await _patientRepository.GetPatients();

                return Ok(patients);
            }
            catch (Exception ex)
            {
                return BadRequest("Error while getting patients information. Message:" + ex.Message);
            }
        }
        //api/patients/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<PatientInfo>> GetPatient(int id)
        {
            try
            {
                var patient = await _patientRepository.GetPatientByID(id);

                if (patient == null)
                {
                    return NotFound($"Data with the Patient Id {id} not found");
                }

                return Ok(patient);
            }
            catch (Exception ex)
            {
                return BadRequest("Error while getting patient information. Message:" + ex.Message);
            }
        }
        #endregion
       
        #region Create, update and delete patients
        //api/patients/Create/
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] PatientInfo patientInfo)
        {
            try
            {
                if (patientInfo == null)
                {
                    return BadRequest("Invalid patient information provided.");
                }

                _patientRepository.CreatePatientInfo(patientInfo);

                return Ok("Patient Info Added Successfully!");
            }
            catch (Exception ex)
            {
                return BadRequest("Error in creating patient info; Message:" + ex.Message);
            }
        }

        //api/patients/update/{id}
        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PatientInfo patientInfo)
        {
            try
            {
                if (patientInfo == null)
                {
                    return BadRequest("Invalid patient information provided.");
                }

                var existingPatient = await _patientRepository.GetPatientByID(id);

                if (existingPatient == null)
                {
                    return NotFound($"Patient with ID {id} not found.");
                }

                // Update basic properties
                existingPatient.Name = patientInfo.Name;
                existingPatient.DiseasesId = patientInfo.DiseasesId;
                existingPatient.IsEpilepsy = patientInfo.IsEpilepsy;
                

                // Update NCD details
                if (patientInfo.NCD_Details != null)
                {
                    // Clear existing NCD details 
                    existingPatient.NCD_Details.Clear();

                    foreach (var ncdDetail in patientInfo.NCD_Details)
                    {
                        var newNcdDetail = new NCD_Details
                        {
                            NCDId = ncdDetail.NCDId,
                            PatientId = existingPatient.Id,
                        };
                        existingPatient.NCD_Details.Add(newNcdDetail);
                    }
                }

                // Update allergy details
                if (patientInfo.Allergies_Details != null)
                {
                    // Clear existing allergy details 
                    existingPatient.Allergies_Details.Clear();

                    foreach (var allergyDetail in patientInfo.Allergies_Details)
                    {
                        var newAllergyDetail = new Allergies_Details
                        {
                            AllergiesId = allergyDetail.AllergiesId,
                            PatientId = existingPatient.Id,
                        };
                        existingPatient.Allergies_Details.Add(newAllergyDetail);
                    }
                }

                await _patientRepository.EditPatientInfo(existingPatient);

                return Ok("Patient Info Updated Successfully!");
            }
            catch (Exception ex)
            {
                return BadRequest("Error in updating patient info; Message:" + ex.Message);
            }
        }


        //api/patients/delete/{id}
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<PatientInfo>> DeletePatient(int id)
        {
            try
            {
                var patient = await _patientRepository.GetPatientByID(id);

                if (patient == null)
                {
                    return NotFound($"Data with the Patient Id {id} not found");
                }

                await _patientRepository.DeletePatientInfo(patient);
                return Ok("PatientInfo Deleted Successfully!");
            }
            catch (Exception ex)
            {
                return BadRequest("Error while deleting patient information. Message:" + ex.Message);
            }
        }
        #endregion

    }
}
