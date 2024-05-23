using AssignmentExcelbd.Front.Models;
using AssignmentExcelbd.Shared;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace AssignmentExcelbd.Front.Controllers
{
    public class HomeController : Controller
    {
        string baseUrl;

        public HomeController()
        {
            baseUrl = "https://localhost:7164/";
        }

        public async Task<IActionResult> Index()
        {
            List<PatientInfo> patients = new List<PatientInfo>();
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri(baseUrl);
                    HttpResponseMessage httpResponse = await httpClient.GetAsync("api/patients/");

                    if (httpResponse.IsSuccessStatusCode)
                    {
                        var res = await httpResponse.Content.ReadAsStringAsync();
                        patients = JsonConvert.DeserializeObject<List<PatientInfo>>(res);
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Failed to retrieve patient details. Status code: " + httpResponse.StatusCode);
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                ModelState.AddModelError(string.Empty, "Failed to retrieve patient details. Error: " + ex.Message);
            }

            return View(patients);
        }

        private async Task<PatientViewModel> InitialViewModelAsync()
        {
            var newModel = new PatientViewModel();
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri(baseUrl);

                    // Fetch Diseases
                    HttpResponseMessage httpResponse = await httpClient.GetAsync("api/diseases/");
                    if (httpResponse.IsSuccessStatusCode)
                    {
                        var res = await httpResponse.Content.ReadAsStringAsync();
                        newModel.Diseases = JsonConvert.DeserializeObject<List<DiseasesInfo>>(res);
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Failed to retrieve diseases. Status code: " + httpResponse.StatusCode);
                    }

                    // Fetch Allergies
                    httpResponse = await httpClient.GetAsync("api/allergies/");
                    if (httpResponse.IsSuccessStatusCode)
                    {
                        var res = await httpResponse.Content.ReadAsStringAsync();
                        newModel.Allergies = JsonConvert.DeserializeObject<List<Allergies>>(res);
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Failed to retrieve allergies. Status code: " + httpResponse.StatusCode);
                    }

                    // Fetch NCDs
                    httpResponse = await httpClient.GetAsync("api/ncds/");
                    if (httpResponse.IsSuccessStatusCode)
                    {
                        var res = await httpResponse.Content.ReadAsStringAsync();
                        newModel.NCDs = JsonConvert.DeserializeObject<List<NCD>>(res);
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Failed to retrieve NCDs. Status code: " + httpResponse.StatusCode);
                    }

                    // Fetch Epilepsy
                    newModel.Epilepsies = Enum.GetValues(typeof(Epilepsy))
                               .Cast<Epilepsy>()
                               .Select(e => e.ToString())
                               .ToList();
                }
            }
            catch (HttpRequestException ex)
            {
                ModelState.AddModelError(string.Empty, "Failed to retrieve patient details. Error: " + ex.Message);
            }
            return newModel;
        }

        // Creating new patientinfo
        public async Task<IActionResult> Create()
        {
            // Fetch diseases, epilepsy, ncds, and allergies
            var viewModel = await InitialViewModelAsync();
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(PatientViewModel patient)
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    // Defining models from view model
                    var newPatient = new PatientInfo
                    {
                        Name = patient.Name,
                        IsEpilepsy = patient.IsEpilepsy,
                        DiseasesId = patient.DiseasesId,
                        NCD_Details = patient.SelectedNCD_Details.Select(id => new NCD_Details { NCDId = id }).ToList(),
                        Allergies_Details = patient.SelectedAllergies_Details.Select(id => new Allergies_Details { AllergiesId = id }).ToList()
                    };

                    // For creating new patientinfo data
                    httpClient.BaseAddress = new Uri(baseUrl);
                    HttpResponseMessage httpResponseMessage = await httpClient.PostAsJsonAsync("api/patients/Create", newPatient);

                    if (httpResponseMessage.IsSuccessStatusCode)
                    {
                        ViewBag.IsSuccess = true;
                        var viewModel = await InitialViewModelAsync();
                        return View(viewModel);
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Failed to create. Status code: " + httpResponseMessage.StatusCode);
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                ModelState.AddModelError(string.Empty, "Failed to create . Error: " + ex.Message);
            }

            return View(patient);
        }

        
        public async Task<IActionResult> Delete(int id)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(baseUrl);
                HttpResponseMessage httpResponse = await httpClient.DeleteAsync($"api/patients/delete/{id}");
                if (!httpResponse.IsSuccessStatusCode)
                {
                    ModelState.AddModelError(string.Empty, "Error deleting patient");
                }
            }

            return RedirectToAction(nameof(Index));
        }

        // Edit the patient info

        private async Task<PatientViewModel> GetPatientViewModelAsync(int id)
        {
            var viewModel = await InitialViewModelAsync();
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri(baseUrl);

                    // Fetch Patient info
                    HttpResponseMessage httpResponse = await httpClient.GetAsync($"api/patients/{id}");
                    if (httpResponse.IsSuccessStatusCode)
                    {
                        var res = await httpResponse.Content.ReadAsStringAsync();
                        var patient = JsonConvert.DeserializeObject<PatientInfo>(res);
                        viewModel.ID = patient.Id;
                        viewModel.Name = patient.Name;
                        viewModel.DiseasesId = patient.DiseasesId;
                        viewModel.IsEpilepsy = patient.IsEpilepsy;
                        viewModel.SelectedNCD_Details = patient.NCD_Details.Select(nd => nd.NCDId).ToList();
                        viewModel.SelectedAllergies_Details = patient.Allergies_Details.Select(ad => ad.AllergiesId).ToList();
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                ModelState.AddModelError(string.Empty, "Failed to retrieve patient details. Error: " + ex.Message);
            }
            return viewModel;
        }


        //edit patients 
        public async Task<IActionResult> Edit(int id)
        {
            var viewModel = await GetPatientViewModelAsync(id);
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PatientViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                var newModel = await InitialViewModelAsync();
                viewModel.Diseases = newModel.Diseases;
                viewModel.Allergies = newModel.Allergies;
                viewModel.NCDs = newModel.NCDs;
                viewModel.Epilepsies = newModel.Epilepsies;
                return View(viewModel);
            }

            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri(baseUrl);
                    var patient = new PatientInfo
                    {
                        Id = viewModel.ID,
                        Name = viewModel.Name,
                        DiseasesId = viewModel.DiseasesId,
                        IsEpilepsy = viewModel.IsEpilepsy,
                        NCD_Details = viewModel.SelectedNCD_Details.Select(id => new NCD_Details { NCDId = id }).ToList(),
                        Allergies_Details = viewModel.SelectedAllergies_Details.Select(id => new Allergies_Details { AllergiesId = id }).ToList()
                    };

                    var content = new StringContent(JsonConvert.SerializeObject(patient), System.Text.Encoding.UTF8, "application/json");
                    using (var response = await httpClient.PutAsync(baseUrl + "api/patients/update/" + viewModel.ID, content))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            ViewBag.IsSuccess = true;
                        }
                        else
                        {
                            ModelState.AddModelError(string.Empty, "Failed to update patient info. Status code: " + response.StatusCode);
                        }
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                ModelState.AddModelError(string.Empty, "Failed to update patient info. Error: " + ex.Message);
            }

            var refreshedModel = await InitialViewModelAsync();
            viewModel.Diseases = refreshedModel.Diseases;
            viewModel.Allergies = refreshedModel.Allergies;
            viewModel.NCDs = refreshedModel.NCDs;
            viewModel.Epilepsies = refreshedModel.Epilepsies;

            return View(viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
