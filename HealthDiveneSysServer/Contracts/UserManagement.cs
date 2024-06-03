using HealthDiveneSysServer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace HealthDiveneSysServer
{
    [ServiceContract]
    public interface UserManagement
    {
        [OperationContract]
        int AddPatient(Patient patient);

        [OperationContract]
        int UpdatePatient(Patient patient);

        [OperationContract]
        int UpdateMedicalInformation(MedicalInformation information); 

        [OperationContract]
        Patient GetPatient(int id);

        [OperationContract]
        List<Patient> GetMyPatients(int NutritionistId);

        [OperationContract]
        List<Patient> FilterPatients(int nutritionistId, string filter);

        [OperationContract]
        Nutritionist LogIn(string username, string password); 
    }

}
