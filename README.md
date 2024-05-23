This is a simple Application for create, view, update and delete patient information 
#### Technology used:
- .Net 8,
- ASP.Net core MVC for Fronted,
- ASP.Net Core Web API for Backend,

## Table of Contents
- Installation
- Configuration
- Usage
- Features
- API Endpoints

## Installation

1. **Clone the repository:**

##### git clone https://github.com/raihanulkarim/PatientApp.git

##### Open the project in Visual Studio 2022:

- Open Visual Studio 2022.
- Select Open a project or solution.
- Navigate to the cloned repository folder and open AssignmentExcelbd.sln.

##### Restore dependencies:

- In Visual Studio, go to Tools > NuGet Package Manager > Package Manager Console.
Run the following command:
- dotnet restore
## Configuration
##### Update the database connection string:

Open appsettings.json in the AssignmentExcelbd.Backend project.
Update the DefaultConnection string with your database details:
> "ConnectionStrings": {
  "DefaultConnection": "Provide your server, db name, and username-password if necessary"
}

##### Apply migrations to create the database:

In Visual Studio, go to Tools > NuGet Package Manager > Package Manager Console.
Ensure the Default project dropdown is set to AssignmentExcelbd.Backend.
Run the following command:

>  dotnet ef database update

## Usage
Starting the Projects
Start the Backend API project:

In Visual Studio, right-click on the AssignmentExcelbd.Backend project in the Solution Explorer.
Select Set as Startup Project.
Press F5 to run the project. The backend API will be available at https://localhost:7164/.

Start the Frontend project:
In Visual Studio, right-click on the AssignmentExcelbd.Front project in the Solution Explorer.
Select Set as Startup Project.
Press F5 to run the project.
Accessing the Application
Home Page:

Navigate to browser to view the list of patients.
##### Create a New Patient:

Click on the "Insert New" button on the home page to open the create patient form.
Fill in the patient's details, including name, disease, epilepsy status, allergies, and NCDs.
Click the "Save" button to save the new patient.

#####  Edit an Existing Patient:

On the home page, click the "Edit" button next to the patient you wish to edit.
Update the patient's details as needed.
Click the "Save" button to apply the changes.

##### Delete a Patient:

On the home page, click the "Delete" button next to the patient you wish to delete.
Confirm the deletion in the pop-up dialog.

#####  View Patient Details:

On the home page, click on a patient's name to view detailed information about the patient.
Features
 - Create Patient: Add a new patient with details such as name, disease, epilepsy status, allergies, and NCDs.
 - Edit Patient: Update existing patient information.
- Delete Patient: Remove a patient from the database.
- View Patients: Display a list of all patients with their details.
- Manage Diseases, Allergies, and NCDs: Associate diseases, allergies, and NCDs with patients.

## API Endpoints
Patients
#####  Get all patients: 
> GET /api/patients

#####  Get a patient by ID:
> GET /api/patients/{id}

#####  Create a new patient:
> POST /api/patients/create

#####  Update a patient: 
> PUT /api/patients/update/{id}

- Delete a patient: 
> DELETE /api/patients/delete/{id}

#####  Get All Allergies: 
> GET /api/allergies

#####  Get All NCDs: 
> GET /api/ncds

#####  Get All Diseases: 
> GET /api/diseases